using System;
using System.Linq;
using System.Text;
using SevenWestMedia.Technical.Core.Services.User;

namespace SevenWestMedia.Technical.ConsoleApp.Printer
{
    public class Printer : IPrinter
    {
        private readonly IUserService _userService;

        public Printer(IUserService userService)
        {
            _userService = userService;
        }

        public void Print()
        {
            PrintUserFullNameById();

            PrintUserFirstNamesByAge();

            PrintUsersGroupByAge();

            Console.ReadKey();
        }

        private void PrintUserFullNameById()
        {
            const int userId = 42;

            var user = _userService.GetUserById(userId);

            Console.WriteLine(user != null
                ? $"Name of user id {userId}: {user.FirstName} {user.LastName}\n"
                : $"Sorry, user with Id {userId} not found\n");
        }

        private void PrintUserFirstNamesByAge()
        {
            const int userAge = 23;

            var users = _userService.GetUsersByAge(userAge);

            var usersFirstNames = users.Select(a => a.FirstName);

            var firstNames = usersFirstNames as string[] ?? usersFirstNames.ToArray();

            Console.WriteLine(firstNames.Any()
                ? $"First names of users with age {userAge}: {string.Join(", ", firstNames)}\n"
                : $"Sorry, user with age {userAge} not found\n");
        }

        private void PrintUsersGroupByAge()
        {
            var usersGroup = _userService.GetUsersGroupByAge();

            if (usersGroup.Any())
            {
                var usersBuilder = new StringBuilder();

                usersBuilder.AppendLine("Users gender by age:\n");
                foreach (var userGroup in usersGroup)
                {
                    usersBuilder.AppendLine(
                        $"Age:{userGroup.Age}, Female: {userGroup.FemaleCount}, " +
                        $"Male: {userGroup.MaleCount}, NonBinary: {userGroup.NonBinaryCount}");
                }

                Console.WriteLine(usersBuilder.ToString());
            }
            else
            {
                Console.WriteLine("Sorry no users found.");
            }
        }
    }
}