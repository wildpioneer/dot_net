namespace ChainOfResponsibilities;

public class Mechanic : ServiceHandler
{
    public Mechanic() : base(ServiceRequirements.EngineTune)
    {
    }
}