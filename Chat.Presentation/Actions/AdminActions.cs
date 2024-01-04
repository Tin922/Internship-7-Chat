using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using System.Data;

namespace Chat.Presentation.Actions
{
    public class AdminActions
    {
        private readonly UserRepository _userRepository;

        public AdminActions(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public void ShowAdminMenu()
        //{
        //    // Display all registered users
        //    var users = _userRepository.GetAll();
        //    Console.WriteLine("List of all registered users:");
        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}, Role: {user.Role}");
        //    }

            // Allow admin to choose actions for each user
            // For each user, provide options to delete profile, update email, and promote to admin
        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"Actions for User ID {user.UserId}:");

        //        Console.WriteLine("1. Delete profile");
        //        Console.WriteLine("2. Update email");
        //        Console.WriteLine("3. Promote to admin");

        //        var choice = Console.ReadLine();

        //        switch (choice)
        //        {
        //            case "1":
        //                _userRepository.Delete(user.UserId);
        //                Console.WriteLine($"Profile for User ID {user.UserId} deleted.");
        //                break;
        //            case "2":
        //                Console.WriteLine("Enter new email:");
        //                var newEmail = Console.ReadLine();
        //                _userRepository.UpdateEmail(user.UserId, newEmail);
        //                Console.WriteLine($"Email for User ID {user.UserId} updated.");
        //                break;
        //            case "3":
        //                _userRepository.UpdateRole(user.UserId, Role.Admin);
        //                Console.WriteLine($"User ID {user.UserId} promoted to admin.");
        //                break;
        //            default:
        //                Console.WriteLine("Invalid choice.");
        //                break;
        //        }
        //    }
        //}
    }
}
