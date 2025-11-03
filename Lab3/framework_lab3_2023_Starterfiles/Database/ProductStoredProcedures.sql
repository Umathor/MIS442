DELIMITER //
CREATE PROCEDURE usp_ProductDelete (in ProdId int, in conCurrId int)
BEGIN
	Delete from Products where ProductId = ProdID and ConcurrencyID = conCurrId;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE usp_ProductCreate (out ProdId int, in productcode_p varchar(10), in description_p varchar(50), in unitprice_p decimal(10,4), in onhandquantity_p int)
BEGIN
	Insert into Products (ProductCode, Description, UnitPrice, OnHandQuantity, concurrencyid)
    Values (productcode_p, description_p, unitprice_p, onhandquantity_p, 1);
    Select LAST_INSERT_ID() into ProdId;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE usp_ProductSelect (in ProdId int)
BEGIN
	Select * from Products where ProductID = ProdId;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE usp_ProductSelectAll ()
BEGIN
	Select * from Products order by ProductID;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE usp_ProductUpdate (in ProdId int, in productcode_p varchar(10), in description_p varchar(50), in unitprice_p decimal(10,4), in onhandquantity_p int, conCurrId int)
BEGIN
	Update Products
    Set ProductCode = productcode_p, Description = description_p, UnitPrice = unitprice_p, OnHandQuantity = onhandquantity_p, ConcurrencyID = (ConcurrencyID + 1)
    Where ProductID = ProdId and ConcurrencyID = conCurrId;
END //
DELIMITER ;