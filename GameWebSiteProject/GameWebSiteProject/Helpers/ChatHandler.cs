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

        public void SendMessage(string usernameSession, string subject, string content)
        {
            User user = userRepository.GetBy("username", usernameSession);
            var currentTime = DateTime.Now;

            Message message = new Message();
            message.Id = Guid.NewGuid();
            message.User_Id = user.Id;
            message.Subject = subject;
            message.Content = content;
            message.DateSent = currentTime;
            var time = currentTime.ToString("MM/dd/yyyy HH:mm:ss");

            messageRepository.Insert(message);
          
            var username = user.Username;
            var avatar = user.Avatar;
            InvokeClientMethodToAllAsync("pingMessage", subject, username, avatar, content, time);
        }     
    }
}
