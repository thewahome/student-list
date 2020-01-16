using System;
using System.Linq;

namespace StudentList.Services
{
    public class StudentManager
    {
        private StudentStorage _studentStorage;
        private const char _studentEntryDelimiter = ',';
        private Random _rand;
        private string _studentList;

        public string[] Students { 
            get
            {
                return _studentList.Split(_studentEntryDelimiter);
            }
        }

        public StudentManager(StudentStorage studentStorage)
        {
            _studentStorage = studentStorage;
            _rand = new Random();
            _studentList = _studentStorage.LoadStudentsList();

        }

        public StudentManager()
        {
            _studentStorage = new StudentStorage();
            _rand = new Random();
            _studentList = _studentStorage.LoadStudentsList();
        }

        public string PickRandomStudent() 
        {
            var randomIndex = _rand.Next(0, this.Students.Length-1);
            return this.Students[randomIndex];
        }

        public bool StudentExists(string student)
        {
            if (this.Students.Any(k=>k.Trim().ToLower() == student.ToLower()))
            {
                return true;
            }
            return false;
        }

        public void AddStudent(string newStudent)
        {
            _studentList += "," + newStudent;
           _studentStorage.UpdateStudentList(_studentList);
        }
    }
}
