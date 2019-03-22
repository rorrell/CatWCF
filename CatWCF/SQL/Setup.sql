use Cats;

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Gender')
BEGIN
	CREATE TABLE Gender (
		Id INT NOT NULL PRIMARY KEY,
		Description VARCHAR(10)
	)
END
GO

IF (SELECT COUNT(*) FROM Gender) = 0
BEGIN
	INSERT INTO Gender (Id, Description) VALUES
		(0, 'Female'),
		(1, 'Male')
END
GO

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'FurType')
BEGIN
	CREATE TABLE FurType (
		Id INT NOT NULL PRIMARY KEY,
		Description VARCHAR(10)
	)
END
GO

IF (SELECT COUNT(*) FROM FurType) = 0
BEGIN
INSERT INTO FurType (Id, Description) VALUES
	(0, 'ShortHair'),
	(1, 'MediumHair'),
	(2, 'LongHair')
END
GO

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Cat')
BEGIN
	CREATE TABLE Cat (
		Id INT IDENTITY(1,1),
		Name VARCHAR(50) NOT NULL,
		Gender INT NOT NULL,
		FurType INT NOT NULL,
		Breed VARCHAR(50) NULL,
		Age INT NULL,
		CONSTRAINT FK_Cat_Gender FOREIGN KEY (Gender) REFERENCES Gender(Id),
		CONSTRAINT FK_Cat_FurType FOREIGN KEY (FurType) REFERENCES FurType(Id)
	)
END
GO