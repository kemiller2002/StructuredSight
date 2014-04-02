CREATE DATABASE SNAP_Example ON --the name of the snapshot database to create
(
	Name = 'Example' -- The database file, each file in a database must have an entry.
	,FileName = 'C:\Temp\SnapExample.ss' --Path To Place Data For Snapshot file.
	
) AS SNAPSHOT OF Example --The database to copy
