--(1)--

CREATE TABLE TypeSolution
(
	ID_TypeSolution int identity(1,1) not null,
	Name varchar(40) not null,

	primary key(ID_TypeSolution)
)


--(2)--

CREATE TABLE Role
(
	ID_Role int identity(1,1) not null,
	Name varchar(10) not null,

	primary key(ID_Role)
)


--(3)--

CREATE TABLE Users
(
	ID_User int identity(1,1) not null,
	ID_Role int not null,
	fName varchar(30) not null,
	sName varchar(30) not null,
	lName varchar(30) not null,
	Position varchar(60) not null,
	Login varchar(50) not null,
	Password varchar(50) not null,

	primary key (ID_User),
	foreign key (ID_Role) references Role(ID_Role)
)


--(4)--

CREATE TABLE Status
(
	ID_Status int identity(1,1) not null,
	Name varchar(30) not null,

	primary key(ID_Status)
)


--(5)--

CREATE TABLE Material
(
	ID_Material int identity(1,1) not null,
	Material varchar(40) not null,

	primary key(ID_Material)
)


--(6)--

CREATE TABLE BuildingType
(
	ID_BuildingType int identity(1,1) not null,
	Name varchar(40) not null,

	primary key(ID_BuildingType)
)


--(7)--

CREATE TABLE Building
(
	ID_Building int identity(1,1) not null,
	ID_Material int not null,
	ID_BuildingType int not null,
	Floors int not null,
	Square float not null,
	Cadaster varchar(15) not null,
	Address varchar(100) not null,

	primary key(ID_Building),
	foreign key(ID_BuildingType) references BuildingType(ID_BuildingType),
	foreign key(ID_Material) references Material(ID_Material)
)


--(8)--

CREATE TABLE Solution
(
	ID_Solution int identity(1,1) not null,
	ID_TypeSolution int not null,
	Description varchar(1000) not null,

	primary key(ID_Solution),
	foreign key(ID_TypeSolution) references TypeSolution(ID_TypeSolution)
)


--(9)--

CREATE TABLE Chief
(
	ID_Chief int identity(1,1) not null,
	ID_User int not null,
	

	primary key(ID_Chief),
	foreign key(ID_User) references Users(ID_User)
)


--(10)--

CREATE TABLE Tasks
(
	ID_Task int identity(1,1) not null,
	ID_Status int not null,
	ID_Building int not null,
	ID_Chief int not null,
	ID_Solution int not null,
	DateBegin varchar(10) not null,
	DateEnd varchar(10) not null,
	Description varchar(1000) not null,

	primary key(ID_Task),
	foreign key(ID_Status) references Status(ID_Status),
	foreign key(ID_Building) references Building(ID_Building),
	foreign key(ID_Chief) references Chief(ID_Chief),
	foreign key(ID_Solution) references Solution(ID_Solution),
)
