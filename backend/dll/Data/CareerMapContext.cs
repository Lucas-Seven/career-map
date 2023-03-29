using dll.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Data
{
    public class CareerMapContext : DbContext
    {
        public CareerMapContext(DbContextOptions<CareerMapContext> options) : base(options)
        { }

        // Mapeando as entidades do modelo para tabelas no banco de dados.
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<AccessType_User> AccessTypes_Users { get; set; }
        public DbSet<CareerMap> CareerMaps { get; set; }
        public DbSet<CareerMap_CompanyPosition> CareerMaps_CompanyPositions { get; set; }
        public DbSet<CompanyPosition> CompanyPositions { get; set; }
        public DbSet<CompanyPosition_PositionRequirement> CompanyPositions_PositionRequirements { get; set; }
        public DbSet<PositionRequirement> PositionRequirements { get; set; }
        public DbSet<QuestionAlternative> QuestionAlternatives { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test_TestQuestion> Tests_TestQuestions { get; set; }
        public DbSet<TestAnswer> TestAnswers { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Reescrevendo os nomes das tabelas.
            modelBuilder.Entity<AccessType>().ToTable("accessTypes_tb");
            modelBuilder.Entity<AccessType_User>().ToTable("accessTypes_users_tb");
            modelBuilder.Entity<CareerMap>().ToTable("careerMaps_tb");
            modelBuilder.Entity<CareerMap_CompanyPosition>().ToTable("careerMaps_companyPositions_tb");
            modelBuilder.Entity<CompanyPosition>().ToTable("companyPositions_tb");
            modelBuilder.Entity<CompanyPosition_PositionRequirement>().ToTable("companyPositions_positionRequirements_tb");
            modelBuilder.Entity<PositionRequirement>().ToTable("positionRequirements_tb");
            modelBuilder.Entity<QuestionAlternative>().ToTable("questionAlternatives_tb");
            modelBuilder.Entity<QuestionType>().ToTable("questionTypes_tb");
            modelBuilder.Entity<Test>().ToTable("tests_tb");
            modelBuilder.Entity<Test_TestQuestion>().ToTable("tests_testQuestions_tb");
            modelBuilder.Entity<TestAnswer>().ToTable("testAnswers_tb");
            modelBuilder.Entity<TestQuestion>().ToTable("testQuestions_tb");
            modelBuilder.Entity<User>().ToTable("users_tb");
        }
    }
}
