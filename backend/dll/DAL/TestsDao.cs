using dll.Data;
using dll.Models;
using dll.ViewModels;

namespace dll.DAL
{
    public class TestsDao : GenericDao<Test>
    {
        public TestsDao(AprovAtosContext context) : base(context)
        {
            this.Context = context;
        }

        public IEnumerable<TestVM> ListTests()
        {
            var list = Context.Tests.Join(
                Context.Tests_TestQuestions,
                t => t.test_id,
                tq => tq.test_id,
                (t, tq) => new { Test = t, Test_TestQuestion = tq }
            )
            .Join(
                Context.PositionRequirements,
                ttq => ttq.Test.requirement_id,
                r => r.requirement_id,
                (ttq, r) => new { Test = ttq.Test, Test_TestQuestion = ttq.Test_TestQuestion, PositionRequirement = r }
            )
            .Join(
                Context.TestQuestions,
                ttqr => ttqr.Test_TestQuestion.question_id,
                q => q.question_id,
                (ttqr, q) => new { Test = ttqr.Test, Test_TestQuestion = ttqr.Test_TestQuestion, PositionRequirement = ttqr.PositionRequirement, TestQuestion = q }
            )
            .Join(
                Context.QuestionTypes,
                ttqrq => ttqrq.TestQuestion.question_type_id,
                qt => qt.question_type_id,
                (ttqrq, qt) => new { Test = ttqrq.Test, Test_TestQuestion = ttqrq.Test_TestQuestion, PositionRequirement = ttqrq.PositionRequirement, TestQuestion = ttqrq.TestQuestion, QuestionType = qt }
            )
            .Join(
                Context.QuestionAlternatives,
                ttqrqqt => ttqrqqt.Test_TestQuestion.question_id,
                a => a.question_id,
                (ttqrqqt, a) => new TestVM
                {
                    test_id = ttqrqqt.Test.test_id,
                    testDescription = ttqrqqt.Test.description,
                    requirement_id = ttqrqqt.PositionRequirement.requirement_id,
                    requirement_name = ttqrqqt.PositionRequirement.requirement_name,
                    question_id = ttqrqqt.TestQuestion.question_id,
                    is_required = ttqrqqt.TestQuestion.is_required,
                    question = ttqrqqt.TestQuestion.question,
                    questionDescription = ttqrqqt.TestQuestion.description,
                    question_type_id = ttqrqqt.QuestionType.question_type_id,
                    question_type_name = ttqrqqt.QuestionType.question_type_name,
                    alternative_id = a.alternative_id,
                    alternative = a.alternative
                }
            )
            .OrderBy(
                o => o.test_id
            );

            return list.ToList();
        }

        public IEnumerable<TestVM> TestById(int idRequirement)
        {
            var obj = Context.Tests.Join(
                Context.Tests_TestQuestions,
                t => t.test_id,
                tq => tq.test_id,
                (t, tq) => new { Test = t, Test_TestQuestion = tq }
            )
            .Join(
                Context.PositionRequirements,
                ttq => ttq.Test.requirement_id,
                r => r.requirement_id,
                (ttq, r) => new { Test = ttq.Test, Test_TestQuestion = ttq.Test_TestQuestion, PositionRequirement = r }
            )
            .Join(
                Context.TestQuestions,
                ttqr => ttqr.Test_TestQuestion.question_id,
                q => q.question_id,
                (ttqr, q) => new { Test = ttqr.Test, Test_TestQuestion = ttqr.Test_TestQuestion, PositionRequirement = ttqr.PositionRequirement, TestQuestion = q }
            )
            .Join(
                Context.QuestionTypes,
                ttqrq => ttqrq.TestQuestion.question_type_id,
                qt => qt.question_type_id,
                (ttqrq, qt) => new { Test = ttqrq.Test, Test_TestQuestion = ttqrq.Test_TestQuestion, PositionRequirement = ttqrq.PositionRequirement, TestQuestion = ttqrq.TestQuestion, QuestionType = qt }
            )
            .Join(
                Context.QuestionAlternatives,
                ttqrqqt => ttqrqqt.Test_TestQuestion.question_id,
                a => a.question_id,
                (ttqrqqt, a) => new TestVM
                {
                    test_id = ttqrqqt.Test.test_id,
                    testDescription = ttqrqqt.Test.description,
                    requirement_id = ttqrqqt.PositionRequirement.requirement_id,
                    requirement_name = ttqrqqt.PositionRequirement.requirement_name,
                    question_id = ttqrqqt.TestQuestion.question_id,
                    is_required = ttqrqqt.TestQuestion.is_required,
                    question = ttqrqqt.TestQuestion.question,
                    questionDescription = ttqrqqt.TestQuestion.description,
                    question_type_id = ttqrqqt.QuestionType.question_type_id,
                    question_type_name = ttqrqqt.QuestionType.question_type_name,
                    alternative_id = a.alternative_id,
                    alternative = a.alternative
                }
            )
            .Where(
                w => w.requirement_id == idRequirement
            );

            return obj;
        }
    }
}
