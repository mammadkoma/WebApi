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

<hr>

Regular Expression for Username:

[A-Za-z0-9][A-Za-z0-9._]{2,50}

chars , numbers , . , _ accepted

minimun 3 chars

<hr>

Regex for Password:

^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$

^: first line

(?=.*[a-z]) : Should have at least one lower case

(?=.*[A-Z]) : Should have at least one upper case

(?=.*\d) : Should have at least one number

(?=.*[#$^+=!*()@%&] ) : Should have at least one special character

.{8,} : Minimum 8 characters

$ : end line

<hr>

Regex for Iranian mobiles:

09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}

start with 09 and then 1 for hamrahe avval , 3 for irancell , 2 for rightel

lenght is only 11 numbers

<hr>

Regex for Email:

[RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = Constants.RegularExpressionMsg)]

<hr>

ErrorMessages are in Constants class , so you change error messages only one place:

![image](https://user-images.githubusercontent.com/17564001/170648785-710b73c9-0f27-4e59-b6cb-e297e09f6f1c.png)

<hr>

- Global exceptions handling:

You shouldn't repeate code for error 404 bad request : if(!ModelState.IsValid)

They are catched in Configs > BadRequestConfig.cs and handle

![image](https://user-images.githubusercontent.com/17564001/170649729-cbc71464-bec4-4566-81a3-e90a5fa04664.png)

You shouldn't repeate code for status 500 server errors. They are catched in Configs > ExceptionConfig.cs and handle.

You should throw Business Exceptions , for example : 

if(user.CanInsert()) 
   throw new Exception("You can not be our user.");

![image](https://user-images.githubusercontent.com/17564001/170650025-60de933b-34b6-462a-8536-fcdde2d544db.png)

You shouldn't repeate code for error 401 Unauthorized , 403 Forbidden. They are catched in Configs > UnauthorizedConfig.cs and handle.

![image](https://user-images.githubusercontent.com/17564001/170652409-114ae4a4-b696-4c0c-b2f1-24b9951ff54b.png)

<hr>
