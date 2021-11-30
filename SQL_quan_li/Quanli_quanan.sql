--init database

CREATE DATABASE QuanAn COLLATE Vietnamese_CI_AS;
go

use QuanAn
set dateformat DMY

--Tạo bảng
--ROLE(RoleID, RoleName)
alter table EMPLOYEE drop CHK_SEX
alter table TABLEQA drop CHK_STATUS
create table ROLE
(
	ID		integer primary key,
	NAME	nvarchar(200)
)
go
INSERT INTO ROLE(ID,NAME) VALUES ('0',N'Người quản lí')
INSERT INTO ROLE(ID,NAME) VALUES ('1',N'Nhân viên')
delete ROLE where ID in ('0','1')

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
alter table EMPLOYEE add constraint CHK_SEX CHECK (SEX in(N'Nam',N'Nữ'))
alter table EMPLOYEE drop CHK_SEX
insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('1',N'Trần Hữu Trí',N'Người quản lí',N'95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7','0857350234',N'Nam',N'tritran5789@gmail.com');
select * from EMPLOYEE
drop table EMPLOYEE

select * from EMPLOYEE where FULLNAME LIKE N'Trần %'LIKE N't%';

alter table EMPLOYEE alter column FULLNAME nvarchar(max) COLLATE Vietnamese_CI_AS
insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('2','Trần Hữu Trí','Nhân viên','95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7','0857350234','Nam','tritran5789@gmail.com');
insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('7','Trần Hữu Trí','Nhân viên','95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7','0857350234','Nam','tritran5789@gmail.com');
insert into EMPLOYEE(ID,FULLNAME,POSITION,ADDRESS,PHONE,SEX,EMAIL) values ('8','Trần Hữu Trí','Nhân viên','95/20/18B Lê Văn Lương, Tân Kiểng, Quận 7','0857350234','Nam','tritran5789@gmail.com');


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

INSERT INTO ACCOUNT(EMPLOYEEid,ROLEid,USERNAME,PASSWORD) values ('1','0','trihuu15','123456');
select * from ACCOUNT WHERE USERNAME = N'trihuu15' AND PASSWORD = N'123456'

delete ACCOUNT  where EMPLOYEEid = '1' AND ROLEid = '0'


create table CATEGORY
(
	ID			integer primary key,
	NAME		nvarchar(500)
)
go

select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID

select ID from CATEGORY where NAME = N'Nước uống'

insert into CATEGORY (ID, NAME) values ('1',N'Nước uống')
insert into CATEGORY (ID, NAME) values ('2',N'Cơm')
insert into CATEGORY (ID, NAME) values ('3',N'Lẩu')
insert into CATEGORY (ID, NAME) values ('4',N'Rau củ')
insert into CATEGORY (ID, NAME) values ('5',N'Món xào')


create table FOOD
(
	ID			integer primary key,
	NAME		nvarchar(max),
	PRICE		money,
	CATEid		integer
	
	FOREIGN KEY (CATEid) REFERENCES CATEGORY(ID)
)
go
alter table FOOD alter column PRICE integer

insert into FOOD (ID, NAME, CATEid, PRICE) values ('2',N'Cơm bò xào','2','35000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('3',N'Cơm chiên cá mặn','2','35000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('4',N'Lẩu cá','3','200000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('5',N'Rau muống xào','4','30000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('6',N'Bò xào chua ngọt','5','60000')
insert into FOOD (ID, NAME, CATEid, PRICE) values ('7',N'Mực xào cải ngọt','5','80000')

select A.ID, A.NAME, B.NAME, A.PRICE from FOOD A inner join CATEGORY B on A.CATEid = B.ID where A.NAME LIKE N'C%'

create table TABLEQA
(
	ID			integer primary key,
	NAME		nvarchar(50),
	STATUS		nvarchar(50)
)
go
alter table TABLEQA add constraint CHK_STATUS CHECK (STATUS in (N'Bàn trống',N'Có người'))
alter table TABLEQA drop CHK_STATUS
update TABLEQA
SET ID = '13', NAME = N'Bàn 14', STATUS = N'Bàn trống'
where ID = 12

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



drop table TABLEQA

create table ORDER_QA
(
	ID			integer identity(1,1) primary key,
	TABLEid		integer,
	CHECKIN		datetime,
	CHECKOUT	datetime,
	BILLstatus	int not null default 0 

	FOREIGN KEY (TABLEid) REFERENCES TABLEQA(ID)
)
go 

insert into ORDER_QA(TABLEid,CHECKIN, CHECKOUT,BILLstatus) values ('1','19:30:12 11/09/2020','20:30:12 11/09/2020','0')
insert into ORDER_QA(TABLEid,CHECKIN, CHECKOUT,BILLstatus) values ('3','8:30:00 11/12/2020','9:00:00 11/12/2020','0')

select * from ORDER_QA

drop table ORDER_QA
drop table ORDER_FOOD
drop table REVENUE

create table ORDER_FOOD
(
	ID			integer identity(1,1) PRIMARY KEY,
	ORDERid		integer,
	FOODid		integer,
	QUANTITY	integer

	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID),
	FOREIGN KEY (FOODid) REFERENCES FOOD(ID)
)


select * from ORDER_FOOD

insert into ORDER_FOOD (ORDERid, FOODid, QUANTITY) values ('1','1','1')
insert into ORDER_FOOD (ORDERid, FOODid, QUANTITY) values ('1','2','1')
insert into ORDER_FOOD (ORDERid, FOODid, QUANTITY) values ('2','1','1')

select A.ID,B.FOODid,B.QUANTITY from (ORDER_QA A inner join ORDER_FOOD B on A.ID=B.ORDERid) where A.TABLEid = '1' and A.BILLstatus = '0'
select * from FOOD where NAME like N'Cơm%'
--create table REVENUE
--(
--	ORDERid		integer primary key,
--	PRICE		money,
--	CHECKIN		datetime,
--	CHECKOUT	datetime

--	FOREIGN KEY (ORDERid) REFERENCES ORDER_QA(ID)
--)


update TABLEQA
set STATUS = N'Có người'
where ID in 
(
	(
		select TABLEid from ORDER_QA where BILLstatus = '0'
	)
)
select ID from TABLEQA where NAME = N'Bàn 1'
select * from EMPLOYEE

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

select * from ACCOUNT
select * from CATEGORY
select * from EMPLOYEE
select * from FOOD
select * from ORDER_FOOD
select * from ORDER_QA
select * from REVENUE
select * from ROLE
select

