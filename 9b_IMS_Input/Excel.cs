using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace IMS_Input
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        //Main constructor
        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        //Read individual cells
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if(ws.Cells[i,j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            } else
            {
                return "";
            }
        }

        //Save the workbook
        public void Save()
        {
            wb.Save();
        }

        //Save as option for workbook
        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        //2D array to read a range
        public string[,] ReadRange(int starti, int starty, int endi, int endy)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            object[,] holder = range.Value2;
            string[,] retrunString = new string[endi - starti, endy - starty];
            for (int p=1; p <= endi - starti; p++)
            {
                for (int q=1; q <= endy - starty; q++)
                {
                    retrunString[p - 1, q - 1] = holder[p, q].ToString();

                }
            }
            return retrunString;
        }

    }
}
