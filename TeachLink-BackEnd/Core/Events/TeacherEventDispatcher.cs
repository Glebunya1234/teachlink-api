//namespace TeachLink_BackEnd.Core.Events
//{
//    public class TeacherEventDispatcher
//    {
//        private event EventHandler<ReviewEventArgs> ReviewCreated;
//        private event EventHandler<ReviewEventArgs> ReviewUpdated;

//        public void RegisterHandler(
//            EventHandler<ReviewEventArgs> reviewCreatedHandler,
//            EventHandler<ReviewEventArgs> reviewUpdatedHandler
//        )
//        {
//            ReviewCreated += reviewCreatedHandler;
//            ReviewUpdated += reviewUpdatedHandler;
//        }

//        public void RaiseReviewCreatedEvent(
//            string teacherId,
//            decimal newAverageRating,
//            int newReviewCount
//        )
//        {
//            var eventArgs = new ReviewEventArgs
//            {
//                TeacherId = teacherId,
//                NewAverageRating = newAverageRating,
//                NewReviewCount = newReviewCount,
//            };

//            ReviewCreated?.Invoke(this, eventArgs);
//        }

//        public void RaiseReviewUpdatedEvent(
//            string teacherId,
//            decimal newAverageRating,
//            int newReviewCount
//        )
//        {
//            var eventArgs = new ReviewEventArgs
//            {
//                TeacherId = teacherId,
//                NewAverageRating = newAverageRating,
//                NewReviewCount = newReviewCount,
//            };

//            ReviewUpdated?.Invoke(this, eventArgs);
//        }
//    }
//}
