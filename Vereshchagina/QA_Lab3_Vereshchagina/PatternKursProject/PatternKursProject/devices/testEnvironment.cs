using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.devices
{
    /// <summary>
    /// класс для генерации тестовых показателей среды
    /// </summary>
    class testEnvironment
    {
        private static Random rnd = new Random();
       
        public static double getMean(string name)
        {
            double mean = 0;
            switch (name)
                {
                case "Термометр":
                    {mean = -40.0 + rnd.NextDouble() * (40.0 + 40.0);
                        break;}

                case "Барометр":
                    {
                        mean = 600.0 + rnd.NextDouble() * (200.0);
                        break;
                    }
                case "Психрометр":
                    {
                        mean = 0.0 + rnd.NextDouble() * (100.0);
                        break;
                    }
                case "Анемометр":
                    {
                        mean = 0.1 + rnd.NextDouble() * (10.5);
                        break;
                    }
                case "Дифманометр":
                    {
                        mean = 0.1 + rnd.NextDouble() * (10.5);
                        break;
                    }
            }
            return mean;

        }
        /// <summary>
        /// генератор значений газоанализатора
        /// </summary>
        /// <returns></returns>
        public static double getAirAnalis()
        {
            double mean = 0;
            mean = 0.0 + rnd.NextDouble() * (0.01);
            return mean;  
            }
        /// <summary>
        /// генератор значений водоанализатора
        /// </summary>
        /// <returns></returns>
        public static double getWaterAnalis()
        {
            double mean = 0;
            mean = 0.0 + rnd.NextDouble() * (0.5);
            return mean;
        }
        /// <summary>
        /// генератор значений почвоанализатора
        /// </summary>
        /// <returns></returns>
        public static double getSoilAnalis()
        {
            double mean = 0;
            mean = 0.0 + rnd.NextDouble() * (300.0);
            return mean;
        }
    }
}
