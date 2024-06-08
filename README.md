Fankart project is built on Microsoft technology stack (c#, .net core, razor pages, SQL), HTML and CSS.
So to work on local environment 
  Install visual studio Microsoft Visual Studio Community 2022 from https://visualstudio.microsoft.com/downloads/?cid=learn-onpage-download-tutorial-create-csharp-aspnetcore-web-app-page-cta  
  Follow steps from https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022
  You might need to install .net framewrok if not prompted in steps
  Clone the repository into your system from https://github.com/chellatoremaruthi/FanKart 
  Once cloned click on .sln file
  ![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/36786cdf-cfb1-4358-bd81-f91800852534)

We already have a Azure SQl with all the scripts executed may be we can connect to azure database instead of downloading sql and running the scripts.

Once project is opened click on Build -> Build Solution present on top bar
Click on solution explorer -> Right click on Fankart -> Properties
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/772730ea-fc09-4e37-a97b-13287ab21a2c)

Once properties tab is presented click on Debug -> General -> Open debug launch profiles UI
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/b723e334-6a41-4491-b4a5-5e0f1daa3caf)

From popup under environment variables add key ASPNETCORE_ENVIRONMENT and values Production
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/93b46068-3af5-4f90-aa81-6903dcaadfa5)

The set up is done and we can run the solution now

if we wish to run the project on sql server from local environment


create table dbo.Category
(
	CategoryId int Primary key,
	CategoryName varchar(200)
)

create table dbo.Brand
(
	BrandId int Primary key,
	BrandName varchar(200)
)

create table dbo.Size
(
	SizeId int Primary key,
	SizeName varchar(20),
	SizeDescription varchar(50)
)

create table dbo.Product
(
	ProductId int Primary key identity(10000, 1),
	ProductName varchar(20),
	ProductDescription varchar(50),
	BrandId int Foreign key references dbo.Brand(BrandId),
	CategoryId int Foreign key references dbo.Category(CategoryId),
)

create table dbo.Inventory
(
	InventoryId int Primary key identity(100000, 1),
	ProductId int Foreign key references dbo.Product(ProductId),
	SizeId int Foreign key references dbo.Size(SizeId),
	QuantityAvailable int,
	Price decimal,
	IsActive bit
)

create table dbo.Address
(
	AddressId int Primary key identity(100000, 1),
	UserEmailId varchar(500),
	FirstName varchar(20),
	LastName varchar(20),
	AddressLine1 varchar(200),
	AddressLine2 varchar(200),
	State varchar(50),
	ZipCode varchar(50),
	Country varchar(50),
	IsActive bit,
	CreatedOn DateTime
)

create table Cart
(
	CartId int Primary Key Identity(1,1),
	UserEmailId varchar(500),
	IsActive bit
)

create table CartProductMap
(
	CartProductMapId int primary key Identity(1,1),
	CartId int Foreign key references dbo.Cart(CartId),
	ProductId int Foreign key references dbo.Product(ProductId),
	SizeId int Foreign key references dbo.Size(SizeId),
	Quatity int,
	CreatedOn DateTime,
	ModifiedOn DateTime
)

create table dbo.Card
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmailId varchar(500),
    MaskedCreditCard NVARCHAR(19) NOT NULL,  
    EncryptedCreditCard NVARCHAR(MAX) NOT NULL, 
    EncryptedCardHolderName NVARCHAR(MAX) NOT NULL, 
    EncryptedSecurityCode NVARCHAR(MAX) NOT NULL, 
    EncryptedExpiry NVARCHAR(MAX) NOT NULL,
	IsAcive bit
);

create table dbo.Orders
(
	OrderId int primary key identity(788787, 1),
	OrderDate DateTime,
	EmailId varchar(500),
	AddressId int Foreign key references dbo.Address(AddressId),
	TotalOrderCost decimal,
	CardId int Foreign key references dbo.Card(Id),
	IsDelivered bit
)

create table dbo.OrderProductMap
(
	Id int primary key identity(1,1),
	OrderId int Foreign key references dbo.Orders(OrderId),
	ProductId int Foreign key references dbo.Product(ProductId),
	SizeId int Foreign key references dbo.Size(SizeId),
	Quantity int,
	price decimal,
	CreatedOn Datetime
)



Alter table dbo.Product 
Add  ImagePath varchar(1000)
Alter table dbo.Product
Alter Column ProductName varchar(100)

