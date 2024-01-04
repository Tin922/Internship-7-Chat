using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;

namespace Chat.Presentation.Actions
{
    public class GroupChannelEnter : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Uđi u kanal";
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
            

            var channelsNotJoined = _groupRepository.GetChannelsNotJoinedByUser(currentUser.UserId);

            if (channelsNotJoined.Count == 0)
            {
                Console.WriteLine("Usao si u sve dostupne kanale.");
                return;
            }

            Console.WriteLine("Dostupni kanali");
            foreach (var channel in channelsNotJoined)
            {
                Console.WriteLine($"Kanal: {channel.Name}, Korisnici: {channel.GroupUsers.Count}");
            }

            Console.WriteLine("Upisi ime kanla kojem se zelis pridruziti ili 'exit' za izlaz");
            var channelName = Console.ReadLine();

            if (channelName?.ToLower() == "exit")
            {
                Console.WriteLine("Operacija otkazana");
                return;
            }

            var selectedChannel = _groupRepository.GetByName(channelName);

            if (selectedChannel == null)
            {
                Console.WriteLine($"Channel '{channelName}' not found.");
                return;
            }      
            
                var result = _groupRepository.AddUserToGroup(selectedChannel.GroupId, currentUser.UserId);

                if (result == ResponseResultType.Success)
                {
                    Console.WriteLine($"Uspjesno si se pridruzio kanalu'{selectedChannel.Name}'.");
                }
                else
                {
                    Console.WriteLine($"Nisis se uspio pridruziti kanalu '{selectedChannel.Name}'.");
                }
            

           
        }
    }
}
