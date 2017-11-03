DECLARE @Version as int; 

set @Version = 0;

IF EXISTS (SELECT 1 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_TYPE='BASE TABLE' 
           AND TABLE_NAME='DatabaseVersion') 
   select @Version = ( select MAX(Version) as currentVersion from dbo.DatabaseVersion) ELSE set @Version = 0 ;

If @Version is null set @Version = 0;

--:setvar Version @Version