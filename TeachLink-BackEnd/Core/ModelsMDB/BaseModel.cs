using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public abstract class BaseModelMDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    }
}
