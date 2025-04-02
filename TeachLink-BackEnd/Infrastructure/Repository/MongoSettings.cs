namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TeachersCollectionName { get; set; } = null!;

        public string StudentsCollectionName { get; set; } = null!;

        public string ReviewsCollectionName { get; set; } = null!;

        public string ExperiencesCollectionName { get; set; } = null!;

        public string DegreesCollectionName { get; set; } = null!;

        public string NotificationsCollectionName { get; set; } = null!;

        public string AnnouncementsCollectionName { get; set; } = null!;
    }
}
