using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallengeWeek3
{
    /// <summary>
    /// Interface for UserInterface class, for simple UI building
    /// </summary>
    interface UserInterface
    {
        public List<string> options { get; set; }
        void build();
        void prompt();
        void select(int choice);
    }
}
