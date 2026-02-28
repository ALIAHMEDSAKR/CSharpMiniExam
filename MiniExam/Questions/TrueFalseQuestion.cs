
namespace MiniExam.Questions
{
    internal class TrueFalseQuestion : Core.Question
    {
        public TrueFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void Display()
        {
            Console.WriteLine($"{Header} \t Marks({Mark})");
            Console.WriteLine(Body);

            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
            Console.WriteLine("-----------------------------------");
        }
    }
}
