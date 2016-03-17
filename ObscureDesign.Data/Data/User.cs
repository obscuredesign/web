using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ObscureDesign.Data
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public Permission Permissions { get; set; }
        [Required]
        public string CertificateThumbrint { get; set; }
    }

    [Flags]
    public enum Permission : int
    {
        //Meta
        None = 0x0,
        All = 0xFFFFFF,

        //Permissions
        AdminAccess = 0x2,

        ArticleCreate = 0x10,
        ArticleEdit = 0x20,
        ArticlePublish = 0x40,

        CommentEdit = 0x200,
        CommentAward = 0x400,
    }

    /// <summary>
    /// Service layer for User
    /// </summary>
    public static class UserServices
    {
        /// <summary>
        /// 
        /// </summary>
        public static User Find(this DbSet<User> source, int id)
        {
            return source.FirstOrDefault(u => u.UserId == id);
        }

        /// <summary>
        /// 
        /// </summary>
        public static User Update(this User source, string displayName, string email)
        {
            source.DisplayName = displayName;
            source.Email = email;
            return source;
        }
    }
}
