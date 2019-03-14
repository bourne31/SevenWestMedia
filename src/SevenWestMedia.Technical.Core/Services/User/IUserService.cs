using System.Collections.Generic;
using SevenWestMedia.Technical.Core.Models;

namespace SevenWestMedia.Technical.Core.Services.User
{
    public interface IUserService
    {
        UserModel GetUserById(int userId);

        List<UserModel> GetUsersByAge(int userAge);

        List<UserAgeGroupModel> GetUsersGroupByAge();
    }
}