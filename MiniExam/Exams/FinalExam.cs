
using MiniExam.Core;
using MiniExam.Collections;

namespace MiniExam.Exams // Duplicated code => Todo: Refactor this code to avoid duplication with PracticeExam DRY Principle
{
    public class FinalExam(int time, int numberOfQuestions, Subject subject) : Exam(time, numberOfQuestions, subject) //Primary Constructor
    {
        public override void ShowExam()
        {
            TakeExam();

            Console.WriteLine("\n------------------------------------------------");
            DisplayExam();

        }

        private void DisplayExam()
        {
            Console.WriteLine("Questions & Student Answers:");
            foreach (var entry in Questions)
            {
                var question = entry.Key;

                Console.WriteLine($"Question: {question.Header}");
                Console.WriteLine($"Your Answers: {string.Join(", ", studentAnswers[question].Select(a => a.Text))}");
                Console.WriteLine("-----------------------------------");
            }

        }
    }
}
