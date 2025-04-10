//using TeachLink_BackEnd.Core.Events;
//using TeachLink_BackEnd.Infrastructure.Services;

//namespace TeachLink_BackEnd.Infrastructure.GlobalHendelrs
//{
//    public class TeacherEventHandler : IHostedService
//    {
//        private readonly TeachersService _teachersService;

//        public TeacherEventHandler(
//            TeachersService teachersService,
//            TeacherEventDispatcher eventDispatcher
//        )
//        {
//            _teachersService = teachersService;
//            eventDispatcher.RegisterHandler(HandleReviewCreated, HandleReviewUpdated);
//        }

//        public Task StartAsync(CancellationToken cancellationToken)
//        {
//            return Task.CompletedTask;
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            return Task.CompletedTask;
//        }

//        public async void HandleReviewCreated(object? sender, ReviewEventArgs e)
//        {
//            var teacher =
//                await _teachersService.GetById(e.TeacherId)
//                ?? throw new NotFoundException($"Teacher with id {e.TeacherId} was not found");

//            var updateDto = new UpdateTeacherDTO
//            {
//                review_count = e.NewReviewCount,
//                average_rating = e.NewAverageRating,
//            };

//            await _teachersService.Update(e.TeacherId, updateDto);
//        }

//        public async void HandleReviewUpdated(object? sender, ReviewEventArgs e)
//        {
//            var teacher =
//                await _teachersService.GetById(e.TeacherId)
//                ?? throw new NotFoundException($"Teacher with id {e.TeacherId} was not found");

//            var updateDto = new UpdateTeacherDTO
//            {
//                review_count = e.NewReviewCount,
//                average_rating = e.NewAverageRating,
//            };

//            await _teachersService.Update(e.TeacherId, updateDto);
//        }
//    }
//}
