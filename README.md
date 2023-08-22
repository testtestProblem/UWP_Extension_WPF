# Why need UWP extention
Universal Windows Platform (UWP). It has delicate UI by XAML. 
But it can not support a lot of WIN32 function. 
That is why we need UWP extention to unlimited it ability. 

# Project describe
* Testing paltform: visual studio 2019
* Minimum requirement: Win10, version 1809
* Function describe: UWP through Windows Desktop Extensions for the UWP tool side loading WPF. Uwp can communicate with WPF, WPF can reply it.  
* Compile sample: UWP can not run at any CPU, and target should set Windows Application Packaging Project.  
![image](https://github.com/testtestProblem/UWP_extention/assets/107662393/b60b14bc-4c7e-4bba-9e72-c146665b3147)

# UWP extention
* This UWP_extention can side loading WPF by using ```FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync()```.  

* And should generate self-signed certification.  
![image](https://github.com/testtestProblem/UWP_extention/assets/107662393/0aca610e-2e1f-483e-be29-ae0ea8851638)

* Add references Windows Desktop Extensions for the UWP in UWP project.  
![image](https://github.com/testtestProblem/UWP_extention/assets/107662393/9c2721f2-0fc4-4a04-8162-bc3da3b69213)

* Modify Package.appxmanifest by adding extensions in Windows Application Packaging Project which is showed below.
```
<Extensions>
  <uap:Extension Category="windows.appService">
       <uap:AppService Name="SampleInteropService" />
  </uap:Extension>
	<desktop:Extension Category="windows.fullTrustProcess" Executable="WindowsFormsApp1\WindowsFormsApp1.exe" />
</Extensions>
```

# Reference
* https://stefanwick.com/2018/04/16/uwp-with-desktop-extension-part-3/
* https://www.cnblogs.com/manupstairs/p/14178931.html
* https://github.com/StefanWickDev/UWP-FullTrust/tree/master/UWP_FullTrust_3
* https://freetion26.medium.com/uwp%E9%80%8F%E9%81%8Eappserviceconnection%E5%92%8Cwin32-process%E6%BA%9D%E9%80%9A%E5%8F%96%E5%BE%97%E7%B3%BB%E7%B5%B1%E8%B7%AF%E5%BE%91%E4%B8%8B%E6%AA%94%E6%A1%88%E5%88%97%E8%A1%A8-981dd0765e52
