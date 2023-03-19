# asp.net core 6 web api for spa apps , focusing on writing less code
- Global Using Statements , then you shouldn't write using using ... on top of all classes.

![image](https://user-images.githubusercontent.com/17564001/170569285-18e5694b-a610-4346-ae36-61920e49c7c4.png)

<hr> 

- File Scoped Namespaces , then we remove namespace block and get more space.

![image](https://user-images.githubusercontent.com/17564001/170643358-46b23d5a-c0af-4c2f-b8a3-3482b0ea5806.png)

Enable it in visual studio options for your new classes:

![image](https://user-images.githubusercontent.com/17564001/170640230-90d33c4a-a0bb-4c1a-bfad-616b28143b34.png)

<hr>

- EF core 6 data base first

Open ssms and connect to your sql server instance , right click on Databases , select Attach... , click on Add... button , go to the WebApi project and Data folder , select WebApi.mdf and select OK. Now you have the WebApi data base on your sql server instance.

![image](https://user-images.githubusercontent.com/17564001/171223461-b29a2c3e-76fd-49b9-9b1d-5826aead1f76.png)

The sql server connection string of project (CS) is in appsettings.json file in root of the project path.

The current Data Source is .\\sqlexpress , you must change it if your Data Source is different.

![image](https://user-images.githubusercontent.com/17564001/171224102-4db40b6a-ce07-40ab-ab95-b1f1e41c205c.png)

for scaffolding: 

1. Install "ef core power tools" visual studio extension (It needs close and open Visual Studio after downloading)

![image](https://user-images.githubusercontent.com/17564001/170569946-da43bfa3-1d1e-4bbe-8144-f8e1df6c38f3.png)

2. Right click on web project (not solution) , then select EF Core Power Tools > Reverse Engineer
![image](https://user-images.githubusercontent.com/17564001/170573556-462f5026-a076-4c47-88e4-79aca32d6b58.png)

3. Add or select a connection string.

![image](https://user-images.githubusercontent.com/17564001/170640698-63e2f85b-79e6-4617-9a9f-154a974db2b3.png)

4. Select all tables you created or changed.

![image](https://user-images.githubusercontent.com/17564001/170640887-19b6771d-38b2-46e7-a767-2f6310651629.png)

5. Set DbContext file name , Entities path , DbContext path , select pluralize to plural DbSet<> name. (These settings saved in efpt.config.json on root path of project and do every time)

(dbcontext file recreate every time so do not write any code in it)

![image](https://user-images.githubusercontent.com/17564001/170641507-342c2168-bf51-4934-87cf-e7d7da32fd25.png)

<hr>

- Validation : create a ViewModel class file and add validation attribute on top of properties.

![image](https://user-images.githubusercontent.com/17564001/170645236-f01caaec-ed07-499d-a34a-756bc905fb1e.png)

There are regex validations for username , password , Iranian mobile and email in this project.



Regular Expression for Username:

[A-Za-z0-9][A-Za-z0-9._]{2,50}

chars , numbers , . , _ accepted

minimun 3 chars



Regex for Password:

^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$

^: first line

(?=.*[a-z]) : Should have at least one lower case

(?=.*[A-Z]) : Should have at least one upper case

(?=.*\d) : Should have at least one number

(?=.*[#$^+=!*()@%&] ) : Should have at least one special character

.{8,} : Minimum 8 characters

$ : end line



Regex for Iranian mobiles:

09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}

start with 09 and then 1 for hamrahe avval , 3 for irancell , 2 for rightel

lenght is only 11 numbers



Regex for Email:

[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = Constants.RegularExpressionMsg)]



ErrorMessages are in Constants class , so you change error messages only one place:

![image](https://user-images.githubusercontent.com/17564001/170648785-710b73c9-0f27-4e59-b6cb-e297e09f6f1c.png)

<hr>

- Global exceptions handling:

You shouldn't repeat code for error 400 bad request : if(!ModelState.IsValid)

They are catched in Configs > BadRequestConfig.cs and handle

![image](https://user-images.githubusercontent.com/17564001/170649729-cbc71464-bec4-4566-81a3-e90a5fa04664.png)

You shouldn't repeat code for status 500 server errors. They are catched in Configs > ExceptionConfig.cs and handle.

You should throw Business Exceptions , for example : 

if(!user.CanInsert()) 
   throw new Exception("You can not be our user.");

![image](https://user-images.githubusercontent.com/17564001/170650025-60de933b-34b6-462a-8536-fcdde2d544db.png)

You shouldn't repeat code for error 401 Unauthorized , 403 Forbidden. They are catched in Configs > UnauthorizedConfig.cs and handle.

![image](https://user-images.githubusercontent.com/17564001/170652409-114ae4a4-b696-4c0c-b2f1-24b9951ff54b.png)

<hr>

- Secure user passwords : We must prevent to give away the user passwords , so we must change them that other persons can't read them in the data base.
We can generate one way hash for user1 password. If then user1 password give away , a person who access the data base can set user1's hash for user2 and login to the system with user2 username and gived away password. Then there is a solution for this problem and it is the salt password. The salt password is a random string that it use to generate the hash and causes that generated hashes are not similar to. For example the generated hash for pasword aA@12345 is change every time it generate so the hacker can not set it to user2. Then we must save the salt password in the data base for every user to generate the hash again for comparing in login service. So we should create 2 columns for password in user data base User table : HashPassword and SaltPasword.
But Here is how the default implementation (ASP.NET Framework or ASP.NET Core) works. It uses a Key Derivation Function with random salt to produce the hash. The salt is included as part of the output of the KDF. Thus, each time you "hash" the same password you will get different hashes. To verify the hash the output is split back to the salt and the rest, and the KDF is run again on the password with the specified salt. If the result matches to the rest of the initial output the hash is verified.
I write the class PasswordHasher based on .net6 PasswordHasher docs latest version (V3) , so you don't need to create SaltPassword in data base because the SaltPassword is in the Password.

<hr>
