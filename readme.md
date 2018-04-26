Here is a brief guide on deploying the DSM project once we have information about deploying to production please update this document

Accessing and Publishing to QA
============================================================================
You can access the QA server via Remote Desktop with the machine name ewx-dsm-qa and we using Windows Authentication

If you wish connect to the database just open up Sql Server Management Studio and connect to ewx-dsm-qa (using Windows Auth). The QA database name is DSM_DB.

To publish checkout the origin/QA branch for this project. Open the dsm.sln file in Visual Studio 2017. Right click on the "dsm" project in Solution Explorer and select the "Publish" option. Select QA in the drop down list and select the "Publish" button

NOTE: You may need to disable the DSM website in IIS when you try and publish just remember to start the site again when you are done


Logging In
=========================================================================
You can then access QA in your browser http://ewx-dsm-qa

You can view all the available logins using the sql script below:

~~~sql
SELECT Email, FirstName, ClearPassword
FROM [DSM_DB].[dbo].[Users]
~~~

MailGun Credentials
==========================================================================
Site: https://www.mailgun.com/
Email: lehana.mokoena@ewx.co.za
Password: sacrratemp