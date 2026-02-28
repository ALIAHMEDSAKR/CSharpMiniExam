
namespace MiniExam.Questions
{
    internal class ChooseAllQuestion : Core.Question
    {
        public override bool AllowMultipleAnswers => true;
        public ChooseAllQuestion(string header, string body, int mark) : base(header, body, mark)
        {
        }
        public override void Display()
        {
            Console.WriteLine($"{Header} \t Marks({Mark})");
            Console.WriteLine(Body);
            Console.WriteLine("(Note: You can select multiple answers)");

            for (int i = 0; i < Answers.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].ToString()}");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
