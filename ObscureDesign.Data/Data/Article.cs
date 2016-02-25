﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Data
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Abstract { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Conclusion { get; set; }

        [Required]
        public string PreprocessorAQM { get; set; }
        [Required]
        public string PostprocessorAQM { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Published { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }

        //TODO: QR code
    }
}