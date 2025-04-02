using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("announcements")]
    public class AnnouncementsModel : BaseEntityModel
    {
        [Reference(typeof(StudentsModel))]
        public StudentsModel id_student { get; set; }

        [Column("mini_description")]
        public string mini_description { get; set; } = string.Empty;

        [Column("school_subjects")]
        public IEnumerable<SchoolSubjectsModel> school_subjects { get; set; }

        [Column("description")]
        public string description { get; set; } = string.Empty;
    }
}
