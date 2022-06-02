using System.Collections.Generic;
using System;
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// The design-time data for a <see cref="VehicleDetailsViewModel"/>
    /// <summary>
    public class VehicleDetailsDesignModel : VehicleDetailsViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// <summary>
        public static VehicleDetailsDesignModel Instance => new VehicleDetailsDesignModel();
    
#endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// <summary>
public VehicleDetailsDesignModel()
        {

            NumberOfDoors = new TextEntryViewModel { Label = "NumberOfDoors", OriginalText = "myNumberOfDoors" };
            Cylinders = new TextEntryViewModel { Label = "Cylinders", OriginalText = "myCylinders" };
            FuelType = new TextEntryViewModel { Label = "FuelType", OriginalText = "myFuelType" };
            FuelSystem = new TextEntryViewModel { Label = "FuelSystem", OriginalText = "myFuelSystem" };
            FuelEconomy = new TextEntryViewModel { Label = "FuelEconomy", OriginalText = "myFuelEconomy" };
            TransmissionType = new TextEntryViewModel { Label = "TransmissionType", OriginalText = "myTransmissionType" };
            TransmissionSpeed = new TextEntryViewModel { Label = "TransmissionSpeed", OriginalText = "myTransmissionSpeed" };
            Drivetrain = new TextEntryViewModel { Label = "Drivetrain", OriginalText = "myDrivetrain" };
            Engine = new TextEntryViewModel { Label = "Engine", OriginalText = "myEngine" };
            EngineType = new TextEntryViewModel { Label = "EngineType", OriginalText = "myEngineType" };
            EngineSerialNumber = new TextEntryViewModel { Label = "EngineSerialNumber", OriginalText = "myEngineSerialNumber" };
            IgnitionKeyCode = new TextEntryViewModel { Label = "IgnitionKeyCode", OriginalText = "myIgnitionKeyCode" };
            TrunkKeyCode = new TextEntryViewModel { Label = "TrunkKeyCode", OriginalText = "myTrunkKeyCode" };
            Weight = new TextEntryViewModel { Label = "Weight", OriginalText = "myWeight" };
            LicensePlate = new TextEntryViewModel { Label = "LicensePlate", OriginalText = "myLicensePlate" };
            LicenseState = new TextEntryViewModel { Label = "LicenseState", OriginalText = "myLicenseState" };
            LicenseExpirationDate = new DateSelectionViewModel { Label = "LicenseExpirationDate", Date = Convert.ToDateTime("02/05/1991") };
            LotLocation = new TextEntryViewModel { Label = "LotLocation", OriginalText = "myLotLocation" };
            Style = new TextEntryViewModel { Label = "Style", OriginalText = "myStyle" };
            ModelCode = new TextEntryViewModel { Label = "ModelCode", OriginalText = "myModelCode" };
        }

        #endregion
    }
}
