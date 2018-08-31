USE finskewdb
GO

-- AMFI views --

CREATE VIEW NAVS_52WeekLowHigh
AS
    SELECT
        SchemeCode,
        MIN(NAV) AS [52WeekLow],
        MAX(NAV) AS [52WeekHigh]
    FROM NAVs
    WHERE (
	ReportingDate >= CONVERT(date, DATEADD(YEAR, -1, GETDATE())) AND
        ReportingDate <= CONVERT(date, GETDATE()))
    GROUP BY SchemeCode
GO

CREATE VIEW NAVs_Current
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, GETDATE())
GO

CREATE VIEW NAVs_NinetyDaysAgo
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, DATEADD(DAY, -90, GETDATE()))
GO

CREATE VIEW NAVs_OneEightyDaysAgo
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, DATEADD(DAY, -180, GETDATE()))
GO

CREATE VIEW NAVs_OneYearAgo
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, DATEADD(YEAR, -1, GETDATE()))
GO

CREATE VIEW NAVs_ThreeYearsAgo
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, DATEADD(YEAR, -3, GETDATE()))
GO

CREATE VIEW NAVs_FiveYearsAgo
AS
    SELECT
        SchemeCode,
        NAV,
        ReportingDate
    FROM NAVs
    WHERE ReportingDate = CONVERT(date, DATEADD(YEAR, -5, GETDATE()))
GO