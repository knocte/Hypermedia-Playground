
    if exists (select * from dbo.sysobjects where id = object_id(N'Items') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Items

    create table Items (
        ItemId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       primary key (ItemId)
    )
