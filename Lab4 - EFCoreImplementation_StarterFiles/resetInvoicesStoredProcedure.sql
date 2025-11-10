DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_testingResetInvoiceData`()
BEGIN

-- disable foreign key constraints first
	set foreign_key_checks=0;
    set sql_safe_updates=0;
    
	delete from Invoices;
    delete from InvoiceLineItems;
    
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (18, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (18, 'DB1R      ', 42.0000, 1, 42.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (18, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (23, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (26, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (27, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (28, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (29, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (30, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (31, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (32, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (32, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (33, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (33, 'CRFC      ', 50.0000, 1, 50.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (33, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (41, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (42, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (43, 'JAVP      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (44, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (45, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (46, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (46, 'DB2R      ', 45.0000, 1, 45.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (46, 'SQ12      ', 57.5000, 1, 57.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (46, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (47, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (47, 'DB2R      ', 45.0000, 4, 180.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (48, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (49, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (49, 'DB1R      ', 42.0000, 1, 42.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (50, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (57, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (58, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (59, 'A4VB      ', 56.5000, 10, 565.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (60, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (62, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (66, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (68, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (69, 'DB1R      ', 42.0000, 1, 42.0000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (101, 'CS10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (102, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (102, 'ADV4      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (102, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (104, 'A4CS      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (105, 'A4CS      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (105, 'CS10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (106, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (106, 'ADV4      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (106, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (108, 'CS10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (110, 'ADV4      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (110, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (111, 'A4CS      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (111, 'CS10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (114, 'A4VB      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (114, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (115, 'A4CS      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (116, 'VB10      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (117, 'JAVP      ', 56.5000, 1, 56.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (117, 'JSP2      ', 52.5000, 1, 52.5000);
INSERT InvoiceLineItems (InvoiceID, ProductCode, UnitPrice, Quantity, ItemTotal) VALUES (118, 'VB10      ', 56.5000, 1, 56.5000);

INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (18, 20, NOW(), 155.0000, 11.6250, 6.2500, 172.8750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (23, 694, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (26, 35, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (27, 11, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (28, 12, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (29, 13, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (30, 15, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (31, 11, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (32, 40, NOW(), 113.0000, 8.4750, 5.0000, 126.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (33, 33, NOW(), 163.0000, 12.2250, 6.2500, 181.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (41, 333, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (42, 666, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (43, 332, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (44, 555, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (45, 213, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (46, 20, NOW(), 215.5000, 16.1625, 7.5000, 239.1625);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (47, 10, NOW(), 236.5000, 17.7375, 8.7500, 262.9875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (48, 25, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (49, 694, NOW(), 98.5000, 7.3875, 5.0000, 110.8875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (50, 20, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (57, 88, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (58, 10, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (59, 50, NOW(), 565.0000, 42.3750, 15.0000, 622.3750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (60, 15, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (62, 15, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (66, 10, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (68, 10, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (69, 11, NOW(), 42.0000, 3.1500, 3.7500, 48.9000);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (101, 10, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (102, 408, NOW(), 169.5000, 12.7125, 6.2500, 188.4625);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (104, 25, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (105, 239, NOW(), 113.0000, 8.4750, 5.0000, 126.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (106, 125, NOW(), 169.5000, 12.7125, 6.2500, 188.4625);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (108, 495, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (110, 470, NOW(), 113.0000, 8.4750, 5.0000, 126.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (111, 233, NOW(), 113.0000, 8.4750, 5.0000, 126.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (114, 495, NOW(), 113.0000, 8.4750, 5.0000, 126.4750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (115, 200, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (116, 326, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (117, 601, NOW(), 109.0000, 8.1750, 5.0000, 122.1750);
INSERT Invoices (InvoiceID, CustomerID, InvoiceDate, ProductTotal, SalesTax, Shipping, InvoiceTotal) VALUES (118, 523, NOW(), 56.5000, 4.2375, 3.7500, 64.4875);

-- enable foreign key constraints
	set foreign_key_checks=1;
	set sql_safe_updates=1;
END$$
DELIMITER ;