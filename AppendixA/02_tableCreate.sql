CREATE TABLE Superhero(
	SuperHeroID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
	Alias varchar (255) NOT NULL,
	Origin varchar (255) NOT NULL,
);

CREATE TABLE Assistant(
	AssistantID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
);

CREATE TABLE SuperPower(
	SuperPowerID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
	Description varchar(255),
);
