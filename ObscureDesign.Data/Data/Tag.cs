using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ObscureDesign.Data
{
    public class Tag
    {
        public int TagId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }

        //TODO: tag ico
    }

    internal static class TagExtensions
    {
        public static ModelBuilder BuildTag(this ModelBuilder builder)
        {
            builder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            return builder;
        }
    }

    /// <summary>
    /// Services for manipulating tags
    /// TODO: what about case handling?
    /// </summary>
    public static class TagServices
    {
        /// <summary>
        /// Creates all tags in supplied collection that don't already exist and returns the newly created tags.
        /// </summary>
        public static IEnumerable<Tag> CreateAllIfNotExists(this DbSet<Tag> source, IEnumerable<string> tags)
        {
            var tagSet = new HashSet<string>(tags);
            
            var existingTags = source
                .Where(t => tagSet.Contains(t.Name))
                .Select(t => t.Name)
                .ToList(); // consume to get result out of DB

            tagSet.RemoveWhere(tag => existingTags.Contains(tag));

            var newTags = tagSet.Select(t => new Tag { Name = t });

            source.AddRange(newTags);
            return newTags;
        }

        /// <summary>
        /// Returns all tag object with specified tag names
        /// </summary>
        public static IQueryable<Tag> SearchAll(this DbSet<Tag> source, IEnumerable<string> tags)
        {
            return source.Where(s => tags.Contains(s.Name));
        }
    }
}
