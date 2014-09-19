using System;

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;


namespace CastleExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<IFantasyMagician>().ImplementedBy<Wizard>());
            container.Register(Component.For<IFactory>().AsFactory());

            var factory = container.Resolve<IFactory>();
            var magician = factory.Create<IFantasyMagician>();

            Console.WriteLine("The magician's name is: {0}", magician.Name);

            container.Dispose();

            Console.ReadLine();
        }
    }

    internal interface IFactory
    {
        T Create<T>();
        void Release(object value);

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

