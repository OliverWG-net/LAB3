CREATE VIEW PersonalLista AS
SELECT FNamn, LNamn, Position, Anställningsdatum,
DATEDIFF(YEAR, Anställningsdatum, GETDATE()) AS 'Antal år'
FROM Personal;
GO

ALTER PROCEDURE AddStudent
	@FirstName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@Personnummer NVARCHAR(15),
	@FkKlassID INT
AS
BEGIN 
	INSERT INTO Student (FirstName, LastName, Personnummer, FkKlassID)
	VALUES(@FirstName, @LastName, @Personnummer, @FkKlassID)
END;

EXEC AddStudent
@FirstName = 'Johan', @LastName ='Karlsson', @Personnummer = '040826-7822', @FkKlassID = 1;
GO

CREATE PROCEDURE SetGrade
	@StudentID INT,
	@FkKursID INT,
	@LärareID INT,
	@BetygsDatum DATE,
	@Betyg INT
AS
BEGIN
	INSERT INTO Betyg (StudentID, FkKursID, LärareID, BetygsDatum, Betyg)
	VALUES (@StudentID, @FkKursID, @LärareID, @BetygsDatum, @Betyg)
END;
GO

CREATE PROCEDURE AddPersonel
	@FNamn NVARCHAR(30),
	@LNamn NVARCHAR(30),
	@Personnummer NVARCHAR(20),
	@Position NVARCHAR (30),
	@Avdelning NVARCHAR(30),
	@Lön INT,
	@Anställningsdatum DATE
AS
BEGIN
	INSERT INTO Personal (Fnamn, LNamn, Personnummer, Position, Avdelning, Lön, Anställningsdatum)
	VALUES(@FNamn, @LNamn, @Personnummer, @Position, @Avdelning, @Lön, @Anställningsdatum)
END;
GO

EXEC AddPersonel
	@FNamn = 'Monka', @LNamn = 'Micheal',
	@Personnummer = '810210-7862', @Position = 'Lärare',
	@Avdelning = 'Skolverkert', @Lön = 28000,
	@Anställningsdatum = '2024-11-01';
GO
SELECT * FROM Personal COUNT
WHERE Position = 'Lärare'
GO

SELECT SUM(Lön) AS 'Total lön', Avdelning FROM Personal
GROUP BY Avdelning
GO

SELECT AVG(Lön) AS 'Medel lön', Avdelning FROM Personal
GROUP BY Avdelning
GO

CREATE PROCEDURE Studentinfo
	@StudentID INT
	AS
	SELECT * FROM Student
	WHERE StudentID = @StudentID
GO

EXEC Studentinfo @StudentID = 1

GO

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @StudentID INT = 1;
    DECLARE @Betyg INT = 5;

    IF NOT EXISTS (SELECT 1 FROM Student WHERE StudentID = @StudentID)
    BEGIN
        THROW 50001, 'Studenten hittades inte', 1;
    END;

	IF @Betyg < 0 or @Betyg > 5
	BEGIN
		THROW 50001, 'Betyg måste vara mellan 0-5',1;
	END;

    UPDATE Betyg
    SET Betyg = @Betyg
    WHERE StudentID = @StudentID;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
    END;
	PRINT 'Updateringen lyckades inte'
    PRINT ERROR_MESSAGE();
END CATCH;

GO

