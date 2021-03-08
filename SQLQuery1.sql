CREATE TABLE [dbo].[CarImages] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CarId]        INT            NULL,
    [ImagePath]    NVARCHAR (MAX) NULL,
    [CarImageDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);
