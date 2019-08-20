using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapSimBackend.Models
{
    public class Budget
    {
        public int Units { get; set; }

        [BsonElement("OrderDate")]
        public DateTime Ordered { get; set; }

        [BsonElement("ExpiryDate")]
        public DateTime Expires { get; set; }
    }
}
