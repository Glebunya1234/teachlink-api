using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class ReviewsModelMDB : BaseModelMDB
    {
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id_teacher { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id_student { get; set; }

        public string reviews_text { get; set; } = string.Empty;

        public IEnumerable<SchoolSubjectsModelMDB> school_subjects { get; set; }

        public int rating { get; set; }
    }
}
