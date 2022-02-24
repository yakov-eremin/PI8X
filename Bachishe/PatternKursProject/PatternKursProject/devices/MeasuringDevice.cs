using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.devices
{
    /// <summary>
    /// интерфейс измерительного устройства
    /// </summary>
  public  interface MeasuringDevice
    {
        string getName();
        double getNorma();
        List<Measurement> getMeasurement();
       double getDev(double n);
    }
}
