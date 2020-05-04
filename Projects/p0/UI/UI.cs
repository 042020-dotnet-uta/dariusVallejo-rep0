using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    interface UserInterface
    {
        public List<string> options { get; set; }
        void build();
        void prompt();
        void select(int choice);
    }
}
