# REST_FULL API witch Adding, deleting, updating data in DB.

## Connection string, may be later if I have time, will make connection string in XML file in root of app.

## Instruction for setUP Data Base.

Aleksejs Birula

Базу создавал в Visual Studio 2017
BD was created in Visual Studio 2017

DB VERSION - (localdb)\MSSQLLocalDB

--Step 1

CREATE TABLE [dbo].[departments] (
[Id]       INT            IDENTITY (1, 1) NOT NULL,
[name]     NVARCHAR (MAX) NOT NULL,
[location] NVARCHAR (MAX) NOT NULL,
[salary]   NVARCHAR (MAX) NOT NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);

--Step 2

CREATE TABLE [dbo].[employee] (
[Id]       INT            IDENTITY (1, 1) NOT NULL,
[name]     NVARCHAR (MAX) NOT NULL,
[surename] NVARCHAR (MAX) NOT NULL,
[salary]   NVARCHAR (MAX) NOT NULL,
[deplist]  NVARCHAR (MAX) NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);
