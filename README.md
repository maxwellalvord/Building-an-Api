# Building an Api

#### By _**Maxwell Alvord**_   

#### _This is an API for National Parks that includes information about their names, locations, and popularity!_  


## Technologies Used

* _C#_
* _.NET 5_
* _SQL Workbench_
* _Entity Framework_
* _Swagger_

---
## Description

This is an API that's populated with seed data from real National Parks around the country. Swagger UI is integrated into this project for easy api use.
_Written in C#_

---
## Setup and Installation Requirements
**This Setup assumes you have GitBash and MySQL Workbench pre-installed.   
If needed, please navigate to these links:  
https://git-scm.com/download/  
Download Git and follow the setup wizard.  
https://dev.mysql.com/downloads/workbench/  
Download MySQL Workbench, follow the setup wizard & create a localhost server on port 3306**


*Note: Keep track of your username and password, this will be used in the connection link under,*  
"**SQL Workbench Configuration**" > "2. Insert the following code:"

<details>
<summary><strong>Initial Setup</strong></summary>
<ol>
<li>Copy the git repository url: https://github.com/maxwellalvord/Building-an-Api.git
<li>Open a terminal and navigate to your Desktop with <strong>cd</strong> command
<li>Run,   
<strong>$ git clone https://github.com/maxwellalvord/Building-an-Api.git</strong>
<li>In the terminal, navigate into the projects root directory, "NatPark".
<li>Move onto "SQL Workbench Configuration" instructions below to build the necessary database.
<br>
</details>

<details>
<summary><strong>SQL Workbench Configuration</strong></summary>
<ol>
<li>Create an appsettings.Development.json file in the "NatPark" directory  
   <pre>NatPark
   └── appsettings.Development.json</pre>

<li> Insert the following code: <br>

<pre>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=nat_park;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}</pre>
<small>*Note: you must include your password in the code block section labeled "YOUR-PASSWORD-HERE".</small><br>
<small>**Note: you must include your username in the code block section labeled "YOUR-USERNAME-HERE".</small><br>
<small>***Note: if you plan to push this cloned project to a public-facing repository, remember to add the appsettings.Development.json file to your .gitignore before doing so.</small>

<li>In root directory of project folder "NatPark", run  
<strong>$ dotnet ef migrations add restoreDatabase</strong>
<li>Then run <strong>$ dotnet ef database update</strong>

<ol> 
  <li>Open SQL Workbench.
  <li>Navigate to "NatPark" schema.
  <li>Click the drop down, select "Tables" drop down.
  <li>Verify the table, you should see <strong>park</strong>.
  
</details>

<details>
<summary><strong>To Run</strong></summary>
Navigate to:  
   <pre>NatPark/</pre>

Run ```$ dotnet restore``` in the terminal.<br>
Run ```$ dotnet run``` in the terminal.
</details>
<br>

---

## API Documentation
_This API is using Swagger (an open-source API tool) to describe its structure and display all available endpoints_

<details>
<summary><strong>View in Browser</strong></summary>
<ol>
<li> Follow the project <strong>Setup and Installation Requirements</strong> below & run the application in a terminal inside the projects root directory with   

```$ dotnet run```
<li> Open the application in a browser by selecting the provided link in your terminal   

(Ex:|| http://localhost:5004) 

<li> Add <strong>"/swagger/v1/swagger.json"</strong> to the end of the URL path to view API structure and all endpoints    

(Ex:|| http://localhost:5004/swagger/v1/swagger.json)

<br>
</details>

---
## Endpoints

Base URL: http://localhost:5004

#### HTTP Request

```
GET api/Parks
POST api/Parks
DELETE api/Parks/{id}
PUT api/Parks/{id}
GET api/Parks/{id}
```

#### Example Query

```
http://localhost:5004/api/Parks/1
```

---

>#### _**A Big Thanks To:**_ 
>#### **Garrett Hays @ https://github.com/GarrettHays**    
>#### **Zachary Waggoner @ https://github.com/CyndaZ42**  
>#### _**for amazing README formatting and instructions!**_  

---

## License
[MIT](https://opensource.org/osd)

Copyright &copy;
2022 Maxwell Alvord

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

<br>

## Contact Information
Contact me with questions and bugs at: <br>
[A link to my issues page on GitHub](https://github.com/maxwellalvord/maxwellalvord/issues)<br>
or email me at <a href = "mailto:maxwellalvord@gmail.com">maxwellalvord@gmail.com</a>