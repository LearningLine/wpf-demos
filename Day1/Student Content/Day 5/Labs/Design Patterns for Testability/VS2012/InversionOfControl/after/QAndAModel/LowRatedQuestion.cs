using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAModel
{
    public class LowRatedQuestion : Question
    {
        public LowRatedQuestion(User user) : base(user)
        {
        }

        protected override void IncrementVote(VoteEnum direction)
        {
            Votes += GetVoteIncrement(direction);
        }
    }
}
