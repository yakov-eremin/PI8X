using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.sampleAnalyzer
{
    class AirSampleAnalysis: SampleAnalysisSystem
    {
        public AirSampleAnalysis()
        {
            name = "Газоанализатор";
            norma = new double[]{ normaA.Cl2, normaA.H2S, normaA.CO };
        }

        public override List<Measurement> analyzeSample()
        {
            allMeasurements = new List<Measurement>();
            string unit = "мг/л";
            double mean;
            allMeasurements.Add(new Measurement("Содержание хлора", mean = testEnvironment.getAirAnalis(), unit, Math.Abs(mean - normaA.Cl2)));
            allMeasurements.Add(new Measurement("Содержание сероводорода", mean = testEnvironment.getAirAnalis(), unit, Math.Abs(mean - normaA.H2S)));
            allMeasurements.Add(new Measurement("Содержание оксида углерода", mean = testEnvironment.getAirAnalis(), unit, Math.Abs(mean - normaA.CO)));
            return allMeasurements;
           
        }
    }
}
