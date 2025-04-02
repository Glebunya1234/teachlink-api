using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class AnnouncementsModelMDB : BaseModelMDB
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id_student { get; set; }

        public string mini_description { get; set; } = string.Empty;

        public IEnumerable<SchoolSubjectsModelMDB> school_subjects { get; set; }

        public string description { get; set; } = string.Empty;
    }
}
