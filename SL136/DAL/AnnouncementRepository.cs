namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class AnnouncementRepository : BaseRepository, IAnnouncementRepository
    {
        private const string AddAnnouncementProcedure = "addAnnouncement";
        private const string DeleteAnnouncementProcedure = "deleteAnnouncement";
        private const string GetAnnouncementProcedure = "getAnnouncements";

        public void AddAnnouncement(Announcement announcement, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(AddAnnouncementProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, -1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime));

                adapter.SelectCommand.Parameters["@text"].Value = announcement.Text;
                adapter.SelectCommand.Parameters["@date"].Value = announcement.Date;

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

        public Announcement GetAnnouncementById(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var announcement = new Announcement();
            try
            {
                var adapter = new SqlDataAdapter("getAnnouncementById", conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                announcement.ID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["id"].ToString());
                announcement.Text = dataSet.Tables[0].Rows[0]["text"].ToString();
                announcement.Date = dataSet.Tables[0].Rows[0]["date"].ToString();
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return announcement;
        }

        public void DeleteAnnouncement(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteAnnouncementProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@id"].Value = id;

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

        public List<Announcement> GetAnnouncements(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var announcementList = new List<Announcement>();

            try
            {
                var adapter = new SqlDataAdapter(GetAnnouncementProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var announcement = new Announcement
                                      {
                                          ID = (int)dataSet.Tables[0].Rows[i]["id"],
                                          Text = dataSet.Tables[0].Rows[i]["text"].ToString(),
                                          Date = dataSet.Tables[0].Rows[i]["date"].ToString(),
                                      };
                    announcementList.Add(announcement);
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

            return announcementList;
        }

        public void EditAnnouncement(Announcement announcement, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter("editAnnouncement", conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, -1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime));

                adapter.SelectCommand.Parameters["@id"].Value = announcement.ID;
                adapter.SelectCommand.Parameters["@text"].Value = announcement.Text;
                adapter.SelectCommand.Parameters["@date"].Value = announcement.Date;

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
    }
}