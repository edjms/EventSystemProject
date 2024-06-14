using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB_CRUD.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("identificacion")]
        public string identificacion { get; set; }
        [BsonElement("nombres")]
        public string Nombres { get; set; }

        [BsonElement("apellidos")]
        public string Apellidos { get; set; }

        [BsonElement("ocupacion")]
        public string Ocupacion { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("ciudad")]

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> cityEvent { get; set; }
    }
}
