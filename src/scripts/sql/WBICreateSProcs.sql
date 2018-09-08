USE finskewdb
GO

-- WBI stored procedures --

CREATE PROCEDURE uspUpsertWBICatalogSources
AS
MERGE [WBICatalogSources] as target1
	USING [WBIStaging_CatalogSources] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.Code = staging1.Code,
			target1.Lastupdated = staging1.Lastupdated,
			target1.CatalogSourceName = staging1.CatalogSourceName,
			target1.CatalogSourceDescription = staging1.CatalogSourceDescription,
			target1.CatalogSourceUrl = staging1.CatalogSourceUrl,
			target1.DataAvailability = staging1.DataAvailability,
			target1.MetaDataAvailability = staging1.MetaDataAvailability
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES
		(
			Id, 
			Code,
			Lastupdated,
			CatalogSourceName,
			CatalogSourceDescription,
			CatalogSourceUrl,
			DataAvailability,
			MetaDataAvailability
		);
DELETE FROM [WBIStaging_CatalogSources];
GO

CREATE PROCEDURE uspUpsertWBICountries
AS
MERGE [WBICountries] as target1
	USING [WBIStaging_Countries] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.Iso2Code = staging1.Iso2Code,
			target1.CountryName = staging1.CountryName,
			target1.CapitalCity = staging1.CapitalCity,
			target1.RegionCode = staging1.RegionCode,
			target1.AdminRegionId = staging1.AdminRegionId,
			target1.AdminRegionIso2Code = staging1.AdminRegionIso2Code,
			target1.AdminRegionValue = staging1.AdminRegionValue,
			target1.IncomeLevelId = staging1.IncomeLevelId,
			target1.LendingTypeId = staging1.LendingTypeId,
			target1.Longitude = staging1.Longitude,
			target1.Latitude = staging1.Latitude
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES
		(
			Id,
			Iso2Code,
			CountryName,
			CapitalCity,
			RegionCode,
			AdminRegionId,
			AdminRegionIso2Code,
			AdminRegionValue,
			IncomeLevelId,
			LendingTypeId,
			Longitude,
			Latitude
		);
DELETE FROM [WBIStaging_Countries];
GO

CREATE PROCEDURE uspUpsertWBIIncomeLevels
AS
MERGE [WBIIncomeLevels] as target1
	USING [WBIStaging_IncomeLevels] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.Iso2Code = staging1.Iso2Code,
			target1.IncomeLevelValue = staging1.IncomeLevelValue
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES(Id, Iso2Code, IncomeLevelValue);
DELETE FROM [WBIStaging_IncomeLevels];
GO

CREATE PROCEDURE uspUpsertWBIIndicators
AS
MERGE [WBIIndicators] as target1
	USING [WBIStaging_Indicators] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.IndicatorName = staging1.IndicatorName,
			target1.SourceId = staging1.SourceId,
			target1.SourceNote = staging1.SourceNote,
			target1.SourceOrganization = staging1.SourceOrganization,
			target1.Unit = staging1.Unit
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		(
			Id,
			IndicatorName,
			SourceId,
			SourceNote,
			SourceOrganization,
			Unit
		)
		VALUES
		(
			Id,
			IndicatorName,
			SourceId,
			SourceNote,
			SourceOrganization,
			Unit
		);
DELETE FROM [WBIStaging_Indicators];
GO

CREATE PROCEDURE uspUpsertWBIIndicatorData
AS
MERGE [WBIIndicatorData] as target1
	USING [WBIStaging_IndicatorData] as staging1
	ON target1.IndicatorId = staging1.IndicatorId AND target1.CountryId = staging1.CountryId AND target1.IndicatorDataDate = staging1.IndicatorDataDate
	WHEN MATCHED THEN
		UPDATE SET
			target1.IndicatorDataValue = staging1.IndicatorDataValue,
			target1.Unit = staging1.Unit,
			target1.ObsStatus = staging1.ObsStatus,
			target1.IndicatorDataDecimal = staging1.IndicatorDataDecimal
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES
		(
			IndicatorId,
			CountryId,
			IndicatorDataDate,
			IndicatorDataValue,
			Unit,
			ObsStatus,
			IndicatorDataDecimal
		);
DELETE FROM [WBIStaging_IndicatorData];
GO

CREATE PROCEDURE uspUpsertWBILendingTypes
AS
MERGE [WBILendingTypes] as target1
	USING [WBIStaging_LendingTypes] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE SET
			target1.Iso2Code = staging1.Iso2Code,
			target1.LendingTypeValue = staging1.LendingTypeValue
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES(Id, Iso2Code, LendingTypeValue);
DELETE FROM [WBIStaging_LendingTypes];
GO

CREATE PROCEDURE uspUpsertWBIRegions
AS
MERGE [WBIRegions] as target1
	USING [WBIStaging_Regions] as staging1
	ON target1.Code = staging1.Code
	WHEN MATCHED THEN
		UPDATE SET
			target1.Iso2Code = staging1.Iso2Code,
			target1.Id = staging1.Id,
			target1.RegionName = staging1.RegionName
	WHEN NOT MATCHED BY TARGET THEN
		INSERT
		VALUES(Code, Iso2Code, Id, RegionName);
DELETE FROM [WBIStaging_Regions];
GO

CREATE PROCEDURE uspUpsertWBITopics
AS
MERGE [WBITopics] as target1
	USING [WBIStaging_Topics] as staging1
	ON target1.Id = staging1.Id
	WHEN MATCHED THEN
		UPDATE 
		SET
			target1.TopicValue = staging1.TopicValue,
			target1.SourceNote = staging1.SourceNote
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
		VALUES (Id, TopicValue, SourceNote);
DELETE FROM [WBIStaging_Topics];
GO