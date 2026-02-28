using MiniExam.Collections;

namespace MiniExam.Core
{
    public class Subject 
    {
        int SubjectId { get; set; }
        string? SubjectName { get; set; }
        QuestionList Questions { get; set; }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Questions = new QuestionList(subjectName);

        }

        public override string ToString()
        {
            return $"Subject ID : {SubjectId} | Subject Name : {SubjectName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Subject other = (Subject)obj;
            return SubjectId == other.SubjectId && SubjectName == other.SubjectName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubjectId, SubjectName);
        }
    }
}
