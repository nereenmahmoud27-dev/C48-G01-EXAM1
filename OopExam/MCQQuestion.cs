using OopExam;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, double mark, Answer[] answerList, Answer rightAnswer) : base(header, body, mark, answerList, rightAnswer)
        {
        }

        public override void ShowQuestion(int questionNumber)
        {
            Console.WriteLine("Question " + questionNumber + ": " + Body);
            Console.WriteLine("MCQ Question:Mark" + Mark);

            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine(AnswerList[i].AnswerId + "- " + AnswerList[i].AnswerText);
            }

            Console.WriteLine("Enter your answer ID:");
        }

        public static MCQQuestion InputFromConsole()
        {
            Console.WriteLine("Please enter the question body:");
            string body = Console.ReadLine();

            double mark;
            do
            {
                Console.WriteLine("Please enter the question mark:");
            } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

            Console.WriteLine("Choices of Question:");
            Answer[] choices = new Answer[4];

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Please enter choice number {i + 1}:");
                string choiceText = Console.ReadLine();
                choices[i] = new Answer(i + 1, choiceText);
            }

            int correctId;
            do
            {
                Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
            } while (!int.TryParse(Console.ReadLine(), out correctId) || correctId < 1 || correctId > 4);

            Answer rightAnswer = choices[correctId - 1];

            return new MCQQuestion("MCQ Question", body, mark, choices, rightAnswer);
        }

        public override string ToString()
        {
            return base.ToString() + "(MCQ Question)";
        }

    }
}