namespace Ingresso.Domain
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;

    public class Filme
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Lancamento")]
        public DateTime Lancamento { get; set; }

        [BsonElement("QtDiasExibicao")]
        public int QtDiasExibicao { get; set; }

        [BsonElement("Diretor")]
        public string Diretor { get; set; }

        [BsonElement("Genero")]
        public string Genero { get; set; }

        [BsonElement]
        public IEnumerable<Ator> Atores { get; set; }

    }
}
