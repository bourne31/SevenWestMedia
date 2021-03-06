﻿using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using SevenWestMedia.Technical.Core.Services.User;

namespace SevenWestMedia.Technical.ConsoleApp.Writer
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly ILogger<ConsoleWriter> _logger;
        private readonly IUserService _userService;

        public ConsoleWriter(IUserService userService, ILogger<ConsoleWriter> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public void Write(int userId, int userAge)
        {
            var logInfo = new
            {
                UserId = userId,
                UserAge = userAge
            };

            _logger.LogInformation("Begin writing filter results to console.",
                logInfo);

            WriteUserFullNameById(userId);

            WriteUserFirstNamesByAge(userAge);

            WriteUsersGroupByAge();

            _logger.LogInformation("Finished writing filter results to console.",
                logInfo);

            Console.WriteLine("Press any key to exit...");
        }

        private void WriteUserFullNameById(int userId)
        {
            var user = _userService.GetUserById(userId);

            var message = user != null
                ? $"Name of user id {userId}: {user.FirstName} {user.LastName}\n"
                : $"Sorry, user with Id {userId} is not found\n";

            Console.WriteLine(message);
        }

        private void WriteUserFirstNamesByAge(int userAge)
        {
            var users = _userService.GetUsersByAge(userAge);

            if (users == null)
            {
                Console.WriteLine($"Sorry, user with age {userAge} is not found\n");
                return;
            }

            var usersFirstNames = users.Select(a => a.FirstName);

            var firstNames = usersFirstNames.ToArray();

            Console.WriteLine($"First names of users with age {userAge}: " +
                              $"{string.Join(", ", firstNames)}\n");
        }

        private void WriteUsersGroupByAge()
        {
            var usersGroup = _userService.GetUsersGroupByAge();

            if (usersGroup != null)
            {
                var usersWriteBuilder = new StringBuilder();
                usersWriteBuilder.AppendLine("Users gender by age:\n");

                foreach (var userGroup in usersGroup)
                {
                    usersWriteBuilder.AppendLine(
                        $"Age:{userGroup.Age}, Female: {userGroup.FemaleCount}, " +
                        $"Male: {userGroup.MaleCount}, NonBinary: {userGroup.NonBinaryCount}");
                }

                Console.WriteLine(usersWriteBuilder);
            }
            else
            {
                Console.WriteLine("Sorry no user is found to be grouped by age.\n");
            }
        }
    }
}