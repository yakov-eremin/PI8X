using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternKursProject.sampleAnalyzer
{
    abstract class SampleAnalysisSystem
    {/// <summary>
    /// имя анализатора (газоанализатор, водо- или почво-)
    /// </summary>
        protected string name;
        public void setName(string  n) { name = n; }
        public string getName() { return name; }

        /// <summary>
        /// все показатели анализтора
        /// </summary>
        protected List<Measurement> allMeasurements;

        /// <summary>
        /// сбор пробы
        /// </summary>
        public void collectSample() { 
           // MessageBox.Show("Проба успешно получена"); 
        }

        /// <summary>
        /// подготовка пробы
        /// </summary>
        public void prepareSample() {
           // MessageBox.Show("Проба подготовлена"); 
        }
        /// <summary>
        /// анализ пробы
        /// </summary>
        public abstract List<Measurement> analyzeSample();

        public double[] norma;
    }

    public struct normaA
    {
        public const double Cl2 = 0.001;//хлор, мг/л
        public const double H2S = 0.008;//сероводоро, мг/л
        public const double CO = 0.002;//оксид углерода, мг/л
    }
    public struct normaW
    {
        public const double Cl2 = 0.4;//хлор, норма хлора в воде мг/л
        public const double H2S = 0.03;//сероводоро, в воде мг/л
        public const double CH = 0.09;//нефтепродукты, мг/дм3
    }

    public struct normaS
    {
        public const double Cl2 = 15;//хлор,  мг/кг
        public const double CH = 300;//нефтепродукты, мг/кг
        public const double CO = 20;//оксид углерода, мг/кг
    }
}
