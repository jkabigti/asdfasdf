namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private const string GetScheduleListProcedure = "spGetScheduleList";

        public List<CourseInfo> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<CourseInfo>();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleListProcedure, conn);
                
                if (year.Length > 0)
                {
                    if (year == "All Years")
                    {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                        adapter.SelectCommand.Parameters["@year"].Value = DBNull.Value;
                    }
                    else {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                        adapter.SelectCommand.Parameters["@year"].Value = year;
                    }                    
                }
                               
                if (quarter.Length > 0)
                {
                    if (quarter == "All Quarters")
                    {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
                        adapter.SelectCommand.Parameters["@quarter"].Value = DBNull.Value;
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
                        adapter.SelectCommand.Parameters["@quarter"].Value = quarter;
                    }
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
                    var schedule = new CourseInfo
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(),
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_id"].ToString()),
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        CourseDescription = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                        
                    };
                    scheduleList.Add(schedule);
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

            return scheduleList;
        }

        public List<CourseInfo> GetAllSchedules(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<CourseInfo>();

            try
            {
                var adapter = new SqlDataAdapter("getAllSchedules", conn);

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var info = new CourseInfo
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(),
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(),
                        CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_id"].ToString()),
                        CourseTitle = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                        CourseDescription = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                    };
                    scheduleList.Add(info);
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

            return scheduleList;
        }

        public void AddSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter("addCourseSchedule", conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = sch.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = sch.Course.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = Convert.ToInt32(sch.Year);
                adapter.SelectCommand.Parameters["@quarter"].Value = sch.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = sch.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = sch_day_id;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = sch_time_id;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = instr_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error in AddSchedule in ScheduleRepository.cs!:\t" + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteSchedule(Schedule sch, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter("deleteCourseSchedule", conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = sch.ScheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error in DeleteSchedule in ScheduleRepository.cs!:\t" + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void EditSchedule(Schedule sch, int sch_day_id, int sch_time_id, int instr_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter("editCourseSchedule", conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@schedule_id"].Value = sch.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = sch.Course.CourseId;
                adapter.SelectCommand.Parameters["@year"].Value = Convert.ToInt32(sch.Year);
                adapter.SelectCommand.Parameters["@quarter"].Value = sch.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = sch.Session;
                adapter.SelectCommand.Parameters["@schedule_day_id"].Value = sch_day_id;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = sch_time_id;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = instr_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error in EditSchedule in ScheduleRepository.cs!:\t" + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public List<string> GetYears(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var yearList = new List<string>();

            try
            {
                var adapter = new SqlDataAdapter("getYears", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    string year = dataSet.Tables[0].Rows[i]["year"].ToString(); ;
                    yearList.Add(year);
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

            return yearList;
        }

        public List<string> GetQuarters(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var quarterList = new List<string>();

            try
            {
                var adapter = new SqlDataAdapter("getQuarters", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    string quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(); ;
                    quarterList.Add(quarter);
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

            return quarterList;
        }
    }
}
