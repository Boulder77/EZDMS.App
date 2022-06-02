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

            NumberOfDoors = new TextEntryViewModel { Label = "Number Of Doors", OriginalText = "myNumberOfDoors" };
            Cylinders = new TextEntryViewModel { Label = "Cylinders", OriginalText = "myCylinders" };
            FuelType = new TextEntryViewModel { Label = "Fuel Type", OriginalText = "myFuelType" };
            FuelSystem = new TextEntryViewModel { Label = "Fuel System", OriginalText = "myFuelSystem" };
            FuelEconomy = new TextEntryViewModel { Label = "Fuel Economy", OriginalText = "myFuelEconomy" };
            TransmissionType = new TextEntryViewModel { Label = "Transmission Type", OriginalText = "myTransmissionType" };
            TransmissionSpeed = new TextEntryViewModel { Label = "Transmission Speed", OriginalText = "myTransmissionSpeed" };
            Drivetrain = new TextEntryViewModel { Label = "Drivetrain", OriginalText = "myDrivetrain" };
            Engine = new TextEntryViewModel { Label = "Engine", OriginalText = "myEngine" };
            EngineType = new TextEntryViewModel { Label = "Engine Type", OriginalText = "myEngineType" };
            EngineSerialNumber = new TextEntryViewModel { Label = "Engine Serial Number", OriginalText = "myEngineSerialNumber" };
            IgnitionKeyCode = new TextEntryViewModel { Label = "Ignition Key Code", OriginalText = "myIgnitionKeyCode" };
            TrunkKeyCode = new TextEntryViewModel { Label = "Trunk Key Code", OriginalText = "myTrunkKeyCode" };
            Weight = new TextEntryViewModel { Label = "Weight", OriginalText = "myWeight" };
            LicensePlate = new TextEntryViewModel { Label = "License Plate", OriginalText = "myLicensePlate" };
            LicenseState = new TextEntryViewModel { Label = "License State", OriginalText = "myLicenseState" };
            LicenseExpirationDate = new DateSelectionViewModel { Label = "License Expiration Date", Date = Convert.ToDateTime("02/05/1991") };
            LotLocation = new TextEntryViewModel { Label = "Lot Location", OriginalText = "myLotLocation" };
            Style = new TextEntryViewModel { Label = "Style", OriginalText = "myStyle" };
            ModelCode = new TextEntryViewModel { Label = "Model Code", OriginalText = "myModelCode" };
        }

        #endregion
    }
}
