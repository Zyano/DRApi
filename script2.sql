CREATE TABLE AssetStore(
	id int identity primary key,
	title nvarchar(250),
	barUrl char(63),
	kind nvarchar(20),
	fileHash nvarchar(),

);

CREATE TABLE 