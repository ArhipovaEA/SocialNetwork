using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var userEntity = userRepository.FindById(f.user_id);
                var friendEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, userEntity.email, friendEntity.email));
            });

            return friends;
        }

        public void AddFriend(FriendAddingData friendAddingData)
        {
            var findUserEntity = userRepository.FindByEmail(friendAddingData.FriendEmail);

            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.UserId,
                friend_id = findUserEntity.id
            };

            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
