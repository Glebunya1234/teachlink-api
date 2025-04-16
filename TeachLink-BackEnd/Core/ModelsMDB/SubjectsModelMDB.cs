using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class SubjectsModelMDB : BaseModelMDB
    {
        private string _subject = null!;
        public string subject
        {
            get => _subject;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BadRequestException("Subject cannot be empty.");
                }
                _subject = value;
            }
        }
    }
}
