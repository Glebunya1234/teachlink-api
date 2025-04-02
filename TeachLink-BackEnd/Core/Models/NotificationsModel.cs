using Supabase.Postgrest.Attributes;

namespace TeachLink_BackEnd.Core.Models
{
    [Table("notifications")]
    public class NotificationsModel : BaseEntityModel
    {
        [Reference(typeof(TeachersModel))]
        public TeachersModel id_teacher { get; set; }

        [Reference(typeof(StudentsModel))]
        public StudentsModel id_student { get; set; }

        [Column("is_read")]
        public bool is_read { get; set; } = false;

        [Column("for_teacher")]
        public bool for_teacher { get; set; } = false;
    }

    public class NotificationsCreateUpdateModel : NotificationsModel
    {
        [Column("id_teacher")]
        public new string id_teacher { get; set; } = Guid.NewGuid().ToString();

        [Column("id_student")]
        public new string id_student { get; set; } = Guid.NewGuid().ToString();
    }
}
