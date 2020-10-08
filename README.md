# *Human: Fall Flat* Source Code

The decompiled source code of the Unity game *Human: Fall Flat*.

English | [简体中文](/docs/README_cn.md)

<br />

## Declaraction


This project aims to provide assistance to the innovative development of the game *Human: Fall Flat*. It also facilitates developers to conduct research and develop modules. The copyright of this project belongs to [*No Brakes Games*](https://www.nobrakesgames.com/). It is only used for technical research and prohibits any type of commercial use. The officials of *Human: Fall Flat* severely crack down on such acts and reserve the right to pursue legal responsibility.

The code of this project follows the GPLv3 open source agreement. But it should be noted that the scope of the code is limited to the Assembly-CSharp.dll library file. The developer's secondary development can't bypass the own copyright of *Human: Fall Flat*. So it is not allowed to use this code for cracking or other acts that violate the copyright of the game.

<br />

## Introduction


This project is a decompilation of the core function code in *Human: Fall Flat* program, namely the Assembly-CSharp.dll. The project will be updated with the update of *Human: Fall Flat*. The project uses [ILSpy](https://github.com/icsharpcode/ILSpy) to decompile and build C sharp project files. Then import into Visual Studio IDE to make solution files. The files of this project include a C Sharp project file and a Visual Studio solution file. If these two files' version are inconsistent, they can be regenerated without affecting the code.

This project contains two branches. The master branch represents the code of Windows. The osx branch represents the code of MacOS. Please use them according to the actual situation.

**If you have read this, you may be using the osx branch.**

<br />

## Build


### We recommend using Visual Studio to build the solution and generate the Assembly-CSharp.dll file:

　　Open Assembly-CSharp.sln file by Visual Studio IDE;  
　　Choose "Assembly-CSharp" from the "Solution Explorer" on the right;  
　　Right click the item, choose "Build" menu;  
　　Then you can see the result of building at the bottom.

<br />

### Build Visual Studio solution through the /src/Assembly-CSharp.csproj file:

　　Open /src/Assembly-CSharp.csproj file by Visual Studio IDE;  
　　Choose "References" from the "Solution Explorer" on the right;  
　　Right click the item, choose "Add Reference..." menu;  
　　Choose "Browse" on the left of the pop-up "Reference Manager" dialog;  
　　Then click "Browse" button at the bottom;  
　　According to the system version used, select different folders under the "reference" folder;  
　　And import all the dll files;  
　　Click "Add" button, a prompt box indicating the failure to introduce "mscorlib.dll" may pop up;  
　　Click "OK" directly;  
　　Click "Project"->"Assembly-CSharp Properties" in the menu bar to enter the project property settings;  
　　Set the "Target Framework" to ".NET Framework 3.5";  
　　Close the page and continue to generate according to the above "Using Visual Studio to build the solution".

<br />

### Build by csc command:

**Warning: This method should not be used in csproj compilation, it only supports c sharp single file compilation.**

　　So, first you need get a single file of Assembly-Csharp.cs, that is default output of [ILSpy](https://github.com/icsharpcode/ILSpy) decompiler.  
　　Then, write a csc command line, use -out:\<path\> to point output dll file location, use -t:library to make a dll file.  
　　That's not enough, you also need -nostdlib to avoid using default .net framework whose version is not correct.  
　　Use -noconfig to avoid using default mscorlib.dll whose version is also not correct.  
　　Use many -t:\<path\> to import all reference dll files.  
　　Make sure all of those be imported in your csc command line.  
　　To do so, you may type some dozens of -t:\<path\> parameters, so be careful and patient.  
　　If you have written all of those parameters, the last you need to write is the location of Assembly-Csharp.cs.  
　　Last, Type Enter, run that command and if you are lucky you will see many warnings but no errors.  
　　If you are unlucky, you should add -errorlog:\<path\> to point where to write error logs and open this file.  
　　Search errors, deal with these errors and repeat those steps until you see no errors.

There is an example of csc command line (Note: We don't guarantee its availability):

```
csc -t:library -out:./Assembly-CSharp.dll -errorlog:./errorlog.log -nostdlib -noconfig \
    -r:../reference/osx/UnityEngine.TerrainPhysicsModule.dll \
    -r:../reference/osx/UnityEngine.SpriteMaskModule.dll \
    -r:../reference/osx/UnityEngine.CrashReportingModule.dll \
    -r:../reference/osx/UnityEngine.Analytics.dll \
    -r:../reference/osx/pb_Stl.dll \
    -r:../reference/osx/UnityEngine.UnityAnalyticsModule.dll \
    -r:../reference/osx/UnityEngine.UnityWebRequestWWWModule.dll \
    -r:../reference/osx/UnityEngine.ARModule.dll \
    -r:../reference/osx/UnityEngine.AccessibilityModule.dll \
    -r:../reference/osx/HumanAPI.dll \
    -r:../reference/osx/UnityEngine.SpriteShapeModule.dll \
    -r:../reference/osx/UnityEngine.TextRenderingModule.dll \
    -r:../reference/osx/ProBuilderMeshOps-Unity5.dll \
    -r:../reference/osx/UnityEngine.UnityWebRequestTextureModule.dll \
    -r:../reference/osx/UnityEngine.StandardEvents.dll \
    -r:../reference/osx/UnityEngine.AssetBundleModule.dll \
    -r:../reference/osx/UnityEngine.AnimationModule.dll \
    -r:../reference/osx/UnityEngine.AudioModule.dll \
    -r:../reference/osx/SumoPlatformLibrary.dll \
    -r:../reference/osx/UnityEngine.ClusterInputModule.dll \
    -r:../reference/osx/UnityEngine.InputModule.dll \
    -r:../reference/osx/UnityEngine.DirectorModule.dll \
    -r:../reference/osx/mscorlib.dll \
    -r:../reference/osx/UnityFbxPrefab.dll \
    -r:../reference/osx/UnityEngine.GameCenterModule.dll \
    -r:../reference/osx/UnityEngine.Physics2DModule.dll \
    -r:../reference/osx/UnityEngine.UnityConnectModule.dll \
    -r:../reference/osx/UnityEngine.dll \
    -r:../reference/osx/UnityEngine.UIElementsModule.dll \
    -r:../reference/osx/UnityEngine.UIModule.dll \
    -r:../reference/osx/UnityEngine.UI.dll \
    -r:../reference/osx/UnityEngine.ParticlesLegacyModule.dll \
    -r:../reference/osx/UnityEngine.StyleSheetsModule.dll \
    -r:../reference/osx/UnityEngine.WebModule.dll \
    -r:../reference/osx/UnityEngine.Timeline.dll \
    -r:../reference/osx/UnityEngine.GridModule.dll \
    -r:../reference/osx/KdTreeLib.dll \
    -r:../reference/osx/UnityEngine.TerrainModule.dll \
    -r:../reference/osx/Assembly-CSharp-firstpass.dll \
    -r:../reference/osx/UnityEngine.VRModule.dll \
    -r:../reference/osx/UnityEngine.JSONSerializeModule.dll \
    -r:../reference/osx/UnityEngine.SpatialTracking.dll \
    -r:../reference/osx/Mono.Security.dll \
    -r:../reference/osx/Poly2Tri.dll \
    -r:../reference/osx/System.dll \
    -r:../reference/osx/UnityEngine.SharedInternalsModule.dll \
    -r:../reference/osx/UnityEngine.ImageConversionModule.dll \
    -r:../reference/osx/UnityEngine.TilemapModule.dll \
    -r:../reference/osx/UnityEngine.ParticleSystemModule.dll \
    -r:../reference/osx/UnityEngine.VehiclesModule.dll \
    -r:../reference/osx/UnityEngine.PhysicsModule.dll \
    -r:../reference/osx/UnityEngine.CoreModule.dll \
    -r:../reference/osx/UnityEngine.PerformanceReportingModule.dll \
    -r:../reference/osx/System.Xml.dll \
    -r:../reference/osx/UnityEngine.WindModule.dll \
    -r:../reference/osx/UnityEngine.ScreenCaptureModule.dll \
    -r:../reference/osx/UnityEngine.ClusterRendererModule.dll \
    -r:../reference/osx/UnityEngine.UnityWebRequestModule.dll \
    -r:../reference/osx/ProBuilderCore-Unity5.dll \
    -r:../reference/osx/UnityEngine.Networking.dll \
    -r:../reference/osx/UnityEngine.UnityWebRequestAudioModule.dll \
    -r:../reference/osx/UnityEngine.UNETModule.dll \
    -r:../reference/osx/UnityEngine.ClothModule.dll \
    -r:../reference/osx/UnityEngine.AIModule.dll \
    -r:../reference/osx/UnityEngine.IMGUIModule.dll \
    -r:../reference/osx/System.Core.dll \
    -r:../reference/osx/UnityEngine.VideoModule.dll \
    ./Assembly-CSharp.cs

```

More detail about csc command, see [this](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe).

<br />

### Build by msbuild command:

　　If you want to compile csproj you should go to src folder and run the next command:

```
msbuild Assembly-CSharp.csproj
```

　　Then if no errors you will see bin folder was generated in src folder, that's what we need.  
　　You can also use msbuild to compile sln file (Visual Studio project file), run the next command:

```
msbuild Assembly-CSharp.sln
```

　　We have not tried such usage, but it is theoretically feasible.

More detail about msbuild, see [this](https://docs.microsoft.com/zh-cn/visualstudio/msbuild/msbuild?view=vs-2019).

<br />

## Index


The file index of this project is the following:

HumanFallFlat  
|-- Assembly-CSharp.sln　　　　 　 The Visual Studio project file  
|-- README.md　　　　　　　　　　The introduction file of this project  
|-- docs　　　　　　　　　　　 　　 This folder is used to store all documents  
|　　　|-- README_cn.md　　　　　The introduction file of this project by Chinese  
|　　　|-- single_README.md　　 　 The introduction file of the single folder  
|　　　|-- single_README_cn.md　　The introduction file of the single folder by Chinese  
|-- reference　　　　　　　　 　　　 This folder is used to store all references  
|　　　|-- osx　　　　　　　　　　　This folder is used to store all references in MacOS  
|　　　　　　|-- \*.dll　　　　　　　　All dll files in the game  
|-- single　　　　　　　　　　　　　 This folder is used to store all about the single-file code   
|　　　|-- Assembly-CSharp.cs　　　The source code of the game in a single file  
|　　　|-- complie_code.txt　　　　　The csc command line is used to compile Assembly-CSharp.cs  
|　　　|-- csc_generator.py　　　　　The python script is used to generate the csc command line  
|-- src　　　　　　　　　　　　　 　 This folder is used to store all source code files  
　　　 |-- \*.cs　　　　　　　　　　　 The C# source code files  
　　　 |-- Assembly-CSharp.csproj　 The C# project file

<br />

## Credit


[XiaoHuiHui233](https://github.com/XiaoHuiHui233)