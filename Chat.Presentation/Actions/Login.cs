


using Chat.Data.Entities.Models;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Extensions;
using Chat.Presentation.Factories;

namespace Chat.Presentation.Actions
{
    public class Login : IAction
    {

        private readonly UserRepository _userRepository;
        private static User? _currentUser = null;
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";
        public Login(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Open()
        {

            Console.WriteLine("Upisite email");
            var email = Console.ReadLine();
            Console.WriteLine("Upisite sifru");
            var passsword = Console.ReadLine();

            var user = _userRepository.GetByEmail(email);
            if (user is not null && user.Password == passsword)
            {
                Console.WriteLine("Login uspjesan");
                 _currentUser = user;
                var menuActions = MenuAfterLogin.CreateActions();
                menuActions.PrintActionsAndOpen();
              
            }
            else
            {
                Console.WriteLine("Login neuspjesan");
                Thread.Sleep(30000);
            }

        }
        public static User? GetCurrentUser()
        {
            return _currentUser;
        }
        public static void Logout()
        {
           
            _currentUser = null;
            Console.WriteLine("Logout uspjesan");
            var mainMenuActions = MainMenuFactory.CreateActions();
            mainMenuActions.PrintActionsAndOpen();
        }
}

}
