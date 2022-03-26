using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.sampleAnalyzer
{
    class Adapter : MeasuringDevice
    {
        

        private SampleAnalysisSystem adaptable;
        public Adapter(SampleAnalysisSystem a)
        { adaptable = a; }
        /// <summary>
        /// получить имя
        /// </summary>
        /// <returns></returns>
       public string getName()
        {
            return adaptable.getName();
        }

        int ind = 0;
        public double getNorma()
        { if(ind<3)
            return adaptable.norma[ind++];
        else return adaptable.norma[ind=0];
        }
        /// <summary>
        /// опросить ситему (анализатор требует дополнительно собирать пробу и готовить к анализу)
        /// </summary>
        /// <returns></returns>
        public List<Measurement> getMeasurement() {
            adaptable.collectSample();
            adaptable.prepareSample();
            return adaptable.analyzeSample();
        }

        public double getDev(double n)
        { return Math.Abs(getNorma() - n); }
        
    }
}
