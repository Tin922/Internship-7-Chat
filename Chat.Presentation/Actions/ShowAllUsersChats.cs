using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using System;
using System.Linq;

namespace Chat.Presentation.Actions
{
    public class ShowAllUsersChats : IAction
    {
        private readonly DirectMessageRepository _directMessageRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Ispis svih korisnika s kojim si komunicirao";

        public ShowAllUsersChats(DirectMessageRepository directMessageRepository)
        {
            _directMessageRepository = directMessageRepository;
        }

        public void Open()
        {
            var currentUser = Login.GetCurrentUser();

            var usersCommunicatedWith = _directMessageRepository.GetUsersCommunicatedWith(currentUser.UserId);

            if (usersCommunicatedWith.Count == 0)
            {
                Console.WriteLine("Nemas poruka");
            }
            else
            {
                Console.WriteLine("Korisnici s kojima si komunicirao: ");

                foreach (var user in usersCommunicatedWith)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}");
                }
            }
        }
    }
}
