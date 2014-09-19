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

    [Transient]
    public class Wizard : IFantasyMagician//, IDisposable
    {
        public string Name
        {
            get
            {
                return "Hubert";
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public interface IFantasyMagician
    {
        string Name { get; }
    }


}

