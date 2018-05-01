CREATE TABLE [dbo].[UserAddresses] (
    [Id]        INT NOT NULL IDENTITY,
    [AddressId] INT NOT NULL,
    [UserId]    INT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.UserAddresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserAddresses_dbo.Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([AddressId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.UserAddresses_dbo.UserModels_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserModels] ([UserId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserAddresses]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AddressId]
    ON [dbo].[UserAddresses]([AddressId] ASC);

