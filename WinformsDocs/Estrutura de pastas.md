
MyTrainingApp/  
│  
├── Forms/                  <- All WinForms  
│   ├── MainForm.cs  
│   ├── EmployeeForm.cs  
│   └── SalaryForm.cs  
│  
├── Models/                 <- Data structures  
│   ├── Employee.cs  
│   ├── Salary.cs  
│   └── Training.cs  
│  
├── BusinessLogic/          <- Core logic  
│   ├── EmployeeManager.cs  
│   ├── SalaryManager.cs  
│   └── TrainingManager.cs  
│  
├── DataAccess/             <- Database interaction  
│   ├── EmployeeRepository.cs  
│   ├── SalaryRepository.cs  
│   └── TrainingRepository.cs  
│  
├── Utils/                  <- Helpers, extensions, validators  
│   ├── DbHelper.cs  
│   └── InputValidator.cs  
│  
├── Program.cs              <- Entry point  
└── App.config / appsettings.json