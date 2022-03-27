create database QuanLyQuanAn
go

use QuanLyQuanAn
go

-- Bàn
create table TableFood
(
	TF_ID int identity primary key,
	TF_Name nvarchar (100) not null default N'Chưa có tên',
	TF_Status nvarchar (100) not null default N'Trống'
)
go

-- Loại món
create table CategoryFood
(
	CF_ID int identity primary key,
	CF_Name nvarchar (100) not null default N'Chưa có tên'
)
go

-- Món
create table Food
(
	F_ID int identity primary key,
	F_Name nvarchar (100) not null default N'Chưa có tên',
	F_IDCategory int not null,
	F_Funds Float not null,
	F_Price Float not null

	foreign key (F_IDCategory) references dbo.CategoryFood(CF_ID)
)
go

-- Nhân viên
create table Staff
(
	S_ID int identity primary key,
	S_Name nvarchar(100) not null,
	S_PhoneNumber varchar(10) not null, --Tao cũng đéo biết là bao nhiêu số cho đúng
	S_IdentityCard varchar(10) not null, --Tao cũng đéo biết là bao nhiêu số cho đúng
	S_Salary int null
)
go

-- Hóa đơn
create table Bill
(
	B_ID int identity primary key,
	DateCheckIn date not null default getdate(), --datetime
	DateCheckOut date, --datetime
	B_IDTable int not null,
	B_IDStaff int not null,
	B_Status int not null default 0,
	B_Discount int not null default 0,
	B_TotalPrice float null,
	B_TotalFunds float null
	foreign key (B_IDTable) references dbo.TableFood(TF_ID),
	foreign key (B_IDStaff) references dbo.Staff(S_ID)
)
go

-- Thông tin hóa đơn
create table BillInfor
(
	BI_ID int identity primary key,
	BI_IDBill int references dbo.Bill(B_ID),
	BI_IDFood int references dbo.Food(F_ID),
	BI_Total int not null Default 0,		
)
go

-- Tài khoản
create table Account
(
	UserName nvarchar (100) primary key,
	DisplayName nvarchar (100) not null default N'Chưa có tên',
	PassWord nvarchar (100) not null default 1,
	A_IDStaff int,
	A_Type int not null

	foreign key (A_IDStaff) references dbo.Staff(S_ID)
)
go

create proc USP_Login
@Username nvarchar(100), @Password nvarchar(100)
as
begin
	select * from dbo.Account where UserName = @Username and PassWord = @Password
end
go

create proc USP_GetTableList
as
select * from dbo.TableFood
go

create proc USP_GetIDStaffByTable
@TF_ID int
as
select b.B_IDStaff from dbo.TableFood as a, dbo.Bill as b where a.TF_ID = @TF_ID and a.TF_ID = b.B_IDTable and b.B_Status = 0
go

create proc USP_InsertBill
@B_IDTable int, @B_IDStaff int
as
begin
	insert dbo.Bill( DateCheckIn, DateCheckOut, B_IDTable, B_IDStaff, B_Status, B_Discount )
	values ( GETDATE(), null, @B_IDTable, @B_IDStaff, 0, 0 )
end
go

Create proc USP_InsertBillInfo
@BI_IDBill int, @BI_IDFood int, @BI_Total int
as
begin
	declare @isExitBillInfo int
	declare @foodCount int = 1

	select @isExitBillInfo = BI_ID, @foodCount = BI_Total 
	from dbo.BillInfor
	where BI_IDBill = @BI_IDBill
	and BI_IDFood = @BI_IDFood

	if(@isExitBillInfo > 0)
	begin
		declare @newCount int = @foodCount + @BI_Total
		if(@newCount > 0)
			update dbo.BillInfor set BI_Total = @foodCount + @BI_Total where BI_IDFood = @BI_IDFood
		else
			delete dbo.BillInfor where BI_IDBill = @BI_IDBill and BI_IDFood = @BI_IDFood
	end

	else
	begin
	insert dbo.BillInfor (BI_IDBill, BI_IDFood, BI_Total)
	values (@BI_IDBill, @BI_IDFood, @BI_Total )
	end
end
go

create trigger UTG_UpdateBillInfo
on dbo.BillInfor for insert, update
as
begin
	declare @BI_IDBill int

	select @BI_IDBill = BI_IDBill from inserted

	declare @BI_IDTable int

	select @BI_IDTable = B_IDTable from dbo.Bill where B_ID = @BI_IDBill and B_Status = 0

	declare @count int

	select @count = count (*) from dbo.BillInfor where BI_IDBill = @BI_IDBill

	if(@count > 0)
		update dbo.TableFood set TF_Status = N'Có người' where TF_ID = @BI_IDTable
	else
		update dbo.TableFood set TF_Status = N'Trống' where TF_ID = @BI_IDTable
end
go

