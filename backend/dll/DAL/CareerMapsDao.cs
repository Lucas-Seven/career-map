using dll.Models;
using dll.ViewModels;
using Microsoft.Data.SqlClient;

namespace dll.DAL
{
    public class CareerMapsDAO
    {
        private readonly string _connectionString;
        public CareerMapsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CareerMapCompanyPositionsVM SelectCareerMapByIdWithCompanyPositions(int careerMapId)
        {
            CareerMapCompanyPositionsVM careerMap = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SELECT m.career_map_id, m.career_map_name, " +
                                "p.company_position_id, p.company_position_name, " +
                                "mp.hierarchy_number " +
                            "FROM careerMaps_tb AS m " +
                            "INNER JOIN careerMaps_companyPositions_tb AS mp ON mp.career_map_id = m.career_map_id " +
                            "INNER JOIN companyPositions_tb AS p ON p.company_position_id = mp.company_position_id " +
                            "WHERE m.career_map_id = @careerMapId " +
                            "ORDER BY mp.hierarchy_number;", connection))
                        {
                            command.Parameters.AddWithValue("@careerMapId", careerMapId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {
                                    careerMap = new CareerMapCompanyPositionsVM();
                                    careerMap.CompanyPositions = new List<CompanyPositionVM>();
                                    while (dataReader.Read())
                                    {
                                        careerMap.CareerMap = new CareerMapVM()
                                        {
                                            CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                            CareerMapName = dataReader["career_map_name"].ToString()
                                        };

                                        if (!Convert.IsDBNull(dataReader["company_position_id"]))
                                        {
                                            CompanyPositionVM companyPosition = new CompanyPositionVM
                                            {
                                                CompanyPositionId = Convert.ToInt32(dataReader["company_position_id"]),
                                                CompanyPositionName = dataReader["company_position_name"].ToString(),
                                                HierarchyNumber = Convert.ToInt32(dataReader["hierarchy_number"])
                                            };
                                            careerMap.CompanyPositions.Add(companyPosition);
                                        }
                                    }
                                }
                            }
                        }

                        if (careerMap == null)
                        {
                            throw new Exception($"Career map with Id {careerMapId} not found.");
                        }
                        Console.WriteLine("The SelectAllCompanyPositionsByCareerMapId query was successful.");
                        return careerMap;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching company positions from the database. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when fetching company positions from the database. \n\nException: {ex.Message}");
            }
        }
    }
}
