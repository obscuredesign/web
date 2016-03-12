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

    public static class TagServices
    {
        public static void MergeAll(this DbSet<Tag> source, IEnumerable<string> tags)
        {
            var tagSet = new HashSet<string>(tags);
            var existingTags = source
                .Where(s => tagSet.Contains(s.Name))
                .ToList() // consume to get result out of DB
                .Select(s => { tagSet.Remove(s.Name); return s; })
                .ToList(); // consume only for side effect
            source.AddRange(tagSet.Select(t => new Tag { Name = t }));
        }

        public static IQueryable<Tag> Search(this DbSet<Tag> source, IEnumerable<string> tags)
        {
            return source.Where(s => tags.Contains(s.Name));
        }
    }
}
