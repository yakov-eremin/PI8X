using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PatternKursProject.DecoratorAnalysisSystem
{
    class AnalysisSystemWithReport : DecoratorAS
    {
        private exelHelper dock;
        public AnalysisSystemWithReport(AnalysisSystemMethod t) : base(t)
        {
            
        }
        /// <summary>
        /// записать результаты очередного измерения в отчет по источнику (если отчет еще не создан, создает)
        /// </summary>
        public void writeInReport()
        {
            try
            {
                using (dock = new exelHelper())
                {
                    if (dock.Open(filePath: Path.Combine(Environment.CurrentDirectory, "Report/Система Анализа №" + thisSystem.getAccountNumber()+"_"+ DateTime.Now.Year.ToString() + ".xlsx")))
                    {
                         dock.Set(thisSystem.getLastMeasurements());
                        dock.Save();
                    }
                }
                Console.Read();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        
            
    }
}
