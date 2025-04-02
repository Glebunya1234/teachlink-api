using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("experiences")]
    public class ExperienceModel : BaseEntityInt
    {
        [Column("experience_name")]
        public string experience_name { get; set; } = string.Empty;
    }
}
