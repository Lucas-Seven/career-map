using dll.Models;
using dll.ViewModels;
using Microsoft.Data.SqlClient;

namespace dll.DAL
{
    public class CompanyPositionsDAO
    {
        private readonly string _connectionString;
        public CompanyPositionsDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CompanyPositionRequirementsVM SelectCompanyPositionByIdWithRequirements(int careerMapId, int companyPositionId)
        {
            CompanyPositionRequirementsVM companyPosition = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "SELECT pr.career_map_id, " +
                            "p.company_position_id, p.company_position_name, " +
                            "pr.group_name, " +
                            "r.requirement_id, r.requirement_name " +
                            "FROM companyPositions_tb AS p " +
                            "INNER JOIN companyPositions_positionRequirements_tb AS pr ON pr.company_position_id = p.company_position_id " +
                            "INNER JOIN positionRequirements_tb AS r ON r.requirement_id = pr.requirement_id " +
                            "WHERE pr.career_map_id = @careerMapId AND pr.company_position_id = @companyPositionId " +
                            "ORDER BY pr.group_name;", connection))
                        {
                            command.Parameters.AddWithValue("@careerMapId", careerMapId);
                            command.Parameters.AddWithValue("@companyPositionId", companyPositionId);

                            using (SqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.HasRows)
                                {
                                    companyPosition = new CompanyPositionRequirementsVM();
                                    companyPosition.Requirements = new List<PositionRequirementVM>();
                                    while (dataReader.Read())
                                    {
                                        companyPosition.CareerMapId = Convert.ToInt32(dataReader["career_map_id"]);
                                        companyPosition.CompanyPositionId = Convert.ToInt32(dataReader["company_position_id"]);
                                        companyPosition.CompanyPositionName = dataReader["company_position_name"].ToString();
                                        if (!Convert.IsDBNull(dataReader["requirement_id"]))
                                        {
                                            PositionRequirementVM requirement = new PositionRequirementVM
                                            {
                                                RequirementId = Convert.ToInt32(dataReader["requirement_id"]),
                                                RequirementName = dataReader["requirement_name"].ToString(),
                                                GroupName = dataReader["group_name"].ToString(),
                                            };
                                            companyPosition.Requirements.Add(requirement);
                                        }
                                    }
                                }
                            }
                        }

                        if (companyPosition == null)
                        {
                            throw new Exception($"Career map with Id {careerMapId} and company position with Id {companyPositionId} not found.");
                        }
                        Console.WriteLine("The SelectCompanyPositionByIdWithRequirements query was successful.");
                        return companyPosition;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"An error occurred when fetching the company's position requirements from the database. \n\nSqlException: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred when fetching the company's position requirements from the database. \n\nException: {ex.Message}");
            }
        }
    }
}
