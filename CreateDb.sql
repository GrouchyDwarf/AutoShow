CREATE TABLE CarBrand
(
	CarBrandId           INTEGER IDENTITY(1,1) NOT NULL,
	CarBrandName         VARCHAR(30) NOT NULL,
	PRIMARY KEY (CarBrandId),
	CONSTRAINT UC_CarBrand UNIQUE(CarBrandName)
);



CREATE TABLE Country
(
	CountryId            INTEGER IDENTITY(1,1) NOT NULL,
	CountryName          VARCHAR(30) NOT NULL,
	PRIMARY KEY (CountryId),
	CONSTRAINT UC_Country UNIQUE(CountryName)
);



CREATE TABLE BodyType
(
	BodyTypeId           INTEGER IDENTITY(1,1) NOT NULL,
	BodyTypeName         VARCHAR(30) NOT NULL,
	PRIMARY KEY (BodyTypeID),
	CONSTRAINT UC_BodyType UNIQUE(BodyTypeName)
);



CREATE TABLE EngineType
(
	EngineTypeId         INTEGER IDENTITY(1,1) NOT NULL,
	EngineTypeName       VARCHAR(30) NOT NULL,
	PRIMARY KEY (EngineTypeId),
	CONSTRAINT UC_EngineType UNIQUE(EngineTypeName)
);



CREATE TABLE EngineLocation
(
	EngineLocationId     INTEGER IDENTITY(1,1) NOT NULL,
	EngineLocationName   VARCHAR(30) NOT NULL,
	PRIMARY KEY (EngineLocationId),
	CONSTRAINT UC_EngineLocation UNIQUE(EngineLocationName)
);



CREATE TABLE TechnicalInformation
(
	TechnicalInformationId INTEGER IDENTITY(1,1) NOT NULL,
	BodyTypeId           INTEGER NOT NULL,
	DoorsAmount          INTEGER NOT NULL,
	SeatsAmount          INTEGER NOT NULL,
	EngineDisplacement   INTEGER NOT NULL,
	EngineTypeId         INTEGER NOT NULL,
	EngineLocationId     INTEGER NOT NULL,
	PRIMARY KEY (TechnicalInformationId),
	Constraint UC_TechnicalInformation UNIQUE(BodyTypeId,DoorsAmount,SeatsAmount,EngineDisplacement,
	                                          EngineTypeId,EngineLocationId),
	CONSTRAINT R_2 FOREIGN KEY (BodyTypeId) REFERENCES BodyType (BodyTypeId),
	CONSTRAINT R_3 FOREIGN KEY (EngineTypeId) REFERENCES EngineType (EngineTypeId),
	CONSTRAINT R_4 FOREIGN KEY (EngineLocationId) REFERENCES EngineLocation (EngineLocationId)
);



CREATE TABLE CarModel
(
	CarModelId           INTEGER IDENTITY(1,1) NOT NULL,
	CarModelName         VARCHAR(30) NOT NULL,
	CarBrandId           INTEGER NOT NULL,
	CountryId            INTEGER NOT NULL,
	TechnicalInformationId INTEGER NOT NULL,
	PRIMARY KEY (CarModelId),
	CONSTRAINT UC_CarModel UNIQUE(CarModelName,CarBrandId,CountryId,TechnicalInformationId),
	CONSTRAINT R_23 FOREIGN KEY (CarBrandId) REFERENCES CarBrand (CarBrandId),
	CONSTRAINT R_26 FOREIGN KEY (CountryId) REFERENCES Country (CountryId),
	CONSTRAINT R_40 FOREIGN KEY (TechnicalInformationId) REFERENCES TechnicalInformation (TechnicalInformationId)
);



CREATE TABLE Colour
(
	ColourId             INTEGER IDENTITY(1,1) NOT NULL,
	ColourName           VARCHAR(30) NOT NULL,
	PRIMARY KEY (ColourId),
	CONSTRAINT UC_Colour UNIQUE(ColourName)
);



CREATE TABLE PaintedModel
(
    PaintedModelId       INTEGER IDENTITY(1,1) NOT NULL,
	CarModelId           INTEGER NOT NULL,
	ColourId             INTEGER NOT NULL,
	PRIMARY KEY (PaintedModelId),
	CONSTRAINT UC_PaintedModel UNIQUE(CarModelId,ColourId),
	CONSTRAINT R_37 FOREIGN KEY (CarModelId) REFERENCES CarModel (CarModelId),
	CONSTRAINT R_38 FOREIGN KEY (ColourId) REFERENCES Colour (ColourId)
);



