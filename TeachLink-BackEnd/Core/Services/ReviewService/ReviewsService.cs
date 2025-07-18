﻿using TeachLink_BackEnd.Core.Helpers;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Core.Services.TeacherService;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Services.StudentService
{
    public class ReviewsService(
        IReviewRepository reviewRepository,
        ITeacherRepository teacherRepository,
        IStudentRepository studentRepository,
        IBaseMapper<ReviewsModelMDB, CreateReviewDTO> createMapper,
        IBaseMapper<ReviewsModelMDB, ReviewDTO> getMapper
    )
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ITeacherRepository _teacherRepository = teacherRepository;
        private readonly IBaseMapper<ReviewsModelMDB, CreateReviewDTO> _createMapper = createMapper;
        private readonly IBaseMapper<ReviewsModelMDB, ReviewDTO> _getMapper = getMapper;

        public async Task Create(CreateReviewDTO createReview)
        {
            var reviewModel = _createMapper.ToModel(createReview);
            var teacher =
                await _teacherRepository.GetById(createReview.id_teacher)
                ?? throw new NotFoundException(
                    $"Teacher with id {createReview.id_teacher} was not found"
                );
            var student =
                await _studentRepository.GetById(createReview.id_student)
                ?? throw new NotFoundException(
                    $"Student with id {createReview.id_student} was not found"
                );
            await _reviewRepository.Create(reviewModel);

            var reviews = await _reviewRepository.GetAllByTeacherId(createReview.id_teacher);
            var newReviewCount = reviews.Count();
            decimal newAverageRating = (decimal)reviews.Average(r => r.rating);

            var teachersModel = await _teacherRepository.GetById(createReview.id_teacher);

            teachersModel.review_count = reviews.Count();
            teachersModel.average_rating = (decimal)reviews.Average(r => r.rating);

            await _teacherRepository.UpdateById(createReview.id_teacher, teachersModel);
        }

        public async Task<PaginationResponse<ReviewDTO>> GetAll(
            string id_teacher,
            int offset,
            int limit
        )
        {
            var result = await _reviewRepository.GetAll(id_teacher, offset, limit);

            var totalCount = await _reviewRepository.CountAsync();
            bool hasNextPage = (offset + limit) < totalCount;

            var dtoList = _getMapper.ToDtoList(result);

            var studentIds = result
                .Where(n => !string.IsNullOrEmpty(n.id_student))
                .Select(n => n.id_student)
                .Distinct()
                .ToList();

            var teachersModel = await _teacherRepository.GetById(id_teacher);

            var studentsModel = await _studentRepository.GetByIdList(studentIds);

            var studentDict = studentsModel.ToDictionary(s => s.uid, s => s);
            var enrichedDtos = ReviewHelper.EnrichNotifications(
                dtoList,
                result,
                teachersModel,
                studentDict
            );
            return new PaginationResponse<ReviewDTO>
            {
                Items = enrichedDtos,
                HasNextPage = hasNextPage,
                TotalCount = totalCount,
            };
        }

        public async Task<ReviewDTO?> GetById(string id_teacher, string id_student)
        {
            var result =
                await _reviewRepository.GetById(id_teacher, id_student)
                ?? throw new NotFoundException(
                    $"\"Review\" with id {id_teacher} and {id_student} was not found"
                );
            var dtoList = _getMapper.ToDto(result);

            var teachersModel =
                await _teacherRepository.GetById(id_teacher)
                ?? throw new NotFoundException($"Teacher with id {id_teacher} was not found");

            var studentsModel =
                await _studentRepository.GetById(id_student)
                ?? throw new NotFoundException($"Student with id {id_student} was not found");

            var enrichedDto = ReviewHelper.EnrichNotification(
                dtoList,
                result,
                teachersModel,
                studentsModel
            );
            return enrichedDto;
        }

        public async Task Update(string id, UpdateReviewDTO review)
        {
            var oldmodel =
                await _reviewRepository.GetById(id)
                ?? throw new NotFoundException($"Review with id {id} was not found");
            UpdateHelper.ApplyPatch(review, oldmodel, "school_subjects");
            if (review.school_subjects != null)
                oldmodel.school_subjects = review
                    .school_subjects.Select(s => new SchoolSubjectsModelMDB { Subject = s.Subject })
                    .ToList();
            await _reviewRepository.Update(id, oldmodel);

            var reviews = await _reviewRepository.GetAllByTeacherId(oldmodel.id_teacher);

            var teachersModel = await _teacherRepository.GetById(oldmodel.id_teacher);

            teachersModel.review_count = reviews.Count();
            teachersModel.average_rating = (decimal)reviews.Average(r => r.rating);

            await _teacherRepository.UpdateById(oldmodel.id_teacher, teachersModel);
        }
    }
}
