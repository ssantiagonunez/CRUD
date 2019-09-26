create database Samuel_Prueba

Go

create table Samuel_Prueba.dbo.Persona (
ID smallint identity(1,1) primary key ,
Nombre varchar(30),
FechaDeNacimiento date);