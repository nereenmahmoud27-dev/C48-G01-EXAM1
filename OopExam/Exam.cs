using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        public Exam(int timeOfExamMinutes, int numberOfQuestions, Question[] questions)
        {
            TimeOfExam = timeOfExamMinutes;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ShowExam();

        public bool AskToStart()
        {
            string choice;
            do
            {
                Console.WriteLine("Do You Want To Start Exam (Y | N)");
                choice = Console.ReadLine();
                if (choice != null)
                    choice = choice.ToUpper();
            } while (choice != "Y" && choice != "N");

            return choice == "Y";
        }

        public void RunExamLoop()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].ShowQuestion(i + 1);
                Questions[i].AskStudentAnswer();
            }
        }

        public void ShowResult(string title, TimeSpan elapsedTime)
        {
            Console.WriteLine(title);

            double grade = 0;
            double totalMarks = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                Question q = Questions[i];
                Console.WriteLine($"Question " + (i + 1) + ": " + q.Body);
                Console.WriteLine("Your Answer => " + q.StudentAnswer);
                Console.WriteLine("Correct Answer => " + q.RightAnswer);

                totalMarks = totalMarks + q.Mark;
                if (q.IsCorrect())
                    grade = grade + q.Mark;
            }

            Console.WriteLine("Your Grade is " + grade + " from " + totalMarks);
        }
    }
}
