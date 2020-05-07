using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// Interface for creating interactable UIs
    /// </summary>
    interface UserInterface
    {
        // Required public for interface
        public List<string> options { get; set; }
        void build();
        void prompt();
        void select(int choice);
    }
}
