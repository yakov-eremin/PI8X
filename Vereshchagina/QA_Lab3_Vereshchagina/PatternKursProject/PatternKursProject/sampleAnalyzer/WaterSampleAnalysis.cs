using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.sampleAnalyzer
{
    class WaterSampleAnalysis : SampleAnalysisSystem
    {
        public WaterSampleAnalysis()
        {
            name = "Водоанализатор";
            norma = new double[] { normaW.Cl2, normaW.H2S, normaW.CH };
        }

        public override List<Measurement> analyzeSample()
        {
            allMeasurements = new List<Measurement>();
            string unit = "мг/л";
            double mean;
            allMeasurements.Add(new Measurement("Содержание хлора", mean = testEnvironment.getWaterAnalis(), unit, Math.Abs(mean - normaW.Cl2)));
            allMeasurements.Add(new Measurement("Содержание сероводорода", mean = testEnvironment.getWaterAnalis(), unit, Math.Abs(mean - normaW.H2S)));
            allMeasurements.Add(new Measurement("Содержание нефтепродуктов", mean = testEnvironment.getWaterAnalis(), unit, Math.Abs(mean - normaW.CH)));
            return allMeasurements;

        }
    }
}
