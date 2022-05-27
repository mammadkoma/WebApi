# asp.net core 6 web api for spa apps , focusing on writing less code
- Global Using Statements , then you shouldn't write using using ... on top of all classes.
![image](https://user-images.githubusercontent.com/17564001/170569285-18e5694b-a610-4346-ae36-61920e49c7c4.png)

- File Scoped Namespaces , then we remove namespace block and get more space.
![image](https://user-images.githubusercontent.com/17564001/170639922-4c4f0a43-3d06-4118-a151-b3e8e3d87224.png)
 * Enable it in visual studio options for your new classes:
   ![image](https://user-images.githubusercontent.com/17564001/170640230-90d33c4a-a0bb-4c1a-bfad-616b28143b34.png)
<hr>

- ef core 6 data base first
 * for scaffolding: 
 1. Install "ef core power tools" visual studio extension (It needs open and close Visual Studio after downloading)
 ![image](https://user-images.githubusercontent.com/17564001/170569946-da43bfa3-1d1e-4bbe-8144-f8e1df6c38f3.png)
 2. Right click on web project (not solution) , then select EF Core Power Tools > Reverse Engineer
 ![image](https://user-images.githubusercontent.com/17564001/170573556-462f5026-a076-4c47-88e4-79aca32d6b58.png)
3. Add or select a connection string
