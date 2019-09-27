# REST_FULL API witch Adding, deleting, updating data in DB.

## Instruction for DB setup.

DB was created in Visual Studio 2017.<br>
DB VERSION - (localdb)\MSSQLLocalDB

--Step 1

```
CREATE TABLE [dbo].[departments] (
[Id]       INT            IDENTITY (1, 1) NOT NULL,
[name]     NVARCHAR (MAX) NOT NULL,
[location] NVARCHAR (MAX) NOT NULL,
[salary]   NVARCHAR (MAX) NOT NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

--Step 2

```
CREATE TABLE [dbo].[employee] (
[Id]       INT            IDENTITY (1, 1) NOT NULL,
[name]     NVARCHAR (MAX) NOT NULL,
[surename] NVARCHAR (MAX) NOT NULL,
[salary]   NVARCHAR (MAX) NOT NULL,
[deplist]  NVARCHAR (MAX) NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);
```