Alter table dbo.Product
Alter Column ProductDescription varchar(100)

![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/35be7dc6-fe37-4f56-bcfe-741846814ceb)


SCRIPTS

--Insert into dbo.Category values (1, 'Hats')
--Insert into dbo.Category values (2, 'Jerseys')
--Insert into dbo.Category values (3, 'Sweat-shirts')
--Insert into dbo.Category values (4, 'Footwear')
--Insert into dbo.Category values (5, 'Jackets')
--Insert into dbo.Category values (6, 'Pants')
--Insert into dbo.Category values (7, 'Polos')
--Insert into dbo.Category values (8, 'Shorts')
--Insert into dbo.Category values (9, 'Accessories')
--Insert into dbo.Category values (10, 'Backpacks')
--Insert into dbo.Category values (11, 'T-Shirts')


--Insert into dbo.Brand values (1, 'Nike')
--Insert into dbo.Brand values (2, 'Adidas')
--Insert into dbo.Brand values (3, 'Puma')
--Insert into dbo.Brand values (4, 'New Era')
--Insert into dbo.Brand values (5, 'Under Armor')
--Insert into dbo.Brand values (6, 'North Face')
--Insert into dbo.Brand values (7, 'Jordon')




--Insert into dbo.Product values ('Paris Saint-Germain Nike Campus Performance Adjustable Hat - Navy', 'Paris Saint-Germain Nike Campus Performance Adjustable Hat - Navy', 1, 1, 'IMG-1')
--Insert into dbo.Product values ('Manchester United New Era Black & Gold Pack Cuffed Knit Hat - Black', 'Manchester United New Era Black & Gold Pack Cuffed Knit Hat - Black', 1, 1, 'IMG-2')
--Insert into dbo.Product values ('Manchester United New Era Reflective Camo 9FIFTY Stretch-Snap Adjustable Hat - Black', 'Manchester United New Era Reflective Camo 9FIFTY Stretch-Snap Adjustable Hat - Black', 4, 1, 'IMG-3')
--Insert into dbo.Product values ('Real Madrid adidas C40 Adjustable Hat - White', 'Real Madrid adidas C40 Adjustable Hat - White', 1, 1, 'IMG-4')
--Insert into dbo.Product values ('Manchester United New Era Bobble Cuffed Knit Hat with Pom - Red', 'Manchester United New Era Bobble Cuffed Knit Hat with Pom - Red', 2, 1, 'IMG-5')
--Insert into dbo.Product values ('Manchester United adidas Dad Adjustable Hat - Hunter Green', 'Manchester United adidas Dad Adjustable Hat - Hunter Green', 2, 1, 'IMG-6')
--Insert into dbo.Product values (' Manchester City Puma Fan Pom Knit Hat - Blue', ' Manchester City Puma Fan Pom Knit Hat - Blue', 3, 1, 'IMG-7')
--Insert into dbo.Product values ('Manchester United New Era Youth Sport Cuffed Knit Hat with Pom - Red', 'Manchester United New Era Youth Sport Cuffed Knit Hat with Pom - Red', 3, 1, 'IMG-8')
--Insert into dbo.Product values ('Paris Saint-Germain Nike Classic99 Trucker Snapback Hat - Navy', 'Paris Saint-Germain Nike Classic99 Trucker Snapback Hat - Navy', 1, 1, 'IMG-9')
--Insert into dbo.Product values ('Real Madrid Dusk Fitted Hat - Black', 'Real Madrid Dusk Fitted Hat - Black', 4, 1, 'IMG-10')
--Insert into dbo.Product values ('Manchester United adidas Woolie Cuffed Knit Hat - Black', 'Manchester United adidas Woolie Cuffed Knit Hat - Black', 2, 1, 'IMG-11')
--Insert into dbo.Product values ('Paris Saint-Germain Guide Cuffed Knit Hat - Blue', 'Paris Saint-Germain Guide Cuffed Knit Hat - Blue', 5, 1, 'IMG-12')




