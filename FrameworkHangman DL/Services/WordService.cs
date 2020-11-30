using System;
using System.Linq;

namespace FrameworkHangman_DL.Services
{
    public class WordService
    {
        public string WordGenerator(int subjectId)
        {
            using (var ctx = new HangmanDbConext())
            {
                return ctx.Words.OrderBy(w => Guid.NewGuid()).FirstOrDefault(w => w.SubjectId == subjectId).Value.ToString();
            }
        }
    }
}
