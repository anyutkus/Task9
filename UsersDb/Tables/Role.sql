CREATE TABLE [dbo].[Role]
(
    [Id] INT CONSTRAINT [PR_dbo_Role] PRIMARY KEY,
    [Name] NVARCHAR(32) UNIQUE NOT NULL
);