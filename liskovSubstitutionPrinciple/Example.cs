/// <author> Kiwin Bendtsen Andersen </author>

/// <summary>
/// This namespace contains a bad example of liskovs substitution principle.
/// 
/// This example is bad because we can't use the robot duck, which inherits from 'Duck', 
/// as a duck without the program running into unexpected errors. 
/// Therefore it violates liskovs substitution principle.
/// 
/// </summary>
namespace liskovSubstitutionPrinciple.BadExample
{

    public class Duck
    {

        public int Happiness { get; set; }
        public int Energy { get; set; }
        public int Satiety { get; set; }

        public virtual void Fly()
        {
            /* Fly code */
            Energy -= 5;
        }

        public virtual void Swim()
        {
            /* Swim code */
            Energy -= 2;
        }

        public virtual void Sleep()
        {
            Energy += Satiety;
            Satiety = 0;
        }

        public virtual void EatFood()
        {
            Satiety += 10;
            Happiness += 1;
        }
    }

    public class RobotDuck : Duck
    {

        public override void EatFood()
        {
            throw new Exception("Neutrient neglected! - Robot duck does not need food.");
        }

        public override void Sleep()
        {
            throw new Exception("Sleep neglected! - Robot duck does not need sleep.");
        }

        public void Recharge()
        {
            Energy += 10;
        }
    }

    public class CareTaker
    {
        public void FeedPet(Duck pet)
        {
            pet.EatFood();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck monty = new Duck();
            Duck robert = new RobotDuck();

            CareTaker kate = new CareTaker();

            kate.FeedPet(monty);
            kate.FeedPet(robert);
        }
    }

}

/// <summary>
/// This namespace contains a good example of liskovs substitution principle.
/// 
/// There are many solutions to -, and decisions on, fixing the problem from the previous example.
/// In this example we better the program by segregating some functionality of the duck into some higher stuctures.
/// A Robotduck is not a duck. Therefore it shouldn't inherit from 'Duck'. 
/// It can fly though, and it does share some properties with the duck. 
/// Therefore we extract these features into interfaces.
/// 
/// The takeaway conclusion is that the RobotDuck never was a subtype of Duck.
/// 
/// </summary>
namespace liskovSubstitutionPrinciple.GoodExample
{

    public interface IRecharge
    {
        public void Recharge();
    }

    public abstract class Duckboid : IFly, ISwim
    {
        public int Energy { get; set; }

        public virtual void Fly()
        {
            /* Fly code */
            Energy -= 5;
        }

        public virtual void Swim()
        {
            /* Swim code */
            Energy -= 2;
        }
    }

    public class Duck : Duckboid
    {

        public int Happiness { get; set; }
        public int Satiety { get; set; }

        public virtual void Sleep()
        {
            Energy += Satiety;
            Satiety = 0;
        }

        public virtual void EatFood()
        {
            Satiety += 10;
            Happiness += 1;
        }
    }

    public class RobotDuck : Duckboid, IRecharge
    {
        public void Recharge()
        {
            Energy += 10;
        }
    }

    public class CareTaker
    {
        public void FeedPet(Duck pet)
        {
            pet.EatFood();
        }
        public void RechargeDevice(IRecharge device)
        {
            device.Recharge();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck monty = new Duck();
            RobotDuck robert = new RobotDuck();

            CareTaker kate = new CareTaker();

            kate.FeedPet(monty);
            kate.RechargeDevice(robert);
        }
    }

}
