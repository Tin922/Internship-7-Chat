using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Data.Entities.Models; 
using Chat.Presentation.Actions;

public class ShowAllUsersForMessages : IAction
{
    private readonly UserRepository _userRepository;
    private readonly DirectMessageRepository _directMessageRepository;
    User currentUser = Login.GetCurrentUser();


    public ShowAllUsersForMessages(UserRepository userRepository, DirectMessageRepository directMessageRepository)
    {
        _userRepository = userRepository;
        _directMessageRepository = directMessageRepository;
    }

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Show All Users For Messages";

    public void Open()
    {
        var users = _userRepository.GetAll();

        Console.WriteLine("Lista svih korisnika: ");
        foreach (var user in users)
        {
            Console.WriteLine($"User ID: {user.UserId}, Email: {user.Email}");
        }

        OpenPrivateChat();
    }

    private void OpenPrivateChat()
    {
        Console.WriteLine("Upsiite ID korisnika s kojim zelite komunicirati. (exit za izlaz)");
        var input = Console.ReadLine();

        if (input?.ToLower() == "exit")
        {
            Console.WriteLine("Operacija otkazana");
            return;
        }

        if (int.TryParse(input, out var selectedUserId))
        {
            var selectedUser = _userRepository.GetById(selectedUserId);

            if (selectedUser != null)
            {
                OpenPrivateChatWithUser(selectedUser);
            }
            else
            {
                Console.WriteLine($"User s ID-em {selectedUserId} nije pronađen.");
                OpenPrivateChat();
            }
        }
        else
        {
            Console.WriteLine("Neispravan unos. Upisite korisnika s ispravnim ID-em");
            OpenPrivateChat();
        }
    }

    private void OpenPrivateChatWithUser(User selectedUser)
    {

        var directMessages = _directMessageRepository.GetDirectMessagesBetweenUsers(currentUser.UserId, selectedUser.UserId);

        Console.WriteLine($"Privatni chat s {selectedUser.Email}");

        foreach (var message in directMessages)
        {
            Console.WriteLine($"[{message.Timestamp}] {message.Sender.Email}: {message.Text}");
        }

        SendMessageToUser(selectedUser);
    }

    private void SendMessageToUser(User otherUser)
    {
        Console.WriteLine("Napisi svoju pourku (napisi'/exit' za povratak):");

        while (true)
        {
            var messageText = Console.ReadLine();

            if (messageText?.ToLower() == "/exit")
            {
                Console.WriteLine("Izlazk iz privatnih poruka");
                break;
            }

            _directMessageRepository.Add(new DirectMessage
            {
                SenderId = Login.GetCurrentUser().UserId,
                ReceiverId = otherUser.UserId,
                Text = messageText,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
