/*
-- 创建sa用户并设置密码
CREATE LOGIN [sa] WITH PASSWORD = N'sa';
-- 启用sa用户
ALTER LOGIN [sa] ENABLE;
-- 设置sa用户密码
ALTER LOGIN [sa] WITH PASSWORD = N'sa';
*/
EXECUTE sp_password NULL,'sa','sa';
GO
-- 查询系统中是否存在数据库
SELECT *
FROM sys.databases;
-- 新建查询修改数据库为单用户模式
-- alter database [数据库名或完整路径] set single_user with rollback  immediate;  
ALTER DATABASE SuperMarket SET single_user WITH ROLLBACK IMMEDIATE;
GO
-- 修改排序规则（这里为中文--拼音--不区分大小写）,设置的目的时防止中文乱码
ALTER DATABASE SuperMarket COLLATE Chinese_PRC_CI_AS; 
GO
-- 重新设置为多用户模式
ALTER DATABASE SuperMarket SET multi_user;
GO
DROP TABLE dbo.Users;
GO
DROP TABLE dbo.Units;
GO
-- 用户表
CREATE TABLE Users
(
    UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) NOT NULL ,
    Pwd NVARCHAR(50) NOT NULL
);
GO
-- 商品单位表
CREATE TABLE dbo.Units
(
    Id VARCHAR(10) NOT NULL PRIMARY KEY ,
    UnitName NVARCHAR(50) NOT NULL,
    INDEX index_1 (UnitName)
);
ALTER TABLE dbo.Units DROP INDEX index_1;
GO
SP_HELP Units;
GO
-- 商品分类表
CREATE TABLE CommoditySort
(
    SortId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    SortName NVARCHAR(50) NOT NULL
);
GO
-- 商品清单表
CREATE TABLE CommodityList
(
    CommodityId VARCHAR(10) NOT NULL PRIMARY KEY,
    CommodityName NVARCHAR(50) NOT NULL ,
    Category NVARCHAR(50) NOT NULL ,
    BarCode NVARCHAR(50) NOT NULL ,
    Unit NVARCHAR(50) NOT NULL ,
    Specification NVARCHAR(50) DEFAULT NULL,
    PurchasePrice DECIMAL(5,2) NOT NULL,
    SelingPrice DECIMAL(5,2) NOT NULL,
    Producer NVARCHAR(50) DEFAULT NULL ,
    INDEX index_1(Unit)
);
GO
-- 商品打折表
CREATE TABLE Commodity
(
    CommodityId INT NOT NULL IDENTITY(1,1),
    CommodityName VARCHAR(50) NOT NULL,
    SortId INT NOT NULL ,
    CommodityPrice DECIMAL(5,2) NOT NULL ,
    IsDiscount INT NOT NULL ,
    ReducedPrice DECIMAL(5,2) NOT NULL ,
    PRIMARY KEY (CommodityId),
    CONSTRAINT Commodity_ibfk_1 FOREIGN KEY (SortId) REFERENCES CommoditySort (SortId)
);
GO
SELECT *
FROM dbo.Users;
GO
SELECT *
FROM dbo.Units;
GO
SELECT *
FROM dbo.CommoditySort;
GO
SELECT *
FROM dbo.CommodityList;
GO
SELECT *
FROM dbo.Commodity;
GO
INSERT INTO Users
VALUES
    (1, 'admin', 'admin');
GO
INSERT INTO Units
VALUES
    (1, '瓶'),
    (2, '袋'),
    (3, '斤'),
    (4, '个'),
    (5, '条'),
    (6, '盒');
GO
INSERT INTO CommoditySort
VALUES
    (1, '冲剂'),
    (2, '酒饮'),
    (3, '休闲'),
    (5, '粮油'),
    (6, '日配'),
    (7, '生鲜'),
    (8, '洗涤'),
    (9, '家居'),
    (10, '文体'),
    (11, '儿童'),
    (12, '针织'),
    (13, '家电');
GO
INSERT INTO CommodityList
VALUES
    ('010001', '百花牌蜂蜜', '冲调', '9832002', '瓶', '60g', 9.80, 18.00, '百花集团'),
    ('020001', '泰国香米', '粮油', '9832006', '袋', '1000g', 30.00, 50.00, NULL),
    ('020002', '山西老陈醋', '粮油', '9832007', '瓶', '400ml', 1.50, 2.30, '山西陈醋酿造厂'),
    ('030001', '康师傅夹心饼干', '休闲', '9832001', '袋', '180g', 2.10, 3.50, '康师傅食品厂'),
    ('030002', '乐事薯片', '休闲', '9832005', '袋', '40g', 3.00, 4.50, '乐事集团'),
    ('060001', '蒙牛鲜牛奶', '日配', '9832008', '袋', '250ml', 0.80, 1.50, '蒙牛集团'),
    ('070001', '草鱼', '生鲜', '9832009', '斤', NULL, 6.00, 9.00, NULL),
    ('070002', '鲜虾', '生鲜', '9832010', '斤', NULL, 9.00, 13.00, NULL),
    ('080001', '汰渍洗衣粉', '洗涤', '9832011', '袋', '500g', 5.00, 6.80, '宝洁集团'),
    ('080002', '高露洁牙膏', '洗涤', '9832012', '盒', '90g', 4.00, 6.50, '宝洁集团'),
    ('160001', '红星二锅头', '酒水', '9832003', '瓶', '500ml', 4.00, 6.50, '红星集团'),
    ('160002', '五粮液', '酒水', '9832004', '瓶', '450ml', 120.00, 280.00, '五粮液集团');
GO
INSERT INTO Commodity
VALUES
    (1, '百花牌蜂蜜', 1, 18.00, 1, 15.00),
    (2, '红星二锅头', 2, 28.00, 0, 28.00),
    (3, '五粮液', 2, 280.00, 0, 280.00),
    (10, '乐事薯片', 3, 4.50, 1, 4.00),
    (11, '泰国香米', 5, 2.50, 0, 2.50),
    (12, '山西老陈醋', 5, 2.30, 0, 2.30),
    (13, '伊利优酸乳', 6, 9.20, 1, 9.00),
    (14, '蒙牛鲜牛奶', 6, 1.50, 1, 1.20),
    (15, '草鱼', 7, 9.00, 0, 9.00),
    (17, '鲜虾', 7, 13.00, 1, 12.00),
    (18, '汰渍洗衣粉', 8, 6.80, 0, 6.80),
    (19, '高露洁牙膏', 8, 6.50, 1, 6.30);