create trigger UTG_UpdateBill
on dbo.Bill for update
as
begin
	declare @B_ID int

	select @B_ID = B_ID from inserted

	declare @B_IDTable int

	select @B_IDTable = B_IDTable from dbo.Bill where B_ID = @B_ID

	declare @tong int = 0

	select @tong = count (*) from dbo.Bill where B_IDTable = @B_IDTable and B_Status = 0
	
	if (@tong = 0)
		update dbo.TableFood set TF_Status = N'Trống' where TF_ID = @B_IDTable
end
go


create proc USP_SwitchTable
@idTable1 int, @idTable2 int, @idStaff1 int, @idStaff2 int
as
begin
	declare @idHDBanDau int
	declare @idHDSauDo int

	declare @isFirstTableEmty int = 1
	declare @isSecondTableEmty int = 1

	select @idHDSauDo = B_ID from dbo.Bill where B_IDTable = @idTable2 and B_Status = 0
	select @idHDBanDau = B_ID from dbo.Bill where B_IDTable = @idTable1 and B_Status = 0

	if (@idHDBanDau is null)
	begin
		insert dbo.Bill( DateCheckIn, DateCheckOut, B_IDTable, B_IDStaff, B_Status, B_Discount )
		values ( GETDATE(), null, @idTable1, @idStaff1, 0, 0 )

		select @idHDBanDau = max(B_ID) from dbo.Bill where B_IDTable = @idTable1 and B_Status = 0
	
	end

	select @isFirstTableEmty = count (*) from dbo.BillInfor where BI_IDBill = @idHDBanDau

	if (@idHDSauDo is null)
	begin
		insert dbo.Bill( DateCheckIn, DateCheckOut, B_IDTable, B_IDStaff, B_Status, B_Discount )
		values ( GETDATE(), null, @idTable2, @idStaff2, 0, 0 )

		select @idHDSauDo = max(B_ID) from dbo.Bill where B_IDTable = @idTable2 and B_Status = 0
	
	end

	select @isSecondTableEmty = count (*) from dbo.BillInfor where BI_IDBill = @idHDSauDo

	select BI_ID into idTtHDBan from dbo.BillInfor where BI_IDBill = @idHDSauDo

	update dbo.BillInfor set BI_IDBill = @idHDSauDo where BI_IDBill = @idHDBanDau
	
	update dbo.BillInfor set BI_IDBill = @idHDBanDau where BI_ID in (select * from idTtHDBan)

	drop table idTtHDBan

	if (@isFirstTableEmty = 0)
		update dbo.TableFood set TF_Status = N'Trống' where TF_ID = @idTable2

	if (@isSecondTableEmty = 0)
		update dbo.TableFood set TF_Status = N'Trống' where TF_ID = @idTable1
end
go

create proc USP_GetListBillByDate
@DateCheckIn date, @DateCheckOut date
as
begin
	select a.TF_Name as [Tên bàn],
	b.B_TotalPrice as [Tổng tiền/HD],
	b.B_TotalFunds as [Tổng vốn/HD],
	b.DateCheckIn as [Thời gian vào],
	b.DateCheckOut as [Thời gian ra],
	b.B_Discount as [Giảm giá]
	from dbo.TableFood as a, dbo.Bill as b
	where DateCheckIn >= @DateCheckIn
	and DateCheckOut <= @DateCheckOut
	and b.B_Status = 1
	and a.TF_ID = b.B_IDTable
end
go

create proc USP_GetTotalPriceByDate
@DateCheckIn date, @DateCheckOut date
as
begin
	select sum (B_TotalPrice) as [Tổng thu],
	sum (B_TotalFunds) as [Tổng vốn],
	sum (B_TotalPrice) - sum (B_TotalFunds) as [Tiền lãi]
	from dbo.Bill
	where DateCheckIn >= @DateCheckIn
	and DateCheckOut <= @DateCheckOut
	and B_Status = 1
end
go

create proc USP_UpdateAccount
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newpassWord nvarchar(100)
as
begin
	declare @isRightPass int = 0

	select @isRightPass = count(*)
	from dbo.Account
	where UserName = @userName
	and PassWord = @passWord

	if(@isRightPass = 1)
	begin
		if (@newpassWord = null or @newpassWord = '')
		begin
			update dbo.Account set DisplayName = @displayName where UserName = @userName
		end
		else
			update dbo.Account set DisplayName = @displayName, PassWord = @newpassWord where UserName = @userName
	end
end
go

create trigger UTG_DeletBillInfo
on dbo.BillInfor for Delete
as
begin
	declare @BI_ID int
	declare @BI_IDBill int
	select @BI_ID = BI_ID, @BI_IDBill = deleted.BI_IDBill from deleted

	declare @BI_IDTable int
	select @BI_IDTable = B_IDTable from dbo.Bill where B_ID = @BI_IDBill
	
	declare @count int = 0

	select @count = count(*)
	from dbo.BillInfor as a, dbo.Bill as b
	where b.B_ID = a.BI_IDBill
		and b.B_ID = @BI_IDBill
		and b.B_Status = 0

	if (@count = 0)
		update dbo.TableFood set TF_Status = N'Trống' where TF_ID = @BI_IDTable
end
go

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
go

