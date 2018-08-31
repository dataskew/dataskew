USE finskewdb
GO

-- AMFI indices --

CREATE NONCLUSTERED INDEX IX_AMCs_AMCName 
	ON AMCs(AMCName)
GO

CREATE NONCLUSTERED INDEX IX_NAVs_SchemeCode 
	ON NAVs(SchemeCode)   
GO

CREATE NONCLUSTERED INDEX IX_NAVs_ReportingDate 
	ON NAVs(ReportingDate)   
GO

CREATE NONCLUSTERED INDEX IX_NAVs_SchemeCode_ReportingDate 
	ON NAVs(SchemeCode, ReportingDate)
	INCLUDE(NAV,RepurchasePrice,SalePrice)
GO

CREATE NONCLUSTERED INDEX IX_SchemeCategories_SchemeCategoryName 
	ON SchemeCategories(SchemeCategoryName)   
GO

CREATE NONCLUSTERED INDEX IX_SchemeTypes_SchemeTypeName 
	ON SchemeTypes(SchemeTypeName)   
GO