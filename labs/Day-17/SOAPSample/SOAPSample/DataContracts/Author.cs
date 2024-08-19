﻿using System.Runtime.Serialization;

namespace SOAPSample.DataContracts
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
