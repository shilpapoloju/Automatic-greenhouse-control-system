using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sesprint1
{
    public class Sensor
    {
        public double temperature;
        public double Water;
        public double SoilAcidity;
        public double Humidity;
        public double Fertilizer;
        public double Lighting;
        public double PlantBed;

        Random rand1 = new Random();
        public double sensortemperature()
        {
            
            temperature = rand1.Next(1, 50);
            return temperature;
            //return 1;
        }
        public double sensorWater()
        {

            Water = rand1.Next(1, 50);
            return Water;
        }
        public double sensorSoilAcidity()
        {

            SoilAcidity = rand1.Next(1, 50);
            return SoilAcidity;
        }
        public double sensorHumidity()
        {

            Humidity = rand1.Next(1, 50);
            return Humidity;
        }
        public double sensorFertilizer()
        {

            Fertilizer = rand1.Next(1, 50);
            return Fertilizer;
        }

        public double sensorLighting()
        {

            Lighting = rand1.Next(1, 50);
            return Lighting;
        }
        public double sensorPlantBed()
        {

            PlantBed = rand1.Next(1, 50);
            return PlantBed;
        }
    }
}