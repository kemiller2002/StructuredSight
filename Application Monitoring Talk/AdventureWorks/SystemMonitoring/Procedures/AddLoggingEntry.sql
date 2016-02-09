CREATE PROCEDURE [dbo].[AddLoggingEntry]
	 @machineName VARCHAR(100)  = NULL
	,@siteName VARCHAR(100) = NULL
	,@logged VARCHAR(500) = NULL
	,@level VARCHAR(20) = NULL
	,@username VARCHAR(100)    = NULL     
	,@message VARCHAR(500)     = NULL     
	,@logger VARCHAR(100)      = NULL    
	,@properties VARCHAR(100)   = NULL    
	,@serverName VARCHAR(100)    = NULL   
	,@port VARCHAR(100)         = NULL   
	,@url VARCHAR(100)          = NULL  
	,@exception VARCHAR(200) = NULL
AS
	INSERT INTO LogEntry
	(
	 machineName   
	,siteName 
	,logged 
	,level 
	,username         
	,message         
	,logger          
	,properties       
	,serverName       
	,port            
	,url            
	,exception
	)

	VALUES
	(
	 @machineName   
	,@siteName 
	,@logged 
	,@level 
	,@username         
	,@message         
	,@logger          
	,@properties       
	,@serverName       
	,@port            
	,@url            
	,@exception
	)