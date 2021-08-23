INSERT INTO SuperPower (Name, Description)
VALUES ('Big Brain', 'Super smart 200 IQ power');

INSERT INTO SuperPower (Name, Description)
VALUES ('Lantern', 'Trash lantern, does nothing');

INSERT INTO SuperPower (Name, Description)
VALUES ('Super muscles', 'Big biceps, much power');

INSERT INTO SuperPower (Name, Description)
VALUES ('Ant suit', 'Makes you smaller');


INSERT INTO Superhero_SuperPower(SuperheroID, SuperPowerID)
 VALUES ((SELECT SuperheroID from Superhero WHERE Name='Martin'),
 (SELECT SuperPowerId FROM SuperPower WHERE Name='Lantern')
 );

INSERT INTO Superhero_SuperPower(SuperheroID, SuperPowerID)
 VALUES ((SELECT SuperheroID from Superhero WHERE Name='Martin'),
 (SELECT SuperPowerId FROM SuperPower WHERE Name='Super muscles')
 );

 INSERT INTO Superhero_SuperPower(SuperheroID, SuperPowerID)
 VALUES ((SELECT SuperheroID from Superhero WHERE Name='Maki'),
 (SELECT SuperPowerId FROM SuperPower WHERE Name='Lantern')
 );

 INSERT INTO Superhero_SuperPower(SuperheroID, SuperPowerID)
 VALUES ((SELECT SuperheroID from Superhero WHERE Name='Tien'),
 (SELECT SuperPowerId FROM SuperPower WHERE Name='Big Brain')
 );
