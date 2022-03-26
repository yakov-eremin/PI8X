using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.sampleAnalyzer
{
    class SoilSampleAnalysis : SampleAnalysisSystem
    {
        public SoilSampleAnalysis()
        {
            name = "Почвоанализатор";
            norma = new double[] { normaS.Cl2, normaS.CH, normaS.CO };
        }

        public override List<Measurement> analyzeSample()
        {
            allMeasurements = new List<Measurement>();
            string unit = " мг/кг";
            double mean;
            allMeasurements.Add(new Measurement("Содержание хлора", mean = testEnvironment.getSoilAnalis(), unit, Math.Abs(mean - normaS.Cl2)));
            allMeasurements.Add(new Measurement("Содержание нефтепродуктов", mean = testEnvironment.getSoilAnalis(), unit, Math.Abs(mean - normaS.CH)));
            allMeasurements.Add(new Measurement("Содержание оксида углерода", mean = testEnvironment.getSoilAnalis(), unit, Math.Abs(mean - normaS.CO)));
            return allMeasurements;

        }
    }
}
