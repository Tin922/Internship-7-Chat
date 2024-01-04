


using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using System.Text.RegularExpressions;


namespace Chat.Presentation.Actions
{
    public class Register : IAction
    {

        private readonly UserRepository _userRepository;
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Register";
        public Register(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Open()
        {

            var email = GetEmailFromUser(_userRepository);
            var passsword = GetNonBlankPassword();
            ConfirmPassword(passsword);
            string captcha = GenerateRandomCaptcha();
            ValidateCaptcha(captcha);

            if (_userRepository.Add(new User() { 
                Email = email,
                Password = passsword}
            ) == ResponseResultType.Success)
            {
                Console.WriteLine("Uspjesna registracija.");
            }


            

        }
        public static string GetEmailFromUser(UserRepository userRepository)
        {
            string email;
            do
            {
                Console.WriteLine("Unesite email");
                email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Neispravan format emaila! Unesite email ponovno.");
                }
                if (userRepository.GetByEmail(email) != null)
                {
                    Console.WriteLine("korisnik s tim emailom vec postoji! Unesite neki drugi email.");
                }
            } while (!IsValidEmail(email) || userRepository.GetByEmail(email) != null);
            return email;
        }
        public static string GenerateRandomCaptcha()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] captchaArray = new char[8];
            captchaArray[0] = characters[random.Next(26)];
            captchaArray[1] = characters[random.Next(52, 62)];
            for (int i = 2; i < 8; i++)
            {
                captchaArray[i] = characters[random.Next(characters.Length)];
            }
            for (int i = 0; i < 7; i++)
            {
                int j = random.Next(i, 8);
                char temp = captchaArray[i];

                captchaArray[i] = captchaArray[j];
                captchaArray[j] = temp;
            }

            return new string(captchaArray);
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^.+@[a-zA-Z]{2,}\.[a-zA-Z]{3,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static string GetNonBlankPassword()
        {
            string password;

            do
            {
                Console.WriteLine("Upisite sifru:");
                password = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(password));

            return password;

        }
        public static void ConfirmPassword(string password)
        {
            string reenteredPassword;
            do
            {
                Console.WriteLine("Upisite sifru ponovno: ");
                reenteredPassword = Console.ReadLine();

                if (reenteredPassword != password)
                {
                    Console.WriteLine("Sifre se ne podudaraju! Unesite sifru ponovno.");
                }
            } while (reenteredPassword != password);
        }
        public static void ValidateCaptcha(string captcha)
        {
            string enteredCaptcha;
            do
            {
                Console.WriteLine("Unesite tekst " + captcha);
                enteredCaptcha = Console.ReadLine();
            } while (enteredCaptcha != captcha);
        }
    }
    
}
