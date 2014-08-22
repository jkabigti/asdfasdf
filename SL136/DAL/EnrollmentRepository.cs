namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;
    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        private const string GetEnrolledStudentProcedure = "spGetEnrolledStudents";
        private const string InsertStudentScheduleProcedure = "spInsertStudentSchedule";
        private const string DeleteStudentScheduleProcedure = "spDeleteStudentSchedule";
	    private const string GetCourseProcedure = "getCourse";
	    private const string GetEnrolledSchedulesProcedure = "getEnrolledSchedules";

        public List<int> GetEnrolledStudents(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentList = new List<int>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrolledStudentProcedure, conn);


                if (scheduleId > 0)
                {
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
                    int studentId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["student_id"].ToString());
                    studentList.Add(studentId);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }


            return studentList;
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertStudentScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }
	
	    public int GetCourse(int sch_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            int courseId = -1;
            try
            {
                var adapter = new SqlDataAdapter(GetCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = sch_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                courseId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["course_id"].ToString());

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return courseId;
        }

	    public List<Enrollment> GetEnrolledSchedules(string student_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrolledSchedulesProcedure, conn)

                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = student_id;

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
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return enrollmentList;
        }
    }
}
