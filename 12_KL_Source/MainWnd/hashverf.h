class HASHV
{
	private:
		DWORD *hash;
		DWORD h_cnt;
		
	public:
		HASHV()
		{
			hash=0;
			h_cnt=0;
		}
		~HASHV()
		{
			h_cnt =0;
			free(hash);

		}

		DWORD make_hash(const char *hstr,DWORD len)
		{
			DWORD ret;
			ret =0;
			while(len--)
				ret+=hstr[len]*(len+1);

			return ret;
		}

		char verf_and_add(const char* hstr,DWORD len)
		{
			DWORD hsh;
			hsh = make_hash(hstr,len);
			if(!verf_hash(hsh))
			{
				add_hash(hsh);
				return 0;
			}
			return 1;
		}
		DWORD add_hash(DWORD hsh)
		{
			hash = (DWORD *)realloc(hash,sizeof(DWORD)*(h_cnt+1));
			hash[h_cnt] = hsh;//
			return hash[h_cnt++];
		}

		char verf_hash(DWORD hsh)
		{
			DWORD i;
			i = h_cnt;
			while(i--)
				if(hsh==hash[i])
					return 1;
			return 0;
		}

		char del_hash(DWORD hsh)
		{
			DWORD i;
			i=h_cnt;
			while(i--)
				if(hsh==hash[i])
				{
					h_cnt--;
					for(i;i<h_cnt;i++)
						hash[i]=hash[i+1];
					return 1;
				}
			return 0;
		}
};