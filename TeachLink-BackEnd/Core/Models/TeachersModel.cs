using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("teachers")]
    public class TeachersModel : BaseEntityModel
    {
        [Column("full_name")]
        public string full_name { get; set; } = string.Empty;

        [Column("mini_description")]
        public string mini_description { get; set; } = string.Empty;

        [Column("description")]
        public string description { get; set; } = string.Empty;

        [Column("school_subjects")]
        public IEnumerable<SchoolSubjectsModel> school_subjects { get; set; }

        [Reference(typeof(ExperienceModel))]
        public ExperienceModel experience { get; set; }

        [Reference(typeof(DegreeModel))]
        public DegreeModel degree { get; set; }

        [Column("educational_institution")]
        public string educational_institution { get; set; } = string.Empty;

        [Column("year_of_end")]
        public int year_of_end { get; set; } = 0;

        [Column("city")]
        public string city { get; set; } = string.Empty;

        [Column("age")]
        public int age { get; set; } = 0;

        [Column("sex")]
        public string sex { get; set; } = string.Empty;

        [Column("online")]
        public bool online { get; set; }

        [Column("show_info")]
        public bool show_info { get; set; }

        [Column("price")]
        public int price { get; set; } = 0;
    }
}
