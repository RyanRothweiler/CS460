
DBCC CHECKIDENT('dbo.Pirate', RESEED, 0)
DBCC CHECKIDENT('dbo.Ship', RESEED, 0)
DBCC CHECKIDENT('dbo.Crew', RESEED, 0)

INSERT INTO [dbo].[Pirate](Name, DateConscripted)VALUES('Jack Sparrow', '20120618 10:34:09 AM');
INSERT INTO [dbo].[Pirate](Name, DateConscripted)VALUES('Captain Morgan', '20110615 10:34:09 PM');
INSERT INTO [dbo].[Pirate](Name, DateConscripted)VALUES('Edward Lowe', '19201001 7:34:36 AM');
INSERT INTO [dbo].[Pirate](Name, DateConscripted)VALUES('Cheng I Sao', '17620201 1:00:09 PM');
INSERT INTO [dbo].[Pirate](Name, DateConscripted)VALUES('Sir Francis Drake', '20741226 10:34:09 AM');

INSERT INTO [dbo].[Ship](Name, Type, tonnage)VALUES('Killers Killer', 'Ketch', 200);
INSERT INTO [dbo].[Ship](Name, Type, tonnage)VALUES('Oceans Nightmare', 'Corvette', 2000);
INSERT INTO [dbo].[Ship](Name, Type, tonnage)VALUES('The Green of the Caribbean', 'Snow', 250);
INSERT INTO [dbo].[Ship](Name, Type, tonnage)VALUES('THe Sad Strumpet', 'Frigate', 4000);
INSERT INTO [dbo].[Ship](Name, Type, tonnage)VALUES('The Hell-born Murderer', 'Schooner', 400);

INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(1, 1, 110.98);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(1, 2, 385.37);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(1, 3, 88.30);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(1, 4, 88);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(1, 5, 947);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(2, 1, 234);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(2, 2, 234.79);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(2, 3, 73);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(2, 4, 400);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(2, 5, 4.23);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(3, 1, 1.23);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(3, 2, 0.10);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(3, 3, 0.99);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(3, 4, 0.87);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(3, 5, 0.23);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(4, 1, 4320.1);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(4, 2, 0.01);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(4, 4, 300);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(5, 4, 500);
INSERT INTO [dbo].[Crew](PirateID, ShipID, Booty)VALUES(5, 5, 100);