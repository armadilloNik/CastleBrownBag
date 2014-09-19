using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Rhino.Commons;


namespace CastleExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly().BasedOn<IRequireWindsor>().WithServiceAllInterfaces());

            IoC.Initialize(container);

            var world = container.Resolve<IFantasyWorld>();

            Console.WriteLine("The center of the fantasy world is located at: \n{0}", world.WorldOrigin);

            container.Dispose();

            Console.ReadLine();
        }
    }

    public interface IFantasyWorld : IRequireWindsor
    {
        string WorldOrigin { get; }
    }

    public class FantasyWorld : IFantasyWorld
    {
        public string WorldOrigin
        {
            get
            {
                var forest = IoC.Resolve<IMagicalForest>();
                var coordinates = forest.Coordinates;
                IoC.Container.Release(coordinates);

                return coordinates;
            }
        }
    }

    public interface IMagicalForest : IRequireWindsor
    {
        string Coordinates { get; }
    }

    public class MagicalForest : IMagicalForest
    {
        public string Coordinates
        {
            get { return "Latitude : 33.096549 | Longitude : -96.67347"; }
        }
    }

    public interface IRequireWindsor
    {
    }

}

