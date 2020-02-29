use scb;

select * from Customer;
select top 3 * from [Order];
--select top 3 * from Orderitem;
select   * from product;
select top 3 * from Supplier;


--1.
--Customer page 
--select id, Firstname, LastName, City, Country, Phone from Customer;

--2. 
--Orders from Customer
Select C.Id, C.FirstName, C.LastName, C.City, C.Country, O.CustomerId, O.OrderNumber, 
	O.TotalAmount TotalAmount, OrderDate 
from [order] O
	INNER JOIN Customer C
ON C.Id = O.CustomerId
Where C.Id = 1

--3
--products from OrderId
select p.Id, p.ProductName, p.UnitPrice, p.Package, o.unitprice from OrderItem o
Inner join Product p on o.ProductId = p.Id
Inner join Supplier S on p.SupplierId = S.Id
where o.OrderId = 4

--4. products from suppliers
select * from Supplier s
Inner Join product p on p.SupplierId = s.Id
where s.Id = 4 

---------------------------------------------

select CUS.FirstName, CUS.City, CUS.Phone, PDT.ProductName, PDT.Package, PDT.UnitPrice from customer CUS
INNER JOIN [Order] ORD ON CUS.Id = ORD.CustomerId
INNER JOIN [OrderItem] ORDTM ON ORD.Id = ORDTM.OrderId
INNER JOIN Product PDT ON ORDTM.ProductId = PDT.Id
where CUS.Id = 55

