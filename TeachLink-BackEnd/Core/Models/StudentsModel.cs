using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using TeachLink_BackEnd.Core.Entities;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("students")]
    public class StudentsModel : BaseEntityModel
    {
        [Column("full_name")]
        public string full_name { get; set; } = string.Empty;

        [Column("city")]
        public string city { get; set; } = string.Empty;

        [Column("age")]
        public int age { get; set; } = 0;

        [Column("sex")]
        public string sex { get; set; } = string.Empty;
    }
}
