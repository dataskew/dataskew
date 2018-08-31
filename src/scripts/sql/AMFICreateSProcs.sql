USE finskewdb
GO

-- AMFI stored procs --

CREATE PROCEDURE uspUpsertAMFIAMCs
AS
MERGE [AMCs] as target1
	USING [AMFIStaging_AMCs] as staging1
	ON target1.AMCName = staging1.AMCName
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (AMCName) 
		VALUES (staging1.AMCName);
DELETE FROM [AMFIStaging_AMCs];
GO

CREATE PROCEDURE uspUpsertAMFINAVs
AS
MERGE [NAVs] as target1
	USING [AMFIStaging_NAVs] as staging1
	ON target1.ReportingDate = staging1.ReportingDate AND target1.SchemeCode = staging1.SchemeCode
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
		(
			ReportingDate,
			SchemeCode,
			NAV,
			RepurchasePrice,
			SalePrice
		) 
		VALUES 
		(
			ReportingDate,
			SchemeCode,
			NAV,
			RepurchasePrice,
			SalePrice
		);
DELETE FROM [AMFIStaging_NAVs];
GO

CREATE PROCEDURE uspUpsertAMFISchemeCategories
AS
MERGE [SchemeCategories] as target1
	USING [AMFIStaging_SchemeCategories] as staging1
	ON target1.SchemeCategoryName = staging1.SchemeCategoryName
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
		VALUES (staging1.SchemeCategoryName);
DELETE FROM [AMFIStaging_SchemeCategories];
GO

CREATE PROCEDURE uspUpsertAMFISchemes
AS
MERGE [Schemes] as target1
	USING [AMFIStaging_Schemes] as staging1
	ON target1.SchemeCode = staging1.SchemeCode
	WHEN MATCHED THEN
		UPDATE 
		SET
			target1.SchemeName = staging1.SchemeName,
			target1.SchemeNAVName = staging1.SchemeNAVName,
			target1.SchemeMinAmountNotes = staging1.SchemeMinAmountNotes,
			target1.SchemeLaunchDate = staging1.SchemeLaunchDate,
			target1.SchemeClosureDate = staging1.SchemeClosureDate,
			target1.SchemeISIN = staging1.SchemeISIN,
			target1.AMCId = staging1.AMCId,
			target1.SchemeTypeId = staging1.SchemeTypeId,
			target1.SchemeCategoryId = staging1.SchemeCategoryId
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
		(
			SchemeCode,
			SchemeName,
			SchemeNAVName,
			SchemeMinAmountNotes,
			SchemeLaunchDate,
			SchemeClosureDate,
			SchemeISIN,
			AMCId,
			SchemeTypeId,
			SchemeCategoryId
		)
		VALUES 
		(
			SchemeCode,
			SchemeName,
			SchemeNAVName,
			SchemeMinAmountNotes,
			SchemeLaunchDate,
			SchemeClosureDate,
			SchemeISIN,
			AMCId,
			SchemeTypeId,
			SchemeCategoryId
		);
DELETE FROM [AMFIStaging_Schemes];
GO

CREATE PROCEDURE uspUpsertAMFISchemeTypes
AS
MERGE [SchemeTypes] as target1
	USING [AMFIStaging_SchemeTypes] as staging1
	ON target1.SchemeTypeName = staging1.SchemeTypeName
	WHEN NOT MATCHED BY TARGET THEN
		INSERT 
		VALUES (staging1.SchemeTypeName);
DELETE FROM [AMFIStaging_SchemeTypes];
GO