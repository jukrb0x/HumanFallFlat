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

**If you have read this, you may be using the master branch.**

<br />

## Build


We recommend using Visual Studio to build the solution and generate the Assembly-CSharp.dll file:

> Open Assembly-CSharp.sln file by Visual Studio IDE;

> Choose "Assembly-CSharp" from the "Solution Explorer" on the right;

> Right click the item, choose "Build" menu;

> Then you can see the result of building at the bottom.

<br />

Build Visual Studio solution through the /src/Assembly-CSharp.csproj file:

> open /src/Assembly-CSharp.csproj file by Visual Studio IDE;

> Choose "References" from the "Solution Explorer" on the right;

> Right click the item, choose "Add Reference..." menu;

> Choose "Browse" on the left of the pop-up "Reference Manager" dialog, then click "Browse" button at the bottom;

> According to the system version used, select different folders under the "reference" folder and import all the dll files;

> Click "Add" button, a prompt box indicating the failure to introduce "mscorlib.dll" may pop up, click "OK" directly;

> Click "Project"->"Assembly-CSharp Properties" in the menu bar to enter the project property settings;

> Set the "Target Framework" to ".NET Framework 3.5";

> Close the page and continue to generate according to the above "Using Visual Studio to build the solution".

<br />

Build by csc command:

**Warning: This method should not be used in csproj compilation, it only supports c sharp single file compilation.**

> So, first you need get a single file of Assembly-Csharp.cs, that is default output of [ILSpy](https://github.com/icsharpcode/ILSpy) decompiler.

> Then, write a csc command line, use -out:\<path\> to point output dll file location, use -t:library to make a dll file.

> That's not enough, you also need -nostdlib to avoid using default .net framework whose version is not correct.

> Use -noconfig to avoid using default mscorlib.dll whose version is also not correct.

> Use many -t:\<path\> to import all reference dll files. Make sure all of those be imported in your csc command line.

> To do so, you may type some dozens of -t:\<path\> parameters, so be careful and patient.

> If you have written all of those parameters, the last you need to write is the location of single Assembly-Csharp.cs file.

> Last, Type Enter, run that command and if you are lucky you will see many warnings but no errors.

> If you are unlucky, you should add -errorlog:\<path\> to point where to write error logs and open this file.

> Search errors, deal with these errors and repeat those steps until you see no errors.

> There is an example of csc command line (Note: We don't guarantee its availability):

```
csc -t:library -out:./Assembly-CSharp.dll -errorlog:./errorlog.log -nostdlib -noconfig \
    -r:../UnityEngine.TerrainPhysicsModule.dll -r:../UnityEngine.SpriteMaskModule.dll \
    -r:../UnityEngine.CrashReportingModule.dll -r:../UnityEngine.Analytics.dll \
    -r:../pb_Stl.dll -r:../UnityEngine.UnityAnalyticsModule.dll \
    -r:../UnityEngine.UnityWebRequestWWWModule.dll -r:../UnityEngine.ARModule.dll \
    -r:../UnityEngine.AccessibilityModule.dll -r:../HumanAPI.dll \
    -r:../UnityEngine.SpriteShapeModule.dll -r:../UnityEngine.TextRenderingModule.dll \
    -r:../ProBuilderMeshOps-Unity5.dll -r:../UnityEngine.UnityWebRequestTextureModule.dll \
    -r:../UnityEngine.StandardEvents.dll -r:../UnityEngine.AssetBundleModule.dll \
    -r:../UnityEngine.AnimationModule.dll -r:../UnityEngine.AudioModule.dll \
    -r:../SumoPlatformLibrary.dll -r:../UnityEngine.ClusterInputModule.dll \
    -r:../UnityEngine.InputModule.dll -r:../UnityEngine.DirectorModule.dll \
    -r:../mscorlib.dll -r:../UnityFbxPrefab.dll -r:../UnityEngine.GameCenterModule.dll \
    -r:../UnityEngine.Physics2DModule.dll -r:../UnityEngine.UnityConnectModule.dll \
    -r:../UnityEngine.dll -r:../UnityEngine.UIElementsModule.dll -r:../UnityEngine.UIModule.dll \
    -r:../UnityEngine.UI.dll -r:../UnityEngine.ParticlesLegacyModule.dll \
    -r:../UnityEngine.StyleSheetsModule.dll -r:../UnityEngine.WebModule.dll \
    -r:../UnityEngine.Timeline.dll -r:../UnityEngine.GridModule.dll -r:../KdTreeLib.dll \
    -r:../UnityEngine.TerrainModule.dll -r:../Assembly-CSharp-firstpass.dll \
    -r:../UnityEngine.VRModule.dll -r:../UnityEngine.JSONSerializeModule.dll \
    -r:../UnityEngine.SpatialTracking.dll -r:../Mono.Security.dll -r:../Poly2Tri.dll \
    -r:../System.dll -r:../UnityEngine.SharedInternalsModule.dll \
    -r:../UnityEngine.ImageConversionModule.dll -r:../UnityEngine.TilemapModule.dll \
    -r:../UnityEngine.ParticleSystemModule.dll -r:../UnityEngine.VehiclesModule.dll \
    -r:../UnityEngine.PhysicsModule.dll -r:../UnityEngine.CoreModule.dll \
    -r:../UnityEngine.PerformanceReportingModule.dll -r:../System.Xml.dll \
    -r:../UnityEngine.WindModule.dll -r:../UnityEngine.ScreenCaptureModule.dll \
    -r:../UnityEngine.ClusterRendererModule.dll -r:../UnityEngine.UnityWebRequestModule.dll \
    -r:../ProBuilderCore-Unity5.dll -r:../UnityEngine.Networking.dll \
    -r:../UnityEngine.UnityWebRequestAudioModule.dll -r:../UnityEngine.UNETModule.dll \
    -r:../UnityEngine.ClothModule.dll -r:../UnityEngine.AIModule.dll \
    -r:../UnityEngine.IMGUIModule.dll -r:../System.Core.dll -r:../UnityEngine.VideoModule.dll \
    ./Assembly-CSharp.cs
```

More detail about csc command, see [this](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe).

<br />

Build by msbuild command:

> If you want to compile csproj you should go to src folder and run the next command:

```
msbuild Assembly-CSharp.csproj
```

> Then if no errors you will see bin folder was generated in src folder, that's what we need.

> You can also use msbuild to compile sln file (Visual Studio project file), run the next command:

```
msbuild Assembly-CSharp.sln
```

> We have not tried such usage, but it is theoretically feasible.

More detail about msbuild, see [this](https://docs.microsoft.com/zh-cn/visualstudio/msbuild/msbuild?view=vs-2019).

<br />

## Credit


[XiaoHuiHui233](https://github.com/XiaoHuiHui233)