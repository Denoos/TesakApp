using System.ComponentModel;
using System.Security.AccessControl;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TesakApp.Models;

namespace TesakApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Students = GetSomeStudents(4);
        }

        private List<Student> GetSomeStudents(int count)
        {
            List<Student> res = [];
            
            Student student = new();
            for (int i = 0; i < count; i++)
            {
                student = GetOneStudent();
                res.Add(student);
                student = new();
            }

            return res;
        }

        private Student GetOneStudent()
        {
            var res = new Student();

            res.Name = RandomString(15);

            var r = new Random();

            res.HoursAtForka = r.Next(0, 251);
            res.CompletedWorksCount = r.Next(0, 25);
            res.CountOfQuestions = r.Next(0, int.MaxValue);
            res.Situations = GetSomeSituations(r.Next(3, 15));

            return res;
        }

        private List<Situation> GetSomeSituations(int count)
        {
            List<Situation> res = [];

            Situation sit = new();
            for (int i = 0; i < count; i++)
            {
                sit = GetOneSituation();
                res.Add(sit);
                sit = new();
            }

            return res;
        }

        private Situation GetOneSituation()
        {
            var res = new Situation
            {
                Text = RandomString(45)
            };

            var r = new Random();

            int d = r.Next(1,27);
            int m = r.Next(1,13);
            int y = r.Next(0, 10000);

            DateOnly date = new(y, m, d);

            res.Date = date;

            return res;
        }

        private string RandomString(int count)
        {
            string res = "";

            for (int i = 0; i < count; i++)
                res += (char)new Random().Next(0, 256);

            return res;
        }

        private List<Student> students;
        private Student selectedStudent;
        public List<Student> Students { get => students; set { students = value; Signal(); } }
        public Student SelectedStudent { get => selectedStudent; set { selectedStudent = value; Signal(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal(string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


    }
}