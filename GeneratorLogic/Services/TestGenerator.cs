using GeneratorLogic.Interfaces;
using Models;

namespace GeneratorLogic.Services
{
    public class TestGenerator
    {
        private readonly ISerializerServiceWrapper _serializerServiceWrapper;

        public int NumberTests { get; }

        public int NumberQuestions { get; }

        public int NumberAnswers { get; }

        public TestGenerator(int numberTests, int numberQuestions, int numberAnswers,
            ISerializerServiceWrapper serializerServiceWrapper)
        {
            if (numberAnswers < 2 || numberQuestions <= 0 || numberTests <= 0)
                throw new ArgumentException("The entered data is not correct");

            NumberTests = numberTests;
            NumberQuestions = numberQuestions;
            NumberAnswers = numberAnswers;
            _serializerServiceWrapper = serializerServiceWrapper;
        }

        public void GenerateTestsFromBasic(Test basicTest)
        {
            Parallel.For(0, NumberTests, i =>
            {
                var dateForRandSeed = new DateTime();

                var randomTest = RandomlyGenerateTest(
                    basicTest, dateForRandSeed.Millisecond + i * i
                    );

                var serializer = _serializerServiceWrapper.GetJsonSerializerService(@"Tests\test" + i + ".json");

                TestWriter(randomTest, serializer);
            });
        }

        public void TestWriter(Test test, ISerializerService serializer)
        {
            serializer.Serialize(test);
        }

        public Test RandomlyGenerateTest(Test basicTest, int randomSeed)
        {
            var random = new Random(randomSeed);
            var questions = RandomlyGenerateQuestions(
                    basicTest.Questions, random);
            var randomTest = new Test(questions); 

            return randomTest;
        }

        public List<Question> RandomlyGenerateQuestions(List<Question> basicQuestions, Random random)
        {
            var questions = basicQuestions.OrderBy(x => random.Next()).Take(NumberQuestions).ToList();

            foreach (var q in questions)
            {
                q.Answers = RandomlyGenerateAnswers(q.Answers, random);
            }

            return questions;
        }

        public List<Answer> RandomlyGenerateAnswers(List<Answer> basicAnswers, Random random)
        {
            var answers = basicAnswers.FindAll(x => x.Correct == false).
                OrderBy(x => random.Next()).
                Take(NumberAnswers - 1).ToList();
            answers.Add(basicAnswers.FindAll(x => x.Correct).OrderBy(x => random.Next()).First());

            return answers.OrderBy(x => random.Next()).ToList();
        }
    }
}
