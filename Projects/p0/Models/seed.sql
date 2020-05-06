delete from Locations;
delete from Products;
delete from Inventory;
delete from Customers;
delete from Orders;
delete from OrderItems;

Insert into Locations (
LocationId,
LocationName)
VALUES 
("sss", "Sears"),
("www", "Walmart"),
("ttt", "Target");

Insert into Products (
ProductId,
ProductName,
ProductPrice)
VALUES
("ppp", "Pliers", 12.99),
("ggg", "Glue", 2.75),
("ddd", "Dishwasher", 299.99),
("mmm", "Maple Syrup", 1.28),
("ccc", "Carburetor", 342.99),
("bbb", "Broom", 8.56),
("eee", "Eggs", 1.99),
("fff", "Flashlight", 3.00),
("zzz", "Zip Ties", 0.38);

Insert into Inventory (
InventoryId,
Quantity,
LocationId,
ProductId)
VALUES
("1", 3, "sss", "ppp"),
("2", 3, "sss", "ggg"),
("3", 3, "sss", "ddd"),
("4", 3, "www", "mmm"),
("5", 3, "www", "ccc"),
("6", 3, "www", "bbb"),
("7", 3, "ttt", "eee"),
("8", 3, "ttt", "fff"),
("9", 3, "ttt", "zzz");