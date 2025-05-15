using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using TeachLink_BackEnd.Core.Mappers.BaseMappers;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Core.Services.ImageService.DTOs;
using TeachLink_BackEnd.Core.Services.StudentService;
using TeachLink_BackEnd.Core.Services.TeacherService;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class ImagesService
    {
        private readonly IGridFSBucket _gridFsBucket;
        private readonly StudentsService _studentsService;
        private readonly TeachersService _teachersService;

        public ImagesService(
            IOptions<MongoSettings> dbSettings,
            TeachersService teachersService,
            StudentsService studentsService
        )
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _gridFsBucket = new GridFSBucket(database);
            _teachersService = teachersService;
            _studentsService = studentsService;
        }

        public async Task UploadFileAsync(UpdateImagesDTO dto)
        {
            using var stream = dto.avatarFile.OpenReadStream();
            var fileId = await _gridFsBucket.UploadFromStreamAsync(dto.avatarFile.FileName, stream);
            var avatarId = fileId.ToString();
            if (dto.for_teacher)
            {
                var teacher = await _teachersService.GetById(dto.uid);
                if (teacher == null)
                    throw new NotFoundException($"Teacher with uid {dto.uid} not found");
                if (!string.IsNullOrEmpty(teacher.avatarId))
                    await DeleteFileAsync(teacher.avatarId);
                await _teachersService.Update(
                    dto.uid,
                    new UpdateTeacherDTO { avatarId = avatarId }
                );
            }
            else
            {
                var student = await _studentsService.GetById(dto.uid);
                if (student == null)
                    throw new NotFoundException($"Student with uid {dto.uid} not found");
                if (!string.IsNullOrEmpty(student.avatarId))
                    await DeleteFileAsync(student.avatarId);
                await _studentsService.Update(
                    dto.uid,
                    new UpdateStudentDTO { avatarId = avatarId }
                );
            }
        }

        public async Task<Stream> DownloadFileAsync(string avatarId)
        {
            var objectId = new ObjectId(avatarId);
            var stream = await _gridFsBucket.OpenDownloadStreamAsync(objectId);
            return stream;
        }

        public async Task RemoveUserAvatarAsync(DeleteImagesDTO deleteImagesDTO)
        {
            if (deleteImagesDTO.for_teacher)
            {
                var teacher = await _teachersService.GetById(deleteImagesDTO.uid);
                if (string.IsNullOrEmpty(teacher.avatarId))
                    throw new NotFoundException($"Avatar with uid {deleteImagesDTO.uid} not found");
                if (teacher == null)
                    throw new NotFoundException(
                        $"Teacher with uid {deleteImagesDTO.uid} not found"
                    );

                await _teachersService.Update(
                    deleteImagesDTO.uid,
                    new UpdateTeacherDTO { avatarId = null }
                );
                await DeleteFileAsync(teacher.avatarId);
            }
            else
            {
                var student = await _studentsService.GetById(deleteImagesDTO.uid);
                if (string.IsNullOrEmpty(student.avatarId))
                    throw new NotFoundException($"Avatar with uid {deleteImagesDTO.uid} not found");
                if (student == null)
                    throw new NotFoundException(
                        $"Student with uid {deleteImagesDTO.uid} not found"
                    );
                await _studentsService.Update(
                    deleteImagesDTO.uid,
                    new UpdateStudentDTO { avatarId = "" }
                );
                await DeleteFileAsync(student.avatarId);
            }
        }

        public async Task DeleteFileAsync(string avatarId)
        {
            var objectId = new ObjectId(avatarId);
            await _gridFsBucket.DeleteAsync(objectId);
        }
    }
}
