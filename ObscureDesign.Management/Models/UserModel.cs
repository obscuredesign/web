using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Management.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }

    public static class UserModelExtensions
    {
        public static IEnumerable<UserModel> ToViewModel(this IQueryable<Data.User> source)
        {
            return source.Select(user => new UserModel
            {
                Id = user.UserId,
                DisplayName = user.DisplayName,
                Email = user.Email,
            });
        }
    }
}
