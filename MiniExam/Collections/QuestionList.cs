using MiniExam.Core;

namespace MiniExam.Collections
{
    public class QuestionList : List<Question>
    {
        string LogFilePath { get; set; }
        public string SubjectName { get; set; }
        public QuestionList(string subjectName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            SubjectName = subjectName;

            LogFilePath = Path.Combine(baseDirectory, $"{SubjectName}.txt");

            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Close();
            }
        }

        public new void Add(Question item)
        {
            base.Add(item);

            LogQuestionToFile(item);
        }

        private void LogQuestionToFile(Question item)
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath, append: true))
            {
                writer.WriteLine($"Question Header: {item.Header}");
                writer.WriteLine($"Body: {item.Body}");
                writer.WriteLine($"Marks: {item.Mark}");
                writer.WriteLine($"Allow Multiple Answers: {item.AllowMultipleAnswers}");
                writer.WriteLine("Answers:");
                foreach (var answer in item.Answers)
                {
                    writer.WriteLine($"- {answer}");
                }
                writer.WriteLine("------------------------------------------------");
            }
        }

        public void ReadAndDisplayLog()
        {
            Console.WriteLine($"\n=== Reading {SubjectName} File from Disk ===");

            if (File.Exists(LogFilePath))
            {
                using (TextReader tr = new StreamReader(LogFilePath))
                {
                    string content = tr.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
        }
    }
}
