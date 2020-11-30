using System.Collections.Generic;
using System.Linq;

namespace FrameworkHangman_DL.Services
{
    public class SubjectService
    {
        public List<Subject> SubjectsGetAll()
        {
            using (var ctx = new HangmanDbConext())
            {
                return ctx.Subjects.ToList();
            }
        }
        public Subject SubjectPick(string subId)
        {
            int result = 0;
            if (int.TryParse(subId, out result))
            {
                using (var ctx = new HangmanDbConext())
                {
                    if (ctx.Subjects.Any(s => s.SubjectId == result)) return ctx.Subjects.FirstOrDefault(s => s.SubjectId == result);
                    else return null;
                }
            }
            else return null;
        }
    }
}
