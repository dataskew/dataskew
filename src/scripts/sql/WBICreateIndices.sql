USE finskewdb
GO

-- WBI indices --

CREATE NONCLUSTERED INDEX IX_WBICountries_CountryName
	ON WBICountries(CountryName)
GO