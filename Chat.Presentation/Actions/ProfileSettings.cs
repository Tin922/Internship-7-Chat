using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;


namespace Chat.Presentation.Actions
{
    public class ProfileSettings : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Profile Settings";

        public ProfileSettings(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            var currentUser = Login.GetCurrentUser();

            Console.WriteLine("Odaberite opciju:");
            Console.WriteLine("1. Promijeni sifru");
            Console.WriteLine("2. Promijeni mail");
            Console.WriteLine("3. Idi nazad");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ChangePassword(currentUser);
                    break;
                case "2":
                    ChangeEmail(currentUser);
                    break;
                case "3":
                    Console.WriteLine("Nazad na prethodni meni");
                    break;
                default:
                    Console.WriteLine("Neispravan odabir");
                    Open();
                    break;
            }
        }

        private void ChangePassword(User currentUser)
        {
            Console.WriteLine("Upisite sadasnju sifru");
            var currentPassword = Console.ReadLine();

            if (currentPassword == currentUser.Password)
            {
                Console.WriteLine("Upisite novu sifru");
                var newPassword = Register.GetNonBlankPassword();                
                string captcha = Register.GenerateRandomCaptcha();
                Register.ValidateCaptcha(captcha);


                currentUser.Password = newPassword;
                _userRepository.Update(currentUser, currentUser.UserId);

                Console.WriteLine("Sifra promijenjna uspjesno");
            }
            else
            {
                Console.WriteLine("Pogresna sadasnja sifra. Promjena se nece dogoditi");
            }
        }

        private void ChangeEmail(User currentUser)
        {
            var newEmail = Register.GetEmailFromUser(_userRepository);
            string captcha = Register.GenerateRandomCaptcha();
            Register.ValidateCaptcha(captcha);

            currentUser.Email = newEmail;
            _userRepository.Update(currentUser, currentUser.UserId);

            Console.WriteLine("Email promijenjen uspjesno.");
        }
    }
}
