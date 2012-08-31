
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK605DAD4018BAAAAF]') AND parent_object_id = OBJECT_ID('Tracks'))
alter table Tracks  drop constraint FK605DAD4018BAAAAF


    if exists (select * from dbo.sysobjects where id = object_id(N'Baskets') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Baskets

    if exists (select * from dbo.sysobjects where id = object_id(N'Items') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Items

    if exists (select * from dbo.sysobjects where id = object_id(N'Tracks') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tracks

    create table Baskets (
        BasketId INT IDENTITY NOT NULL,
       primary key (BasketId)
    )

    create table Items (
        ItemId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       primary key (ItemId)
    )

    create table Tracks (
        TrackId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       BasketId INT null,
       primary key (TrackId)
    )

    alter table Tracks 
        add constraint FK605DAD4018BAAAAF 
        foreign key (BasketId) 
        references Baskets
