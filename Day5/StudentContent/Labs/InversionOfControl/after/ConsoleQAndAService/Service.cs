using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.Configuration;
using QAndAModel;
using QAndAService;
using QAndADataAccessDAO;
using System.Configuration;
using QAndADataAccess;
using Microsoft.Practices.Unity;

namespace ConsoleQAndAService
{
    public class Service : IQAndAService
    {
        static IUnityContainer unityContainer;
        static Service()
        {
            unityContainer = new UnityContainer();
            UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (section != null)
            {
                section.Containers.Default.Configure(unityContainer);
            }

        }
        private IQuestionDataAccess _questionDataAccess;

        public Service()
            : this(unityContainer.Resolve<IQuestionDataAccess>())
        { }

        public Service(IQuestionDataAccess questionDataAccess)
        {
            _questionDataAccess = questionDataAccess;
        }

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
            Question q = _questionDataAccess.GetQuestion(1);
            q.Vote(VoteEnum.Up);
            return q.Votes;
        }
    }
}
