namespace Ingresso.Domain
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Sala
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Cinema")]
        public string Cinema { get; set; }

        [BsonElement("Cidade")]
        public string Cidade { get; set; }
    }
}
