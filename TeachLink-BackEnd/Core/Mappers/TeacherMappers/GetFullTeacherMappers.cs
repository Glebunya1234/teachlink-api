﻿using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Processors;

namespace TeachLink_BackEnd.Core.Mappers.StudentMappers
{
    public class GetFullTeacherMappers : BaseMapper<TeachersModelMDB, FullTeacherTileDTO>
    {
        private readonly IUrlProcessor _urlProcessor;

        public GetFullTeacherMappers(IUrlProcessor urlProcessor)
        {
            _urlProcessor = urlProcessor;
        }

        public override TeachersModelMDB ToModel(FullTeacherTileDTO dto) =>
            new TeachersModelMDB
            {
                id = dto.id,
                uid = dto.uid,
                email = dto.email,
                full_name = dto.full_name,
                mini_description = dto.mini_description,
                description = dto.description,
                school_subjects = dto.school_subjects.Select(s => new SchoolSubjectsModelMDB
                {
                    Subject = s.Subject,
                }),
                experience = dto.experience,
                degree = dto.degree,
                educational_institution = dto.educational_institution,
                city = dto.city,
                age = dto.age,
                sex = dto.sex,
                avatarId = dto.avatarId,
                average_rating = dto.average_rating,
                review_count = dto.review_count,
                year_of_end = dto.year_of_end,
                online = dto.online,
                show_info = dto.show_info,
                price = dto.price,
                phone_number = dto.phone_number,
                createdAt = dto.createdAt,
                updatedAt = dto.updatedAt,
            };

        public override FullTeacherTileDTO ToDto(TeachersModelMDB model) =>
            new FullTeacherTileDTO
            {
                id = model.id,
                uid = model.uid,
                email = model.email,
                full_name = model.full_name,
                mini_description = model.mini_description,
                description = model.description,
                school_subjects = model.school_subjects.Select(s => new SchoolSubjectDTO
                {
                    Subject = s.Subject,
                }),
                experience = model.experience,
                degree = model.degree,
                year_of_end = model.year_of_end,
                educational_institution = model.educational_institution,
                city = model.city,
                age = model.age,
                sex = model.sex,
                avatarUrl = string.IsNullOrEmpty(model.avatarId)
                    ? null
                    : _urlProcessor.GetImagesUrl(model.avatarId),
                avatarId = model.avatarId,
                online = model.online,
                show_info = model.show_info,
                price = model.price,
                phone_number = model.phone_number,
                average_rating = model.average_rating,
                review_count = model.review_count,
                createdAt = model.createdAt,
                updatedAt = model.updatedAt,
            };
    }
}
