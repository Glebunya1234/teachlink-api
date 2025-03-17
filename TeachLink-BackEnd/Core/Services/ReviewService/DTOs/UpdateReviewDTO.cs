using TeachLink_BackEnd.Core.Models;

public record UpdateReviewDTO
{
    public required string reviews_text { get; init; }

    public required SchoolSubjectListDTO school_subjects { get; init; }

    public required int rating { get; init; }
}
