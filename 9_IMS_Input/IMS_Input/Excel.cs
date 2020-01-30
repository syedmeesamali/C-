using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;

namespace IMS_Input
{
    class ExcelWork
    {
        string path = "";
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook wb;
        Excel.Worksheet ws;

        //Procedure excelwork
        public ExcelWork(string path, int sheet)
        {
            this.path = path;

            try
            {
                wb = xlApp.Workbooks.Open(path);
                ws = wb.Worksheets[sheet];
            } catch (System.IO.IOException e)
            {
                 MessageBox.Show("Make sure no other Excel window is Open and Excel is closed!", MessageBoxButtons.OK.ToString());
            }
            finally
            {
                wb.Close();
            }
            
            
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].value2 != null)
            {
                return ws.Cells[i, j].value2;
            }
            else
            {
                return "";
            }
        }

        
    }
}
