using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Install(new HighFantasyInstaller());

            var magician = container.Resolve<IFantasyMagician>();

            Console.WriteLine("The magician's name is: {0}", magician.Name);

            container.Dispose();

            Console.ReadLine();
        }
    }

    public class HighFantasyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFantasyMagician>().ImplementedBy<Wizard>());
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
