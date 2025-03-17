using Supabase.Postgrest.Attributes;
using TeachLink_BackEnd.Core.Entities;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("reviews")]
    public class ReviewsModel : BaseEntityModel
    {
        [Reference(typeof(TeachersModel))]
        public TeachersModel id_teachers { get; set; }

        [Reference(typeof(StudentsModel))]
        public StudentsModel id_students { get; set; }

        [Column("reviews_text")]
        public string reviews_text { get; set; } = string.Empty;

        [Reference(typeof(SchoolSubjectsModel))]
        public SchoolSubjectsModel school_subjects { get; set; }

        [Column("rating")]
        public int rating { get; set; }
    }
}
