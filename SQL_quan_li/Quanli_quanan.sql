--init database

CREATE DATABASE QuanAn COLLATE Vietnamese_CI_AS;
go

use QuanAn
set dateformat DMY

--Tạo bảng
--ROLE(RoleID, RoleName)
create table ROLE
(
	ID		integer primary key,
	NAME	nvarchar(200)
)
go
INSERT INTO ROLE(ID,NAME) VALUES ('0',N'Người quản lí')
INSERT INTO ROLE(ID,NAME) VALUES ('1',N'Nhân viên')

create table EMPLOYEE
(
	ID			integer primary key, 
	FULLNAME	nvarchar(200),
	POSITION	nvarchar(150),
	ADDRESS		nvarchar(max),
	PHONE		nvarchar(40),
	SEX			nvarchar(10),
	EMAIL		nvarchar(300),
)
go
ALTER TABLE EMPLOYEE ALTER COLUMN FULLNAME NVARCHAR(200) COLLATE Vietnamese_CI_AS

insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('1',N'Trần Hữu Trí',N'Người quản lí',N'95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7','0857350234',N'Nam',N'tritran5789@gmail.com');
insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('2',N'Kim Thảo',N'Nhân viên',N'95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7',N'0857350234',N'Nữ',N'tritran5789@gmail.com');


create table ACCOUNT 
(
	EMPLOYEEid	integer,
	ROLEid		integer,
	USERNAME	nvarchar(max), 
	PASSWORD	nvarchar(max)
	
	PRIMARY KEY (EMPLOYEEid,ROLEid)
	FOREIGN KEY (ROLEid) REFERENCES ROLE(ID),
	FOREIGN KEY (EMPLOYEEid) REFERENCES EMPLOYEE(ID)
)
go

INSERT INTO ACCOUNT(EMPLOYEEid,ROLEid,USERNAME,PASSWORD) values ('1','0','admin','123456');

create table CATEGORY
(
	ID			integer primary key,
	NAME		nvarchar(500)
)
go

insert into CATEGORY (ID, NAME) values ('1',N'Nước uống')
insert into CATEGORY (ID, NAME) values ('2',N'Cơm')
insert into CATEGORY (ID, NAME) values ('3',N'Lẩu')
insert into CATEGORY (ID, NAME) values ('4',N'Rau củ')
insert into CATEGORY (ID, NAME) values ('5',N'Món xào')


create table FOOD
(
	ID			integer primary key,
	NAME		nvarchar(max),
	PRICE		integer,
	CATEid		integer
	
	FOREIGN KEY (CATEid) REFERENCES CATEGORY(ID)
)
go

insert into FOOD (ID, NAME, CATEid, PRICE) values ('2',N'Cơm bò xào','2','35000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('3',N'Cơm chiên cá mặn','2','35000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('4',N'Lẩu cá','3','200000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('5',N'Rau muống xào','4','30000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('6',N'Bò xào chua ngọt','5','60000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('7',N'Mực xào cải ngọt','5','80000')

create table TABLEQA
(
	ID			integer primary key,
	NAME		nvarchar(50),
	STATUS		nvarchar(50)
)
go

insert into TABLEQA (ID, NAME, STATUS) values ('1',N'Bàn 1',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('2',N'Bàn 2',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('3',N'Bàn 3',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('4',N'Bàn 4',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('5',N'Bàn 5',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('6',N'Bàn 6',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('7',N'Bàn 7',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('8',N'Bàn 8',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('9',N'Bàn 9',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('10',N'Bàn 10',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('11',N'Bàn 11',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('12',N'Bàn 12',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('13',N'Bàn 13',N'Bàn trống')
insert into TABLEQA (ID, NAME, STATUS) values ('14',N'Bàn 14',N'Bàn trống')

create table ORDER_QA
(
	ID			integer identity(1,1) primary key,
	TABLEid		integer,
	CHECKIN		datetime,
	CHECKOUT	datetime,
	BILLstatus	int not null default 0 
)
go 

create table ORDER_FOOD
(
	ID			integer identity(1,1) primary key,
	ORDERid		integer,
	FOODid		integer,
	QUANTITY	integer

	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID),
)
go

create table REVENUE
(
	ORDERid		integer primary key,
	CHECKIN		datetime,
	CHECKOUT	datetime,
	TOTAL		integer,

	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID)
)
go

