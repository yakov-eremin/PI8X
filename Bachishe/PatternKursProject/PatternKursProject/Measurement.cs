using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject
{/// <summary>
/// класс измерения,хранит название измерения, значение и единицу измерения + отклонение от нормы
/// </summary>
   public class Measurement
    {
        /// <summary>
        /// наименование
        /// </summary>
        public string nameMeasurement;

        /// <summary>
        /// значение
        /// </summary>
        public double meanMeasurement;

        /// <summary>
        /// единица измерения
        /// </summary>
        public string unitMeasurement;

        /// <summary>
        /// отклонение от нормы
        /// </summary>
        public double deviationMeasurement;
        /// <summary>
        /// конструткор
        /// </summary>
        public Measurement(string n, double m, string u, double d)
        {
            nameMeasurement = n;
            meanMeasurement = m;
            unitMeasurement = u;
            deviationMeasurement = d;
        }
    }
}
