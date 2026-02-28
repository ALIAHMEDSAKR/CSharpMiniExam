using System;
using MiniExam.Collections; // For AnswerList
using MiniExam.Core;
using MiniExam.Exams;
using MiniExam.Models;
using MiniExam.Questions;
namespace MiniExam
{
    /*
     TODOS : 
        Landing Page and User Interface (UI) for selecting exam type, subject, and starting the exam
        TIMING 
        EXAM MODES
        
        
        IMPROVE USER INPUT HANDLING AND VALIDATION
        REFRACTOR CODE TO BE MORE OOP AND CLEAN (EX: SEPARATE UI LOGIC FROM EXAM LOGIC)
        USE INTERFACES AND ABSTRACTION TO IMPROVE FLEXIBILITY AND EXTENSIBILITY (EX: IExam, IQuestion, IAnswer)
        USE DESIGN PATTERNS WHERE APPROPRIATE (EX: FACTORY PATTERN FOR CREATING EXAMS AND QUESTIONS)
        USE EXCEPTION HANDLING TO MANAGE ERRORS GRACEFULLY
        USE LINQ TO SIMPLIFY DATA MANIPULATION AND QUERIES
        USE GENERICS TO CREATE MORE FLEXIBLE AND REUSABLE COLLECTIONS (EX: GENERIC ANSWER LIST)
        USE DEPENDENCY INJECTION TO IMPROVE TESTABILITY AND DECUPLING OF COMPONENTS
        USE DELEGATES TO IMPLEMENT EVENT-DRIVEN BEHAVIOR (EX: EVENT FOR EXAM COMPLETION)
        REFRACTOR EXAM DISPLAY LOGIC TO BE MORE DYNAMIC AND SUPPORT DIFFERENT QUESTION TYPES WITHOUT HARD-CODING
        GENERLIZE CALCULATION GRADE LOGIC TO SUPPORT DIFFERENT EXAM TYPES AND GRADING SCHEMES
     */


    /*
     DONE :
        OVERRIDE TOSTRING, EQUALS, HASHCODE FOR EXAM CLASS & SUBJECT CLASS
        SAVE/LOAD QUESTIONS AND FILE HANDLING     
         IMPROVE AND REDUCE DUPLICATION IN EXAM TYPES (DRY PRINCIPLE)
    */
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(10, "C# Programming");

            // Create the Exam (60 minutes, 3 questions)
            Exam exam = new FinalExam(60, 3, sub1);

            // ==========================================
            // QUESTION 1: True or False
            // ==========================================
            var q1 = new TrueFalseQuestion("Basics", "C# is an Object Oriented Language", 5);
            q1.Answers.Add(new Answer(1, "True"));
            q1.Answers.Add(new Answer(2, "False"));

            // TEACHER KEY: The correct answer is 1 (True)
            AnswerList q1Correct = new AnswerList();
            q1Correct.Add(new Answer(1, "True"));

            // Add to Exam
            exam.Questions.Add(q1, q1Correct);


            // ==========================================
            // QUESTION 2: Choose One
            // ==========================================
            var q2 = new ChooseOneQuestion("Memory", "Which type is a Reference Type?", 10);
            q2.Answers.Add(new Answer(1, "int"));
            q2.Answers.Add(new Answer(2, "char"));
            q2.Answers.Add(new Answer(3, "string")); // Correct

            // TEACHER KEY: The correct answer is 3
            AnswerList q2Correct = new AnswerList();
            q2Correct.Add(new Answer(3, "string"));

            // Add to Exam
            exam.Questions.Add(q2, q2Correct);


            // ==========================================
            // QUESTION 3: Choose All (Multiple Choice)
            // ==========================================
            var q3 = new ChooseAllQuestion("OOP", "Select OOP Principles (Select Multiple)", 15);
            q3.Answers.Add(new Answer(1, "Encapsulation")); // Correct
            q3.Answers.Add(new Answer(2, "Compilation"));
            q3.Answers.Add(new Answer(3, "Polymorphism"));  // Correct
            q3.Answers.Add(new Answer(4, "Recursion"));

            // TEACHER KEY: The correct answers are 1 AND 3
            AnswerList q3Correct = new AnswerList();
            q3Correct.Add(new Answer(1, "Encapsulation"));
            q3Correct.Add(new Answer(3, "Polymorphism"));

            // Add to Exam
            exam.Questions.Add(q3, q3Correct);


            // ==========================================
            // 3. START THE EXAM
            // ==========================================
            Console.Clear();
            Console.WriteLine("Exam Generated. Starting now...");
            Console.WriteLine("Press Enter to begin.");
            Console.ReadLine();

            exam.ShowExam();
        }
    }
}