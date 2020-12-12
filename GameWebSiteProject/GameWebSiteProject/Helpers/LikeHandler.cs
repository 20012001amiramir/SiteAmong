using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using System;
using Microsoft.Extensions.Configuration;
using WebSocketManager;
using System.Collections.Generic;

namespace GameWebSiteProject.Helpers
{
    public class LikeHandler : WebSocketHandler
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<PeopleWork> workRepository;
        private readonly IRepository<Like> likeRepository;
        public LikeHandler(WebSocketConnectionManager webSocketConnectionManager, IConfiguration configuration) : base(webSocketConnectionManager)
        {
            this.userRepository = new Repository<User>(configuration);
            this.workRepository = new Repository<PeopleWork>(configuration);
            this.likeRepository = new Repository<Like>(configuration);
        }

        public void LeaveLike(string username, string workname)
        {
            User user = userRepository.GetBy("username", username);
            PeopleWork work = workRepository.GetBy("name", workname);

            Like oldLike = likeRepository.GetBy("Work_Id", work.Id.ToString(), "User_Id", user.Id.ToString() );


            if (oldLike == null)
            {
                Like like = new Like
                {
                    Id = Guid.NewGuid(),
                    User_Id = user.Id,
                    Work_Id = work.Id,
                    IsLiked = 1,
                    NumberOfChange = 1,
                    DateSent = DateTime.Now
                };

                work.Likes++;
                workRepository.Update(work);
                likeRepository.Insert(like);
            }
            else
            {
                oldLike.NumberOfChange++;
                oldLike.DateSent = DateTime.Now;
                if (oldLike.NumberOfChange % 2 != 0)
                {
                    oldLike.IsLiked = 1;
                    work.Likes++;
                }
                else
                {
                    work.Likes--;
                    oldLike.IsLiked = 0;
                }
                workRepository.Update(work);
                likeRepository.Update(oldLike);
            }

            int likes = work.Likes;

            
            InvokeClientMethodToAllAsync("pingLike", likes);
        }

        
    }
}
