INSERT INTO Assistant (Name, SuperHeroID)
VALUES ('Emil', (SELECT SuperheroID from Superhero WHERE Name='Tien'));

INSERT INTO Assistant (Name, SuperHeroID)
VALUES ('Edvard', (SELECT SuperheroID from Superhero WHERE Name='Maki'));

INSERT INTO Assistant (Name, SuperHeroID)
VALUES ('Nick', (SELECT SuperheroID from Superhero WHERE Name='Martin'));