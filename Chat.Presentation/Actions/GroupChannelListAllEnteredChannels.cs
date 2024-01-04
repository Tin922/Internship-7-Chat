using Chat.Data.Entities.Models;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;

public class GroupChannelListAllEnteredChannels : IAction
{
    private readonly GroupRepository _groupRepository;
    private readonly GroupMessageRepository _groupMessageRepository;
    User currentUser = Login.GetCurrentUser();


    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Ispis svih kanala u kojima se nalazis";

    public GroupChannelListAllEnteredChannels(GroupRepository groupRepository, GroupMessageRepository groupMessageRepository)
    {
        _groupRepository = groupRepository;
        _groupMessageRepository = groupMessageRepository;
    }

    public void Open()
    {
        var channelsJoined = _groupRepository.GetChannelsJoinedByUser(currentUser.UserId);

        Console.WriteLine("Kanali u kojima se nalazite: ");
        foreach (var channel in channelsJoined)
        {
            Console.WriteLine($"Kanal: {channel.Name}, Korisnici: {channel.GroupUsers.Count}");
        }

        Group selectedChannel;

        do
        {
            selectedChannel = GetSelectedChannel();

            if (selectedChannel == null)
            {
                Console.WriteLine("Neispravan unos. Provjerite ime kanala i pokušajte ponovno.");
            }

        } while (selectedChannel == null);
        DisplayChannelMessages(selectedChannel);

        SendMessages(selectedChannel);
    }

    private void DisplayChannelMessages(Group selectedChannel)
    {
        var messages = _groupMessageRepository.GetChannelMessages(selectedChannel.GroupId);

        Console.WriteLine($"Poruke u {selectedChannel.Name}:");
        foreach (var message in messages)
        {
            Console.WriteLine($"[{message.Timestamp}] {message.Sender.Email}: {message.Text}");
        }
    }

    private void SendMessages(Group selectedChannel)
    {
        Console.WriteLine("Napisi svoju poruku. ('/exit' za povratak nazad)");

        while (true)
        {
            var messageText = Console.ReadLine();

            if (messageText?.ToLower() == "/exit")
            {
                Console.WriteLine("Izlazenje iz chata");
                break;
            }

            _groupMessageRepository.AddMessageToChannel(selectedChannel.GroupId, currentUser.UserId, messageText);
        }
    }

    private Group GetSelectedChannel()
    {
        
        Console.WriteLine("Upisite ime kanala u kojeg zelite uci: ");
        var channelName = Console.ReadLine();

        return _groupRepository.GetByName(channelName);
    }
}
