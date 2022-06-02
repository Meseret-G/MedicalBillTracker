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
DROP TABLE IF EXISTS Archive;
DROP TABLE IF EXISTS ArchiveItem;



CREATE TABLE Patient (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
    Email VARCHAR(55) NOT NULL,
    [FirebaseKeyId] VARCHAR(55) NOT NULL UNIQUE,
    CONSTRAINT UQ_Email UNIQUE(Email)
);

CREATE TABLE Bill (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(55) NOT NULL,
    [Provider] VARCHAR(55) NOT NULL,
    ImageURL TEXT,
    OutOfPocket DECIMAL(9,2) NOT NULL,
    --IsOpen BIT NOT NULL,
    --BillDate DATETIME NOT NULL,
   --PatientId INTEGER NOT NULL,
   --CONSTRAINT [FK_Bill-Patient] FOREIGN KEY (PatientId) REFERENCES [Patient]([Id]) 
);

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
INSERT INTO Bill ([Title], [Provider],ImageURL, OutOfPocket) VALUES ('Emergency Room', 'Hospital','https://www.mauryregional.com/media/Image/banner-emergency.jpg', 385.00);
INSERT INTO Bill ([Title], [Provider],ImageURL, OutOfPocket) VALUES ('Therapy', 'Nashville Therapy Center','https://i.imgur.com/jKFsoJs.jpg', 300.00);

INSERT INTO Patient ([Name], Email, [FirebaseKeyId]) VALUES ('Jane', 'jame@gmail.com', 1234)
INSERT INTO Patient ([Name], Email, [FirebaseKeyId]) VALUES ('Mercy', 'mercy@gmail.com', 3456);
INSERT INTO Patient ([Name], Email, [FirebaseKeyId]) VALUES ('Unlucky', 'unlucky@gmail.com', 2345);
INSERT INTO Patient ([Name], Email, [FirebaseKeyId]) VALUES ('GG', 'gg@gmail.com', 2875);





select * FROM
dbo.Bill;

select * FROM
dbo.Patient;

EXEC sp_RENAME 'Patient.UID' , 'FirebaseKeyId', 'COLUMN'

ALTER TABLE ArchiveItem
DROP COLUMN BillReceived

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


EXEC sp_RENAME 'Bill.[Date]' , 'Date', 'COLUMN'


INSERT INTO Bill ([Title], [Provider],[Date],ImageURL, OutOfPocket, IsOpen) VALUES ('Emergency Room', 'Hospital', '2022-05-05','https://www.mauryregional.com/media/Image/banner-emergency.jpg','20', 0);

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
DROP CONSTRAINT FK_PatientId


select * from Bill

alter table dbo.Bill
alter column [[[Date]]] datetime NOT NULL