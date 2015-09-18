using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAModel
{
    public abstract class Question
    {
        public Question(User user)
        {
            User = user;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Answered { get; set; }
        public int Votes { get; set; }
        public User User { get; set; }
        public bool Closed { get; set; }

        public void Vote(VoteEnum direction)
        {
            if (Closed)
            {
                throw new QuestionException();
            }
            IncrementVote(direction);

            User.QuestionVotedUp(direction);
        }

        protected abstract void IncrementVote(VoteEnum direction);

        protected int GetVoteIncrement(VoteEnum direction)
        {
            int voteIncrement;
            if (direction == VoteEnum.Up)
            {
                voteIncrement = 1;
            }
            else
            {
                voteIncrement = -1;
            }
            return voteIncrement;
        }
    }
}
