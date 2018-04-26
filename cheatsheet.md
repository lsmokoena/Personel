# Seems that with Core you have to use migrations otherwise it doesn't actually generated a database. So we need to use migrations
# When we ready to deploy to prod we need to delete all the migrations and create a new initial migration

# to add a migration run this script and change the "Initial" to whatever you want to call the migration
Add-Migration -Project DAL

# if you want to generate the database before running the code you can run the script below
Update-Database -Verbose -Project DAL -StartUpProject Dream

# if you want to delete the current database you can run the T-SQL script below in SQL Server Management Studio
USE [master]
ALTER DATABASE [DSM_DB] SET SINGLE_USER WITH Rollback IMMEDIATE
DROP DATABASE [DSM_DB]
