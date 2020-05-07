-- 1. List all customers (full names, customer ID, and country) who are not in the US
select
CustomerId,
FirstName,
LastName,
Country
from Customer
where Country != 'USA';
-- 2. List all customers from brazil
select
CustomerID,
FirstName,
LastName,
Country
from Customer
where Country = 'Brazil';
-- 3. List all sales agents
select
*
from Employee
where Title like '%Sales%Agent%';
-- 4. Show a list of all countries in billing addresses on invoices
select distinct
BillingCountry
from Invoice;
-- 5. How many invoices were there in 2009, and what was the sales total for that year?
select
sum(Total) as TotalAmount,
count(InvoiceId) as invoicesin2009
from Invoice
where YEAR(InvoiceDate) = 2009;
-- 6. How many line items were there for invoice #37?
select
count(*)
from InvoiceLine
where InvoiceId = 37;

-- 7. How many invoices per country?
select
count(*),
BillingCountry
from Invoice
group by BillingCountry

-- 8. Show total sales per country, ordered by highest sales first.
select
sum(Total) as total_sales,
BillingCountry
from Invoice
group by BillingCountry
order by sum(Total) DESC