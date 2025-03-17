using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using TeachLink_BackEnd.Core.Entities;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("experiences")]
    public class ExperienceModel : BaseEntityModel
    {
        [Column("experience_name")]
        public string experience_name { get; set; } = string.Empty;
    }
}
