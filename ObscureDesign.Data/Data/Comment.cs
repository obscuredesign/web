using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObscureDesign.Data
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }

        public Award Awards { get; set; }

        [Required]
        public string PreprocessorAQM { get; set; }
        [Required]
        public string PostprocessorAQM { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }

    [Flags]
    public enum Award : int
    {
        MedaOfHodor = 0x01,
        CargoCultist = 0x02,
        SealOfApproval = 0x04,
        Trolled = 0x08,
        Cancer = 0x16,
        Dickbutt = 0x32,
        BlastFromThePast = 0x64,
    }
}
