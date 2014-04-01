CREATE DATABASE Example
ON PRIMARY 
(
	Name = Example
	,FILENAME = 'C:\temp\Example.mdf'
	,SIZE = 10MB
	,MAXSIZE = 20MB
	,FILEGROWTH = 2
)

