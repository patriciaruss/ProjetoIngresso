using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingresso.Domain
{
    public class Horario
    {
        [BsonElement("Horario")]
        public string Horarios { get; set; }
    }
}
