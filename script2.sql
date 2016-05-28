CREATE TABLE AssetStore(
	id int identity primary key,
	title nvarchar(250),
	barUrl char(63),
	kind nvarchar(20),
	fileHash nvarchar(60),
	quality char(10)
);

CREATE TABLE Asset(
	id int identity primary key,
	description nvarchar(500),
	title nvarchar(150),
	airDate datetime,
	logged datetime,

)


CREATE TABLE DownloadLog(
	id bigint identity primary key,
	url nvarchar(500),
	stamp datetime,
	
);


CREATE TABLE BannedUsers(
	userId int foreign key references(aspnetUserId),
	startDate datetime,
	endDate datetime,
	ip nvarchar(45), -- IPV6 support
	reason nvarchar(200),
);

CREATE TABLE UserFavorites(
	userId int foreign key references(aspnetUserId),


)