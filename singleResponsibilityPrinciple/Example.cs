/// <author> Kiwin Bendtsen Andersen </author>

/// <summary>
/// This namespace contains a bad example of the single responsability principle.
/// </summary>
namespace SingleResponsabilityPrinciple.BadExample
{
    /// <summary>
    /// This class has way too much responsability.
    /// It contains the functionality of a radio and a gearbox.
    /// 
    /// This is not only bad because of clutter, 
    /// but if a framework or library is built upon the 'Car' class, then
    /// it could be hard or impossible to change the behavior of the radio 
    /// or gearbox code without breaking something else that dependents on the Car class.
    /// </summary>
    public abstract class Car
    {
        public abstract void Accelerate();
        public abstract void Break();
        public abstract void ChangeGearUp();
        public abstract void ChangeGearDown();
        public abstract void ChangeToNextRadioChannel();
        public abstract void ChangeToPreviousRadioChannel();
    }
}

/// <summary>
/// This namespace contains a good example of the single responsability principle.
/// </summary>
namespace SingleResponsabilityPrinciple.GoodExample
{
    /// <summary>
    /// This class now has the responsibility of a car.
    /// It contains references to other classes with their own single responsability.
    /// 
    /// One could even argue the the 'Accelerate' method should be in a 'Motor' class.
    /// </summary>
    public abstract class Car
    {
        public Radio radio;
        public Gearbox gearbox;
        public abstract void Accelerate();
        public abstract void Break();
    }

    /// <summary>
    /// This class' single responsibility is to serve the functionality of a gearbox.
    /// </summary>
    public abstract class Gearbox
    {
        public abstract void ChangeGearUp();
        public abstract void ChangeGearDown();
    }

    /// <summary>
    /// This class' single responsibility is to serve the functionality of a radio.
    /// </summary>
    public abstract class Radio
    {
        public abstract void ChangeToNextRadioChannel();
        public abstract void ChangeToPreviousRadioChannel();
    }
}
