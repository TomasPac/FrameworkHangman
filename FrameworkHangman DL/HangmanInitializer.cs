using System.Collections.Generic;
using System.Data.Entity;

namespace FrameworkHangman_DL
{
    public class HangmanInitializer : CreateDatabaseIfNotExists<HangmanDbConext>
    {
        protected override void Seed(HangmanDbConext context)
        {
            base.Seed(context);
            var sub1 = new Subject { Value = "VARDAI" };
            var sub2 = new Subject { Value = "MIESTAI" };
            var sub3 = new Subject { Value = "VALSTYBES" };
            var sub4 = new Subject { Value = "KITA" };

            var vardai1 = new Word { Value = "antanas", SubjectId = 1 };
            var vardai2 = new Word { Value = "dzebedajus", SubjectId = 1 };
            var vardai3 = new Word { Value = "aleksandra", SubjectId = 1 };

            var miestai1 = new Word { Value = "karakasas", SubjectId = 2 };
            var miestai2 = new Word { Value = "tokijas", SubjectId = 2 };
            var miestai3 = new Word { Value = "singapuras", SubjectId = 2 };

            var valstybes1 = new Word { Value = "indonezija", SubjectId = 3 };
            var valstybes2 = new Word { Value = "australija", SubjectId = 3 };
            var valstybes3 = new Word { Value = "norvegija", SubjectId = 3 };

            var kita1 = new Word { Value = "melancholija", SubjectId = 4 };
            var kita2 = new Word { Value = "paauglyste", SubjectId = 4 };
            var kita3 = new Word { Value = "vakuumas", SubjectId = 4 };

            

            context.Subjects.Add(sub1);
            context.Subjects.Add(sub2);
            context.Subjects.Add(sub3);
            context.Subjects.Add(sub4);

            context.Words.Add(vardai1);
            context.Words.Add(vardai2);
            context.Words.Add(vardai3);

            context.Words.Add(miestai1);
            context.Words.Add(miestai2);
            context.Words.Add(miestai3);

            context.Words.Add(valstybes1);
            context.Words.Add(valstybes2);
            context.Words.Add(valstybes3);

            context.Words.Add(kita1);
            context.Words.Add(kita2);
            context.Words.Add(kita3);

        }
    }
}
