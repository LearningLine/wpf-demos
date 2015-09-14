using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAModel
{
public class HighRatedQuestion : Question
{
    public HighRatedQuestion(User user) : base(user)
    {
    }

    protected override void IncrementVote(VoteEnum direction)
    {
        Votes += 5 * GetVoteIncrement(direction);
    }
}
}
