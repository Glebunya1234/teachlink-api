using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace TeachLink_BackEnd.Models
{
    [Table("testdb")]
    public class TestusModel : BaseModel
    {
        //[PrimaryKey("id")]
        //public int Id { get; set; } = 0;

        //[Column("users")]
        //public string Users { get; set; } = string.Empty;

        //[Column("email")]
        //public string Email { get; set; } = string.Empty;
    }
}
