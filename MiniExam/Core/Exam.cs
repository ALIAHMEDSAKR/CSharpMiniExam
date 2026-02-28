using MiniExam.Collections;

namespace MiniExam.Core
{

    public abstract class Exam : ICloneable, IComparable
    {
        // public int ExamId { get; set; }
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Subject Subject { get; set; }
        public Dictionary<Question, AnswerList> Questions { get; set; }

        protected Dictionary<Question, AnswerList> studentAnswers;
        protected Exam(int time, int NumOfQuestions, Subject sb)
        {
            Time = time;
            NumberOfQuestions = NumOfQuestions;
            Subject = sb;
            Questions = new();
            studentAnswers = new();

        }

        public object Clone()
        {
            return this.Clone();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            Exam exam = (Exam)obj;
            return this.Time.CompareTo(exam.Time);
        }

        public override string ToString()
        {
            return $"Exam Time : {Time} | Number Of Questions : {NumberOfQuestions} | Subject : {Subject}";
        }

        override public bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Exam other = (Exam)obj;
            return Time == other.Time && NumberOfQuestions == other.NumberOfQuestions && Subject.Equals(other.Subject);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Time, NumberOfQuestions, Subject);
        }

        public abstract void ShowExam();
        protected void TakeExam()
        {
            foreach (var item in Questions)
            {
                Console.WriteLine("------------------------------------------------");
                var currQuestion = item.Key;

                while (true)
                {
                    currQuestion.Display();
                    Console.Write("Enter Answer ID(s) (separate with space if multiple): ");
                    string input = Console.ReadLine() ?? "";
                    var answerIds = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (!currQuestion.AllowMultipleAnswers && answerIds.Length > 1)
                    {
                        Console.WriteLine("Error: You can only select ONE answer for this question.");
                        continue;
                    }

                    AnswerList choiceIds = new AnswerList();

                    foreach (var id in answerIds)
                    {
                        if (int.TryParse(id, out int answerId))
                        {
                            // Search the available options (currQuestion.Answers), NOT item.Value!
                            var selectedAnswer = currQuestion.Answers.FirstOrDefault(a => a.Id == answerId);
                            if (selectedAnswer != null)
                            {
                                choiceIds.Add(selectedAnswer);
                            }
                            else
                            {
                                Console.WriteLine($"Error: Answer ID {answerId} is not valid for this question.");
                            }
                        }
                    }

                    if (choiceIds.Count == 0)
                    {
                        Console.WriteLine("\n[!] Error: Invalid ID entered. Please try again.\n");
                        continue;
                    }

                    studentAnswers.Add(currQuestion, choiceIds);
                    break;
                }
            }
            Console.Clear();
        }

    }
}
