USE finskewdb
GO

-- WBI tables -- 

CREATE TABLE WBICatalogSources
(
    Id
        int
        not null
        primary key,
    Code
        varchar(3)
        not null
        unique,
    Lastupdated
        datetime,
    CatalogSourceName
        varchar(255),
    CatalogSourceDescription
        varchar(255),
    CatalogSourceUrl
        varchar(255),
    DataAvailability
        bit,
    MetaDataAvailability
        bit
)
GO

CREATE TABLE WBICountries
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    CountryName
        varchar(255)
        not null,
    CapitalCity
        varchar(255),
    RegionCode
        varchar(3)
        foreign key references WBIRegions(Code),
    AdminRegionId
        varchar(3),
    AdminRegionIso2Code
        varchar(2),
    AdminRegionValue
        varchar(64),
    IncomeLevelId
        varchar(3)
        foreign key references WBIIncomeLevels(Id),
    LendingTypeId
        varchar(3)
        foreign key references WBILendingTypes(Id),
    Longitude
        decimal(18,10),
    Latitude
        decimal(18,10)
)
GO

CREATE TABLE WBIIncomeLevels
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    IncomeLevelValue
        varchar(64)
)
GO

CREATE TABLE WBIIndicators
(
    Id
        varchar(64)
        not null
        primary key,
    IndicatorName
        varchar(255),
    SourceId
        int
        not null
        foreign key references WBICatalogSources(Id),
    SourceNote
        varchar(4096),
    SourceOrganization
        varchar(2048),
    Unit
        varchar(10),
    LastETLUpdate
        datetime
)
GO

CREATE TABLE WBILendingTypes
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    LendingTypeValue
        varchar(64)
)
GO

CREATE TABLE WBIRegions
(
    Code
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    Id
        int,
    RegionName
        varchar(255)
)
GO

CREATE TABLE WBITopics
(
    Id
        int
        not null
        primary key,
    TopicValue
        varchar(255)
        not null,
    SourceNote
        varchar(2048)
        not null
)
GO

-- WBI staging tables --

CREATE TABLE WBIStaging_WBICatalogSources
(
    Id
        int
        not null
        primary key,
    Code
        varchar(3)
        not null
        unique,
    Lastupdated
        datetime,
    CatalogSourceName
        varchar(255),
    CatalogSourceDescription
        varchar(255),
    CatalogSourceUrl
        varchar(255),
    DataAvailability
        bit,
    MetaDataAvailability
        bit
)
GO

CREATE TABLE WBIStaging_WBICountries
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    CountryName
        varchar(255)
        not null,
    CapitalCity
        varchar(255),
    RegionCode
        varchar(3)
        foreign key references WBIRegions(Code),
    AdminRegionId
        varchar(3),
    AdminRegionIso2Code
        varchar(2),
    AdminRegionValue
        varchar(64),
    IncomeLevelId
        varchar(3)
        foreign key references WBIIncomeLevels(Id),
    LendingTypeId
        varchar(3)
        foreign key references WBILendingTypes(Id),
    Longitude
        decimal(18,10),
    Latitude
        decimal(18,10)
)
GO

CREATE TABLE WBIStaging_WBIIncomeLevels
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    IncomeLevelValue
        varchar(64)
)
GO

CREATE TABLE WBIStaging_WBIIndicators
(
    Id
        varchar(64)
        not null
        primary key,
    IndicatorName
        varchar(255),
    SourceId
        int
        not null
        foreign key references WBICatalogSources(Id),
    SourceNote
        varchar(4096),
    SourceOrganization
        varchar(2048),
    Unit
        varchar(10),
    LastETLUpdate
        datetime
)
GO

CREATE TABLE WBIStaging_WBILendingTypes
(
    Id
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    LendingTypeValue
        varchar(64)
)
GO

CREATE TABLE WBIStaging_WBIRegions
(
    Code
        varchar(3)
        not null
        primary key,
    Iso2Code
        varchar(2)
        not null
        unique,
    Id
        int,
    RegionName
        varchar(255)
)
GO

CREATE TABLE WBIStaging_WBITopics
(
    Id
        int
        not null
        primary key,
    TopicValue
        varchar(255)
        not null,
    SourceNote
        varchar(2048)
        not null
)
GO