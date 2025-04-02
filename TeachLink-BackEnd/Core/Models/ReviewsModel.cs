using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("reviews")]
    public class ReviewsModel : BaseEntityModel
    {
        [Reference(typeof(TeachersModel))]
        public TeachersModel id_teacher { get; set; }

        [Reference(typeof(StudentsModel))]
        public StudentsModel id_student { get; set; }

        [Column("reviews_text")]
        public string reviews_text { get; set; } = string.Empty;

        [Reference(typeof(SchoolSubjectsModel))]
        public IEnumerable<SchoolSubjectsModel> school_subjects { get; set; }

        [Column("rating")]
        public int rating { get; set; }
    }

    public class ReviewsModelCreateUpdateModel : ReviewsModel
    {
        [Column("id_teacher")]
        public new string id_teacher { get; set; } = Guid.NewGuid().ToString();

        [Column("id_student")]
        public new string id_student { get; set; } = Guid.NewGuid().ToString();
    }
}