Insert into dbo.Product values ('Erling Haaland Manchester City Puma 2023/24 Home Replica Player Jersey - Sky Blue', 'Erling Haaland Manchester City Puma 2023/24 Home Replica Player Jersey - Sky Blue', 3, 2, 'IMG-13')
Insert into dbo.Product values ('Kylian Mbappe Paris Saint-Germain Jordan Brand Youth 2023/24 Third Stadium Replica Player Jersey', 'Kylian Mbappe Paris Saint-Germain Jordan Brand Youth 2023/24 Third Stadium Replica Player Jersey', 7, 2, 'IMG-14')
Insert into dbo.Product values ('Jude Bellingham Real Madrid adidas 2023/24 Home Replica Jersey - White', 'Jude Bellingham Real Madrid adidas 2023/24 Home Replica Jersey - White', 2, 2, 'IMG-15')
Insert into dbo.Product values ('Jude Bellingham Real Madrid adidas 2023/24 Third Replica Player Jersey - Black', 'Jude Bellingham Real Madrid adidas 2023/24 Third Replica Player Jersey - Black', 2, 2, 'IMG-16')
Insert into dbo.Product values ('Bayern Munich adidas 2023/24 Oktoberfest Replica Jersey - Green', 'Bayern Munich adidas 2023/24 Oktoberfest Replica Jersey - Green', 2, 2, 'IMG-17')
Insert into dbo.Product values (' Barcelona Nike 2023/24 Home Authentic Jersey - Royal', ' Barcelona Nike 2023/24 Home Authentic Jersey - Royal', 1, 2, 'IMG-18')
Insert into dbo.Product values ('Lionel Messi Paris Saint-Germain Nike 2022/23 Home Authentic Player Jersey - Blue', 'Lionel Messi Paris Saint-Germain Nike 2022/23 Home Authentic Player Jersey - Blue', 1, 2, 'IMG-19')
Insert into dbo.Product values ('Barcelona Nike 2023 Home Replica Custom Jersey - Royal', 'Barcelona Nike 2023 Home Replica Custom Jersey - Royal', 1, 2, 'IMG-20')
Insert into dbo.Product values ('Kylian Mbappé Paris Saint-Germain Nike 2022/23 Home Replica Player Jersey - Blue', 'Kylian Mbappé Paris Saint-Germain Nike 2022/23 Home Replica Player Jersey - Blue', 1, 2, 'IMG-21')
Insert into dbo.Product values ('Barcelona Nike 2023/24 Home Stadium Replica Jersey - Royal', ' Barcelona Nike 2023/24 Home Stadium Replica Jersey - Royal', 1, 2, 'IMG-22')
Insert into dbo.Product values ('Manchester United adidas 2023/24 Home Replica Jersey - Red', 'Manchester United adidas 2023/24 Home Replica Jersey - Red', 2, 2, 'IMG-23')
Insert into dbo.Product values ('Manchester United adidas 2023/24 Third Authentic Patch Jersey - White', ' Manchester United adidas 2023/24 Third Authentic Patch Jersey - White', 2, 2, 'IMG-24')



Insert into dbo.Product values ('Manchester United adidas Lifestyle Pullover Hoodie - Cream', 'Manchester United adidas Lifestyle Pullover Hoodie - Cream', 2, 3, 'IMG-25')
Insert into dbo.Product values ('adidas Manchester United Graphic Raglan Full-Zip Windbreaker Jacket - Black', 'adidas Manchester United Graphic Raglan Full-Zip Windbreaker Jacket - Black', 2, 3, 'IMG-26')
Insert into dbo.Product values ('Manchester United adidas Originals OG Pullover Hoodie - Blue/Black', 'Manchester United adidas Originals OG Pullover Hoodie - Blue/Black', 2, 3, 'IMG-27')
Insert into dbo.Product values ('Barcelona Nike Tech Full-Zip Hoodie - Gray', 'Barcelona Nike Tech Full-Zip Hoodie - Gray', 1, 3, 'IMG-28')
Insert into dbo.Product values ('Paris Saint-Germain Nike NSW Club Fleece Pullover Hoodie - Cream', 'Paris Saint-Germain Nike NSW Club Fleece Pullover Hoodie - Cream', 1, 3, 'IMG-29')
Insert into dbo.Product values (' Manchester City Puma FtblCore Graphic Pullover Hoodie - Light Blue', ' Manchester City Puma FtblCore Graphic Pullover Hoodie - Light Blue', 3, 3, 'IMG-30')
Insert into dbo.Product values ('Manchester City Graffiti Pullover Hoodie - Black', 'Manchester City Graffiti Pullover Hoodie - Black', 5, 3, 'IMG-31')
Insert into dbo.Product values ('Manchester United adidas 2023/24 DNA Full-Zip Hoodie - Black', ' Manchester United adidas 2023/24 DNA Full-Zip Hoodie - Black', 2, 3, 'IMG-32')
Insert into dbo.Product values (' Real Madrid adidas 2023/24 DNA Full-Zip Hoodie - Navy', ' Real Madrid adidas 2023/24 DNA Full-Zip Hoodie - Navy', 2, 3, 'IMG-33')
Insert into dbo.Product values ('Manchester United adidas Football Icon Raglan Quarter-Zip Top - Red', 'Manchester United adidas Football Icon Raglan Quarter-Zip Top - Red', 2, 3, 'IMG-34')
Insert into dbo.Product values ('Manchester City Simplicity Leisure Raglan Pullover Sweatshirt - Navy', 'Manchester City Simplicity Leisure Raglan Pullover Sweatshirt - Navy', 5, 3, 'IMG-35')
Insert into dbo.Product values ('Manchester United adidas Designed for Gameday Raglan Full-Zip Hoodie Jacket - Green', 'Manchester United adidas Designed for Gameday Raglan Full-Zip Hoodie Jacket - Green', 2, 3, 'IMG-36')



