USE SuperheroesDB;

CREATE TABLE Superhero (
	ID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50) NOT NULL,
	Alias varchar(50) NOT NULL,
	Origin varchar(50) NOT NULL,
);

CREATE TABLE Assistant (
	ID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50) NOT NULL,
	superheroID int NOT NULL
);

CREATE TABLE [Power] (
	ID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50) NOT NULL,
    [Power] varchar(50) NULL
);
