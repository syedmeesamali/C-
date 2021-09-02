/**********************************************************************
** Copyright (C) 1998-2006 Teslain S.R.L.  All rights reserved.
**
** This is a command line utility program for sending e-mail messages
** using RFC standar¢ SMTP protocol.
**
** This file may be distributed and/or modified under the terms of the
** GNU General Public License version 2 as published by the Free Software
** Foundation and appearing in the file LICENSE.GPL included in the
** packaging of this file.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** See http://www.rohos.com/kidlogger/ for GPL licensing information.
**
** Contact info@rohos.com if any conditions of this licensing are
** not clear to you.
**
**********************************************************************/
#define _WIN32_WINNT 0x500
#include <windows.h>
#include "winsock.h"
#include <stdio.h>
#include <shlwapi.h>
#include <tchar.h>
#include "smtp_auth.h"
#pragma comment(lib,"shlwapi.lib")

int s,x;
char b64b_table[]=
"A78BCDabcdeEFGwxyHIopYZfghijkPQXlmnqJKLMNOrsz01234RStuvTUVW569+/ \0";
char base64table[]=
"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ \0";
union _B64
{
   struct
     {
     unsigned int a4:6;
     unsigned int a3:6;
     unsigned int a2:6;
     unsigned int a1:6;
     } a;
   unsigned char b[3];
   unsigned long num;
} b64;

FILE *f_out;

// check responce from SMTP server
//  error or suceess
//  return TRUE if error
bool is_error(char* text)
{
        return  ( !strncmp("220",text,3) ||
                      !strncmp("250",text,3) ||
                          !strncmp("354",text,3) ||
                          !strncmp("221",text,3) );

}

// send string to socket
int send_to(char* chr )
{
	printf("####### SEND ==> %s\n",chr);
    if ( send(s,chr,strlen(chr),0)==SOCKET_ERROR )
                {
                 printf("error send: %d\n",WSAGetLastError());
                 return 0;
                }

  return 1;
}

// Get response from SMTP server and check status
// 
bool reciv_and_noerr(char* chr )
{
        int len;
	
         if ( (len=(recv(s,(char*)chr,490,0)))==SOCKET_ERROR )
                 { printf("error recv %d \n",WSAGetLastError()); return false;}
		 
         *(chr+len-1)=0;
		 printf("####### RECV <== %s\n",chr);
         

         return is_error((char*)chr);

}


// cl tiny.cpp /MD /Og /Os /link /ALIGN:0x10 /merge:.rdata=.data

