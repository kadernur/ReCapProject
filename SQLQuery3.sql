INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','Manuel1','2','2012','100','Manuel Benzin'),
	('1','Otomotik1','3','2015','150','Otomatik Dizel'),
	('2','Otomotik2','1','2017','200','Otomatik Hybrid'),
	('3','Manuel2','3','2014','125','Manuel Dizel');

Delete (CarName)
ALTER TABLE Cars
DROP COLUMN CarName;

INSERT INTO Brands(BrandName)
VALUES
	('Tesla'),
	('BMW'),
	('Renault');