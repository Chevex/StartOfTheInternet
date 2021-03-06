﻿namespace Terminal.Core.Data.Entities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Board
    {
        public short BoardID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public bool ModsOnly { get; set; }
        public bool Locked { get; set; }
        public bool Anonymous { get; set; }
        public bool AllTopics { get; set; }
        public bool MembersOnly { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public long TopicCount(bool isModerator)
        {
            if (isModerator)
                return Topics
                    .Count();
            else
                return Topics
                    .Where(x => !x.ModsOnly)
                    .Where(x => !x.Board.ModsOnly)
                    .Where(x => !x.Board.Hidden)
                    .Count();
        }
    }
}