-- insert table Customers
INSERT INTO public."Customers"("CustomerID", "Name") VALUES (1001, 'Customer1');
INSERT INTO public."Customers"("CustomerID", "Name") VALUES (1002, 'Customer2');
INSERT INTO public."Customers"("CustomerID", "Name") VALUES (1003, 'Customer3');
INSERT INTO public."Customers"("CustomerID", "Name") VALUES (1004, 'Customer4');
INSERT INTO public."Customers"("CustomerID", "Name") VALUES (1005, 'Customer5');


-- insert table Products
INSERT INTO public."Products"("ProductID", "Name") VALUES (1001, 'Product1');
INSERT INTO public."Products"("ProductID", "Name") VALUES (1002, 'Product2');
INSERT INTO public."Products"("ProductID", "Name") VALUES (1003, 'Product3');
INSERT INTO public."Products"("ProductID", "Name") VALUES (1004, 'Product4');
INSERT INTO public."Products"("ProductID", "Name") VALUES (1005, 'Product5');

-- insert table Purchases
INSERT INTO public."Purchases"("CustomerID", "ProductID") VALUES (1001, 1001);
INSERT INTO public."Purchases"("CustomerID", "ProductID") VALUES (1002, 1002);
INSERT INTO public."Purchases"("CustomerID", "ProductID") VALUES (1003, 1003);
INSERT INTO public."Purchases"("CustomerID", "ProductID") VALUES (1004, 1004);
INSERT INTO public."Purchases"("CustomerID", "ProductID") VALUES (1005, 1005);