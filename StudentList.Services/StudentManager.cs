using System;

namespace StudentList.Services
{
    public class StudentManager
    {
        private StudentStorage _studentStorage;
        public StudentManager()
        {
            _studentStorage = new StudentStorage();
        }

        public StudentManager(StudentStorage studentStorage)
        {
            _studentStorage = studentStorage;
        }
        public string[] GetAllStudents()
        {
            var studentList = _studentStorage.LoadStudentsList();
            return studentList.Split(',');
            // throw new NotImplementedException(" Run tests ");
        }
    }
}
