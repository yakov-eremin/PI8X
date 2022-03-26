using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace PatternKursProject.DecoratorAnalysisSystem
{/// <summary>
/// вспомогательный класс для работы с excel файлом
/// </summary>
    class exelHelper : IDisposable
    {
        private Excel.Application _excel;
        private Excel.Workbook _workbook;
        private string _filePath;

        public exelHelper()
        {
            _excel = new Excel.Application();
        }

        internal bool Open(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _filePath = filePath;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[1, 1] = "Дата/время";
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[1, 2] = "Показатель";
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[1, 3] = "Значение";
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[1, 4] = "Единица измерения";
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[1, 5] = "Отклонение от нормы";
                }

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        
        internal void Save()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath);
                _filePath = null;
            }
            else
            {
                _workbook.Save();
            }
        }


        internal bool Set( List<Measurement> data )
        {
            try
            {
                Excel.Worksheet workSheet = (Excel.Worksheet)_excel.ActiveSheet;
              
                int _lastRow = workSheet.Cells.Find(
                              "*",
                              workSheet.Cells[1, 1],
                              Excel.XlFindLookIn.xlFormulas,
                              Excel.XlLookAt.xlPart,
                              Excel.XlSearchOrder.xlByRows,
                              Excel.XlSearchDirection.xlPrevious
                              ).Row + 1;

             
                ((Excel.Worksheet)_excel.ActiveSheet).Cells[_lastRow++, 1] = DateTime.Now.ToString();
                foreach (var elem in data)
                {
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[_lastRow, 2] = elem.nameMeasurement;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[_lastRow, 3] = elem.meanMeasurement;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[_lastRow, 4] = elem.unitMeasurement;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[_lastRow++, 5] = elem.deviationMeasurement;

                }
               
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }



        public void Dispose()
        {
            try
            {
                _workbook.Close();
                _excel.Quit();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}