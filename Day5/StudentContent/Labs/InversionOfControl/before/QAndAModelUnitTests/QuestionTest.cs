using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using QAndAModel;

namespace QAndAModelUnitTests
{
    [TestFixture]
    public class QuestionTest
    {
        Question question;
        
        [SetUp]
        public void Initialize()
        {
            question = new LowRatedQuestion(new User());
        }

        [Test]
        public void VotesShouldBeIncrementedWhenQuestionIsVotedUp()
        {
            question.Vote(VoteEnum.Up);

            Assert.That(question.Votes, Is.EqualTo(1));
        }

        [Test]
        public void VotesShouldBeDecrementedWhenQuestionIsVotedDown()
        {
            question.Vote(VoteEnum.Down);

            Assert.That(question.Votes, Is.EqualTo(-1));
        }

        [Test]
        public void UsersRatingRisesWhenQuestionIsVotedUp()
        {
            int initialRating = 100;
            User user = new User {Rating = initialRating};
            question.User = user;

            question.Vote(VoteEnum.Up);

            Assert.That(user.Rating, Is.EqualTo(initialRating + User.RatingRiseOnVote));
        }

        [Test]
        public void UsersRatingRisesWhenQuestionIsVotedDown()
        {
            int initialRating = 100;
            User user = new User { Rating = initialRating };
            question.User = user;
            question.Vote(VoteEnum.Down);

            Assert.That(user.Rating, Is.EqualTo(initialRating - User.RatingRiseOnVote));
        }

        [Test]
        [ExpectedException(typeof(QuestionException))]
        public void VoteShouldThrowAnExceptionWhenQuestionHasBeenClosed()
        {
            const int initialVoteCount = 4;
            question.Votes = initialVoteCount;
            question.Closed = true;

            question.Vote(VoteEnum.Up);
        }

        [Test, TestCaseSource(typeof(VoteDataFactory), "TestCases")]
        public int VoteShouldIncrementCorrectlyWhenVotedOn(int initialRating, VoteEnum direction)
        {
            User user = new User { Rating = initialRating };
            question.User = user;
            question.Vote(direction);

            return user.Rating;
        }

    }

    public class VoteDataFactory
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(100, VoteEnum.Up).Returns(100 + User.RatingRiseOnVote);
                yield return new TestCaseData(0, VoteEnum.Up).Returns(User.RatingRiseOnVote);
                yield return new TestCaseData(-User.RatingRiseOnVote, VoteEnum.Up).Returns(0);

                yield return new TestCaseData(100, VoteEnum.Down).Returns(100 - User.RatingRiseOnVote);
                yield return new TestCaseData(0, VoteEnum.Down).Returns(-User.RatingRiseOnVote);
                yield return new TestCaseData(User.RatingRiseOnVote, VoteEnum.Down).Returns(0);
            }
        }
    }

}
