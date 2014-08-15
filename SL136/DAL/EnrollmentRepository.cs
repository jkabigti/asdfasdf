namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;
    class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        private const string GetEnrolledStudentProcedure = "spGetEnrolledStudents";

                public List<Enrollment> GetEnrollments(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrolledStudentProcedure, conn);


                if (scheduleId > 0) {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var enrollment = new Enrollment
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString(),

                    };
                    enrollmentList.Add(enrollment);
                }}
                catch (Exception e)
                {
                    errors.Add("Error: " + e);
                }
                finally{
                conn.Dispose();
            }
            

            return enrollmentList;
        }

    }
}
