# single folder introduction

This document is aimed to introduce the method to compile single/Assembly-CSharp.cs which is the single-file code of the game.

English | [简体中文](/docs/single_README_cn.md)

<br />

## Introduction

This project provides the source code of Assembly-CSharp. According to the code specification, each namespace is independent into a folder, and each class is independent into a file. However, the single-file code has excellent performance in temporary modification and code comparison. Therefore, this project also provides a single-file Assembly-CSharp.cs source code and a compilation command generation program for single-file programming using the C# compiler (The csc command) (this part is in [the README file](/README.md) of the project has a more detailed description). This is what the single folder contains.

<br />

## Usage

According to the description in [the README file](/README.md) of the project, we need to use the csc command to compile the Assembly-CSharp.cs single file. Therefore, we need a csc command line to compile Assembly-CSharp.cs. Assembly-CSharp.dll is based on the Unity engine, so this command line contains a large number of imported parameters, and manual input directly will waste a lot of time. So we use the python script program to generate the compilation command line.

**The python script file needs the support of the glob library. The syntax of python3 is used here, and it is only tested in the python3.8 environment without error. Python2 is not tested, please pay attention when using it.**

　　Open cmd/powershell/bash/zsh in the single folder, and then enter the following command:

```
python csc_generator.py
```

　　If the system environment is correct and everything is running normally, you will see the csc command line output from the console and the generation of the single/complie_code.txt file.  
　　The complie_code.txt file is also written in the csc command line which is used for compilation.  
　　Copy the csc command line. Make sure all characters are copied, and then paste them into cmd/powershell/bash/zsh. Press Enter. If the single/Assembly-CSharp.dll file is generated, the execution is normal.  
　　If it is not generated, check whether there is an error-level error in the single/errorlog.log. Resolve these errors in the Assembly-CSharp.cs file, copy the csc compilation command line again and recompile.

If there is no single/errorlog.log or single/complie_code.txt generated, please check the system environment and the code of single/csc_generator.py. If you have any questions, please submit an issue.

**This project provides a generation example of the single/complie_code.txt file, which can be used directly in theory. If there is any problem, please raise it through issue.**

<br />

## Example

Here is the result of single/complie_code.txt after reading-friendly formatting.

```
csc -t:library -out:./Assembly-CSharp.dll -errorlog:./errorlog.log -nostdlib -noconfig \
    -r:../reference/win/UnityEngine.TerrainPhysicsModule.dll \
    -r:../reference/win/UnityEngine.SpriteMaskModule.dll \
    -r:../reference/win/UnityEngine.CrashReportingModule.dll \
    -r:../reference/win/UnityEngine.Analytics.dll \
    -r:../reference/win/pb_Stl.dll \
    -r:../reference/win/UnityEngine.UnityAnalyticsModule.dll \
    -r:../reference/win/UnityEngine.UnityWebRequestWWWModule.dll \
    -r:../reference/win/UnityEngine.ARModule.dll \
    -r:../reference/win/UnityEngine.AccessibilityModule.dll \
    -r:../reference/win/HumanAPI.dll \
    -r:../reference/win/UnityEngine.SpriteShapeModule.dll \
    -r:../reference/win/UnityEngine.TextRenderingModule.dll \
    -r:../reference/win/ProBuilderMeshOps-Unity5.dll \
    -r:../reference/win/UnityEngine.UnityWebRequestTextureModule.dll \
    -r:../reference/win/UnityEngine.StandardEvents.dll \
    -r:../reference/win/UnityEngine.AssetBundleModule.dll \
    -r:../reference/win/UnityEngine.AnimationModule.dll \
    -r:../reference/win/UnityEngine.AudioModule.dll \
    -r:../reference/win/SumoPlatformLibrary.dll \
    -r:../reference/win/UnityEngine.ClusterInputModule.dll \
    -r:../reference/win/UnityEngine.InputModule.dll \
    -r:../reference/win/UnityEngine.DirectorModule.dll \
    -r:../reference/win/mscorlib.dll \
    -r:../reference/win/UnityFbxPrefab.dll \
    -r:../reference/win/UnityEngine.GameCenterModule.dll \
    -r:../reference/win/UnityEngine.Physics2DModule.dll \
    -r:../reference/win/UnityEngine.UnityConnectModule.dll \
    -r:../reference/win/UnityEngine.dll \
    -r:../reference/win/UnityEngine.UIElementsModule.dll \
    -r:../reference/win/UnityEngine.UIModule.dll \
    -r:../reference/win/UnityEngine.UI.dll \
    -r:../reference/win/UnityEngine.ParticlesLegacyModule.dll \
    -r:../reference/win/UnityEngine.StyleSheetsModule.dll \
    -r:../reference/win/UnityEngine.WebModule.dll \
    -r:../reference/win/UnityEngine.Timeline.dll \
    -r:../reference/win/UnityEngine.GridModule.dll \
    -r:../reference/win/KdTreeLib.dll \
    -r:../reference/win/UnityEngine.TerrainModule.dll \
    -r:../reference/win/Assembly-CSharp-firstpass.dll \
    -r:../reference/win/UnityEngine.VRModule.dll \
    -r:../reference/win/UnityEngine.JSONSerializeModule.dll \
    -r:../reference/win/UnityEngine.SpatialTracking.dll \
    -r:../reference/win/Mono.Security.dll \
    -r:../reference/win/Poly2Tri.dll \
    -r:../reference/win/System.dll \
    -r:../reference/win/UnityEngine.SharedInternalsModule.dll \
    -r:../reference/win/UnityEngine.ImageConversionModule.dll \
    -r:../reference/win/UnityEngine.TilemapModule.dll \
    -r:../reference/win/UnityEngine.ParticleSystemModule.dll \
    -r:../reference/win/UnityEngine.VehiclesModule.dll \
    -r:../reference/win/UnityEngine.PhysicsModule.dll \
    -r:../reference/win/UnityEngine.CoreModule.dll \
    -r:../reference/win/UnityEngine.PerformanceReportingModule.dll \
    -r:../reference/win/System.Xml.dll \
    -r:../reference/win/UnityEngine.WindModule.dll \
    -r:../reference/win/UnityEngine.ScreenCaptureModule.dll \
    -r:../reference/win/UnityEngine.ClusterRendererModule.dll \
    -r:../reference/win/UnityEngine.UnityWebRequestModule.dll \
    -r:../reference/win/ProBuilderCore-Unity5.dll \
    -r:../reference/win/UnityEngine.Networking.dll \
    -r:../reference/win/UnityEngine.UnityWebRequestAudioModule.dll \
    -r:../reference/win/UnityEngine.UNETModule.dll \
    -r:../reference/win/UnityEngine.ClothModule.dll \
    -r:../reference/win/UnityEngine.AIModule.dll \
    -r:../reference/win/UnityEngine.IMGUIModule.dll \
    -r:../reference/win/System.Core.dll \
    -r:../reference/win/UnityEngine.VideoModule.dll \
    ./Assembly-CSharp.cs
    
```