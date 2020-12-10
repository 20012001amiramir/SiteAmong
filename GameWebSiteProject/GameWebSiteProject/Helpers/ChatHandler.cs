using GameWebSiteProject.Models;
using GameWebSiteProject.Repository;
using Microsoft.Extensions.Configuration;
using System;
using WebSocketManager;

namespace GameWebSiteProject.Helpers
{
    public class ChatHandler : WebSocketHandler
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Message> messageRepository;
        public ChatHandler(WebSocketConnectionManager webSocketConnectionManager, IConfiguration configuration) : base(webSocketConnectionManager)
        {
            this.userRepository = new Repository<User>(configuration);
            this.messageRepository = new Repository<Message>(configuration);
        }

        public void SendMessage(string userid, string subject, string content)
        {
            var currentTime = DateTime.Now;

            Message message = new Message();
            message.Id = Guid.NewGuid();
            message.User_Id = Guid.Parse(userid);
            message.Subject = subject;
            message.Content = content;
            message.DateSent = currentTime;
            var time = currentTime.ToString("MM/dd/yyyy HH:mm:ss");

            messageRepository.Insert(message);

            User user = userRepository.GetBy("Id", userid);
            var username = user.Username;
            var avatar = user.Avatar;
            InvokeClientMethodToAllAsync("pingMessage", subject, username, avatar, content, time);
        }     
    }
}
