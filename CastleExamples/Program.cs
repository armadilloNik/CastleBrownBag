using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            // should i expand this into more steps before i get to the help methods?
            container.Register(Component.For<IFantasyMagician>().ImplementedBy<Wizard>());

            var magician = container.Resolve<IFantasyMagician>();
            Console.WriteLine(magician.Name);

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
                return "Joey";
            }
        }
    }
}
