using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using TeachLink_BackEnd.Core.Entities;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("degrees")]
    public class DegreeModel : BaseEntityModel
    {
        [Column("degree_name")]
        public string degree_name { get; set; } = string.Empty;
    }
}
