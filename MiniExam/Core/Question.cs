using MiniExam.Collections;

namespace MiniExam.Core
{
    public abstract class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }
        public virtual bool AllowMultipleAnswers => false;
        public AnswerList Answers { get; set; }

        public Question(string header , string body , int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = new();
        }

        public abstract void Display();
        override public string ToString()
        {
            return $"Question Header : {Header} | Question Body : {Body} | Question Mark : {Mark}";
        }
    }
}
