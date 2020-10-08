# single文件夹使用说明

本文档旨在对single文件夹中Assembly-CSharp.cs单文件进行编译的方法进行说明。

[English](/docs/single_README.md) | 简体中文

<br />

## 介绍

本项目提供了Assembly-CSharp的源码，根据代码规范，每个命名空间独立成文件夹，每个类独立成文件。但是，单文件的代码在临时修改和代码比对等工作上有着优异的表现。因此本项目另提供了单文件的Assembly-CSharp.cs源码以及利用C#编译器（csc指令）进行单文件编程的编译命令生成程序（这部分内容在[项目的README文件](/docs/README_cn.md)中有更加详细的描述）。single文件夹所包含的就是这些。

<br />

## 用法

根据[项目的README文件](/docs/README_cn.md)中的描述，我们需要使用csc命令对Assembly-CSharp.cs单文件进行编译。因此，我们需要一个csc编译Assembly-CSharp.cs的命令行。Assembly-CSharp.dll是基于Unity引擎的，所以这个命令行中包含了大量的引入参数，手动直接输入会浪费大量的时间。所以我们使用python脚本程序来完成编译命令行的生成。

**python脚本文件需要glob库的支持。这里使用了python3的语法，仅在python3.8环境下测试无误；python2未进行测试，使用时请注意。**

　　在single文件夹下打开cmd/powershell/bash/zsh，之后输入以下指令：

```
python csc_generator.py
```
　　若系统环境无误，一切运行正常，则会看到控制台输出的csc命令行以及single/complie_code.txt文件的生成。  
　　complie_code.txt文件写入的也是用于编译的csc命令行。  
　　复制该csc命令行，确保全部字符均被复制，之后粘贴到cmd/powershell/bash/zsh中，按下Enter键。  
　　若生成single/Assembly-CSharp.dll文件，则执行正常。  
　　若未生成，检查single/errorlog.log中是否存在error级的错误。  
　　在Assembly-CSharp.cs文件中解决这些错误，重新复制csc编译命令行，重新编译。

若无single/errorlog.log或single/complie_code.txt生成，请检查系统环境和single/csc_generator.py的代码。如有问题欢迎提出issue进行交流。

**本项目提供了single/complie_code.txt文件的一个生成样例，理论上可以直接使用。若存在问题请通过issue提出。**

<br />

## 代码样例

此处提供了single/complie_code.txt经过阅读友好的规整之后的结果。

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