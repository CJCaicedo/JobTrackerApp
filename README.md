<h1 align="center">💼📃 JobTrackerApp</h1>

<p align="center">
  <b>A modern job application tracker built with ASP.NET Core & AWS ☁️</b><br>
  <i>Stay organized, track progress, and take control of your job search journey!</i>
</p>

-----------------------------------------------------------------------------------------------------------

### ✨ Overview
**JobTrackerApp** is a full-stack web application that helps users manage and track their job applications — from **Applied** to **Interviewing**, **Offer**, or **Rejected**.  
It was built as a professional portfolio project using **.NET 9.0**, **C#**, **Entity Framework Core**, and deployed on **AWS Elastic Beanstalk** with a **SQL Server (RDS)** backend.

-----------------------------------------------------------------------------------------------------------

### 🧠 Features
✅ Add, edit, and delete job applications  
✅ Organize them in a simple Kanban-style view  
✅ Track company, position, salary, and contact info  
✅ Securely connected to an AWS RDS SQL Server database  
✅ Deployed with AWS Elastic Beanstalk  
✅ Modern and clean UI built with Razor Pages & Bootstrap  

-----------------------------------------------------------------------------------------------------------

### 🛠️ Tech Stack
| Category | Tools |
|-----------|--------|
| 💻 **Backend** | ASP.NET Core 9.0 (C#), Entity Framework Core |
| 🗄️ **Database** | SQL Server (Amazon RDS) |
| 🎨 **Frontend** | Razor Pages, HTML5, CSS3, Bootstrap |
| 🔁 **Mapping** | AutoMapper |
| ☁️ **Cloud** | AWS Elastic Beanstalk, Amazon RDS, IAM |
| 🧰 **Other Tools** | Visual Studio, GitHub, Newtonsoft.Json |

---

### 📁 Project Structure
```bash
JobTrackerApp/
│
├── Controllers/          # Handles logic for pages and API routes
├── Data/                 # Database connections and repositories
├── Dtos/                 # Data Transfer Objects (for cleaner data flow)
├── Models/               # Main data structure (JobApplication)
├── Profiles/             # AutoMapper configuration
├── Views/                # Razor pages (UI)
├── wwwroot/              # Static files like CSS, JS, images
├── Program.cs            # App startup configuration
└── README.md             # You are here 🚀

### 🌐 Deployment
This project was successfully deployed to **AWS Elastic Beanstalk** and connected to an **Amazon RDS (SQL Server)** database.

- The app runs on a cloud environment managed by AWS.  
- The database stores all job application information securely.  
- Connection details are kept private using environment variables.  
- HTTPS encryption ensures the communication between app and database is safe.

### 📡 API Endpoints

These routes power the backend of the app and handle data for job applications.

| Method | Endpoint | Purpose |
|--------|-----------|----------|
| GET | '/api/jobapplications' | Show all job applications |
| GET | '/api/jobapplications/{id}' | Show one specific job |
| POST | '/api/jobapplications' | Add a new job application |
| PUT | '/api/jobapplications/{id}' | Update an existing job |
| PATCH | '/api/jobapplications/{id}' | Update part of a job record |
| DELETE | '/api/jobapplications/{id}' | Remove a job application |


### 🧩 How to Run Locally

If you want to see how the app works on your own computer, follow these simple steps:

1️⃣ Clone this repository:  
'git clone https://github.com/yourusername/JobTrackerApp.git'

2️⃣ Go into the project folder:  
'cd JobTrackerApp'

3️⃣ Open the project in **Visual Studio** or **VS Code**.

4️⃣ Update your database connection:  
In the file 'appsettings.json', make sure you have this line:

"ConnectionStrings": {
  "CommanderConnection": "Server=localhost;Database=JobTrackerAppDB;Trusted_Connection=True;"
}

5️⃣ Run the app:  
'dotnet run'

6️⃣ Open your browser and go to:  
👉🏿 https://localhost:5001/JobApplicationUi  
(If your Visual Studio shows a different port, use that one.)



👩🏿‍💻 About the Developer

Cindy Johana Caicedo Caicedo🙆🏿‍♀️
Software Developer | AWS Certified | Bilingual (English / Spanish)

🌍 Based in Philadelphia, PA
📧 www.linkedin.com/in/cindy-johana-caicedo
☁️ Passionate about building cloud-connected, data-driven apps that simplify real-life tasks.
🧾 License

![JobTrackerApp Demo](wwwroot/images/JobTracker-Demo.gif)
