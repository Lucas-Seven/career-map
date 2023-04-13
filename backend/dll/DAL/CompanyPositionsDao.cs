using dll.Models;
using dll.Models.CareerMap;
using Microsoft.Data.SqlClient;
using viewmodels;
using viewmodels.CareerMap;

namespace dll.DAL
{
    public class CompanyPositionsDAO
    {
        private readonly string _connectionString;
        public CompanyPositionsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VMCareerMapEntire SelectCompanyPositionByIdWithRequirements(int careerMapId, int companyPositionId)
        {
            try
            {
                VMCareerMapEntire careerMap = null;

                string sql = @"SELECT 
                                  m.career_map_id, 
                                  m.career_map_name, 
                                  p.company_position_id, 
                                  p.company_position_name, 
                                  pr.group_name, 
                                  r.requirement_id, 
                                  r.requirement_name 
                                FROM 
                                  careerMaps_tb AS m 
                                  INNER JOIN careerMaps_companyPositions_tb AS mp ON mp.career_map_id = m.career_map_id 
                                  INNER JOIN companyPositions_tb AS p ON p.company_position_id = mp.company_position_id 
                                  INNER JOIN companypositions_positionrequirements_tb AS pr ON pr.company_position_id = p.company_position_id 
                                  INNER JOIN positionrequirements_tb AS r ON r.requirement_id = pr.requirement_id 
                                WHERE 
                                  pr.career_map_id = @careerMapId 
                                  AND pr.company_position_id = @companyPositionId 
                                ORDER BY 
                                  pr.group_name;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@careerMapId", careerMapId);
                            command.Parameters.AddWithValue("@companyPositionId", companyPositionId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {
                                    careerMap = new VMCareerMapEntire();
                                    careerMap.Requirements = new List<VMRequirementEntire>();
                                    while (dataReader.Read())
                                    {
                                        careerMap.CareerMap = new VMCareerMap
                                        {
                                            CareerMapId = Convert.ToInt32(dataReader["career_map_id"]),
                                            CareerMapName = dataReader["career_map_name"].ToString()
                                        };

                                        careerMap.CompanyPosition = new VMCompanyPosition
                                        {
                                            CompanyPositionId = Convert.ToInt32(dataReader["company_position_id"]),
                                            CompanyPositionName = dataReader["company_position_name"].ToString()
                                        };

                                        VMRequirementEntire requirement = new VMRequirementEntire()
                                        {
                                            GroupName = dataReader["group_name"].ToString(),
                                            Requirement = new VMRequirement()
                                            {
                                                RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
                                                RequirementName = dataReader["requirement_name"].ToString()
                                            }
                                        };
                                        careerMap.Requirements.Add(requirement);
                                    }
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching \"company positions\" on \"career map\" with id {careerMapId} from the database. \n\nSqlException: {ex.Message}");
                    }
                }

                if (careerMap == null)
                {
                    throw new Exception($"The \"company positions\" on \"career map\" with id {careerMapId} not found.");
                }

                Console.WriteLine("The \"SelectCareerMapByIdWithCompanyPositions\" query was successful.");
                return careerMap;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred. \n\nException: {ex.Message}");
            }
        }
    }
}
