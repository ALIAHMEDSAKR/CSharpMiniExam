using System;

namespace MiniExam.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Text { get; set; }

        public Answer(int id , string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"Answer Text : {Text}";
        }
    }
}
