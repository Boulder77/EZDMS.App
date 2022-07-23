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

            NumberOfDoors = new TextInputViewModel { Label = "Number Of Doors", Text = "myNumberOfDoors" };
            Cylinders = new TextInputViewModel { Label = "Cylinders", Text = "myCylinders" };
            FuelType = new TextInputViewModel { Label = "Fuel Type", Text = "myFuelType" };
            FuelSystem = new TextInputViewModel { Label = "Fuel System", Text = "myFuelSystem" };
            FuelEconomy = new TextInputViewModel { Label = "Fuel Economy", Text = "myFuelEconomy" };
            TransmissionType = new TextInputViewModel { Label = "Transmission Type", Text = "myTransmissionType" };
            TransmissionSpeed = new TextInputViewModel { Label = "Transmission Speed", Text = "myTransmissionSpeed" };
            Drivetrain = new TextInputViewModel { Label = "Drivetrain", Text = "myDrivetrain" };
            Engine = new TextInputViewModel { Label = "Engine", Text = "myEngine" };
            EngineType = new TextInputViewModel { Label = "Engine Type", Text = "myEngineType" };
            EngineSerialNumber = new TextInputViewModel { Label = "Engine Serial Number", Text = "myEngineSerialNumber" };
            IgnitionKeyCode = new TextInputViewModel { Label = "Ignition Key Code", Text = "myIgnitionKeyCode" };
            TrunkKeyCode = new TextInputViewModel { Label = "Trunk Key Code", Text = "myTrunkKeyCode" };
            Weight = new TextInputViewModel { Label = "Weight", Text = "myWeight" };
            LicensePlate = new TextInputViewModel { Label = "License Plate", Text = "myLicensePlate" };
            LicenseState = new TextInputViewModel { Label = "License State", Text = "myLicenseState" };
            LicenseExpirationDate = new DateSelectionViewModel { Label = "License Expiration Date", Date = Convert.ToDateTime("02/05/1991") };
            LotLocation = new TextInputViewModel { Label = "Lot Location", Text = "myLotLocation" };
            Style = new TextInputViewModel { Label = "Style", Text = "myStyle" };
            ModelCode = new TextInputViewModel { Label = "Model Code", Text = "myModelCode" };
        }

        #endregion
    }
}
