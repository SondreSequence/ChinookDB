USE SuperheroesDB;

CREATE TABLE PowerRelationship (
    SuperheroID INT,
    PowerID INT,
    PRIMARY KEY (SuperheroID, PowerID),
    FOREIGN KEY (SuperheroID) REFERENCES Superhero(ID),
    FOREIGN KEY (PowerID) REFERENCES [Power](ID)
);