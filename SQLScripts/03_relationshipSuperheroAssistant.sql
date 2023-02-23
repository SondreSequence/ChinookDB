USE SuperheroesDB;

ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistants_Superheroes
FOREIGN KEY (superheroID) REFERENCES Superhero(ID)
ON DELETE CASCADE;