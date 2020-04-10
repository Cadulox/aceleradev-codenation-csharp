namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym)
        {
            Name = name;
            Acronym = acronym;
        }

        public State(string name, string acronym, double extension) : this(name, acronym)
        {
            Extension = extension;
        }

        public string Name { get; set; }
        public string Acronym { get; set; }
        public double Extension { get; set; }
    }
}
