DROP TABLE CUSTOMERDETAILS

CREATE TABLE CUSTOMERDETAILS(CUSTOMER_ID INTEGER NOT NULL PRIMARY KEY,NAME VARCHAR(20) NOT NULL,PRODUCT_ID VARCHAR(20)
,ORDERDATE DATE,AMOUNT BIGINT,ADDRESS VARCHAR(30),PHONE BIGINT);

INSERT INTO CUSTOMERDETAILS VALUES(101,'CHAITANYA','AB456','2022/11/22',20000,'#156 PUNE',456789087)
INSERT INTO CUSTOMERDETAILS VALUES(102,'KEVIN','PQ123','2022/12/15',80000,'#144 BANGALORE',987864578)
INSERT INTO CUSTOMERDETAILS VALUES(103,'DAVID','AB987','2022/10/22',31000,'#132 CHENNAI',5678943275)
INSERT INTO CUSTOMERDETAILS VALUES(104,'RAKSHA','AB567','2022/9/11',14459,'#112 KERELA',7658490322)
INSERT INTO CUSTOMERDETAILS VALUES(105,'AKANSHA','PQ234','2021/4/5',50000,'#118 HYDERABAD',876543523)
INSERT INTO CUSTOMERDETAILS VALUES(109,'JOHN','AB789','2022/5/9',3000,'#123 BANGALORE',896789008)
INSERT INTO CUSTOMERDETAILS VALUES(110,'WILLIAM','AB456','2022/6/7',20000,'#156 CHENNAI',23489057)
INSERT INTO CUSTOMERDETAILS VALUES(111,'PAXTON','AB456','2021-6-8',5000,'#112 PUNE',987789076)

SELECT * FROM CUSTOMERDETAILS

create or alter procedure create_order(@p_cusid int, @p_name varchar(max), @p_proid varchar(max),@P_date datetime,
@p_amount int,@p_address varchar(max),@p_phone bigint)
as
insert into CUSTOMERDETAILS values(@p_cusid,@p_name,@p_proid,@p_date,@p_amount,@p_address,@p_phone)
exec create_order 100,'MAX','PQ234','2022-09-12',50000,'#100 chennai',978694536

create or alter procedure update_order(@p_cusid int, @p_name varchar(max), @p_proid varchar(max),@p_date datetime
,@p_amount bigint,@p_address varchar(max),@p_phone bigint)
as
update CUSTOMERDETAILS set name=@p_name,product_id=@p_proid ,orderdate=@p_date,amount=@p_amount,address=@p_address where customer_id=@p_cusid
exec update_order  111,'Priya','PQ234','2021-7-8',50000,'#100 chennai',978694536

create or alter procedure delete_sales(@cusid int)
as
Delete from CUSTOMERDETAILS where customer_id=@cusid
EXEC delete_sales 101


