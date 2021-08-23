CREATE TABLE Superhero_SuperPower(
	SuperHeroID int FOREIGN KEY REFERENCES Superhero(SuperHeroID), 
	SuperPowerID int FOREIGN KEY REFERENCES SuperPower(SuperPowerID),
	PRIMARY KEY(SuperHeroID, SuperPowerID),
);