namespace ChainOfResponsibilities;

public class Detailer : ServiceHandler
{
    public Detailer() : base(ServiceRequirements.Dirty)
    {
    }
}