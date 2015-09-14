using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QAndADataAccess;
using QAndAModel;

namespace ConsoleQAndAServiceTest
{
    public class DummyQuestionDataAccess : IQuestionDataAccess
    {
        private readonly int _votes;
        public DummyQuestionDataAccess(int votes)
        {
            _votes = votes;
        }
        public Question GetQuestion(int id)
        {
            return new LowRatedQuestion(new User()) {Votes = _votes, Title = "Dummy title", Message = "Dummy Message"};
        }
    }
}
