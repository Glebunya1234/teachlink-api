using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class NotificationsModelMDB : BaseModelMDB
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id_teacher { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id_student { get; set; }

        public bool is_read { get; set; } = false;

        public bool for_teacher { get; set; } = false;
    }
}
