namespace ATTaxonomyTechnicalData
{

    public class TechnicalData
    {
        public string? derivativeId { get; set; }
        public string? generationId { get; set; }
        public string? vehicleType { get; set; }
        public string? make { get; set; }
        public string? model { get; set; }
        public string? generation { get; set; }
        public string? name { get; set; }
        public string? longName { get; set; }
        public string? introduced { get; set; }
        public string? discontinued { get; set; }
        public string? trim { get; set; }
        public string? bodyType { get; set; }
        public string? fuelType { get; set; }
        public string? fuelDelivery { get; set; }
        public string? transmissionType { get; set; }
        public string? drivetrain { get; set; }
        public string? cabType { get; set; }
        public string? wheelbaseType { get; set; }
        public string? roofHeightType { get; set; }
        public int? seats { get; set; }
        public int? doors { get; set; }
        public int? valves { get; set; }
        public int? gears { get; set; }
        public int? cylinders { get; set; }
        public string? cylinderArrangement { get; set; }
        public string? engineMake { get; set; }
        public string? valveGear { get; set; }
        public int? axles { get; set; }
        public string? countryOfOrigin { get; set; }
        public string? driveType { get; set; }
        public bool? startStop { get; set; }
        public int? enginePowerPS { get; set; }
        public int? engineTorqueNM { get; set; }
        public float? engineTorqueLBFT { get; set; }
        public int? co2EmissionGPKM { get; set; }
        public int? topSpeedMPH { get; set; }
        public float? zeroToSixtyMPHSeconds { get; set; }
        public float? zeroToOneHundredKMPHSeconds { get; set; }
        public float? badgeEngineSizeLitres { get; set; }
        public int? engineCapacityCC { get; set; }
        public int? enginePowerBHP { get; set; }
        public float? fuelCapacityLitres { get; set; }
        public string? emissionClass { get; set; }
        public int? owners { get; set; }
        public float? fuelEconomyNEDCExtraUrbanMPG { get; set; }
        public float? fuelEconomyNEDCUrbanMPG { get; set; }
        public float? fuelEconomyNEDCCombinedMPG { get; set; }
        public string? fuelEconomyWLTPLowMPG { get; set; }
        public string? fuelEconomyWLTPMediumMPG { get; set; }
        public string? fuelEconomyWLTPHighMPG { get; set; }
        public string? fuelEconomyWLTPExtraHighMPG { get; set; }
        public float? fuelEconomyWLTPCombinedMPG { get; set; }
        public int? lengthMM { get; set; }
        public int? heightMM { get; set; }
        public int? widthMM { get; set; }
        public int? wheelbaseMM { get; set; }
        public float? bootSpaceSeatsUpLitres { get; set; }
        public float? bootSpaceSeatsDownLitres { get; set; }
        public string? insuranceGroup { get; set; }
        public string? insuranceSecurityCode { get; set; }
        public int? batteryRangeMiles { get; set; }
        public float? batteryCapacityKWH { get; set; }
        public float? batteryUsableCapacityKWH { get; set; }
        public int? minimumKerbWeightKG { get; set; }
        public int? grossVehicleWeightKG { get; set; }
        public int? grossCombinedWeightKG { get; set; }
        public int? grossTrainWeightKG { get; set; }
        public int? boreMM { get; set; }
        public int? strokeMM { get; set; }
        public int? payloadLengthMM { get; set; }
        public int? payloadWidthMM { get; set; }
        public int? payloadHeightMM { get; set; }
        public int? payloadWeightKG { get; set; }
        public float? payloadVolumeCubicMetres { get; set; }
        public bool? rde2Compliant { get; set; }
        public string? sector { get; set; }
        public List<Chargetime>? chargeTimes { get; set; }
        public Oem? oem { get; set; }
    }

    public class Oem
    {
        public string? make { get; set; }
        public string? model { get; set; }
        public string? derivative { get; set; }
        public string? bodyType { get; set; }
        public string? transmissionType { get; set; }
        public string? drivetrain { get; set; }
        public string? wheelbaseType { get; set; }
        public string? roofHeightType { get; set; }
        public string? engineType { get; set; }
        public string? engineTechnology { get; set; }
        public string? engineMarketing { get; set; }
        public string? editionDescription { get; set; }
        public string? colour { get; set; }
    }

    public class Chargetime
    {
        public string? chargerType { get; set; }
        public string? chargerDescription { get; set; }
        public string? chargerSupplyType { get; set; }
        public string? connectorType { get; set; }
        public int? startBatteryPercentage { get; set; }
        public int? endBatteryPercentage { get; set; }
        public int? durationMinutes { get; set; }
    }

}
