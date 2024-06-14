using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB_CRUD.Models
{
    public class CityEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string country { get; set; }
    }
}
