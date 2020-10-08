# 《人类：一败涂地》源代码

Unity游戏《人类：一败涂地》的反编译源代码。

[English](/README.md) | 简体中文

<br />

## 声明


本项目旨在对《人类：一败涂地》的创新性设计提供帮助，方便开发者进行mod功能研究和开发。本项目版权归[*No Brakes Games*工作室](https://www.nobrakesgames.com/)所有，仅用于技术研究，禁止任何类型的商业用途。《人类：一败涂地》官方严厉打击此类行为，并保留追究法律责任的权利。

本项目代码遵循GPLv3开源协议。但须注意的是，本项目代码的作用范围仅限于Assembly-CSharp.dll库文件。开发者进行二次开发并不能绕过《人类：一败涂地》本身所具有的版权，因此不得使用此代码进行《人类：一败涂地》破解等违反《人类：一败涂地》本身所具有版权的行为。

<br />

## 介绍


本项目是对《人类：一败涂地》程序中功能核心代码，即Assembly-CSharp.dll库文件的反编译。项目会随着《人类：一败涂地》的更新而更新。项目使用[ILSpy](https://github.com/icsharpcode/ILSpy)反编译工具进行反编译，生成C Sharp项目文件，之后导入Visual Studio IDE中生成解决方案。项目文件中包含了C Sharp项目文件和Visual Studio解决方案文件。如果版本不一致，可以重新生成两个文件，不会影响代码本身。

本项目包含两个分支，master分支表示Windows版本的代码，osx分支表示MacOS版本的代码，请根据实际情况使用。

**如果你看到这句话，那么你大概率可能使用的是master分支。**

<br />

## 构建


建议使用Visual Studio进行解决方案构建，生成Assembly-CSharp.dll文件：

　　使用Visual Studio IDE打开Assembly-CSharp.sln文件；  
　　在右侧“解决方案资源管理器”中选择“Assembly-CSharp”项；  
　　右键该项，选择“生成”；  
　　在下方输出栏即可看到生成结果。

</br>

通过/src/Assembly-CSharp.csproj文件进行Visual Studio解决方案构建：

　　使用Visual Studio IDE打开/src/Assembly-CSharp.csproj文件；  
　　在右侧“解决方案资源管理器”中选择“引用”；  
　　右键该项，选择“添加引用”；  
　　在弹出的“引用管理器”对话框中，选择左边的“浏览”，再点击下面的“浏览”按钮；  
　　根据所使用的系统版本，选择reference文件夹下的不同文件夹，引入其中的所有dll文件；  
　　点击“添加”按钮，可能会弹出“mscorlib.dll”引入失败的提示框，直接点击“确定”；  
　　点选菜单栏中的“项目”->“Assembly-CSharp属性”，进入项目属性设置；  
　　将“目标框架”选择为“.NET Framework 3.5”；  
　　关闭该页面，按照上方“使用Visual Studio进行解决方案构建”的方式继续生成即可。

</br>

使用csc命令进行构建:

**注意：此方法不应该用作csproj项目文件的编译，它仅支持编译c#代码文件！**

　　首先你要获取Assembly-Csharp.cs文件，[ILSpy](https://github.com/icsharpcode/ILSpy)反编译器默认输出即此；  
　　然后写一个csc的命令行，使用 -out:\<路径\> 参数指定dll文件输出的路径，使用 -t:library 参数表明输出的是dll库文件；  
　　但这是不够的，你还需要使用 -nostdlib 参数来避免使用默认的 .net framework，因为版本可能不正确；  
　　使用 -noconfig 参数避免使用默认的mscorlib.dll，同样因为版本可能不正确；  
　　使用 -t:\<路径\> 来引入全部依赖dll文件，确保在你的csc命令行中引入了全部的依赖文件；  
　　为了做到这件事，你可能需要键入数十个 -t:\<路径\> 参数，请保持仔细和耐心；  
　　如果你写完了全部的参数，你最后要写的便是Assembly-Csharp.cs文件路径；  
　　最后，敲回车，运行写好的命令行，如果你足够幸运，你将看到很多warnings但是没有任何的errors；  
　　如果你很不幸，你需要添加 -errorlog:\<路径\> 来指定errors输出的logs记录的文件位置，之后打开这个文件；  
　　搜索errors，解决全部的errors之后重复上述步骤，直到没有errors输出。

<br />

这是一个csc命令行的样例（注意：不保证可用性）：

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

更多关于csc命令的细节，[见此](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe)。

<br />

使用msbuild命令进行构建：

　　如果你想要编译csproj项目文件，你应当进入src文件夹并执行如下命令：

```
msbuild Assembly-CSharp.csproj
```

　　然后，如果没有发生错误，你将看到src文件夹下生成了bin文件夹，里面的文件就是我们需要的了。  
　　同样你也可以用msbuild命令编译sln文件（Visual Studio项目文件），运行如下命令：

```
msbuild Assembly-CSharp.sln
```

　　我们还没有试过这个用法，但是它理论上可行。

更多关于msbuild命令的细节，[见此](https://docs.microsoft.com/zh-cn/visualstudio/msbuild/msbuild?view=vs-2019)。

<br />

## 目录


本项目的文件目录如下：

HumanFallFlat  
|-- Assembly-CSharp.sln　　　　 　 Visual Studio项目文件  
|-- README.md　　　　　　　　　　项目自述文件  
|-- docs　　　　　　　　　　　 　　 这个文件夹用来储存所有文档  
|　　　|-- README_cn.md　　　　　中文版项目自述文件  
|　　　|-- single_README.md　　 　 single文件夹自述文件  
|　　　|-- single_README_cn.md　　中文版single文件夹自述文件  
|-- reference　　　　　　　　 　　　 这个文件夹用于储存所有依赖文件  
|　　　|-- win　　　　　　　　　　　这个文件夹用于储存所有Windows系统下的依赖文件  
|　　　　　　|-- \*.dll　　　　　　　　游戏里的所有dll文件  
|-- single　　　　　　　　　　　　　 这个文件夹用于储存所有和单文件游戏源码相关的东西  
|　　　|-- Assembly-CSharp.cs　　　单文件版的游戏源码  
|　　　|-- complie_code.txt　　　　　csc命令行，用于编译Assembly-CSharp.cs  
|　　　|-- csc_generator.py　　　　　python脚本文件，用于生成上面的csc命令行  
|-- src　　　　　　　　　　　　　 　 这个文件夹用来储存所有源代码  
　　　 |-- \*.cs　　　　　　　　　　　 C#源代码  
　　　 |-- Assembly-CSharp.csproj　 C#项目文件

<br />

## 贡献


[XiaoHuiHui233](https://github.com/XiaoHuiHui233)