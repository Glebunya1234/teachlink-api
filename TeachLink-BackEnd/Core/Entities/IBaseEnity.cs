namespace TeachLink_BackEnd.Core.Entities
{
    public interface IBaseEnity
    {
        int id { get; set; }

        DateTime createdAt { get; set; }

        DateTime updatedAt { get; set; }
    }
}
