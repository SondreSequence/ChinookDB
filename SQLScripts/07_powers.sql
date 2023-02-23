USE SuperheroesDB;

INSERT INTO [Power] ([Name], [Power])
VALUES('FireBending', 'FireControl'),
('WaterBending', 'WaterControl'),
('EarthBending', 'EarthControl'),
('AirBending', 'AirControl')

INSERT INTO PowerRelationship(SuperheroID, PowerID)
VALUES(1,1),
(1,2),
(1,3),
(1,4),
(2,1)




