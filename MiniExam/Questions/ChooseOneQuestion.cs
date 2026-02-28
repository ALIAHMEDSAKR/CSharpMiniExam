

namespace MiniExam.Questions
{
    internal class ChooseOneQuestion : Core.Question
    {
        public ChooseOneQuestion(string header, string body, int mark) : base(header, body, mark)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{Header} \t Marks({Mark})");
            Console.WriteLine(Body);

            for(int i = 0; i < Answers.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].ToString()}");
            }
            Console.WriteLine("-----------------------------------");
        }
    }
}
