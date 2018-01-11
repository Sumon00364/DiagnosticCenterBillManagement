Create Database DiagnosticCenter

use DiagnosticCenter

create schema BillManagement


create table BillManagement.TestType
(
	Id int identity primary key,
	Name nvarchar(20) not null
)
go

create table BillManagement.TestSetup
(
	Id int identity primary key,
	Name nvarchar(100) not null,
	Fee money not null,
	TypeId int foreign key references BillManagement.TestType(Id)
)
go
create table BillManagement.PatientInfo
(
	Name varchar(30) not null,
	DateOfBirth date not null,
	MobileNo char(15) primary key
)
go
create table BillManagement.PatientTestInfo
(
	Id int identity,
	TestId int not null foreign key references BillManagement.TestSetup(Id),
	MobileNo char(15) foreign key references BillManagement.PatientInfo(MobileNo),
	TestDate datetime default getdate()
)
go
create table BillManagement.BillPayment
(
	BillNo int identity(1001,1) primary key,
	TotalFee money not null,
	PaidAmount money default 0,
	DueAmount as TotalFee - PaidAmount,
	MobileNo char(15) foreign key references BillManagement.PatientInfo(MobileNo),
	BillDate datetime default getdate()
)
go
create view BillManagement.TestTypeSetupVW
with schemabinding
as
select ts.Name, ts.Fee, tt.Name as [Type] from  BillManagement.TestSetup ts join BillManagement.TestType tt on ts.TypeId=tt.Id

create proc spInsertPatientTest
@name nvarchar(100), @mobile char(15)
as
insert into BillManagement.PatientTestInfo (TestId,MobileNo) values 
((select id from BillManagement.TestSetup where name =@name),@mobile)

exec spInsertPatientTest 'Hand X-ray','01912555820'


create proc spBillPayment
@bilNo int
as
select * from BillManagement.BillPayment where BillNo= @bilNo

create proc spPatientTested
@bilNo int
as
select ts.Name, ts.Fee from BillManagement.TestSetup ts join BillManagement.PatientTestInfo pti on ts.Id = pti.TestId
join BillManagement.BillPayment bp on pti.MobileNo = bp.MobileNo where bp.BillNo= @bilNo

create proc spTestWiseReport '2016/07/27','2016/07/31'
@stDate date, @endDate date
as
select ts.Name, COUNT(pti.TestId) as TotalTest, SUM(ts.Fee) as Total
 from BillManagement.PatientTestInfo pti join BillManagement.TestSetup ts on pti.TestId = ts.Id
where pti.TestDate between @stDate and @endDate
Group By ts.Name

create proc spTypeWiseReport '2016/07/27','2016/07/31'
@firstDate date, @secondDate date
as
select tt.Name, COUNT(pti.TestId) as TotalCount, SUM(ts.Fee) as Amount
from BillManagement.TestType tt join BillManagement.TestSetup ts on tt.Id= ts.TypeId
join BillManagement.PatientTestInfo pti on ts.Id = pti.TestId
where pti.TestDate between @firstDate and @secondDate
Group by tt.Name

create proc spUnpaidBillReport '2016/07/27','2016/07/31'
@strDate date, @lastDate date
as
select bp.BillNo,bp.MobileNo, pin.Name, bp.DueAmount
from BillManagement.BillPayment bp join BillManagement.PatientInfo pin on bp.MobileNo = pin.MobileNo
where bp.BillDate between @strDate and @lastDate

insert BillManagement.PatientInfo Values('Sagor','01/14/1987','01912555820')

insert BillManagement.PatientTestInfo(TestId, MobileNo) values
(
	(select id from BillManagement.TestSetup where name ='Feet X-ray'),'01912555820'
)

select * from BillManagement.PatientTestInfo

select COUNT(Name) as [count] from BillManagement.TestType where Name='Blood'

select Id from BillManagement.TestSetup where Name='Feet X-ray'



select * from BillManagement.TestType

select * from BillManagement.TestSetup

select * from BillManagement.PatientInfo

select * from BillManagement.PatientTestInfo

select * from BillManagement.BillPayment

select top 1 BillNo from BillManagement.BillPayment order by BillNo desc

select * from BillManagement.TestTypeSetupVW

insert BillManagement.PatientTestInfo values
(7, '01856859641','2016/07/27'),
(8, '01856859641','2016/07/27'),
(9, '01856859641','2016/07/27'),
(7, '01912555820','2016/07/28'),
(9, '01912555820','2016/07/28')

insert BillManagement.BillPayment(TotalFee,MobileNo,BillDate) values
('900','01856859641','2016/07/27'),
('700','01912555820','2016/07/28')