Insert into dbo.Product values ('Manchester United adidas Team Samba Shoes - Black', 'Manchester United adidas Team Samba Shoes - Black', 2, 4, 'IMG-37')
Insert into dbo.Product values ('Lionel Messi Paris Saint-Germain ISlide Youth Player Slide Sandals - Navy', 'Lionel Messi Paris Saint-Germain ISlide Youth Player Slide Sandals - Navy', 3, 4, 'IMG-38')
Insert into dbo.Product values ('Paris Saint-Germain Nike Unisex Pegasus 40 Road Running Shoe - Black', 'Paris Saint-Germain Nike Unisex Pegasus 40 Road Running Shoe - Black', 1, 4, 'IMG-39')


Insert into dbo.Product values ('Bayern Munich adidas 2023/24 Training Quarter-Zip Top - Black', 'Bayern Munich adidas 2023/24 Training Quarter-Zip Top - Black', 2, 5, 'IMG-40')
Insert into dbo.Product values ('Paris Saint-Germain Nike 2022/23 Strike Drill Performance Raglan Quarter-Zip Long Sleeve Top - White', 'Paris Saint-Germain Nike 2022/23 Strike Drill Performance Raglan Quarter-Zip Long Sleeve Top - White', 1, 5, 'IMG-41')
Insert into dbo.Product values ('Manchester City Puma 2023/24 Quarter-Zip Training Top - Sky Blue', 'Manchester City Puma 2023/24 Quarter-Zip Training Top - Sky Blue', 3, 5, 'IMG-42')



Insert into dbo.Product values ('Bayern Munich adidas Team Scarf', 'Bayern Munich adidas Team Scarf', 2, 8, 'IMG-43')
Insert into dbo.Product values ('Manchester United adidas Team Scarf', 'Manchester United adidas Team Scarf', 2, 8, 'IMG-44')
Insert into dbo.Product values ('Manchester United Maui Jim Pokowai Arch Sunglasses - Black/Red', 'Manchester United Maui Jim Pokowai Arch Sunglasses - Black/Red', 5, 8, 'IMG-45')
Insert into dbo.Product values ('Paris Saint-Germain Nike Local Verbiage Scarf', 'Paris Saint-Germain Nike Local Verbiage Scarf', 1, 8, 'IMG-46')
Insert into dbo.Product values ('Manchester City Collage Scarf - Sky Blue/Navy', 'Manchester City Collage Scarf - Sky Blue/Navy', 3, 8, 'IMG-47')
Insert into dbo.Product values ('Manchester City 17oz. Personalized Bold Crest Water Bottle', 'Manchester City 17oz. Personalized Bold Crest Water Bottle', 2, 8, 'IMG-48')


--first insert all product with 500 as price

--INSERT INTO DBO.inventory
--select ProductId, SizeId, 100, 500,1
--from 
--dbo.product
--cross join dbo.size
--where sizeid != 6 and categoryid!=8
--order by categoryid

-- insert for accessories with universal size

--INSERT INTO DBO.inventory
--select ProductId, SizeId, 100, 200,1
--from 
--dbo.product
--cross join dbo.size
--where sizeid = 6 and categoryid=8
--order by categoryid


update dbo.product
set categoryId = 9
where categoryid =8


![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/e65d1315-f79e-4d67-9e4e-d0c48160ffb5)


The scripts might not be exactly correct but if someone is trying lets connect and fix any script issues.







