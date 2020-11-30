using System.ComponentModel.DataAnnotations;

namespace FrameworkHangman_DL
{
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        public string Value { get; set; }
        public int SubjectId { get; set; }
    }
}
