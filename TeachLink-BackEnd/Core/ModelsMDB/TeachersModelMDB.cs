using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class TeachersModelMDB : BaseModelMDB
    {
        public string full_name { get; set; } = string.Empty;

        public string mini_description { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public IEnumerable<SchoolSubjectsModelMDB> school_subjects { get; set; } =
            new List<SchoolSubjectsModelMDB>();

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string experience { get; set; } = null;

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string degree { get; set; } = null;

        public string educational_institution { get; set; } = string.Empty;

        public int year_of_end { get; set; } = 0;

        public string city { get; set; } = string.Empty;

        public int age { get; set; } = 18;

        public string sex { get; set; } = string.Empty;

        public bool online { get; set; } = false;

        public bool show_info { get; set; } = false;

        public int price { get; set; } = 100;
    }
}
