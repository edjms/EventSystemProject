using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System;

namespace MongoDB_CRUD.Models
{
    public class DetailsEvent
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<string> Categories { get; set; }
            public DateTime Date { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> placeEvent { get; set; }
     
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Attendees { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Facilitators { get; set; }

        public List<string> OrganizingFaculties { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Comments { get; set; }
    }

    
}
