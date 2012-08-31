
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2129E00DA76CF9EA]') AND parent_object_id = OBJECT_ID('TrackToBasket'))
alter table TrackToBasket  drop constraint FK2129E00DA76CF9EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2129E00D18BAAAAF]') AND parent_object_id = OBJECT_ID('TrackToBasket'))
alter table TrackToBasket  drop constraint FK2129E00D18BAAAAF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA34F020818BAAAAF]') AND parent_object_id = OBJECT_ID('Payments'))
alter table Payments  drop constraint FKA34F020818BAAAAF


    if exists (select * from dbo.sysobjects where id = object_id(N'Baskets') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Baskets

    if exists (select * from dbo.sysobjects where id = object_id(N'TrackToBasket') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TrackToBasket

    if exists (select * from dbo.sysobjects where id = object_id(N'Payments') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Payments

    if exists (select * from dbo.sysobjects where id = object_id(N'Tracks') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Tracks

    create table Baskets (
        BasketId INT IDENTITY NOT NULL,
       primary key (BasketId)
    )

    create table TrackToBasket (
        BasketId INT not null,
       TrackId INT not null
    )

    create table Payments (
        PaymentId INT IDENTITY NOT NULL,
       BasketId INT null,
       primary key (PaymentId)
    )

    create table Tracks (
        TrackId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Price DOUBLE PRECISION null,
       primary key (TrackId)
    )

    alter table TrackToBasket 
        add constraint FK2129E00DA76CF9EA 
        foreign key (TrackId) 
        references Tracks

    alter table TrackToBasket 
        add constraint FK2129E00D18BAAAAF 
        foreign key (BasketId) 
        references Baskets

    alter table Payments 
        add constraint FKA34F020818BAAAAF 
        foreign key (BasketId) 
        references Baskets
