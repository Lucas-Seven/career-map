using Dapper;
using dll.Models;
using dll.Models.User;
using Microsoft.Data.SqlClient;
using System.Transactions;
using System.Windows.Input;
using viewmodels.CareerMap;
using viewmodels.User;

namespace dll.DAL
{
    public class UsersDAO
    {
        private readonly string _connectionString;
        public UsersDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MUser InsertUser(MUser user)
        {
            try
            {
                string sql1 = @"-- Insert user in users_tb table
                                INSERT INTO users_tb (
                                  first_name, last_name, email, career_map_id
                                ) 
                                VALUES (
                                  @FirstName, @LastName, @Email, @CareerMapId
                                );
                               
                               -- Select the last ID entered in users_tb table
                                SELECT 
                                  CAST(SCOPE_IDENTITY() AS INT);";

                string sql2 = @"-- Insert user's access type in accessTypes_users_tb table
                                INSERT INTO accessTypes_users_tb (
                                  user_id, access_type_id
                                ) 
                                VALUES (
                                  (SELECT user_id FROM users_tb WHERE email = @Email), 
                                  @AccessTypeId
                                );";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Add user
                        using (SqlCommand command1 = new SqlCommand(sql1, connection))
                        {
                            command1.Transaction = transaction;
                            command1.Parameters.AddWithValue("@FirstName", user.FirstName);
                            command1.Parameters.AddWithValue("@LastName", user.LastName);
                            command1.Parameters.AddWithValue("@Email", user.Email);
                            command1.Parameters.AddWithValue("@CareerMapId", user.CareerMapId != null ? user.CareerMapId : DBNull.Value);

                            user.UserId = (int)command1.ExecuteScalar();
                        }

                        // Assigning default(employee) access type to user
                        using (SqlCommand command2 = new SqlCommand(sql2, connection))
                        {
                            command2.Transaction = transaction;
                            command2.Parameters.AddWithValue("@Email", user.Email);
                            command2.Parameters.AddWithValue("@AccessTypeId", 1);
                            command2.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine($"The user with Id {user.UserId} was successfully registered.");
                        return user;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        if (ex.Number == 2601 || ex.Number == 2627) // Unique constraint violation
                        {
                            throw new Exception($"An error occurred while registering the user in the database. \n\nSqlException: The email '{user.Email}' is already registered in the system.");
                        }
                        else
                        {
                            throw new Exception($"An error occurred while registering the user in the database. \n\nSqlException: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public List<VMUser> SelectAllUsers()
        {
            try
            {
                List<VMUser> users = new List<VMUser>();

                string sql = @"SELECT 
                                  user_id, 
                                  first_name, 
                                  last_name, 
                                  email
                                FROM 
                                  users_tb;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    int userId = Convert.ToInt32(dataReader["user_id"]);
                                    VMUser user = users.FirstOrDefault(u => u.UserId == userId);

                                    if (user == null)
                                    {
                                        user = new VMUser()
                                        {
                                            UserId = userId,
                                            FirstName = dataReader["first_name"].ToString(),
                                            LastName = dataReader["last_name"].ToString(),
                                            Email = dataReader["email"].ToString()
                                        };
                                        users.Add(user);
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"users\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                if (users == null || users.Count == 0)
                {
                    throw new Exception("The \"users\" not found.");
                }

                Console.WriteLine("The \"SelectUserById\" query was successful.");
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public VMUser SelectUserById(int userId)
        {
            try
            {
                VMUser user = new VMUser();

                string sql = @"SELECT 
                                  user_id, 
                                  first_name, 
                                  last_name, 
                                  email 
                                FROM 
                                  users_tb 
                                WHERE 
                                  user_id = @userId 
                                ORDER BY 
                                  email;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    user = new VMUser()
                                    {
                                        UserId = Convert.ToInt32(dataReader["user_id"]),
                                        FirstName = dataReader["first_name"].ToString(),
                                        LastName = dataReader["last_name"].ToString(),
                                        Email = dataReader["email"].ToString()
                                    };
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"users\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                Console.WriteLine("The \"SelectUserById\" query was successful.");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public VMUserCareerMap SelectUserByIdWithCareerMap(int userId)
        {
            try
            {
                VMUserCareerMap user = new VMUserCareerMap();

                string sql = @"SELECT 
                                  u.user_id, 
                                  u.first_name, 
                                  u.last_name, 
                                  u.email, 
                                  c.career_map_id, 
                                  c.career_map_name
                                FROM 
                                  users_tb AS u 
                                  LEFT JOIN careerMaps_tb AS c ON c.career_map_id = u.career_map_id 
                                WHERE 
                                  u.user_id = @userId 
                                ORDER BY 
                                  u.email;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    user = new VMUserCareerMap();
                                    user.User = new VMUser()
                                    {
                                        UserId = Convert.ToInt32(dataReader["user_id"]),
                                        FirstName = dataReader["first_name"].ToString(),
                                        LastName = dataReader["last_name"].ToString(),
                                        Email = dataReader["email"].ToString()
                                    };

                                    user.CareerMap = new VMCareerMap()
                                    {
                                        CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                        CareerMapName = dataReader["career_map_name"].ToString()
                                    };
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"users\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                Console.WriteLine("The \"SelectUserByIdWithCareerMap\" query was successful.");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
        
        public VMNUserAccessTypes SelectUserByIdWithAccessTypes(int userId)
        {
            try
            {
                VMNUserAccessTypes user = new VMNUserAccessTypes();

                string sql = @"SELECT 
                                  u.user_id, 
                                  u.first_name, 
                                  u.last_name, 
                                  u.email, 
                                  a.access_type_id, 
                                  a.access_type_name 
                                FROM 
                                  users_tb AS u 
                                  INNER JOIN accessTypes_users_tb AS au ON au.user_id = u.user_id 
                                  INNER JOIN accessTypes_tb AS a ON a.access_type_id = au.access_type_id 
                                WHERE 
                                  u.user_id = @userId 
                                ORDER BY 
                                  u.email;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    var list = connection.QueryAsync<MNUser, MNAccessType, MNUser>(sql, (user, acessType) =>
                    {
                        //user.UserId = userId;
                        user.AccessTypes.Add(acessType);
                        return user;
                    }, new { userId = userId }, splitOn: "AccessTypeId").Result;


                    
                    
                    //connection.Open();

                    //try
                    //{
                    //    using (SqlCommand command = new SqlCommand(sql, connection))
                    //    {
                    //        command.Parameters.AddWithValue("@userId", userId);

                    //        using (SqlDataReader dataReader = command.ExecuteReader())
                    //        {
                    //            if (dataReader.Read())
                    //            {
                    //                user = new VMUserAccessTypes();
                    //                user.AccessTypes = new List<VMAccessType>();
                    //                user.User = new VMUser()
                    //                {
                    //                    UserId = Convert.ToInt32(dataReader["user_id"]),
                    //                    FirstName = dataReader["first_name"].ToString(),
                    //                    LastName = dataReader["last_name"].ToString(),
                    //                    Email = dataReader["email"].ToString()
                    //                };

                    //                VMAccessType accessType = new VMAccessType()
                    //                {
                    //                    AccessTypeId = Convert.ToInt32(dataReader["access_type_id"]),
                    //                    AccessTypeName = dataReader["access_type_name"].ToString()
                    //                };
                    //                user.AccessTypes.Add(accessType);
                    //            }
                    //        }
                    //    }
                    //}
                    //catch (SqlException ex)
                    //{
                    //    throw new Exception($"An error occurred when fetching \"users\" from the database. \n\nSqlException: {ex.Message}");
                    //}
                }

                Console.WriteLine("The \"SelectUserByIdWithAccessTypes\" query was successful.");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }

        public VMUserEntire SelectUserEntireById(int userId)
        {
            try
            {
                VMUserEntire user = new VMUserEntire();

                string sql = @"SELECT 
                                  u.user_id, 
                                  u.first_name, 
                                  u.last_name, 
                                  u.email, 
                                  c.career_map_id, 
                                  c.career_map_name, 
                                  a.access_type_id, 
                                  a.access_type_name 
                                FROM 
                                  users_tb AS u 
                                  LEFT JOIN careerMaps_tb AS c ON c.career_map_id = u.career_map_id 
                                  INNER JOIN accessTypes_users_tb AS au ON au.user_id = u.user_id 
                                  INNER JOIN accessTypes_tb AS a ON a.access_type_id = au.access_type_id 
                                WHERE 
                                  u.user_id = @userId 
                                ORDER BY 
                                  u.email;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    user = new VMUserEntire();
                                    user.AccessTypes = new List<VMAccessType>();
                                    user.User = new VMUser()
                                    {
                                        UserId = Convert.ToInt32(dataReader["user_id"]),
                                        FirstName = dataReader["first_name"].ToString(),
                                        LastName = dataReader["last_name"].ToString(),
                                        Email = dataReader["email"].ToString()
                                    };

                                    user.CareerMap = new VMCareerMap()
                                    {
                                        CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                        CareerMapName = dataReader["career_map_name"].ToString()
                                    };

                                    VMAccessType accessType = new VMAccessType()
                                    {
                                        AccessTypeId = Convert.ToInt32(dataReader["access_type_id"]),
                                        AccessTypeName = dataReader["access_type_name"].ToString()
                                    };
                                    user.AccessTypes.Add(accessType);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"users\" from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                Console.WriteLine("The \"SelectUserEntireById\" query was successful.");
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}
