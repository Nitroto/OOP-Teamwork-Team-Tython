using Diablo.Exceptions;

namespace Diablo.Logic
{
    public abstract class GameObject
    {
        private string name;


        protected GameObject(string name)
        {
            this.Name = name;
        }


        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOrNullNameException("Invalid name. The name can't be null or empty.");
                }
                this.name = value;
            }
        }
    }
}
