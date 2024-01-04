using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;

namespace Chat.Presentation.Actions
{
    public class GroupChannelEnter : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Enter channel";
        private readonly GroupRepository _groupRepository;
        private readonly UserRepository _userRepository;
        User currentUser = Login.GetCurrentUser();


        public GroupChannelEnter(GroupRepository groupRepository, UserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public void Open()
        {
            

            // Show available channels
            var channelsNotJoined = _groupRepository.GetChannelsNotJoinedByUser(currentUser.UserId);

            if (channelsNotJoined.Count == 0)
            {
                Console.WriteLine("You have joined all available channels.");
                return;
            }

            Console.WriteLine("Available channels:");
            foreach (var channel in channelsNotJoined)
            {
                Console.WriteLine($"Channel: {channel.Name}, Users: {channel.GroupUsers.Count}");
            }

            Console.WriteLine("Enter the name of the channel you want to join or type 'exit' to cancel:");
            var channelName = Console.ReadLine();

            if (channelName?.ToLower() == "exit")
            {
                Console.WriteLine("Operation canceled.");
                return;
            }

            var selectedChannel = _groupRepository.GetByName(channelName);

            if (selectedChannel == null)
            {
                Console.WriteLine($"Channel '{channelName}' not found.");
                return;
            }
            Console.WriteLine(currentUser.UserId);

            
            
                var result = _groupRepository.AddUserToGroup(selectedChannel.GroupId, currentUser.UserId);

                if (result == ResponseResultType.Success)
                {
                    Console.WriteLine($"You have successfully joined the channel '{selectedChannel.Name}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to join the channel '{selectedChannel.Name}'.");
                }
            

           
        }
    }
}
