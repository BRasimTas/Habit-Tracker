 USE HabitTracker;


 -- once kullanici eklemek lazim, daha sonra Habit ekleyin, daha sonra Habit tablosunu olusturun yoksa tam calismaz --
 -- logs sadece hata ayiklama icin. simdilik bi amaci yok --


 Create Table Logs (
  LogID INT Primary Key IDENTITY(1000,10),
  LogMessage NVARCHAR(500),
  LogDate DateTime Default GetDate()
 );

 Create Table Habits (
  HabitID INT PRIMARY KEY IDENTITY (10,10),
  HabitName NVARCHAR(63) NOT NULL,
  HabitStart DateTime Default GETDATE(),
  UserID INT
 );

 Create Table Users (
  UserID INT PRIMARY KEY IDENTITY (1000,10),
  UserName Nvarchar(25),
 );


  -- example table 
  --
  -- Create Table Smoking (
  -- HabitID INT Primary Key Identity (10,10),
  -- DaysElapsed DATETIME Default GETDATE(),
  -- Completed BIT,
  -- );

 -- INSERT INTO Habits (HabitName,UserID) 
 --	VALUES ('Smoking','1000');

 -- INSERT INTO Users (UserName) 
 --	Values('Test1');

 -- INSERT INTO Smoking (Completed)
 --	Values(1)

	 SELECT *  FROM Habits;
	 SELECT * FROM Users;
  -- SELECT * FROM Smoking;


