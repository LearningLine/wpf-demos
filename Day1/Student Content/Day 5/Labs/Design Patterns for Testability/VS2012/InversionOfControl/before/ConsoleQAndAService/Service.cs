using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QAndAModel;
using QAndADataAccessDAO;
using System.Configuration;

namespace ConsoleQAndAService
{
    public class Service 
    {
        static void Main(string[] args)
        {
            QuestionDataAccessDAO questionDataAccess = new QuestionDataAccessDAO(ConfigurationManager.ConnectionStrings["QAndA"].ConnectionString);
            Question q = questionDataAccess.GetQuestion(1);
            Console.WriteLine("{0}:{1}", q.Title, q.Message);

            Service s = new Service();
            int votes = s.VoteUpQuestion(1);
            Console.WriteLine("Number of votes is: {0}", votes);
        }

        public int VoteUpQuestion(int questionId)
        {
            QuestionDataAccessDAO questionDataAccess = new QuestionDataAccessDAO(ConfigurationManager.ConnectionStrings["QAndA"].ConnectionString);
            Question q = questionDataAccess.GetQuestion(1);
            q.Vote(VoteEnum.Up);
            return q.Votes;
        }
    }
}
