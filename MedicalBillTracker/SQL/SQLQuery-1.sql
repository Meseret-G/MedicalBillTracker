drop database MedicalBillTracker

USE MASTER
GO

IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'MedicalBillTracker'
)
CREATE DATABASE MedicalBillTracker
GO

USE MedicalBillTracker
GO

DROP TABLE IF EXISTS Bill;
DROP TABLE IF EXISTS Patient;
--DROP TABLE IF EXISTS Archive;
--DROP TABLE IF EXISTS ArchiveItem;



CREATE TABLE Patient (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
    Email VARCHAR(55) NOT NULL,

);

CREATE TABLE Bill (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(55) NOT NULL,
    [Provider] VARCHAR(55) NOT NULL,
    ImageURL TEXT,
    OutOfPocket DECIMAL(9,2) NOT NULL,
    isArchived BIT NOT NULL DEFAULT 0,
    [Date] VARCHAR(55) NOT NULl,
    PersonalNote VARCHAR(55) NOT NUll,
    --`UserId VARCHAR(55) NOT NUll,
  
)




CREATE TABLE Archive  (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
 
);

CREATE TABLE ArchiveItem (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	BillId INTEGER NOT NULL,
    ArchiveId INTEGER NOT NULL,
    CONSTRAINT FK_ArchiveItem_Bill FOREIGN KEY (BillId) REFERENCES [Bill](Id),
    CONSTRAINT FK_ArchiveItem_Archive FOREIGN KEY (ArchiveId) REFERENCES [Archive](Id) 
)

INSERT INTO Patient ([Name], Email) VALUES ('Jane', 'jame@gmail.com')
INSERT INTO Patient ([Name], Email) VALUES ('Mercy', 'mercy@gmail.com');
INSERT INTO Patient ([Name], Email) VALUES ('Unlucky', 'unlucky@gmail.com');
INSERT INTO Patient ([Name], Email) VALUES ('GG', 'gg@gmail.com');

INSERT INTO Bill ([Title], [Provider],ImageURL, OutOfPocket, isArchived, [Date], PersonalNote) VALUES ('Emergency Room', 'Hospital','https://www.mauryregional.com/media/Image/banner-emergency.jpg', 385.00, 1, '10/10/2021', 'six month follow up');
INSERT INTO Bill ([Title], [Provider],ImageURL, OutOfPocket, isArchived, [Date], PersonalNote) VALUES ('Therapy', 'Nashville Therapy Center','https://i.imgur.com/jKFsoJs.jpg', 300.00, 1, '10/19/2018', 'was issue with my insurance');







select * FROM Patient;



EXEC sp_RENAME 'Patient.UID' , 'FirebaseKeyId', 'COLUMN'

ALTER TABLE Patient
DROP COLUMN FirebaseKeyId

select * FROM ArchiveItem

EXEC sp_RENAME 'Bill.[Date]' , 'Date', 'COLUMN'


EXEC sp_RENAME 'Patient.FirebaseKeyId' , 'UID', 'COLUMN'



ALTER TABLE Bill
DROP COLUMN isOpen


ALTER TABLE Bill
ADD ServiceDate DATETIME NULL;

SELECT * FROM Invoice;


ALTER TABLE Bill
ALTER COLUMN [DATE] DATETIME NOT NULL;


EXEC sp_RENAME 'Bill.[isArchived]' , 'IsArchived', 'COLUMN'


INSERT INTO Bill ([Title], [Provider],[Date],ImageURL, OutOfPocket, IsOpen) VALUES ('Emergency Room', 'Hospital', '2022-05-05','https://www.mauryregional.com/media/Image/banner-emergency.jpg','20', 1);

SELECT COLUMN_NAME,
DATA_TYPE
FROM Title
where TABLE_NAME = 'Bill'



SELECT * FROM Bill;

SELECT * FROM Archive;

EXEC sp_columns 'Bill';

ALTER TABLE Archive
DROP CONSTRAINT CHK_PatientId

DROP TABLE Patient;

ALTER TABLE dbo.Archive
DROP column FK_PatientId;

-- Add patientID as FK

ALTER TABLE ArchiveItem
ADD PatientId Int;

ALTER TABLE ArchiveItem
ADD FOREIGN KEY (PatientId) REFERENCES Patient(Id);

select * FROM ArchiveItem;
--

ALTER TABLE Bill
ADD IsArchived BIT NOT NULL DEFAULT 0;




ALTER TABLE Bill
ADD [Date] Varchar(50) NOT NULL;


select * from Bill

alter table dbo.Bill
alter column [[[Date]]] datetime NOT NULL

-- able to insert primary key
SET IDENTITY_INSERT dbo.Archive OFF

USE MedicalBillTracker


ALTER TABLE Bill
ADD CONSTRAINT FK_Bill_Patient FOREIGN KEY (PatientId) REFERENCES [Patient](Id);


                        SELECT * FROM Bill
WHERE
isArchived = 1  

SELECT * FROM 
BIll;