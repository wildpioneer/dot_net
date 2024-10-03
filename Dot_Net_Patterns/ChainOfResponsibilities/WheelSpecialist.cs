namespace ChainOfResponsibilities;

public class WheelSpecialist : ServiceHandler
{
    public WheelSpecialist() : base(ServiceRequirements.WheelAlignment)
    {
    }
}