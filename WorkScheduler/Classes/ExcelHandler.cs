using Microsoft.Office.Interop.Excel;
using Shared.Classes;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace WorkScheduler.Classes
{
    internal class ExcelHandler : IDisposable
    {
        private static readonly string SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "workscheduler");
        private static readonly string FilePath = SavePath + "\\print.xlsx";

        private bool _disposed = false;

        private Application ExcelApp;
        private Workbook ExcelWorkbook;
        private Worksheet ExcelWorksheet;
        private Worksheet CurrentWorksheet;

        public ExcelHandler()
        {
            ExcelApp = new Application();
            ExcelWorkbook = ExcelApp.Workbooks.Add();
            //ExcelWorksheet = (Worksheet)ExcelWorkbook.Sheets.Add();
            CurrentWorksheet = (Worksheet)ExcelWorkbook.Worksheets[1];
            CurrentWorksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            CurrentWorksheet.PageSetup.TopMargin = 5;
            CurrentWorksheet.PageSetup.BottomMargin = 5;
            CurrentWorksheet.PageSetup.LeftMargin = 5;
            CurrentWorksheet.PageSetup.RightMargin = 5;


            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

        }

        internal void CreateFromShifts(List<ShiftsModel> shifts, int daysInMonth)
        {
            if (ExcelApp == null) return;

            CreateHeaderRow(daysInMonth);

            int rowIndex = 2;
            int day = 0;

            foreach (ShiftsModel shift in shifts)
            {
                Range cell = CurrentWorksheet.Cells[rowIndex, 1];
                cell.Value = $"{shift.Employee.Surname}, {shift.Employee.FirstName.Substring(0, 1)}";

                for (int i = 0; i <= daysInMonth; i++)
                {
                    cell = CurrentWorksheet.Cells[rowIndex, i + 2];

                    day = i + 1;
                    ShiftModel currShift = shift.Shifts.SingleOrDefault(_ => _.Date.Day == day);

                    if (currShift == null) continue;

                    cell.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    cell.Value = ShiftHelper.GetShifName(currShift.Type);  
                    cell.Interior.Color = currShift.Color;
                    cell.Borders.LineStyle = XlLineStyle.xlContinuous;
                    cell.Borders.Weight = 2;

                }

                rowIndex++;
            }

            Range wholeSheet = CurrentWorksheet.UsedRange;

            ExcelApp.ActiveWorkbook.SaveAs(FilePath, XlFileFormat.xlOpenXMLWorkbook);
            CurrentWorksheet.PrintOut();
            File.Delete(FilePath);
        }

        private void CreateHeaderRow(int daysInMonth)
        {

            //Employee Column
            Range employeeColumn = CurrentWorksheet.Cells[1, 1];
            employeeColumn.ColumnWidth = 15;

            for (int i = 0; i < daysInMonth; i++)
            {
                Range cell = CurrentWorksheet.Cells[1, i + 2];
                cell.Value = i + 1;
                cell.Interior.Color = XlRgbColor.rgbLightGray;
            }

            Range range = ExcelApp.Range[CurrentWorksheet.Cells[1, 2], CurrentWorksheet.Cells[1, daysInMonth + 1]];

            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.ColumnWidth = 3;

        }


        #region IDisposable Pattern
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //Marshal.FinalReleaseComObject(ExcelWorksheet);

                ExcelWorkbook.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(ExcelWorkbook);

                // Close/Exit File
                ExcelApp.Quit();
                Marshal.FinalReleaseComObject(ExcelApp);
            }

            ExcelWorkbook = null;
            ExcelApp = null;

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
