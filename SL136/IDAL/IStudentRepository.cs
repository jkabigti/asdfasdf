﻿namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IStudentRepository
    {
        void InsertStudent(Student student, ref List<string> errors);

        void UpdateStudent(Student student, ref List<string> errors);

        void DeleteStudent(string id, ref List<string> errors);

        Student GetStudentDetail(string id, ref List<string> errors);

        List<Student> GetStudentList(ref List<string> errors);

        void SendStudentRequest(string studentId, int scheduleId, string request, ref List<string> errors);

        List<RequestHistory> GetRequestHistory(string studentId, ref List<string> errors);
    }
}
