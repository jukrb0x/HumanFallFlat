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