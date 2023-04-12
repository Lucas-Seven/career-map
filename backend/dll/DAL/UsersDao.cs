using dll.Models;
using Microsoft.Data.SqlClient;
using viewmodels.ViewModels;

namespace dll.DAL
{
    public class UsersDAO
    {
        private readonly string _connectionString;
        public UsersDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserAccessTypesVM> SelectAllUsersWithAccessTypes()
        {
            List<UserAccessTypesVM> users = new List<UserAccessTypesVM>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SELECT u.user_id, u.first_name, u.last_name, u.email, " +
                                "c.career_map_id, c.career_map_name, " +
                                "a.access_type_id, a.access_type_name " +
                            "FROM users_tb AS u " +
                            "LEFT JOIN careerMaps_tb AS c ON c.career_map_id = u.career_map_id " +
                            "INNER JOIN accessTypes_users_tb AS au ON au.user_id = u.user_id " +
                            "INNER JOIN accessTypes_tb AS a ON a.access_type_id = au.access_type_id " +
                            "ORDER BY u.email;", connection))
                        {
                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    int userId = Convert.ToInt32(dataReader["user_id"]);

                                    UserAccessTypesVM user = users.FirstOrDefault(u => u.UserId == userId);

                                    if (user == null)
                                    {
                                        user = new UserAccessTypesVM()
                                        {
                                            UserId = userId,
                                            FirstName = dataReader["first_name"].ToString(),
                                            LastName = dataReader["last_name"].ToString(),
                                            Email = dataReader["email"].ToString(),
                                            AccessTypes = new List<AccessTypeVM>()
                                        };

                                        if (!Convert.IsDBNull(dataReader["career_map_id"]))
                                        {
                                            user.CareerMap = new CareerMapVM()
                                            {
                                                CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                                CareerMapName = dataReader["career_map_name"].ToString()
                                            };
                                        }
                                        users.Add(user);
                                    }

                                    AccessTypeVM accessType = new AccessTypeVM
                                    {
                                        AccessTypeId = Convert.ToInt32(dataReader["access_type_id"]),
                                        AccessTypeName = dataReader["access_type_name"].ToString()
                                    };
                                    user.AccessTypes.Add(accessType);
                                }
                            }
                        }

                        if (users == null)
                        {
                            throw new Exception($"Users not found.");
                        }
                        Console.WriteLine("The SelectAllUsersWithAccessTypes query was successful.");
                        return users;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching users from the database. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when fetching users from the database. \n\nException: {ex.Message}");
            }
        }

        public UserAccessTypesVM SelectUserByIdWithAccessTypes(int userId)
        {
            UserAccessTypesVM user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SELECT u.user_id, u.first_name, u.last_name, u.email, " +
                                "c.career_map_id, c.career_map_name, " +
                                "a.access_type_id, a.access_type_name " +
                            "FROM users_tb AS u " +
                            "LEFT JOIN careerMaps_tb AS c ON c.career_map_id = u.career_map_id " +
                            "INNER JOIN accessTypes_users_tb AS au ON au.user_id = u.user_id " +
                            "INNER JOIN accessTypes_tb AS a ON a.access_type_id = au.access_type_id " +
                            "WHERE u.user_id = @userId " +
                            "ORDER BY u.email;", connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {
                                    user = new UserAccessTypesVM();
                                    user.AccessTypes = new List<AccessTypeVM>();
                                    while (dataReader.Read())
                                    {
                                        user.UserId = Convert.ToInt32(dataReader["user_id"]);
                                        user.FirstName = dataReader["first_name"].ToString();
                                        user.LastName = dataReader["last_name"].ToString();
                                        user.Email = dataReader["email"].ToString();
                                        user.CareerMap = null;
                                        if (!Convert.IsDBNull(dataReader["career_map_id"]))
                                        {
                                            user.CareerMap = new CareerMapVM()
                                            {
                                                CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                                CareerMapName = dataReader["career_map_name"].ToString()
                                            };
                                        }
                                        AccessTypeVM accessType = new AccessTypeVM
                                        {
                                            AccessTypeId = Convert.ToInt32(dataReader["access_type_id"]),
                                            AccessTypeName = dataReader["access_type_name"].ToString()
                                        };
                                        user.AccessTypes.Add(accessType);
                                    }
                                }
                            }
                        }

                        if (user == null)
                        {
                            throw new Exception($"User with Id {userId} not found.");
                        }
                        Console.WriteLine("The SelectUserByIdWithAccessTypes query was successful.");
                        return user;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching user from the database. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when fetching user from the database. \n\nException: {ex.Message}");
            }
        }

        public UserModel InsertUser(UserModel user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Insert a user
                        using (SqlCommand command1 = new SqlCommand(
                            "INSERT INTO users_tb (career_map_id, first_name, last_name, email) " +
                            "VALUES (@CareerMapId, @FirstName, @LastName, @Email);" +
                            "SELECT CAST(SCOPE_IDENTITY() AS INT);", connection))
                        {
                            command1.Transaction = transaction;
                            command1.Parameters.AddWithValue("@FirstName", user.FirstName);
                            command1.Parameters.AddWithValue("@LastName", user.LastName);
                            command1.Parameters.AddWithValue("@Email", user.Email);
                            if (user.CareerMap != null)
                            {
                                command1.Parameters.AddWithValue("@CareerMapId", user.CareerMap.CareerMapId);
                            }
                            else
                            {
                                command1.Parameters.AddWithValue("@CareerMapId", DBNull.Value);
                            }
                            user.UserId = (int)command1.ExecuteScalar();
                        }

                        // Assigning "employee"(default) access type to user
                        using (SqlCommand command2 = new SqlCommand(
                            "INSERT INTO accessTypes_users_tb (user_id, access_type_id) " +
                            "VALUES " +
                                "(" +
                                    "(SELECT user_id FROM users_tb WHERE email = @Email), " +
                                    "@AccessTypeId" +
                                ");", connection))
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
                throw new Exception($"An error occurred while registering the user in the database. \n\nException: {ex.Message}");
            }
        }
    }
}
