Fankart project is built on Microsoft technology stack (c#, .net core, razor pages, SQL), HTML and CSS.
So to work on local environment 
  Install visual studio Microsoft Visual Studio Community 2022 from https://visualstudio.microsoft.com/downloads/?cid=learn-onpage-download-tutorial-create-csharp-aspnetcore-web-app-page-cta  
  Follow steps from https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022
  You might need to install .net framewrok if not prompted in steps
  Clone the repository into your system from https://github.com/chellatoremaruthi/FanKart 
  Once cloned click on .sln file
  ![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/36786cdf-cfb1-4358-bd81-f91800852534)

We already have a Azure SQl with all the scripts executed may be we can connect to azure database instead of downloading sql and running the scripts.

Once project is opened click on Build -> Build Solution present on top bar
Click on solution explorer -> Right click on Fankart -> Properties
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/772730ea-fc09-4e37-a97b-13287ab21a2c)

Once properties tab is presented click on Debug -> General -> Open debug launch profiles UI
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/b723e334-6a41-4491-b4a5-5e0f1daa3caf)

From popup under environment variables add key ASPNETCORE_ENVIRONMENT and values Production
![image](https://github.com/chellatoremaruthi/FanKart/assets/76154795/93b46068-3af5-4f90-aa81-6903dcaadfa5)

The set up is done and we can run the solution now





