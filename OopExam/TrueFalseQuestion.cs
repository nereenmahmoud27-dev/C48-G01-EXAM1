using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal class TrueFalseQuestion:Question
    {
        public TrueFalseQuestion(string header, string body, double mark, int rightAnswerId) : base(header, body, mark)
        {
            Answer[] answers = new Answer[2];
            answers[0] = new Answer(1, "True");
            answers[1] = new Answer(2, "False");
            AnswerList = answers;

            RightAnswer = null;
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].AnswerId == rightAnswerId)
                    RightAnswer = answers[i];
            }
        }

        public override void ShowQuestion(int questionNumber)
        {
            Console.WriteLine("Question " + questionNumber + ": " + Body);
            Console.WriteLine("True|False Question:Mark " + Mark);
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine(AnswerList[i].AnswerId + "-" + AnswerList[i].AnswerText);
            }
            Console.WriteLine("Enter your answer ID:");
        }

        public static TrueFalseQuestion InputFromConsole()
        {
            Console.WriteLine("Please enter the question body:");
            string body = Console.ReadLine();
            double mark;
            do
            {
                Console.WriteLine("Please enter the question mark:");
            } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

            int correctId;
            do
            {
                Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False):");
            } while (!int.TryParse(Console.ReadLine(), out correctId) || (correctId != 1 && correctId != 2));

            return new TrueFalseQuestion("True/False Question", body, mark, correctId);
        }
        public override string ToString()
        {
            return base.ToString() + "(True/False Question)";
        }
    }
}
