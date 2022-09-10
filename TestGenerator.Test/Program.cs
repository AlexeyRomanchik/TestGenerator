using GeneratorLogic.Interfaces;
using GeneratorLogic.Services;
using Models;

public class Program
{
    public static string JsonFormat = ".json";

    private static void Main(string[] args)
    {

        Console.WriteLine("Enter a file name including format Templates\\(WPF.xml or WPF.json)");

        var filePath = Console.ReadLine();

        var format = Path.GetExtension(filePath);

        ISerializerService serializer;

        if (format == JsonFormat)
            serializer = new JsonSerializerService(filePath);
        else
            serializer = new XmlSerializerService(filePath);

        Test test;
        try
        {
            test = serializer.Deserialize<Test>();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Serialization error, probably the file name or format is incorrect");
            Console.WriteLine(exception.Message);
            return;
        }

        foreach (var question in test.Questions)
        {
            Console.WriteLine(question.Text);
        }


        Console.WriteLine("--------------------------------------------_");
        Console.WriteLine("Enter the number of tests to generate ( > 0 )");

        var numberTests = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.WriteLine("Enter the number of questions to generate ( > 0 )");

        var numberQuestions = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.WriteLine("Enter the number of answers to generate ( > 1 )");

        var numberAnswers = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Directory.CreateDirectory("Tests");

        var jsonSerializer = new JsonSerializerService(@"Tests\");

        var serializerServiceWrapper = new SerializerServiceWrapper();

        var testGenerator = new TestGenerator(numberTests, numberQuestions, numberAnswers, serializerServiceWrapper);

        testGenerator.GenerateTestsFromBasic(test);

        Console.WriteLine("Done!");
    }
}


