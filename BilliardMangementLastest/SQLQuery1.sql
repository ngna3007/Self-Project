CREATE DATABASE BILLIARDMANAGEMENT
GO

USE BILLIARDMANAGEMENT
GO

CREATE TABLE BilliardTable
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'NOT NAMED',
	status NVARCHAR(100) NOT NULL DEFAULT N'EMPTY',
	PlayTime NVARCHAR(50)
)
GO

CREATE TABLE Account
(
	DisplayName NVARCHAR(100) NOT NULL,
	UserName NVARCHAR(100) PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'NOT NAMED'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'NOT NAMED',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0,

	FOREIGN KEY (idTable) REFERENCES dbo.BilliardTable(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(ID)
)
GO

INSERT INTO dbo.Account
( 
	Username,
	DisplayName,
	Password,
	Type
)

VALUES 
(
	N'ADMIN',
	N'NGOC ANH',
	N'1',
	1
)

INSERT INTO dbo.Account
( 
	Username,
	DisplayName,
	Password,
	Type
)

VALUES 
(
	N'STAFF',
	N'ERIC LE',
	N'1',
	0
)
GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @username
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'STAFF'



SELECT COUNT(*) FROM dbo.Account WHERE Username = N'ADMIN' AND Password = N'2'


UPDATE dbo.Account
SET 
    Username = N'NGOC ANH',
    DisplayName = N'ADMIN'
WHERE 
    Username = N'ADMIN' AND 
    DisplayName = N'NGOC ANH'
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName  AND PassWord = @passWord
END
GO

DECLARE @i INT = 0
WHILE @i <= 10
BEGIN
	INSERT dbo.BilliardTable (name) VALUES (N'Table ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
go

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.BilliardTable
Go

EXEC dbo.USP_GetTableList


UPDATE dbo.BilliardTable SET STATUS = N'PLAYING' WHERE id = 2


DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
	UPDATE dbo.BilliardTable
	SET name = N'Table ' + CAST(@i AS nvarchar(100))
	WHERE id = @i;

	SET @i = @i + 1;
END





INSERT dbo.FoodCategory
	(name)
VALUES (N'FOOD')

INSERT dbo.FoodCategory
	(name)
VALUES (N'PLAYTIME')
GO

INSERT dbo.Food
(name, idCategory, price)
VALUES (N'FRIED RICE', 1, 30000)

INSERT dbo.Food
(name, idCategory, price)
VALUES (N'NOODLES', 1, 30000)

INSERT dbo.Food
(name, idCategory, price)
VALUES (N'7-UP', 2, 15000)

INSERT dbo.Food
(name, idCategory, price)
VALUES (N'PLAYTIME', 3, 1000)
GO

INSERT dbo.Bill
( DateCheckIn,
  DateCheckOut,
  idTable,
  status
)
VALUES (GETDATE(),
		NULL,
		1,
		0
		)

INSERT dbo.Bill
( DateCheckIn,
  DateCheckOut,
  idTable,
  status
)
VALUES (GETDATE(),
		NULL,
		2,
		0
		)

INSERT dbo.Bill
( DateCheckIn,
  DateCheckOut,
  idTable,
  status
)
VALUES (GETDATE(),
		GETDATE(),
		2,
		1
		)


INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (1,3,2)

INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (1,7,3)
INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (2,1,2)
INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (2,2,2)
INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (3,2,2)
INSERT dbo.BillInfo
		(idBill,idFood,count)
VALUES (3,8,)
GO

SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory
SELECT * FROM dbo.BilliardTable

SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi,dbo.Bill as b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.idTable = 3

UPDATE dbo.BilliardTable
SET status = 'PLAYING', starttime = GETDATE()
WHERE id = 3;

DECLARE @currentDateTime DATETIME = GETDATE();
UPDATE dbo.BilliardTable
SET status = 'EMPTY', 
    endtime = @currentDateTime, 
    playtime = DATEDIFF(MINUTE, starttime, @currentDateTime)
WHERE id = 2;


SELECT bt.starttime,bt.endtime,bt.playtime,bt.playtime*1000 AS totalPrice FROM dbo.BilliardTable AS bt WHERE bt.id = 3






UPDATE dbo.BilliardTable SET STATUS = N'PLAYING',starttime = GETDATE() WHERE STATUS = N'EMPTY' AND id = 10

UPDATE dbo.BilliardTable SET STATUS = N'PLAYING' WHERE STATUS = N'EMPTY' AND id =
GO
ALTER TABLE dbo.FoodCategory
DROP COLUMN ;

DELETE FROM dbo.FoodCategory
WHERE name = N'PLAYTIME';
GO

ALTER PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill
( DateCheckIn,
  DateCheckOut,
  idTable,
  status,
  discount
)
VALUES (GETDATE(),
		NULL,
		@idTable,
		0,
		0
		)
END
GO

ALTER PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExistBillInfo INT;
	DECLARE @foodCount INT = 1
	SELECT @isExistBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood
	IF (@isExistBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE BillInfo SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT dbo.BillInfo
			(idBill,idFood,count)
		VALUES (@idBill,@idFood,@count)
	END
END
GO

SELECT MAX(id) FROM Bill

UPDATE dbo.BilliardTable SET STATUS = N'EMPTY',endtime = GETDATE() WHERE STATUS = N'PLAYING' AND id = 10
SELECT * FROM dbo.BilliardTable



UPDATE BilliardTable SET starttime = NULL, endtime = NULL,playtime = NULL WHERE id = 2

ALTER TABLE Bill
ADD discount INT

UPDATE dbo.Bill SET discount = 0
Go


ALTER PROC USP_GetFoodByCategoryID
@idCategory INT
AS
BEGIN
    SELECT * FROM dbo.BillInfo WHERE idBill = @idBill
END
GO

DECLARE @currentDateTime DATETIME = GETDATE(); UPDATE dbo.BilliardTable SET status = 'EMPTY', endtime = @currentDateTime, playtime = DATEDIFF(MINUTE, starttime, @currentDateTime) WHERE STATUS = N'PLAYING' AND id = 2

UPDATE BilliardTable SET starttime = NULL, endtime = NULL ,playtime = NULL WHERE id = 1
Go

ALTER PROC USP_SwitchTable
@idTable1 int, @idTable2 int
AS BEGIN
	DECLARE @idFirstBill int
	DECLARE @idSecondBill int

	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0

	if (@idFirstBill = NULL)
	BEGIN
		INSERT Bill
			( DateCheckIn,
			  DateCheckOut,
			  idTable,
			  status
			)
		VALUES (GETDATE(),
				NULL,
				@idTable1,
				0
				)
		SELECT @idFirstBill = MAX(id) FROM Bill WHERE idTable = @idTable1 AND status = 0

	END

	if (@idSecondBill IS NULL)
	BEGIN
		INSERT Bill
			( DateCheckIn,
			  DateCheckOut,
			  idTable,
			  status
			)
		VALUES (GETDATE(),
				NULL,
				@idTable2,
				0
				)
		SELECT @idSecondBill = MAX(id) FROM Bill WHERE idTable = @idTable2 AND status = 0

	END

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	UPDATE BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	UPDATE BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	DROP TABLE IDBillInfoTable
END
GO


ALTER PROC USP_SwitchTable
@idTable1 int, @idTable2 int
AS BEGIN
    DECLARE @idFirstBill int
    DECLARE @idSecondBill int

    SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
    SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0

    IF (@idFirstBill IS NULL)
    BEGIN
        INSERT INTO Bill
            ( DateCheckIn,
              DateCheckOut,
              idTable,
              status
            )
        VALUES (GETDATE(),
                NULL,
                @idTable1,
                0
                )
        SELECT @idFirstBill = MAX(id) FROM Bill WHERE idTable = @idTable1 AND status = 0
    END

    IF (@idSecondBill IS NULL)
    BEGIN
        INSERT INTO Bill
            ( DateCheckIn,
              DateCheckOut,
              idTable,
              status
            )
        VALUES (GETDATE(),
                NULL,
                @idTable2,
                0
                )
        SELECT @idSecondBill = MAX(id) FROM Bill WHERE idTable = @idTable2 AND status = 0
    END

    -- Switch BillInfo
    SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
    UPDATE BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
    UPDATE BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
    DROP TABLE IDBillInfoTable

    -- Switch starttime, endtime, playtime, and status for BilliardTable
    DECLARE @starttime1 datetime, @endtime1 datetime, @playtime1 int, @status1 varchar(20)
    DECLARE @starttime2 datetime, @endtime2 datetime, @playtime2 int, @status2 varchar(20)

    SELECT @starttime1 = starttime, @endtime1 = endtime, @playtime1 = playtime, @status1 = status FROM dbo.BilliardTable WHERE id = @idTable1
    SELECT @starttime2 = starttime, @endtime2 = endtime, @playtime2 = playtime, @status2 = status FROM dbo.BilliardTable WHERE id = @idTable2

    UPDATE dbo.BilliardTable
    SET starttime = @starttime2, endtime = @endtime2, playtime = @playtime2, status = @status2
    WHERE id = @idTable1

    UPDATE dbo.BilliardTable
    SET starttime = @starttime1, endtime = @endtime1, playtime = @playtime1, status = @status1
    WHERE id = @idTable2
END
GO


