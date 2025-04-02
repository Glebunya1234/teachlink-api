using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TeachLink_BackEnd.Core.Models
{
    public abstract class BaseEntityModel : BaseModel
    {
        [PrimaryKey("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [Column("createdAt")]
        public DateTime createdAt { get; set; }

        [Column("updatedAt")]
        public DateTime updatedAt { get; set; }
    }

    public abstract class BaseEntityInt : BaseModel
    {
        [PrimaryKey("id")]
        public int id { get; set; }

        [Column("createdAt")]
        public DateTime createdAt { get; set; }

        [Column("updatedAt")]
        public DateTime updatedAt { get; set; }
    }
}
