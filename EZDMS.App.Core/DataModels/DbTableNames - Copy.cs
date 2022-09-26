using System.ComponentModel;

namespace EZDMS.App.Core
{
    /// <summary>
    /// The types of back adds
    /// </summary>
    public enum BackAddType
    {
        [Description("Dent Protection")]
        Dent,
        [Description("Environmental Protection")]
        Enviromental,
        [Description("Etch")]
        Etch,
        [Description("Glass Protection")]
        Glass,
        [Description("Interior Protection")]
        Interior,
        [Description("Key Replacement")]
        Key,
        [Description("Paint Protection")]
        Paint,
        [Description("Remote Protection")]
        Remote,
        [Description("Road Hazard")]
        RoadHazard,
        [Description("Rust Protection")]
        Rust,
        [Description("Simonize")]
        Simonize,
        [Description("Smart Lease Protection")]
        SmartLease,
        [Description("Theft Deterrent")]
        Theft,
        [Description("Tire & Wheel")]
        TireWheel,
        [Description("Wear Care")]
        WearCare,
        [Description("Windshield Protection")]
        Windshield,
        [Description("Misc")]
        Misc,
        [Description("Credit Guard")]
        CreditGuard,
        [Description("Smart Care")]
        SmartCare,
        [Description("Excess Wear & Use")]
        ExcessWear
        
    }

}
