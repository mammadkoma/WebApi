# asp.net core 6 web api for spa apps , focusing on writing less code
Global Using Statements , then you shouldn't write using using ... on top of all classes.
![image](https://user-images.githubusercontent.com/17564001/170569285-18e5694b-a610-4346-ae36-61920e49c7c4.png)
<hr>
File Scoped Namespaces , then we remove namespace block and get more space.

![image](https://user-images.githubusercontent.com/17564001/170643358-46b23d5a-c0af-4c2f-b8a3-3482b0ea5806.png)


Enable it in visual studio options for your new classes:
![image](https://user-images.githubusercontent.com/17564001/170640230-90d33c4a-a0bb-4c1a-bfad-616b28143b34.png)
<hr>
ef core 6 data base first
for scaffolding: 
1. Install "ef core power tools" visual studio extension (It needs close and open Visual Studio after downloading)

![image](https://user-images.githubusercontent.com/17564001/170569946-da43bfa3-1d1e-4bbe-8144-f8e1df6c38f3.png)

2. Right click on web project (not solution) , then select EF Core Power Tools > Reverse Engineer
![image](https://user-images.githubusercontent.com/17564001/170573556-462f5026-a076-4c47-88e4-79aca32d6b58.png)

3. Add or select a connection string.
![image](https://user-images.githubusercontent.com/17564001/170640698-63e2f85b-79e6-4617-9a9f-154a974db2b3.png)

4. Select all tables you created or changed.
![image](https://user-images.githubusercontent.com/17564001/170640887-19b6771d-38b2-46e7-a767-2f6310651629.png)

5. Set DbContext file name , Entities path , DbContext path , select pluralize to plural DbSet<> name. 
(dbcontext file recreate every time so do not write any code in it)
![image](https://user-images.githubusercontent.com/17564001/170641507-342c2168-bf51-4934-87cf-e7d7da32fd25.png)
