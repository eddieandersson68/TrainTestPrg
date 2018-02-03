using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTestPrg
{
    class DataClass
    {
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class RESPONSE
        {

            private RESPONSETrainAnnouncement[] rESULTField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("TrainAnnouncement", IsNullable = false)]
            public RESPONSETrainAnnouncement[] RESULT
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
        public partial class RESPONSETrainAnnouncement
        {

            private System.DateTime advertisedTimeAtLocationField;

            private uint advertisedTrainIdentField;

            private RESPONSETrainAnnouncementToLocation toLocationField;

            private string trackAtLocationField;

            /// <remarks/>
            public System.DateTime AdvertisedTimeAtLocation
            {
                get
                {
                    return this.advertisedTimeAtLocationField;
                }
                set
                {
                    this.advertisedTimeAtLocationField = value;
                }
            }

            /// <remarks/>
            public uint AdvertisedTrainIdent
            {
                get
                {
                    return this.advertisedTrainIdentField;
                }
                set
                {
                    this.advertisedTrainIdentField = value;
                }
            }

            /// <remarks/>
            public RESPONSETrainAnnouncementToLocation ToLocation
            {
                get
                {
                    return this.toLocationField;
                }
                set
                {
                    this.toLocationField = value;
                }
            }

            /// <remarks/>
            public string TrackAtLocation
            {
                get
                {
                    return this.trackAtLocationField;
                }
                set
                {
                    this.trackAtLocationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RESPONSETrainAnnouncementToLocation
        {

            private string locationNameField;

            private byte priorityField;

            private byte orderField;

            /// <remarks/>
            public string LocationName
            {
                get
                {
                    return this.locationNameField;
                }
                set
                {
                    this.locationNameField = value;
                }
            }

            /// <remarks/>
            public byte Priority
            {
                get
                {
                    return this.priorityField;
                }
                set
                {
                    this.priorityField = value;
                }
            }

            /// <remarks/>
            public byte Order
            {
                get
                {
                    return this.orderField;
                }
                set
                {
                    this.orderField = value;
                }
            }
        }


    }
}

   
