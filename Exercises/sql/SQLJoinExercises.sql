CREATE TABLE Country (
	CountryID NVARCHAR(16) NOT NULL,
	Country NVARCHAR(120) NOT NULL,
	CONSTRAINT PK_CountryID PRIMARY KEY CLUSTERED (CountryID)
);

CREATE TABLE State (
	StateID NVARCHAR(16) NOT NULL,
	CountryID NVARCHAR(16) NOT NULL,
	State NVARCHAR(120) NOT NULL,
	CONSTRAINT PK_StateID PRIMARY KEY CLUSTERED (StateID)
);

ALTER TABLE State
ADD CONSTRAINT FK_StateCountryID
FOREIGN KEY (CountryID)
REFERENCES Country (CountryID)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

CREATE INDEX IFK_CountryStateID ON State (CountryID);

INSERT INTO Country (
CountryID, 
Country) 
VALUES 
(1,'USA'),
(2,'Canada'),
(3,'United Kingdom'),
(4,'Mexico'),
(234,'Georgia');

INSERT INTO State (
StateID,
CountryID,
State)
VALUES 
('sd47',1,'North Carolina'),
('se41',2,'Manitoba'),
('fr76',3,'London'),
('gm56',4,'Aguascalientes');

-- cross
select
*
from Country
cross join State

-- inner
select
*
from Country as c
join State as s
on c.CountryID = s.CountryID;

-- outer
select
*
from Country as c
left join State as s
on c.CountryID = s.CountryID;

select
*
from Country as c
right join State as s
on c.CountryID = s.CountryID;

select
*
from Country as c
full outer join State as s
on c.CountryID = s.CountryID;

drop table State;
drop table Country;
