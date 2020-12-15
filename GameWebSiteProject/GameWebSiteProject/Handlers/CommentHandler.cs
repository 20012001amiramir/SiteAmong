using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.Extensions.Configuration;
using System;
using WebSocketManager;

namespace GameWebSiteProject.Handlers
{
    public class CommentHandler : WebSocketHandler
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<PeopleWork> workRepository;
        public CommentHandler(WebSocketConnectionManager webSocketConnectionManager, IConfiguration configuration) : base(webSocketConnectionManager)
        {
            this.userRepository = new Repository<User>(configuration);
            this.commentRepository = new Repository<Comment>(configuration);
            this.workRepository = new Repository<PeopleWork>(configuration);
        }

        public void SendComment(string usernameComment, string workname, string foruser, string content)
        {
            User user = userRepository.GetBy("username", usernameComment);
            var currentTime = DateTime.Now;

            Comment comment = new Comment();
            comment.Id = Guid.NewGuid();
            comment.User_Id = user.Id;
            comment.Work_Id = workRepository.GetBy("Name", workname).Id;
            if(foruser == null)
            {
                comment.ForUser = "Nobody";
            }
            else
            {
                comment.ForUser = foruser;
            }
            comment.Content = content;
            comment.DateSent = currentTime;
            var time = currentTime.ToString("MM/dd/yyyy HH:mm:ss");

            commentRepository.Insert(comment);

            var username = user.Username;
            var avatar = user.Avatar;
            InvokeClientMethodToAllAsync("pingComment", foruser, username, avatar, content, time);
        }
    }
}
