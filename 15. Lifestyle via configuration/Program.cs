using System;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace CastleExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer(new XmlInterpreter());

            var magician = container.Resolve<IFantasyMagician>();

            Console.WriteLine("The magician's name is: {0}", magician.Name);

            container.Dispose();

            Console.ReadLine();
        }
    }

    public interface IFantasyMagician
    {
        string Name { get; }
    }

    public class Wizard : IFantasyMagician
    {
        public string Name
        {
            get
            {
                return "Hubert";
            }
        }
    }
}

