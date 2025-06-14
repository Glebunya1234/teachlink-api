﻿using System.Reactive.Subjects;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Core.Repositories;
using TeachLink_BackEnd.Infrastructure.Services;

namespace TeachLink_BackEnd.Core.Services.TeacherService
{
    public class TeacherRepository : MongoService<TeachersModelMDB>, ITeacherRepository
    {
        public TeacherRepository(IOptions<MongoSettings> options)
            : base(options, options.Value.TeachersCollectionName) { }

        public async Task Create(TeachersModelMDB teachersModel)
        {
            await _collection.InsertOneAsync(teachersModel);
        }

        public async Task<TeachersModelMDB?> GetById(string uid)
        {
            return await _collection.Find(doc => doc.uid == uid).FirstOrDefaultAsync();
        }

        public async Task UpdateById(string id, TeachersModelMDB teachersModels)
        {
            var res = await _collection.ReplaceOneAsync(t => t.uid == id, teachersModels);
            if (res.ModifiedCount == 0)
                throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeachersModelMDB>> GetAll(
            int offset = 0,
            int limit = 20,
            SortByEnumMDB? sortBy = null,
            string? subject = null,
            bool? isOnline = null,
            string? city = null,
            int? minPrice = null,
            int? maxPrice = null
        )
        {
            var filterBuilder = Builders<TeachersModelMDB>.Filter;
            var filter = filterBuilder.Empty;

            filter &= filterBuilder.Eq(t => t.show_info, true);

            if (!string.IsNullOrEmpty(subject))
            {
                var subjectsArray = subject
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                if (subjectsArray.Any())
                {
                    filter &= filterBuilder.All(
                        t => t.school_subjects.Select(s => s.Subject),
                        subjectsArray
                    );
                }
            }
            if (isOnline.HasValue)
            {
                filter &= filterBuilder.Eq(t => t.online, isOnline.Value);
            }
            if (!string.IsNullOrEmpty(city))
            {
                filter &= filterBuilder.Eq(t => t.city, city);
            }
            if (minPrice.HasValue)
            {
                filter &= filterBuilder.Gte(t => t.price, minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filter &= filterBuilder.Lte(t => t.price, maxPrice.Value);
            }

            var sortDefinition = sortBy switch
            {
                SortByEnumMDB.PriceAsc => Builders<TeachersModelMDB>.Sort.Ascending(t => t.price),
                SortByEnumMDB.PriceDesc => Builders<TeachersModelMDB>.Sort.Descending(t => t.price),
                SortByEnumMDB.Rating => Builders<TeachersModelMDB>.Sort.Descending(t =>
                    t.average_rating
                ),
                SortByEnumMDB.Reviews => Builders<TeachersModelMDB>.Sort.Descending(t =>
                    t.review_count
                ),
                _ => Builders<TeachersModelMDB>.Sort.Descending(t => t.average_rating),
            };

            return await _collection
                .Find(filter)
                .Sort(sortDefinition)
                .Skip(offset)
                .Limit(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<TeachersModelMDB>> GetByIdList(IEnumerable<string> ids)
        {
            return await _collection.Find(teach => ids.Contains(teach.uid)).ToListAsync();
        }

        public async Task<int> CountAsync(
            string? subject = null,
            bool? isOnline = null,
            string? city = null,
            int? minPrice = null,
            int? maxPrice = null
        )
        {
            var filterBuilder = Builders<TeachersModelMDB>.Filter;
            var filter = filterBuilder.Empty;

            filter &= filterBuilder.Eq(t => t.show_info, true);

            if (!string.IsNullOrEmpty(subject))
            {
                var subjectsArray = subject
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                if (subjectsArray.Any())
                {
                    filter &= filterBuilder.All(
                        t => t.school_subjects.Select(s => s.Subject),
                        subjectsArray
                    );
                }
            }

            if (isOnline.HasValue)
            {
                filter &= filterBuilder.Eq(t => t.online, isOnline.Value);
            }

            if (!string.IsNullOrEmpty(city))
            {
                filter &= filterBuilder.Eq(t => t.city, city);
            }

            if (minPrice.HasValue)
            {
                filter &= filterBuilder.Gte(t => t.price, minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filter &= filterBuilder.Lte(t => t.price, maxPrice.Value);
            }

            return (int)await _collection.CountDocumentsAsync(filter);
        }
    }
}
