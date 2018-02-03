using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using TrainTestPrg.Services;

namespace TrainTestPrg
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiHandler ah = new ApiHandler();
            var trainStations = ah.GetTrainStations();

            foreach (var i in trainStations)
            {
                Console.WriteLine(i.AdvertisedLocationName);
            }

            Console.ReadKey();
        }   
    }
}
