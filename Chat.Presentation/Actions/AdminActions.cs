using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using System;
using System.Data;

namespace Chat.Presentation.Actions
{
    public class AdminActions : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly User currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "User management";

        public AdminActions(UserRepository userRepository)
        {
            _userRepository = userRepository;
            currentUser = Login.GetCurrentUser();
        }

        public void Open()
        {
            if (currentUser?.IsAdmin != true)
            {
                Console.WriteLine("Nisi admin");
                return;
            }

            var users = _userRepository.GetAll();
            Console.WriteLine("Lista svih registriranih korisnika");
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}, Admin: {user.IsAdmin}");
            }

            Console.WriteLine("Odaberi usera po ID-u");
            if (int.TryParse(Console.ReadLine(), out var selectedUserId))
            {
                var selectedUser = _userRepository.GetById(selectedUserId);

                if (selectedUser != null)
                {
                    Console.WriteLine($"Akcije za User ID {selectedUser.UserId}:");
                    Console.WriteLine("1. Obrisi profil");
                    Console.WriteLine("2. Promijenite email");
                    Console.WriteLine("3. Promocija u admina");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            _userRepository.Delete(selectedUser.UserId);
                            Console.WriteLine($"Profile s User ID-em {selectedUser.UserId} izbrisan.");
                            break;
                        case "2":
                            Console.WriteLine("Enter new email:");
                            var newEmail = Console.ReadLine();
                            _userRepository.UpdateEmail(selectedUser.UserId, newEmail);
                            Console.WriteLine($"Email za Usera s ID-em {selectedUser.UserId} updatean.");
                            break;
                        case "3":
                            _userRepository.UpdateRole(selectedUser.UserId, true);
                            Console.WriteLine($"User s ID-em {selectedUser.UserId} promoviran u admina.");
                            break;
                        default:
                            Console.WriteLine("Neispravan izbor");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"User s ID-em {selectedUserId} ne postoji.");
                }
            }
            else
            {
                Console.WriteLine("Neispravan ID");
            }
        }
    }
}
