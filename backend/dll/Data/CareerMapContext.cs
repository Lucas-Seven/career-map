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
            modelBuilder.Entity<AccessType>()
                .ToTable("accessTypes_tb")
                .HasKey(a => a.access_type_id);
            modelBuilder.Entity<AccessType_User>()
                .ToTable("accessTypes_users_tb")
                .HasNoKey();
            modelBuilder.Entity<CareerMap>()
                .ToTable("careerMaps_tb")
                .HasKey(a => a.career_map_id);
            modelBuilder.Entity<CareerMap_CompanyPosition>()
                .ToTable("careerMaps_companyPositions_tb")
                .HasNoKey();
            modelBuilder.Entity<CompanyPosition>()
                .ToTable("companyPositions_tb")
                .HasKey(a => a.company_position_id);
            modelBuilder.Entity<CompanyPosition_PositionRequirement>()
                .ToTable("companyPositions_positionRequirements_tb")
                .HasNoKey();
            modelBuilder.Entity<PositionRequirement>()
                .ToTable("positionRequirements_tb")
                .HasKey(a => a.requirement_id);
            modelBuilder.Entity<QuestionAlternative>()
                .ToTable("questionAlternatives_tb")
                .HasKey(a => a.alternative_id);
            modelBuilder.Entity<QuestionType>()
                .ToTable("questionTypes_tb")
                .HasKey(a => a.question_type_id);
            modelBuilder.Entity<Test>()
                .ToTable("tests_tb")
                .HasKey(a => a.test_id);
            modelBuilder.Entity<Test_TestQuestion>()
                .ToTable("tests_testQuestions_tb")
                .HasNoKey();
            modelBuilder.Entity<TestAnswer>()
                .ToTable("testAnswers_tb")
                .HasKey(a => a.answer_id);
            modelBuilder.Entity<TestQuestion>()
                .ToTable("testQuestions_tb")
                .HasKey(a => a.question_id);
            modelBuilder.Entity<User>()
                .ToTable("users_tb")
                .HasKey(a => a.user_id);
        }
    }
}
