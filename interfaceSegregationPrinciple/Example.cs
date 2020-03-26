/// <author> Kiwin Bendtsen Andersen </author>

/// <summary>
/// This namespace contains a bad example of the interface segregation principle.
/// 
/// The example code is bad because the 'Pinguin', 'FlyingFish' and 'Bat'
/// all implement the IAnimal class which forces them to implement functions they don't need.
/// </summary>
namespace interfaceSegregationPrinciple.BadExample
{

    /// <summary>
    /// Interface for a walk-able, swim-able and fly-able entity.
    /// </summary>
    public interface IAnimal
    {
        public void Walk();
        public void Swim();
        public void Fly();
    }

    /// <summary>
    /// Class representing a pinguin.
    /// </summary>
    public class Pinguin : IAnimal
    {
        public void Walk() { /* Walk code */ }
        public void Swim() { /* Swim code */ }
        public void Fly() {} //Empty implementation.
    }

    /// <summary>
    /// Class representing a flying fish (Exocoetidae).
    /// </summary>
    public class FlyingFish : IAnimal
    {
        public void Walk() { } //Empty implementation.
        public void Swim() { /* Swim code */ }
        public void Fly() { /* Fly code */ }
    }

    /// <summary>
    /// Class representing a bat.
    /// </summary>
    public class Bat : IAnimal
    {
        public void Walk() { /* Walk code */ }
        public void Swim() { } //Empty implementation.
        public void Fly() { /* Fly code */ }
    }

}

/// <summary>
/// This namespace contains a good example of the interface segregation principle.
/// 
/// The example code is better because the 'Pinguin', 'FlyingFish' and 'Bat'
/// are not forced to implement functions they don't need. This was done by enforcing 
/// the 'Interface Segregation Principle', by splitting the 'IAnimal' interface into 
/// three role interfaces: 'IWalk', 'ISwim', and 'IFly'.
/// </summary>
namespace interfaceSegregationPrinciple.GoodExample
{
    /// <summary>
    /// Role interface for a walk-able entity.
    /// </summary>
    public interface IWalk
    {
        public void Walk();
    }

    /// <summary>
    /// Role interface for a swim-able entity.
    /// </summary>
    public interface ISwim
    {
        public void Swim();
    }

    /// <summary>
    /// Role interface for a fly-able entity.
    /// </summary>
    public interface IFly
    {
        public void Fly();
    }

    /// <summary>
    /// Class representing a pinguin (Exocoetidae).
    /// </summary>
    public class Pinguin : IWalk, ISwim
    {
        public void Walk() { /* Walk code */ }
        public void Swim() { /* Swim code */ }
    }

    /// <summary>
    /// Class representing a flying fish (Exocoetidae).
    /// </summary>
    public class FlyingFish : ISwim, IFly
    {
        public void Swim() { /* Swim code */ }
        public void Fly() { /* Fly code */ }
    }

    /// <summary>
    /// Class representing a bat.
    /// </summary>
    public class Bat : IWalk, IFly
    {
        public void Walk() { /* Walk code */ }
        public void Fly() { /* Fly code */ }
    }

}
