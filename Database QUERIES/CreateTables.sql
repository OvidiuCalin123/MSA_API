-- Table: Cities
CREATE TABLE Cities (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Primary key with auto-increment
    CityName NVARCHAR(100) NOT NULL,       -- Name of the city
    CityImage VARBINARY(MAX)               -- Image of the city (binary data)
);

-- Table: PetShops (Pet Shops in the city)
CREATE TABLE PetShops (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Primary key with auto-increment
    CityID INT NOT NULL,                      -- Foreign key referencing Cities
    PetShopName NVARCHAR(100) NOT NULL,       -- Name of the pet shop
    PetShopImage VARBINARY(MAX),              -- Image of the pet shop (binary data)
    FOREIGN KEY (CityID) REFERENCES Cities(ID)
);

-- Table: Animals (Animals in the city)
CREATE TABLE Animals (
    ID INT PRIMARY KEY IDENTITY(1,1),   -- Primary key with auto-increment
    CityID INT NOT NULL,                      -- Foreign key referencing Cities
    PetShopID INT NOT NULL,                   -- Foreign key referencing PetShops
    AnimalName NVARCHAR(100) NOT NULL,              -- Name of the animal
    Type NVARCHAR(50) NOT NULL,               -- Type of animal (e.g., dog, cat)
    Available BIT NOT NULL,                   -- Availability status (1 for available, 0 for not)
    Price DECIMAL(10, 2) NOT NULL,            -- Price of the animal
    ContactNumber NVARCHAR(15),               -- Contact number for inquiries
    Description NVARCHAR(MAX),                -- Description of the animal
    Age INT,                                  -- Age of the animal (in years)
    Breed NVARCHAR(50),                       -- Breed of the animal
    Gender NVARCHAR(10),                      -- Gender of the animal (e.g., Male, Female)
    AnimalImage VARBINARY(MAX),               -- Image of the animal (binary data)
    FOREIGN KEY (CityID) REFERENCES Cities(ID),
    FOREIGN KEY (PetShopID) REFERENCES PetShops(ID)
);

USE [GetPet]
GO

/****** Object:  Table [dbo].[LoginUser]    Script Date: 11/03/2024 11:49:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LoginUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[isAdmin] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LoginUser] ADD  DEFAULT ((0)) FOR [isAdmin]
GO


