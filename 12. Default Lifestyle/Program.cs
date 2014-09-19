using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;


namespace CastleExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IFantasyMagician>().ImplementedBy<Wizard>());

            var magician = container.Resolve<IFantasyMagician>();
            
            Console.WriteLine("The magician's name is: {0}", magician.Name);
            Console.WriteLine();
            
         


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

