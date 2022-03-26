using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject
{
    public interface AnalysisSystemMethod
    {

        int getAccountNumber();
        SourceType getTypeOfSystem();
        void addDevice(MeasuringDevice dev);
        List<Measurement> getMeasurements();
        List<Measurement> getLastMeasurements();
        List<MeasuringDevice> getListDev();
       void delDev(int t);
    }
}
