using System;
using Xunit;
using StudentList.Services;
using Moq;

namespace StudentList.Tests
{
    public class StudentManager_Should
    {
        Mock<StudentStorage> mockStorage;

        public StudentManager_Should()
        {
            mockStorage = new Mock<StudentStorage>();
            mockStorage.Setup(sm => sm.LoadStudentsList()).Returns("student1,student2,student3");
        }
    
        
        [Fact]
        public void ReturnAListOfStudents()
        {
            var sut = new StudentManager(mockStorage.Object);
            var actual = sut.Students;
            Assert.IsType(typeof(string[]), actual);
            Assert.True(actual.Length == 3);
        }

        [Fact]
        public void ReturnCorrectStudentCount()
        {
            var sut = new StudentManager(mockStorage.Object);
            var actual = sut.Students.Length;
            Assert.True(actual == 3);
        }

        [Fact]
        public void ReturnRandomStudent()
        {
            var sut = new StudentManager(mockStorage.Object);
            var students = sut.Students;

            var expectedStudent = sut.PickRandomStudent();
            Assert.Contains(expectedStudent, students);

        }

        [Fact]
        public void ReturnFalse_when_SeacrchingForExistingStudent ()
        {
            var sut = new StudentManager(mockStorage.Object);
            var fakeStudent = "STUDENT1";
            var students = sut.Students;

            var actual = sut.StudentExists(fakeStudent);
            Assert.True(actual);

        }

        [Fact]
        public void Call_UpdateStudentList_When_StudentAdded()
        {
            var sut = new StudentManager(mockStorage.Object);
            var originalList = mockStorage.Object.LoadStudentsList();
            var newStudent = "newStudent";
            var updatedList = originalList + "," + newStudent;

            sut.AddStudent(newStudent);

            mockStorage.Verify(x=>x.UpdateStudentList(updatedList));
        }
    }
}
