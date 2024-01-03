


using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;


namespace Chat.Presentation.Actions
{
    public class Login : IAction
    {

        private readonly UserRepository _userRepository;
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Add user";
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
            if(user.Password == passsword && user is not null)
                Console.WriteLine("login successful");
            else
                Console.WriteLine("login failed");

        }
    }
}
