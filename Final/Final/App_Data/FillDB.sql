
DBCC CHECKIDENT('dbo.Artist', RESEED, 0)
DBCC CHECKIDENT('dbo.Artwork', RESEED, 0)
DBCC CHECKIDENT('dbo.Genre', RESEED, 0)
DBCC CHECKIDENT('dbo.Classification', RESEED, 0)

INSERT INTO [dbo].[Artist](Name, BirthDate, BirthCity)VALUES('M.C. Escher', '18980617 12:00:00 AM', 'Leeuwarden, Netherlands');
INSERT INTO [dbo].[Artist](Name, BirthDate, BirthCity)VALUES('Leonardo Da Vinci', '15190502 12:00:00 AM', 'Vinci, Italy');
INSERT INTO [dbo].[Artist](Name, BirthDate, BirthCity)VALUES('Hatip Mehmed Efendi', '16801018 12:00:00 AM', 'Unknown');
INSERT INTO [dbo].[Artist](Name, BirthDate, BirthCity)VALUES('Salvador Dali', '19040511 12:00:00 AM', 'Figueres, Spain');

INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('Circle Limit III', 1);
INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('Twon Tree', 1);
INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('Mona Lisa', 2);
INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('The Vitruvian Man', 2);
INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('Ebru', 3);
INSERT INTO [dbo].[ArtWork](Title, ArtistID)VALUES('Honey Is Sweeter Than Blood', 4);

INSERT INTO [dbo].[Genre](Name)VALUES('Tesselation');
INSERT INTO [dbo].[Genre](Name)VALUES('Surrealism');
INSERT INTO [dbo].[Genre](Name)VALUES('Portrait');
INSERT INTO [dbo].[Genre](Name)VALUES('Renaissance');

INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(1, 1);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(2, 1);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(2, 2);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(3, 3);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(3, 4);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(4, 4);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(5, 1);
INSERT INTO [dbo].[Classification](ArtworkID, GenreID)VALUES(6, 2);