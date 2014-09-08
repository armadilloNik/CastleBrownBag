using System;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace _02.Basic_Container_with_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            // ok so this line -> container.Install(FromAssembly.This()); <- does a new? from 
            // should i add a conatiner explicitly for then get into this?
            container.Install(new HighFantasyInstaller());

            var magician = container.Resolve<IFantasyMagician>();
            Console.WriteLine(magician.Name);

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
                return "Joey";
            }
        }
    }
}
