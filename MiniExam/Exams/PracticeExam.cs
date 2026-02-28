
using MiniExam.Collections;
using MiniExam.Core;
using MiniExam.Models;

namespace MiniExam.Exams
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int time, int numberOfQuestions, Subject subject)
             : base(time, numberOfQuestions, subject)
        {
        }
        public override void ShowExam()
        {
            // 1. Run the shared logic!
            TakeExam();

            // 2. Run Practice Exam specific logic
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine("Correct Answers & Grading:");
            CalculateGrade();
        }

        private void CalculateGrade()
        {
            int totalScore = 0;
            int studentScore = 0;

            Console.WriteLine("--- GRADING REPORT ---");
            foreach (var answer in studentAnswers) // studentAnswers from base class
            {
                var question = answer.Key;
                var studentChoices = answer.Value;

                if (Questions.TryGetValue(question, out AnswerList correctChoices))
                {
                    totalScore += question.Mark;
                    bool isCorrect = false;

                    if (studentChoices.Count == correctChoices.Count)
                    {
                        isCorrect = true;
                        foreach (var sAnswer in studentChoices)
                        {
                            if (!correctChoices.Any(c => c.Id == sAnswer.Id))
                            {
                                isCorrect = false;
                                break;
                            }
                        }
                    }

                    Console.WriteLine($"Q: {question.Body}");

                    if (isCorrect)
                    {
                        studentScore += question.Mark;
                        Console.WriteLine("Result: Correct ");
                    }
                    else
                    {
                        Console.WriteLine($"Result: Wrong ");
                        correctChoices.ForEach(ans => Console.WriteLine($"Correct Answer: {ans.Id} - {ans.Text}"));
                    }
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.WriteLine($"\nFinal Result: {studentScore} / {totalScore}");
        }
    }
}
