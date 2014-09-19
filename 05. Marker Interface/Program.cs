using System;

using Castle.MicroKernel.Registration;
using Castle.Windsor;


namespace CastleExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Classes.FromThisAssembly().BasedOn<IRequireWindsor>().WithServiceAllInterfaces());

            var wizard = container.Resolve<IWizard>();
            var mage = container.Resolve<IMage>();
            var warlock = container.Resolve<IWarlock>();

            Console.WriteLine("The wizard's name is: {0}", wizard.Name);
            Console.WriteLine("The mages's name is: {0}", mage.Name);
            Console.WriteLine("The warlocks's name is: {0}", warlock.Name);

            container.Dispose();

            Console.ReadLine();
        }
    }

    public interface IRequireWindsor
    {
    }

    public interface IFantasyMagician : IRequireWindsor
    {
        string Name { get; }
    }

    public interface IWizard : IFantasyMagician
    {
        void DoWizardSpecificThings();
    }

    public class Wizard : IWizard
    {
        public string Name
        {
            get
            {
                return "Hubert";
            }
        }

        public void DoWizardSpecificThings()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMage : IFantasyMagician
    {
        void DoMageSpecificThings();
    }


    public class Mage : IMage
    {
        public string Name
        {
            get
            {
                return "Eddy";
            }
        }

        public void DoMageSpecificThings()
        {
            throw new NotImplementedException();
        }
    }

    public interface IWarlock : IFantasyMagician
    {
       void DoWarlockSpecificThings();
    }

    public class Warlock : IWarlock
    {
        public string Name
        {
            get
            {
                return "Ricky Bobby";
            }
        }

        public void DoWarlockSpecificThings()
        {
            throw new NotImplementedException();
        }
    }
}

