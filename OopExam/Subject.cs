using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }


        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam()
        {
            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");
            string examType = Console.ReadLine();

            int time = 0;
            bool validTime = false;
            while (validTime == false)
            {
                Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
                if (int.TryParse(Console.ReadLine(), out time) && time >= 30 && time <= 180)
                    validTime = true;
                else
                    Console.WriteLine("Invalid time.Please enter a value between 30 and 180.");
            }

            int numberOfQuestions;
            do
            {
                Console.WriteLine("Please enter the number of questions:");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0);

            Question[] questions = new Question[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Enter details for question " + (i + 1) + ":");

                if (examType == "2")
                {
                    Console.WriteLine("Choose question type: 1 for MCQ, 2 for True/False:");
                    string qType = Console.ReadLine();

                    if (qType == "1")
                        questions[i] = MCQQuestion.InputFromConsole();
                    else
                        questions[i] = TrueFalseQuestion.InputFromConsole();
                }
                else
                {
                    questions[i] = MCQQuestion.InputFromConsole();
                }
            }

            if (examType == "2")
                SubjectExam = new Final(time, numberOfQuestions, questions);
            else
                SubjectExam = new Practical(time, numberOfQuestions, questions);
        }

        public override string ToString()
        {
            return "Subject [" + SubjectId + "] " + SubjectName;
        }
    }
}
