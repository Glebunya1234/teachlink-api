using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using TeachLink_BackEnd.Core.Entities;

namespace TeachLink_BackEnd.Core.Models
{
    public abstract class BaseEntityModel : BaseModel
    {
        [PrimaryKey("id")]
        public int id { get; set; }

        [PrimaryKey("createdAt")]
        public DateTime createdAt { get; set; }

        [PrimaryKey("updatedAt")]
        public DateTime updatedAt { get; set; }
    }
}
