using System;
using System.Collections.Generic;
using System.Text;

namespace OopExam
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer StudentAnswer { get; set; }

        public Question(string header, string body, double mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }


        public Question(string header, string body, double mark, Answer[] answerList, Answer rightAnswer):this(header, body, mark)
        {
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }


        public abstract void ShowQuestion(int questionNumber);

        public override string ToString()
        {
            return $"Q:{Header} \nBody:{Body} \nMark:{Mark}";
        }

        public void AskStudentAnswer()
        {
            int id = int.Parse(Console.ReadLine());
            for (int i = 0; i < AnswerList.Length; i++)
            {
                if (AnswerList[i].AnswerId == id)
                {
                    StudentAnswer = AnswerList[i];
                    break;
                }
            }
        }

       public bool IsCorrect()
        {
            if (StudentAnswer != null && RightAnswer != null && StudentAnswer.AnswerId == RightAnswer.AnswerId)
            return true;
            return false;
        }     
      
        public int CompareTo(Question other)
        {
            if (other == null)
                return 1;
            if (this.Mark > other.Mark)
                return 1;
            if (this.Mark < other.Mark)
                return -1;
            return 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
