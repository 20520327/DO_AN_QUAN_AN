--init database
create database QuanAn
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

create table EMPLOYEE
(
	ID			integer identity(1,1) primary key,
	USERNAME	nvarchar(100), 
	PASSWORD	nvarchar(max),
	FULLNAME	nvarchar(200),
	ADDRESS		nvarchar(max),
	PHONE		nvarchar(40),
	SEX			nvarchar(10),
	EMAIL		nvarchar(300),
	ROLEid		integer

	FOREIGN KEY (ROLEid) REFERENCES ROLE(ID)
)
go

alter table EMPLOYEE add constraint CHK_SEX CHECK (SEX in('Nam','Nữ'))

create table CATEGORY
(
	ID			integer primary key,
	NAME		nvarchar(500)
)
go

create table FOOD
(
	ID			integer primary key,
	NAME		nvarchar(max),
	PRICE		money,
	CATEid		integer
	
	FOREIGN KEY (CATEid) REFERENCES CATEGORY(ID)
)
go

create table TABLEQA
(
	ID			integer identity(1,1) primary key,
	NAME		nvarchar(50),
	STATUS		nvarchar(50)
)
go

alter table TABLEQA add constraint CHK_STATUS CHECK (STATUS in ('Bàn trống','Có người'))

create table ORDER_QA
(
	ID			integer identity(1,1) primary key,
	TABLEid		integer,
	CHECKIN		datetime,
	CHECKOUT	datetime

	FOREIGN KEY (TABLEid) REFERENCES TABLEQA(ID)
)
go



create table ORDER_FOOD
(
	ORDERid		integer,
	FOODid		integer,
	QUANTITY	integer

	primary key(ORDERid,FOODid)
	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID),
	FOREIGN KEY (FOODid) REFERENCES FOOD(ID)
)

create table REVENUE
(
	ORDERid		integer primary key,
	PRICE		money,
	CHECKIN		datetime,
	CHECKOUT	datetime

	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID)
)

update TABLEQA
set STATUS = 'Có người'
where ID in 
(
	(
		select TABLEid from ORDER_QA
	)
	EXCEPT
	(
		select TABLEid from ORDER_QA inner join REVENUE on ORDER_QA.ID = REVENUE.ORDERid
	)
)

--update TABLEQA
--set STATUS = 'Bàn trống'
--where ID in 
--(
--	select TABLEid from REVENUE inner join ORDER_QA on REVENUE.ORDERid = ORDER_QA.ID
--)

--Thông tin bảng account
select A.USERNAME,A.FULLNAME,B.NAME from EMPLOYEE A inner join ROLE B on A.ROLEid = B.ID

--Thông tin bảng table
select * from TABLEQA

--Thông tin bảng danh mục
select * from CATEGORY

--Thông tin bảng food
select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID

--Thông tin bảng revenue 
select * from REVENUE

INSERT INTO FOOD(ID,NAME,CATEid,PRICE) value ()
UPDATE FOOD
SET ID = 1,NAME,CATEid
select * from FOOD where NAME LIKE 