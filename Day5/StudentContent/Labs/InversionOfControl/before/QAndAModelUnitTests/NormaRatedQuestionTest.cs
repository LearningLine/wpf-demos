using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using QAndAModel;

namespace QAndAModelUnitTests
{
    [TestFixture]
    public class NormaRatedQuestionTest
    {
        [Test]
        public void VoteShouldIncrementCorrectlyWhenVotedOnAndImportanceIsNormal()
        {
            Question question = new NormalRatedQuestion(new User());
            question.Vote(VoteEnum.Up);

            Assert.That(question.Votes, Is.EqualTo(2));
        }

    }
}
