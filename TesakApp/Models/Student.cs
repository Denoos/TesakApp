using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesakApp.Models
{
    public class Student
    {
        public string Name { get; set; }

        public int HoursAtForka { get; set; }

        public int CompletedWorksCount { get; set; }

        public int CountOfQuestions { get; set; }

        public List<Situation> Situations { get; set; } = [];
    }
}
