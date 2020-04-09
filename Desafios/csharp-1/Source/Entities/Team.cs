using System;

namespace Source.Entities
{
    class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }

        public Team(long id, string name, DateTime creationDate, string mainUniformColor, string secondaryUniformColor)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
            MainShirtColor = mainUniformColor;
            SecondaryShirtColor = secondaryUniformColor;
        }
    }
}
