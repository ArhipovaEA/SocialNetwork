using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendsListView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            InfoMessage.Show("Список друзей");

            if (friends.Count() == 0)
            {
                Console.WriteLine("К сожалению, у Вас нет друзей.");
                return;
            }

            friends.ToList().ForEach(f =>
            {
                Console.WriteLine(f.FriendEmail);
            });
        }
    }
}
