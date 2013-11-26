using ComCon.Shared.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace ComCon.Server.Classes
{
    public class SQLStatements
    {
        private const string CONNECTSTRING = "Server=localhost;Port=5432;User Id=ComConAdmin;Password=macitsolutions14;Database=ComConDatabase";
        private static NpgsqlConnection mDatabaseConnection = new NpgsqlConnection(CONNECTSTRING);
        private static DataSet ds = new DataSet();
        private static DataTable dt = new DataTable();


        private static bool ConnectToDatabase()
        {
            try
            {
                mDatabaseConnection.Open();
                while (mDatabaseConnection.FullState != ConnectionState.Open)
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                LoggingService.LogToFile(ex);
                return false;
            }
        }

        private static void DisconnectFromDatabase()
        {
            mDatabaseConnection.Close();
        }

        public static User[] GetChatUsers()
        {
            if (ConnectToDatabase())
            {
                string query = "SELECT \"Mail\", \"Username\", \"LastLogin\", \"IsAdmin\", \"ID\" FROM User";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, mDatabaseConnection);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                User[] users = new User[dt.Rows.Count];
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    User u = new User();
                    u.UserID = row.Field<int>(dt.Columns[4]);
                    u.Email = row.Field<string>(dt.Columns[0]);
                    u.Username = row.Field<string>(dt.Columns[1]);
                    u.IsAdmin = row.Field<bool>(dt.Columns[3]);
                    u.LastOnline = row.Field<DateTime>(dt.Columns[2]);
                    users[count] = u;
                    count++;
                }
                DisconnectFromDatabase();
                return users;


            }
            return null;
        }

        public static User GetChatUser(string pEmail, string pPassword)
        {
            if (ConnectToDatabase())
            {
                try
                {
                    string query = "SELECT * FROM \"User\" WHERE \"Mail\"=\'" + pEmail + "\' AND \"Password\"=\'" + pPassword + "\'";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, mDatabaseConnection);
                    ds.Reset();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    User u = new User();
                    DataRow row = dt.Rows[0];
                    u.UserID = row.Field<int>(dt.Columns[0]);
                    u.Email = row.Field<string>(dt.Columns[1]);
                    u.Username = row.Field<string>(dt.Columns[3]);
                    u.IsAdmin = row.Field<bool>(dt.Columns[5]);
                    //u.LastOnline = row.Field<DateTime>(dt.Columns[4]);                    
                    return u;
                }
                catch (Exception ex)
                {
                    LoggingService.LogToFile(ex);
                    return null;
                }
                finally
                {
                    DisconnectFromDatabase();
                }               
            }
            return null;
        }

        public static bool InsertNewUser(string pEmail, string pPassword, string pUsername, string pRegKey)
        {
            if (ConnectToDatabase())
            {
                List<string> fields = new List<string>();
                List<string> paras = new List<string>();
                fields.Add("Mail");
                fields.Add("Password");
                fields.Add("Username");
                fields.Add("RegKey");
                fields.Add("IsRegistrationComplete");

                paras.Add(pEmail);
                paras.Add(pPassword);
                paras.Add(pUsername);
                paras.Add(pRegKey);
                paras.Add("false");



                //string insertString = GetSQLCommand(SQLCommand.INSERT, "User", fields, paras); 

                string insertString = "INSERT INTO \"User\"(\"Mail\", \"Password\", \"Username\", \"RegKey\")  VALUES ('" + pEmail + "', '" + pPassword + "', '" + pUsername + "', '" + pRegKey + "');";
                try
                {
                    NpgsqlCommand comm = new NpgsqlCommand(insertString, mDatabaseConnection);
                    comm.ExecuteNonQuery();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    LoggingService.Log("INSERT NEW USER FAILED", LogStatus.ERROR);
                    LoggingService.LogToFile(ex);
                    return false;
                }
                finally
                {
                    DisconnectFromDatabase();
                }
                
            }
            return false;
        }

        public static bool UpdateUser(int pUserID, string[] pFields, string[] pValues)
        {
            if (ConnectToDatabase())
            {
                StringBuilder query = new StringBuilder();
                query.Append("UPDATE \"User\" SET");
                foreach (string s in pFields)
                {
                    query.Append("\"" + s + "\",");
                }
                query.Remove(query.Length - 1, 1);
                query.Append("WHERE \"ID\"=\'" + pUserID + "\'");
                try
                {
                    NpgsqlCommand comm = new NpgsqlCommand(query.ToString(), mDatabaseConnection);
                    comm.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    LoggingService.LogToFile(ex);

                    return false;
                }
                finally
                {
                    DisconnectFromDatabase();
                }
                
            }
            return false;
            
        }


        private static string GetSQLCommand(SQLCommand pCommand, string pTable, List<string> mFields, List<string> mParameters)
        {
            StringBuilder sb = new StringBuilder();

            switch (pCommand)
            {
                case SQLCommand.INSERT:
                    sb.Append("INSERT INTO ");
                    sb.Append(pTable);
                    sb.Append("(");
                    foreach (string s in mFields)
                    {
                        sb.Append("\"" + s + "\"");
                        if (s != mFields[mFields.Count - 1])
                            sb.Append(",");

                    }
                    sb.Append(") VALUES (");

                    foreach (string s in mParameters)
                    {
                        sb.Append("'" + s + "'");
                        if (s != mParameters[mParameters.Count - 1])
                            sb.Append(",");
                    }
                    sb.Append(");");
                    return sb.ToString();
                case SQLCommand.DELETE:
                    throw new NotImplementedException();
                case SQLCommand.SELECT:
                    throw new NotImplementedException();
                case SQLCommand.UPDATE:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
                    
            }
        }



        private enum SQLCommand
        {
            INSERT,
            UPDATE,
            SELECT,
            DELETE
        }
    }

    
}
