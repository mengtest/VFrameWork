# VFrameWork

### 作者：vili &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 联系方式：1976763043@qq.com

*unity框架，该框架是一个笔者自己开发过程中总结的框架，目前还在更新中，功能还比较欠缺。笔者正在完善*
## V 0.1.1

### 更新时间：2018/12/21

### 新增功能：

### 1.针对Utils工具包进行了拓展

1.新增EditorUtils工具包，主要包含以下编辑器下常用方法。

2.新增PackageUtils工具包，主要方便VFrameWork的导出（笔者使用）。

### 2.新增FrameWorks框架包，同时新增的框架如下：

#### 1.SingletonFrameWork

*单利模板框架，用户通过继承该框架下的类可自动实现单例模式。*

1.该框架下有两个类可供其他类继承。

2.Singleton，单例类。当一个类继承自该类时，你可以通过类名.Instance访问到该类下的数据而不必将他写成静态类。（详见c#设计模式--单例模式）

3.MonoSingleton，单例类，需要被挂在Gameobject上才起作用，功能同上。

#### 2.MusicFrameWork

*声音管理框架，，用于播放背景音乐和特效音乐*

1，MusicManager为主要管理类，继承自MonoSingleton。需要挂在Gameobject上。

2.声音资源应该被存储在Resources目录下，默认路径为Resources/Sounds，若自定义目录，请在挂载该脚本的物体的Inspector面板上修改ResourceDir为你自定义的路径。（该路径必须在Resources下）

#### 3.FGUIFrameWork

*FairyGUI管理框架，用于管理在FairyGUI下制作的UI界面的显示和跳转*

1.用户必须按规则制作UI包，所有界面需要新建一个包，包名最好有规则（例如LoginMenu），在该包下新建一个组件作为窗体显示，名字为包名+“Windows”（例如LoginMenuWindow,包名随意，但要显示的主组件名必须为包名+“Window”）。

2.将包导入Resources/FGUI对应的目录下，资源包导入ResourceMenu，窗体包导入WindowMenu，导入是指在该目录下新建与包名相同的文件夹，并将FairyGUI的包发布至你创建的文件夹。

3.ResourceMenu下存放的是资源文件，在使用FairyGUI制作UI时，有一些资源或组件可能会重复用到，用户可以在FairyGUI中新建若干资源包，资源包无需有主组件（因为他不是用来显示的）.将需要的资源放置其中。发布方式见上条。

4.ResourceMenu是内存优化的一种方式，开发时可以不用考虑这个，直接每个窗体一个包，所有资源都在自己的包里，然后将每个窗体包导入WindowMenu，ResourceMenu下可以无任何东西。

5.选择导航栏的VFrameWork/UpdetaFGUIConfig，系统将自动更新配置文件，生成一个json和一个枚举类。

6.导入包后，请为每个包创建一个脚本，用于处理窗体逻辑，脚本名字需要与包中主组件的名字相同。并让其继承自BaseWindow类并实现方法，关于窗体的所有逻辑可以写在该脚本中，这个脚本，就是窗体。

6.以上所有所说的导入，是指在ResourceMenu或WindowMenu目录下新建与包名相同的文件夹，并将FairyGUI的包发布至你创建的文件夹。

7.以上是导入配置，处理完这些以后，你将可以通过这个框架来管理界面的跳转。

8.UiWindowManager是框架主类，你可以通过UiWindowManager.OpenWindow()方法，来显示任何一个窗体（资源窗体没有主组件，无法显示）。该方法需要一个枚举类型的变量，UiWindowName，这个是根据你刚刚导入的包生成的，所以在导入FairyGUI包后，一定要选择导航栏的VFrameWork/UpdetaFGUIConfig更新配置文件。

9.你可以通过UiWindowManager.HideWindow()来隐藏一个窗体，该方法需要一个枚举类型的变量，UiWindowName，在该窗体之上打开的窗体都会被关闭。

10,本框架所有的BaseWindow都继承自Window，需要实现其他功能的可以去FairyGUI官网的教程中查看有关窗体的教程。
## V 0.1.0

### 更新时间：2018/12/17

### 新增功能：

#### 1.新增了Utils工具包，其下包含：

1.GameObjectUtils工具包，对GameObject进行拓展。

2.TransformUtils工具包，对Transform进行拓展。

3.Utils类中存放了所有非拓展工具包的静态对象，可通过Utils调用所有非拓展工具包的方法。

4.CommonUtils，通用工具包。

5.MathUtils，数学工具包。

6.ResolutionUtils，分辨率工具包。