//*********************************************************************
//*********************************************************************
int main(int argc, char* argv[])
{
	//ShowWindow(GetConsoleWindow(),0);
	//smtp.mail.ru 25 rohos_welcome@mail.ru "12312314525" from


	char smtp_host[50] = {"smtp.mail.ru"};
	char smtp_port[50] = {"2525"};
	char smtp_login[50] = {"kidloger@mail.ru"};
	char smtp_passw[50] = {"***********"};

	int attempts =0;

send_again:

	if (attempts++ > 2)
	{
		ExitProcess(1);
		return 1;
	}

	printf("input params: \n\n");
	//for(int g=0;g<argc;g++)
	//	printf("[%i] %s\n",g,argv[g]);

	printf("\n\n\n");

        if (argc < 4)
        {
				
			printf("\n\n\report.exe recipient@email [-]\"subject\" [@filename]\"message\" [attach]");
			printf("\noptions :\n");
			// printf(" [@IP]      = IP.address instead of SMTP server name\n");
			//  printf(" [-]         = no subject, file must contain \"Subject:*<enter><enter>\")\n");
			printf(" [@filename] = file with full path to send as message (text!)\n");
			printf(" [attach]    = files to atach (base64)\n");
			printf(" programm output:  responces of SMTP server\n (errorlevel=1 if succes)\n" );
			printf(" examples:\n");
			printf("report.exe to@mail.com \"Re: Subj\" \"message!\" attach.zip\n");
			printf("report.exe to@mail.com - @message.txt attch1.zip attch2.doc\n");
			printf("============================================================\n");
                
			printf("Rohos BugReporting tool (www.rohos.com) \n");
		
			//scanf("%i",&argc);
			//ExitProcess(10);
            return 10;
        }

        WSADATA rec;
        struct sockaddr_in con;
        PHOSTENT pHost;
        char* text= new char[1500];
        bool is_attach = argc >4;  // command line contain file name to attache


         int err=0;
        int exit_code = 1;


	//Open Sokets
        int wVer = MAKEWORD(1, 1);
        if ( WSAStartup(wVer,&rec) )
        {
			printf("error WSAstarup \n");
			ExitProcess(11);
			return 0;
        }
		
		if ((s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP)) == INVALID_SOCKET)
		{ printf("Socket Error:     %d \n",WSAGetLastError()); goto exit_0;}

	//resolve name to IP address
		if ( *(smtp_host)=='@' )
			con.sin_addr.s_addr=inet_addr(smtp_host+1);
		else
		{
			printf("Look up for SMTP....\n");
			if ( !(pHost=gethostbyname(smtp_host)) )
			{ 
				printf("Cant find (error %d)\n",WSAGetLastError());
				goto exit;
			}
			//
			PCHAR p;
			memmove(&p,*pHost->h_addr_list,sizeof(PCHAR));
			memmove(&con.sin_addr.s_addr,&p,sizeof(PCHAR));
		}
		printf((char*)inet_ntoa(con.sin_addr));
		printf("\n");
		
        con.sin_family=AF_INET;
        con.sin_port=htons(StrToInt(smtp_port));  // Use standard SMTP port 25

	//conect to server
        if ( connect(s,(struct sockaddr*)&con,sizeof(con))==INVALID_SOCKET )
        	{ printf("error connect %d\n",WSAGetLastError());  
		goto exit; 
		}
        printf("Connected...\n");
		

	// check responce
         if ( !reciv_and_noerr(text) ) goto exit;

	//Start talking with SMTP server...
	//  and checking responces
         strcpy(text,"EHLO friend\xD\xA\x0");
         if ( !send_to( text) ) goto exit;

         if ( !reciv_and_noerr(text) ) goto exit;
		
		 if(!smtp_send_auth(s,smtp_login,smtp_passw))
			 goto exit;

	// tell email information...
         strcpy(text,"MAIL FROM:<");
         strcat(text,smtp_login);
         strcat(text,">\xD\xA\x0");
         if ( !send_to( text) ) goto exit;
         if ( !reciv_and_noerr(text) ) goto exit;


         strcpy(text,"RCPT TO:<");
         strcat(text,argv[1]);
         strcat(text,">\xD\xA\x0");
         if ( !send_to( text) ) goto exit;
         if ( !reciv_and_noerr(text) ) goto exit;

         strcpy(text,"DATA\xD\xA\x0");
         if ( !send_to( text) ) goto exit;
         if ( !reciv_and_noerr(text) ) 
		 {			 
			 strcpy(smtp_host, "mail.rohos.net");
			 strcpy(smtp_port,"25");
			 strcpy(smtp_login, "kidlogger@rohos.net");			 
			 
			 goto send_again;
			 
		 }

         // send email headers

         strcpy(text,"X-Mailer:Kidl0gger Reporting");
         strcat(text,"\xD\xA\x0");
         if ( !send_to( text) ) goto exit;

         strcpy(text,"To: ");
         strcat(text,argv[1]);
         strcat(text,"\xD\xA\x0");
         if ( !send_to( text) ) goto exit;

         if (*(argv[2])!='-' )  // no Subj
         {
			 char subject[200];
			 char comp_name[50];
			 DWORD dwsz = 40;

			 // insert computer name 
			 GetComputerName(comp_name, &dwsz);
			 strcpy( subject, argv[2]);
			 strcat( subject, " [");
			 strcat( subject, comp_name);
			 strcat( subject, "]");
			 
                 strcpy(text, "Subject:");
                 strcat(text, subject);
                 strcat(text, "\xD\xA\x0");
                 if ( !send_to( text) ) goto exit;
         }

	// if there is attach file to send include attach defenition
         if ( is_attach )
                 {
                         send_to("Content-Type: multipart/mixed; boundary=\"----------Qmailer\"") ;
                         send_to("\n\n\0");
                         send_to("------------Qmailer"); send_to("\n\x0");
                         send_to("Content-Type: text/plain;\n\n");
                 }
                 else
                         send_to("\n\0");


	// sending email body
         if (*(argv[3])!='@')
         {
                 if ( !send_to( argv[3]) ) goto exit;
         }
         else
         {
                 FILE *f;
                 if ((f = fopen(argv[3]+1, "r")) == NULL)
                 { printf("error opening file\n"); goto exit; };
                 while ( !feof(f) )
                 {
                         *text=0;
                         fgets(text,1000,f);
                         if ( (strstr(text,".\n") ) ) strcat(text," ");
                         if ( !send_to(text) ) goto exit;
                 }
         }


	// sending attaches
		 TCHAR *ptr;

         for (x=5; x<=argc; ++x)
         {
			 	 FILE* f2;
				 int  num=2,str=1;
				 char s[4+5];
				 char ch;

				f2=NULL;

				if ( (f2=fopen(argv[x-1],"rb"))==NULL ) 
				{
					continue;
				}
                 send_to("\n\x0");
                 send_to("\n\x0");
                 send_to("------------Qmailer"); send_to("\n\x0");
                 send_to("Content-Transfer-Encoding: base64 \x0"); send_to("\n\x0");
                 send_to("Content-Disposition: attachment; filename=\"\x0");

				 ptr = _tcsrchr(argv[x-1], '\\');
				 if(ptr)
				 	 ptr++;
				 else
					 ptr = argv[x-1];

                 send_to(ptr);
                 send_to("\"\n\x0");
                 send_to("\n\x0");

                 

                 while ( true )
                 {
						 ch=fgetc(f2);
                         if ( !feof(f2) )*(b64.b+num)=ch;
                         if ( num==0 || feof(f2) )
                         {
                                 s[0]=base64table[b64.a.a1];
                                 s[1]=base64table[b64.a.a2];
                                 s[2]=base64table[b64.a.a3];
                                 s[3]=base64table[b64.a.a4];
								 if (num==2)     { break;  }
								 if (num==1)     { s[2]='='; s[3]='='; }
								 if (num==0 && feof(f2) )   { s[3]='='; }

								 s[4]=0;
                                 send_to(s);

                                 if (++str>=20 ) { send_to("\n\x0"); str=1; }
                                 num=3;
                                 memset(b64.b,0,3 );
				if ( feof(f2) ) { break;  }
                         }
                         num--;
                 }
                 fclose(f2);
                 send_to("\n------------Qmailer--");
         }

         // send 'finish' command
         strcpy(text,"\xD\xA.\xD\xA\x0");
         if ( !send_to( text) ) goto exit;
         if ( !reciv_and_noerr(text) ) goto exit;

         strcpy(text,"quit\xD\xA");
         if ( !send_to( text) ) goto exit;
         if ( !reciv_and_noerr(text) ) goto exit_0;

    int pppp;     
	goto exit_0; // sucess
	
exit:
	//	scanf("%i",&pppp);
        //ExitProcess(1);
        return 1;   // Error
exit_0:
	//	scanf("%i",&pppp);
        //ExitProcess(0);
        return 0; // Success

}


