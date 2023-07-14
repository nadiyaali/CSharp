/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists(SELECT 1 FROM dbo.[User])
BEGIN
    INSERT INTO dbo.[User] (FirstName,LastName)
    values ('Jack','Bean'),
    ('Humpty','Dumpty'),
    ('Jill','Jack'),
    ('Mary','Lamb');
END
