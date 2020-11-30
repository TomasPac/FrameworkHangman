using System.ComponentModel.DataAnnotations;

namespace FrameworkHangman_DL
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string Value { get; set; }
    }
}
