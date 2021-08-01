
Create database DBItemsForTrip
go
use DBItemsForTrip
go
Create table Trips 
(
	Id int primary key identity(1,1),
	TripName nvarchar(100) not null, 
)
go
Create table Items
(
	Id int primary key identity (1,1),
	ItemName nvarchar(100) not null
)
go
Create table ItemsToTrips
(
	Id int primary key identity (1,1),
	TripId int,
	ItemId int,    
	CONSTRAINT FK_CertainTrip_To_Trips FOREIGN KEY (TripId)  REFERENCES Trips (Id) on delete cascade,
	CONSTRAINT FK_List_Items_To_Items FOREIGN KEY (ItemId)  REFERENCES Items (Id) on delete cascade
)
go
drop table ItemsToTrips
drop table Trips
drop table Items


insert into Trips values
('Rome'),
('Kyiv')
insert into Items values
('cellphone'),
('cup'),

select Trips.TripName, Items.ItemName from Trips left join
ItemsToTrips on Trips.id  = ItemsToTrips.TripId inner join Items on ItemsToTrips.ItemId = Items.Id
order by Trips.TripName 
select * from Trips
select * from Items
select * from ItemsToTrips

drop database ItemsForTripDB
drop proc Favorites

create proc Favorites as 
begin
	select * from Items where Id in
	(select top 5 ItemId 
	from ItemsToTrips
	group by ItemId order by COUNT(ItemId) desc)
end

exec Favorites


create proc DeleteItemFromTrip 
@IDRow int
as 
begin
	delete ItemsToTrips 
	where id = @IDRow
end

exec DeleteItemFromTrip 13

create proc AddingItemToExistingTrip 
@IDTrip int,
@IDItem int
as 
begin
	insert into ItemsToTrips
	values 
	(@IDTrip, @IDItem)
end

exec AddingItemToExistingTrip 2, 2