CREATE TABLE Product
(
	ProductId            INTEGER IDENTITY(1,1) NOT NULL,
	PaintedModelId       INTEGER NOT NULL,
	Markup               DECIMAL(19,4) NOT NULL,
	PRIMARY KEY (ProductId),
	CONSTRAINT UC_Product UNIQUE(PaintedModelId),
	CONSTRAINT R_39 FOREIGN KEY (PaintedModelId) REFERENCES PaintedModel (PaintedModelId)
);



CREATE TABLE Warehouse
(
	ProductId            INTEGER NOT NULL,
	Quantity             INTEGER NOT NULL,
	Price                DECIMAL(19,4) NOT NULL
	PRIMARY KEY (ProductId),
	CONSTRAINT UC_Warehouse UNIQUE(ProductId),
	CONSTRAINT R_33 FOREIGN KEY (ProductId) REFERENCES Product (ProductId)
);



CREATE TABLE Provider
(
	ProviderId           INTEGER IDENTITY(1,1) NOT NULL,
	FirstName            VARCHAR(20) NOT NULL,
	LastName             VARCHAR(20) NOT NULL,
	Password             VARCHAR(20) NOT NULL,
	PRIMARY KEY (ProviderId),
	CONSTRAINT UC_Provider UNIQUE(FirstName,LastName)
);



CREATE TABLE Supply
(
	ProductId            INTEGER NOT NULL,
	SupplyDate           DATE NOT NULL,
	Quantity             INTEGER NOT NULL,
	ProviderId           INTEGER NOT NULL,
	Price                DECIMAL(19,4) NOT NULL,
	SupplyId             INTEGER IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (SupplyId),
	CONSTRAINT UC_Supply UNIQUE(ProviderId,SupplyDate),
	CONSTRAINT R_27 FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	CONSTRAINT R_28 FOREIGN KEY (ProviderId) REFERENCES Provider (ProviderId)
);



CREATE TABLE Admin
(
	AdminId              INTEGER IDENTITY(1,1) NOT NULL,
	FirstName            VARCHAR(20) NOT NULL,
	LastName             VARCHAR(20) NOT NULL,
	Password             VARCHAR(20) NOT NULL,
	PRIMARY KEY (AdminId),
	CONSTRAINT UC_Admin UNIQUE(FirstName,LastName)
);



CREATE TABLE PaymentType
(
	PaymentTypeId        INTEGER IDENTITY(1,1) NOT NULL,
	PaymentTypeName      VARCHAR(30) NOT NULL,
	PRIMARY KEY (PaymentTypeId),
	CONSTRAINT UC_PaymentType UNIQUE(PaymentTypeName)
);



CREATE TABLE Client
(
	Address              VARCHAR(30) NULL,
	FirstName            VARCHAR(20) NOT NULL,
	LastName             VARCHAR(20) NOT NULL,
	ClientId             INTEGER IDENTITY(1,1) NOT NULL,
	PassportId           INTEGER NOT NULL,
	PassportSeries       INTEGER NOT NULL,
	Password             VARCHAR(20) NOT NULL,
	Phone                VARCHAR(20) NOT NULL,
	Email                VARCHAR(30) NULL,
	Discount             DECIMAL(19,4) NOT NULL,
	PRIMARY KEY (ClientId),
	CONSTRAINT UC_Client_Pasport UNIQUE(PassportId),
	CONSTRAINT UC_Client_FirstName_LastName UNIQUE(FirstName,LastName)
);



CREATE TABLE Manager
(
	ManagerId            INTEGER IDENTITY(1,1) NOT NULL,
	FirstName            VARCHAR(20) NOT NULL,
	LastName             VARCHAR(20) NOT NULL,
	Password             VARCHAR(20) NOT NULL,
	PRIMARY KEY (ManagerId),
	CONSTRAINT UC_Manager UNIQUE(FirstName, LastName)
);



CREATE TABLE Purchase
(
	PurchaseDate         DATE NOT NULL,
	Delivery             BIT NOT NULL,
	PaymentTypeId        INTEGER NOT NULL,
	PaymentDate          DATE NOT NULL,
	ClientId             INTEGER NOT NULL,
	Price                DECIMAL(19,4) NOT NULL,
	ManagerId            INTEGER NOT NULL,
	ProductId            INTEGER NOT NULL,
	PurchaseId           INTEGER IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (PurchaseId),
	CONSTRAINT UC_Purchase UNIQUE(PurchaseDate,ClientId,ProductId),
	CONSTRAINT R_12 FOREIGN KEY (PaymentTypeId) REFERENCES PaymentType (PaymentTypeId),
	CONSTRAINT R_15 FOREIGN KEY (ClientId) REFERENCES Client (ClientId),
	CONSTRAINT R_29 FOREIGN KEY (ManagerId) REFERENCES Manager (ManagerId),
	CONSTRAINT R_35 FOREIGN KEY (ProductId) REFERENCES Product (ProductId)
);