using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        UserService userService;
        FriendService friendService;

        public FriendAddingView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();

            Console.Write("Введите почтовый адрес друга: ");
            friendAddingData.FriendEmail = Console.ReadLine();

            friendAddingData.UserId = user.Id;

            try
            {
                friendService.AddFriend(friendAddingData);

                SuccessMessage.Show($"Пользователь {friendAddingData.FriendEmail} добавлен в друзья!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }
        }
    }
}
