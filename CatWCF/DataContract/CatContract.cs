using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CatWCF.DataContract
{
    [DataContract]
    public class CatContract
    {
        public CatContract() { }

        public CatContract(Cat cat)
        {
            if (cat != null)
            {
                id = cat.Id;
                name = cat.Name;
                gender = cat.Gender1.Description;
                age = cat.Age;
                breed = cat.Breed;
                furLength = cat.FurType1.Description;
            }
        }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string gender { get; set; }

        [DataMember]
        public int? age { get; set; }

        [DataMember]
        public string breed { get; set; }

        [DataMember]
        public string furLength { get; set; }
    }
}