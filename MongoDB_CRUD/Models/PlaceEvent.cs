using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoDB_CRUD.Models
{
    public class PlaceEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> cityEvent {  get; set; }

    }
}
