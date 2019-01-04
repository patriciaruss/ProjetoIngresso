using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingresso.Domain
{
    public class Cinema
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Cidade")]
        public string Cidade { get; set; }
         
    }
}
