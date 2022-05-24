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
DROP TABLE IF EXISTS ArchiveItem

CREATE TABLE Patient (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
    Email VARCHAR(55) NOT NULL,
    [UID] VARCHAR(55) NOT NULL UNIQUE,
    CONSTRAINT UQ_Email UNIQUE(Email)
);

CREATE TABLE Bill (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(55) NOT NULL,
    [Provider] VARCHAR(55) NOT NULL,
    ServiceDate date NOT NULL,
    ImageURL TEXT,
    OutOfPocket DECIMAL(9,2) NOT NULL,
    IsOpen BIT NOT NULL,
--PatientId VARCHAR(55) NOT NULL,
   -- CONSTRAINT FK_Patient FOREIGN KEY (PatientId) REFERENCES [Patient]([UID]) ON DELETE CASCADE
);



CREATE TABLE Archive  (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	PatientId VARCHAR(55) NOT NULL,
    IsOpen BIT NOT NULL,
    CONSTRAINT FK_Patient FOREIGN KEY (PatientId) REFERENCES [Patient]([UID]) ON DELETE CASCADE
);

CREATE TABLE ArchiveItem (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	BillId INTEGER NOT NULL,
    ArchiveId INTEGER NOT NULL,
    CONSTRAINT FK_Bill FOREIGN KEY (BillId) REFERENCES [Bill](Id) ON DELETE CASCADE,
    CONSTRAINT FK_Archive FOREIGN KEY (ArchiveId) REFERENCES [Archive](Id) ON DELETE CASCADE
)
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('Emergency Room', 'Hospital', '2022-05-05','https://www.mauryregional.com/media/Image/banner-emergency.jpg', 385.00, 0);
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('Annual Physical Visit', 'PCP', '2021-03-04', 'https://images.ctfassets.net/uq0sg0aynn6a/twdFWYwQqy46O0asgIOgg/2a3248c7077b817437009f42b9ab8329/Primary_Care_Physicians.jpg', 0.00, 0);
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('Therapy', 'Nashville Therapy Center', '2021-05-02', 'https://i.imgur.com/jKFsoJs.jpg', 300.00, 0);
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('Accupunture', 'Hendersonville Traditional Medicine Center', '2022-08-10','https://post.healthline.com/wp-content/uploads/2020/05/Acupuncture_732x549-thumbnail.jpg', 478.00, 0);
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('MRI', 'St Thomas Hospital','2022-06-01', 'https://i.imgur.com/1puf1fV.jpg', 230.00, 0);
INSERT INTO Bill ([Title], [Provider],ServiceDate,ImageURL, OutOfPocket, IsOpen) VALUES ('Urgent Care', 'Urgent Now', '2021-12-12', 'https://wp02-media.cdn.ihealthspot.com/wp-content/uploads/sites/522/2021/05/27024509/iStock-917307626-1.jpg', 487.00, 0);

INSERT INTO Patient ([Name], Email, [UID]) VALUES ('Jane', 'jame@gmail.com', 1234);
INSERT INTO Patient ([Name], Email, [UID]) VALUES ('Mercy', 'mercy@gmail.com', 3456);
INSERT INTO Patient ([Name], Email, [UID]) VALUES ('Unlucky', 'unlucky@gmail.com', 2345);
INSERT INTO Patient ([Name], Email, [UID]) VALUES ('GG', 'gg@gmail.com', 2875);

INSERT INTO Archive (PatientId, IsOpen) VALUES (1234, 0);
INSERT INTO Archive (PatientId, IsOpen) VALUES (3456, 0);
INSERT INTO Archive (PatientId, IsOpen) VALUES (2345, 0);
INSERT INTO Archive (PatientId, IsOpen) VALUES (2875, 0);


select * From Bill;


