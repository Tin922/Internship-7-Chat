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

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Change Password");
            Console.WriteLine("2. Change Email");
            Console.WriteLine("3. Go Back");

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
                    Console.WriteLine("Going back to the main menu.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Open();
                    break;
            }
        }

        private void ChangePassword(User currentUser)
        {
            Console.WriteLine("Enter your current password:");
            var currentPassword = Console.ReadLine();

            if (currentPassword == currentUser.Password)
            {
                Console.WriteLine("Enter your new password:");
                var newPassword = Register.GetNonBlankPassword();                
                string captcha = Register.GenerateRandomCaptcha();
                Register.ValidateCaptcha(captcha);


                currentUser.Password = newPassword;
                _userRepository.Update(currentUser, currentUser.UserId);

                Console.WriteLine("Password changed successfully.");
            }
            else
            {
                Console.WriteLine("Incorrect current password. Password change failed.");
            }
        }

        private void ChangeEmail(User currentUser)
        {
            Console.WriteLine("Enter your new email:");
            var newEmail = Register.GetEmailFromUser(_userRepository);
            string captcha = Register.GenerateRandomCaptcha();
            Register.ValidateCaptcha(captcha);

            currentUser.Email = newEmail;
            _userRepository.Update(currentUser, currentUser.UserId);

            Console.WriteLine("Email changed successfully.");
        }
    }
}
