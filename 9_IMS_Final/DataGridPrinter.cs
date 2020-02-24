using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IMS_Final
{
    class DataGridPrinter
    {


        
        
        
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            // Draw a label title for the grid  
            DrawTopLabel(g);
            // draw the datagrid using the DrawDataGrid method passing the Graphics surface  
            bool more = dataGridPrinter1.DrawDataGrid(g);
            // if there are more pages, set the flag to cause the form to trigger another print page event  
            if (more == true)
            {
                e.HasMorePages = true;
                dataGridPrinter1.PageNumber++;
            }
        }






        private void PrintMenu_Click(object sender, System.EventArgs e)
        {
            // Initialize the datagrid page and row properties  
            dataGridPrinter1.PageNumber = 1;
            dataGridPrinter1.RowCount = 0;
            // Show the Print Dialog to set properties and print the document after ok is pressed.  
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }



        public bool DrawRows(Graphics g)
        {
            try
            {
                int lastRowBottom = TopMargin;
                // Create an array to save the horizontal positions for drawing horizontal gridlines  
                ArrayList Lines = new ArrayList();
                // form brushes based on the color properties of the DataGrid  
                // These brushes will be used to draw the grid borders and cells  
                SolidBrush ForeBrush = new SolidBrush(TheDataGrid.ForeColor);
                SolidBrush BackBrush = new SolidBrush(TheDataGrid.BackColor);
                SolidBrush AlternatingBackBrush = new SolidBrush(TheDataGrid.AlternatingBackColor);
                Pen TheLinePen = new Pen(TheDataGrid.GridLineColor, 1);
                
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                
                int columnwidth = PageWidth / TheTable.Columns.Count;
                
                int initialRowCount = RowCount;
                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);
                
                for (int i = initialRowCount; i < TheTable.Rows.Count; i++)
                {
                    // get the next DataRow in the DataTable  
                    DataRow dr = TheTable.Rows[i];
                    int startxposition = TheDataGrid.Location.X;
                
                    RowBounds.X = TheDataGrid.Location.X; RowBounds.Y = TheDataGrid.Location.Y +
                    TopMargin + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints +  kVerticalCellLeeway);
                    RowBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
                    RowBounds.Width = PageWidth;
                    // save the vertical row positions for drawing grid lines  
                    Lines.Add(RowBounds.Bottom);
                    // paint rows differently for alternate row colors  
                    if (i % 2 == 0)
                    {
                        g.FillRectangle(BackBrush, RowBounds);
                    }
                    else
                    {
                        g.FillRectangle(AlternatingBackBrush, RowBounds);
                    }
                    // Go through each column in the row and draw the information from the  
                    DataRowfor(int j = 0; j < TheTable.Columns.Count; j++)  
                {
                    RectangleF cellbounds = new RectangleF(startxposition,
                    TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount) + 1) *
                    (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                    columnwidth,
                    TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
                    // draw the data at the next position in the row  
                    if (startxposition + columnwidth <= PageWidth)
                    {
                        g.DrawString(dr[j].ToString(), TheDataGrid.Font, ForeBrush, cellbounds, cellformat);
                        lastRowBottom = (int)cellbounds.Bottom;
                    }
                    // increment the column position  
                    startxposition = startxposition + columnwidth;
                }
                RowCount++;
                // when we've reached the bottom of the page, draw the horizontal and vertical grid lines and return true  
                if (RowCount * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway) >
                PageHeight * PageNumber) -(BottomMargin + TopMargin))  
            {
                    DrawHorizontalLines(g, Lines); DrawVerticalGridLines(g, TheLinePen, columnwidth,
                     lastRowBottom);
                    return true;
                }
            }
// when we've reached the end of the table, draw the horizontal and vertical gridlines and return false  
    DrawHorizontalLines(g, Lines);
            DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
            return false;
        }  
catch (Exception ex)  
{  
MessageBox.Show(ex.Message.ToString());  
return false;  
}
}
}
