using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("degrees")]
    public class DegreeModel : BaseEntityInt
    {
        [Column("degree_name")]
        public string degree_name { get; set; } = string.Empty;
    }
}
