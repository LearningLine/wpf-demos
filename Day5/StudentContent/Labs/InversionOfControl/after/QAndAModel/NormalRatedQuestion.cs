using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAModel
{
    public class NormalRatedQuestion : Question
    {
        public NormalRatedQuestion(User user) : base(user)
        {
        }

        protected override void IncrementVote(VoteEnum direction)
        {
            Votes += 2 * GetVoteIncrement(direction);
        }
    }
}
