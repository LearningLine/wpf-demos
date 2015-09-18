using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAndAModel
{
    public class User
    {
        public const int RatingRiseOnVote = 10;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

        public void QuestionVotedUp(VoteEnum direction)
        {
            if (direction == VoteEnum.Up)
            {
                Rating += RatingRiseOnVote;
            }
            else
            {
                Rating -= RatingRiseOnVote;
            }
        }
    }
}
