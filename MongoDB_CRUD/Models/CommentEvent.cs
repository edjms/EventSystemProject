using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoDB_CRUD.Models
{
    public class CommentEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string comment { get; set; }

        public User user { get; set; }

    }
}
