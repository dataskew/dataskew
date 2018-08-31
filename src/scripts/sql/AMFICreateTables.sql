USE finskewdb
GO

-- AMFI tables --

CREATE TABLE AMCs
(
    AMCId
        int
        not null
        identity
        primary key,
    AMCName
        varchar(255)
        not null
        unique,
    AMCNotes
        varchar(255)
)
GO

CREATE TABLE SchemeTypes
(
    SchemeTypeId
        int
        not null
        identity
        primary key,
    SchemeTypeName
        varchar(64)
        not null
        unique,
)
GO

CREATE TABLE SchemeCategories
(
    SchemeCategoryId
        int
        not null
        identity
        primary key,
    SchemeCategoryName
        varchar(255)
        not null
        unique,
)
GO

CREATE TABLE Schemes
(
    SchemeCode
        int
        not null
        primary key,
    SchemeName
        varchar(255)
        not null,
    SchemeNAVName
        varchar(255)
        not null,
    SchemeMinAmountNotes
        varchar(255),
    SchemeLaunchDate
        datetime,
    SchemeClosureDate
        datetime,
    SchemeISIN
        varchar(32),
    SlopeFiveYears
        decimal(19,10),
    SlopeThreeYears
        decimal(19,10),
    SlopeEighteenMonths
        decimal(19,10),
    SlopeTwelveMonths
        decimal(19,10),
    SlopeNineMonths
        decimal(19,10),
    SlopeSixMonths
        decimal(19,10),
    SlopeThreeMonths
        decimal(19,10),
    SlopeFourWeeks
        decimal(19,10),
    SlopeThreeWeeks
        decimal(19,10),
    SlopeTwoWeeks
        decimal(19,10),
    SlopeOneWeek
        decimal(19,10),
    LastUpdated
        datetime,
    AMCId
        int
        not null
        foreign key references AMCs(AMCId),
    SchemeTypeId
        int
        not null
        foreign key references SchemeTypes(SchemeTypeId),
    SchemeCategoryId
        int
        not null
        foreign key references SchemeCategories(SchemeCategoryId)
)
GO

CREATE TABLE NAVs
(
    ReportingDate
        datetime
        not null,
    SchemeCode
        int
        not null
        foreign key references Schemes(SchemeCode),
    NAV
        decimal(19,4)
        not null,
    RepurchasePrice
        decimal(19,4)
        not null,
    SalePrice
        decimal(19,4)
        not null,
    primary key (ReportingDate, SchemeCode)
)
GO

-- AMFI staging tables --

CREATE TABLE AMFIStaging_AMCs
(
    AMCName
        varchar(255)
        not null
        primary key
)
GO

CREATE TABLE AMFIStaging_SchemeTypes
(
    SchemeTypeName
        varchar(64)
        not null
        primary key,
)
GO

CREATE TABLE AMFIStaging_Schemes
(
    SchemeCode
        int
        not null
        primary key,
    SchemeName
        varchar(255)
        not null,
    SchemeNAVName
        varchar(255)
        not null,
    SchemeMinAmountNotes
        varchar(255),
    SchemeLaunchDate
        datetime,
    SchemeClosureDate
        datetime,
    SchemeISIN
        varchar(32),
    AMCId
        int
        not null
        foreign key references AMCs(AMCId),
    SchemeTypeId
        int
        not null
        foreign key references SchemeTypes(SchemeTypeId),
    SchemeCategoryId
        int
        not null
        foreign key references SchemeCategories(SchemeCategoryId)
)
GO

CREATE TABLE AMFIStaging_SchemeCategories
(
    SchemeCategoryName
        varchar(255)
        not null
        primary key,
)
GO

CREATE TABLE AMFIStaging_NAVs
(
    ReportingDate
        datetime
        not null,
    SchemeCode
        int
        not null
        foreign key references Schemes(SchemeCode),
    NAV
        decimal(19,4)
        not null,
    RepurchasePrice
        decimal(19,4)
        not null,
    SalePrice
        decimal(19,4)
        not null,
    primary key (ReportingDate, SchemeCode)
)
GO