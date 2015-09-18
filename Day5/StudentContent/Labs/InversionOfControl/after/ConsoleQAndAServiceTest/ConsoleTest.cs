using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleQAndAService;

namespace ConsoleQAndAServiceTest
{
    [TestFixture]
    public class ConsoleTest
    {
        [Test]
        public void ServiceShouldReturnCorrectNumberOfVotesFromVoteUpQuestion()
        {
            Service service = new Service(new DummyQuestionDataAccess(1));
            int votes = service.VoteUpQuestion(1);

            Assert.That(2, Is.EqualTo(votes));
        }
    }
}
