using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.devices
{
    class Anemometer : MeasuringDevice
    {
        /// <summary>
        /// наименование устройства
        /// </summary>
        private static string name = "Анемометр";
        public string getName() { return name; }

        /// <summary>
        /// норма измерения
        /// </summary>
        private static double norma;

        public double getNorma()
        { return norma; }
        /// <summary>
        /// значение измерения
        /// </summary>
        private double mean;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="n"></param>
        public Anemometer(double n)
        {
            norma = n;
        }
        /// <summary>
        /// получить отклонение измерения от нормы
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double getDev(double n)
        { return Math.Abs(norma - n); }
        /// <summary>
        /// получить измерение
        /// </summary>
        /// <returns></returns>
        public List<Measurement> getMeasurement()
        {
            mean = testEnvironment.getMean(name);
            return new List<Measurement> { new Measurement("Скорость ветра", mean, "м/с", getDev(mean)) };

        }
    }
}