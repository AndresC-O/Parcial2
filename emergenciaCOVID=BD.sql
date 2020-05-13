Use master;
Go

Create database emergCovid19;
Go
Use emergCovid19
Go

Create table usuarios(
id int primary key identity(1,1),
nombre varchar(60),
DUI varchar(25)
);
Go

Insert into usuarios values ('Andres', '06753476-3');