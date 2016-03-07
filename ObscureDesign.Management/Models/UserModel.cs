using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Management.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }
        [Display(Name = "Email")]
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

        public static UserModel ToViewModel(this Data.User source)
        {
            return new UserModel
            {
                Id = source.UserId,
                DisplayName = source.DisplayName,
                Email = source.Email,
            };
        }
    }
}
