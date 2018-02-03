using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TrainTestPrg.Services
{
    public class ApiHandler
    {
        // Metod - Få en lista på alla stationer
        // Metod - Få alla tider för vald station
        // Metod - ......
        // ....
            
        public List<RESPONSETrainStation> GetTrainStations()
        {
            string xmldata = "<?xml version=\"1.0\" encoding=\"utf-8\"?><REQUEST><LOGIN authenticationkey=\"3533e0c901504a8f8da8d96f881c71f3\" /><QUERY objecttype=\"TrainStation\"> <FILTER/></QUERY></REQUEST>";

            Class1 c1 = new Class1();

            string responsStream = c1.postXMLData("http://api.trafikinfo.trafikverket.se/v1.3/data.xml", xmldata);
            
            StreamWriter sw = new StreamWriter(@"datashit2.txt");
          
            sw.Write(responsStream);
            sw.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(RESPONSE));
            StreamReader reader = new StreamReader(@"datashit2.txt");

            var deserializedData = serializer.Deserialize(reader);
            reader.Close();

            RESPONSE r1 = (RESPONSE)deserializedData;
            r1.RESULT.OrderBy(x => x.AdvertisedLocationName);
            List<RESPONSETrainStation> trainStations = new List<RESPONSETrainStation>();

            for (int i = 0; i < r1.RESULT.Length; i++)
            {
                trainStations.Add(r1.RESULT[i]);
            }

            trainStations.OrderByDescending(x => x.AdvertisedLocationName);

            return trainStations;
        }

        private void SerializeData(StreamReader s1)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RESPONSE));
        }
    }

    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class Class1
    {
        public string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }
        public static readonly HttpClient client = new HttpClient();
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class RESPONSE
    {

        private RESPONSETrainStation[] rESULTField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("TrainStation", IsNullable = false)]
        public RESPONSETrainStation[] RESULT
        {
            get
            {
                return this.rESULTField;
            }
            set
            {
                this.rESULTField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RESPONSETrainStation
    {

        private bool advertisedField;

        private string advertisedLocationNameField;

        private string advertisedShortLocationNameField;

        private string countryCodeField;

        private byte countyNoField;

        private RESPONSETrainStationGeometry geometryField;

        private string locationInformationTextField;

        private string locationSignatureField;

        private System.DateTime modifiedTimeField;

        private byte[] platformLineField;

        private bool prognosticatedField;

        /// <remarks/>
        public bool Advertised
        {
            get
            {
                return this.advertisedField;
            }
            set
            {
                this.advertisedField = value;
            }
        }

        /// <remarks/>
        public string AdvertisedLocationName
        {
            get
            {
                return this.advertisedLocationNameField;
            }
            set
            {
                this.advertisedLocationNameField = value;
            }
        }

        /// <remarks/>
        public string AdvertisedShortLocationName
        {
            get
            {
                return this.advertisedShortLocationNameField;
            }
            set
            {
                this.advertisedShortLocationNameField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public byte CountyNo
        {
            get
            {
                return this.countyNoField;
            }
            set
            {
                this.countyNoField = value;
            }
        }

        /// <remarks/>
        public RESPONSETrainStationGeometry Geometry
        {
            get
            {
                return this.geometryField;
            }
            set
            {
                this.geometryField = value;
            }
        }

        /// <remarks/>
        public string LocationInformationText
        {
            get
            {
                return this.locationInformationTextField;
            }
            set
            {
                this.locationInformationTextField = value;
            }
        }

        /// <remarks/>
        public string LocationSignature
        {
            get
            {
                return this.locationSignatureField;
            }
            set
            {
                this.locationSignatureField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ModifiedTime
        {
            get
            {
                return this.modifiedTimeField;
            }
            set
            {
                this.modifiedTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PlatformLine")]
        public byte[] PlatformLine
        {
            get
            {
                return this.platformLineField;
            }
            set
            {
                this.platformLineField = value;
            }
        }

        /// <remarks/>
        public bool Prognosticated
        {
            get
            {
                return this.prognosticatedField;
            }
            set
            {
                this.prognosticatedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class RESPONSETrainStationGeometry
    {

        private string sWEREF99TMField;

        private string wGS84Field;

        /// <remarks/>
        public string SWEREF99TM
        {
            get
            {
                return this.sWEREF99TMField;
            }
            set
            {
                this.sWEREF99TMField = value;
            }
        }

        /// <remarks/>
        public string WGS84
        {
            get
            {
                return this.wGS84Field;
            }
            set
            {
                this.wGS84Field = value;
            }
        }
    }
}
