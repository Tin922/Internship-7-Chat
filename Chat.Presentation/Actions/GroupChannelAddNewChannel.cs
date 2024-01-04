using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;


namespace Chat.Presentation.Actions
{
    public class GroupChannelAddNewChannel : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Dodaj novi kanal";
        private readonly GroupRepository _groupRepository;
        User? currentUser = Login.GetCurrentUser();


        public GroupChannelAddNewChannel(GroupRepository group)
        {
            _groupRepository = group;       
        }
        public void Open()
        {           
            Console.WriteLine("Upisite ime kanala");
            var channelName = Console.ReadLine();
            var newGroup = new Group() { Name = channelName };

            var groupUser = new GroupUser
            {
                UserId = currentUser.UserId,
                User = currentUser,
                Group = newGroup
            };

            newGroup.GroupUsers = new List<GroupUser> { groupUser };

            if (_groupRepository.Add(newGroup) == ResponseResultType.Success)
            {
                Console.WriteLine("Grupa uspješno dodana");
            }
            else
            {
                Console.WriteLine("Grupa nije dodana");
            }

        } 
    }
}
