using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal class Final:Exam
    {
        public Final(int timeOfExamMinutes, int numberOfQuestions, Question[] questions) : base(timeOfExamMinutes, numberOfQuestions, questions)
        {
        }


        public override void ShowExam()
        {
            if (AskToStart() == false)
                return;

            DateTime startTime = DateTime.Now;
            Console.WriteLine("Final Exam");
            RunExamLoop();
            DateTime endTime = DateTime.Now;
            TimeSpan elapsedTime = endTime - startTime;

            ShowResult("Final Exam Results:", elapsedTime);

            Console.WriteLine("Time = " + elapsedTime);
            Console.WriteLine("Thank you");
        }


    }
}
