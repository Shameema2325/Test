using Microsoft.Data.SqlClient;
using System.Data;

namespace Test.Models
{
    public class UserDB
    {
        SqlConnection con = new SqlConnection(@"server=SHAMEEMA\SQLEXPRESS;database=Test;integrated security=true;TrustServerCertificate=True");

        public string Insert(User user)
        {
            try
            {
                    if (user.Time < new DateTime(1753, 1, 1))
                    {
                        user.Time = DateTime.Now;
                    }

                    SqlCommand cmd = new SqlCommand("sp_insert", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };                    

                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Time", user.Time);
                    cmd.Parameters.AddWithValue("@IsAvailable", user.IsAvailable);
                    cmd.Parameters.AddWithValue("@Qualification", user.Qualification);
                    cmd.Parameters.AddWithValue("@Emirates", user.Emirates);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return "Inserted Successfully";
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public List<User> DisplayAll(User user)
        {
            var users = new List<User>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_display_all", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    var u = new User
                    {
                        Id = Convert.ToInt32(result["Id"]),
                        Name = result["Name"].ToString(),
                        Age = Convert.ToInt32(result["Age"]),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        DateOfBirth = Convert.ToDateTime(result["DateofBirth"]),
                        Time = Convert.ToDateTime(result["Time"].ToString()),
                        IsAvailable = Convert.ToBoolean(result["IsAvailabele"]),
                        Qualification = result["Qualification"].ToString(),
                        Emirates = result["Emirates"].ToString()

                    };
                    users.Add(u);

                }

                con.Close();

                return users;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_user", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Edit(User user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_edit_user", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Time", user.Time);
                cmd.Parameters.AddWithValue("@IsAvailable", user.IsAvailable);
                cmd.Parameters.AddWithValue("@Qualification", user.Qualification);
                cmd.Parameters.AddWithValue("@Emirates", user.Emirates);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public User Display(int id)
        {
            var user = new User();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_get_user_by_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(result["Id"]),
                        Name = result["Name"].ToString(),
                        Age = Convert.ToInt32(result["Age"]),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        DateOfBirth = Convert.ToDateTime(result["DateofBirth"]),
                        Time = Convert.ToDateTime(result["Time"].ToString()),
                        IsAvailable = Convert.ToBoolean(result["IsAvailabele"]),
                        Qualification = result["Qualification"].ToString(),
                        Emirates = result["Emirates"].ToString()
                    };
                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw new Exception("Error retrieving user: " + ex.Message);
            }

            return user;
        }


    }
}
