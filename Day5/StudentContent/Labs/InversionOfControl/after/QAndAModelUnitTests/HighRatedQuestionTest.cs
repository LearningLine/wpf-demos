using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using QAndAModel;

namespace QAndAModelUnitTests
{
    [TestFixture]
    public class HighRatedQuestionTest
    {
        [Test]
        public void VoteShouldIncrementCorrectlyWhenVotedOnAndImportanceIsHigh()
        {
            Question question = new HighRatedQuestion(new User());
            question.Vote(VoteEnum.Up);

            Assert.That(question.Votes, Is.EqualTo(5));
        }
    }
}
