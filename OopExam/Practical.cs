using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal class Practical:Exam
    {
        public Practical(int timeOfExamMinutes, int numberOfQuestions, Question[] questions) : base(timeOfExamMinutes, numberOfQuestions, questions)
        {
        }
        public override void ShowExam()
        {
            if (AskToStart() == false)
                return;

            DateTime startTime = DateTime.Now;
            RunExamLoop();
            DateTime endTime = DateTime.Now;
            TimeSpan elapsedTime = endTime - startTime;

            ShowResult("Practical Exam Results:", elapsedTime);

            Console.WriteLine("Time = " + elapsedTime);
            Console.WriteLine("Thank you");
        }
    }
}
