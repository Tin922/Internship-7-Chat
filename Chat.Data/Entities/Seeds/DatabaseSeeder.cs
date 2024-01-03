using Microsoft.EntityFrameworkCore;
using Chat.Data.Entities.Models;


namespace Chat.Data.Entities.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User()
                    {
                        UserId = 1,
                        Email = "luka@gmail.com",
                        Password = "luka",
                        IsAdmin = false
                    },
                    new User()
                    {
                        UserId = 2,
                        Email = "mate@gmail.com",
                        Password = "mate",
                        IsAdmin = false
                    },
                    new User()
                    {
                        UserId = 3,
                        Email = "sime@gmail.com",
                        Password = "sime",
                        IsAdmin = true
                    }
                }
                ) ;
            builder.Entity<DirectMessage>()
               .HasData(new List<DirectMessage> 
               {
                new DirectMessage()
                {
                    DirectMessageId = 1,
                    SenderId = 1,
                    ReceiverId = 2,
                    Text = "Bok",
                    Timestamp = new DateTime(2023,1,1, 18,0,0, DateTimeKind.Utc)
                },
                new DirectMessage()
                {
                    DirectMessageId = 2,
                    SenderId = 2,
                    ReceiverId = 1,
                    Text = "Bok, Luka",
                    Timestamp = new DateTime(2023,1,1, 18,5,0, DateTimeKind.Utc)
                }
               });

            builder.Entity<Group>()
              .HasData(new List<Group>
              {
                  new Group()
                  {
                      GroupId = 1,
                      Name = "General"
                  },
                   new Group()
                  {
                      GroupId = 2,
                      Name = "Dev"
                  }
              });
            builder.Entity<GroupUser>()
              .HasData(new List<GroupUser> 
              {
                new GroupUser()
                {
                    GroupId = 1,
                    UserId = 1
                },
                new GroupUser()
                {
                    GroupId = 1,
                    UserId = 2
                },
                new GroupUser()
                {
                    GroupId = 1,
                    UserId = 3
                },
                new GroupUser()
                {
                    GroupId = 2,
                    UserId = 1
                },
                 new GroupUser()
                {
                    GroupId = 2,
                    UserId = 2
                }
              });
            builder.Entity<GroupMessage>()
              .HasData(new List<GroupMessage>
              {
                  new GroupMessage()
                  {
                      GroupMessageId = 1,
                      SenderId = 1,
                      GroupId = 1,
                      Text = "Prva poruka u grupi",
                      Timestamp = new DateTime(2023,1,1,20,1,1, DateTimeKind.Utc)
                  },
                   new GroupMessage()
                  {
                      GroupMessageId = 2,
                      SenderId = 2,
                      GroupId = 1,
                      Text = "Bok, Luka",
                      Timestamp = new DateTime(2023,1,1,20,1,2, DateTimeKind.Utc)
                  },
                      new GroupMessage()
                  {
                      GroupMessageId = 3,
                      SenderId = 1,
                      GroupId = 2,
                      Text = "Ovo je dev kanal",
                      Timestamp = new DateTime(2023,1,1,21,1,2, DateTimeKind.Utc)
                  },
                  new GroupMessage()
                  {
                      GroupMessageId = 4,
                      SenderId = 2,
                      GroupId = 2,
                      Text = "Pozdrav",
                      Timestamp = new DateTime(2023,1,1,21,2,2, DateTimeKind.Utc)
                  }
              });
        }
    }
}
