# Hyperspace-Invasion 次元入侵

这个项目演示了如何嵌入zarch脚本混合开发unity3d项目。[点这试玩WebGL版本](http://github.zhangxinhao.com/Hyperspace-Invasion/)

![preview](https://raw.githubusercontent.com/DASTUDIO/Hyperspace-Invasion/master/img/preview.gif)

## 跨平台
Zarch基于反射，但它可以在ios，webgl上执行，为此你需要用保守的代码`Zarch.classes.Register<>()`的方式注册你用到的类，

## 简洁清晰

场景中，只有一个index脚本加载游戏逻辑。

```csharp
Zarch.code = "active('BackGround');";
Zarch.code = "active('Weapons')";
Zarch.code = "load('player','Move')";
Zarch.code = "load('cursor','Cursor')";
Zarch.code = "load('inspectorCamera','InspectorCamera')";
Zarch.code = "load('player','Health')";
Zarch.code = "$.coroutine({$(help).active(bool())},3,0)";
```

7个cs脚本，每个平均实际代码30行。

`Zarch.csharp`与 `Zarch.code="..."` 大幅简化代码量。开发更快速，更清晰。

## 透明依赖管理
实例化对象把prefab拖到zarch的connector上，然后就可以在脚本中用它的名称操作它。

```js
Zarch.code = "$(new(myPrefab)).pos(1,2,3)"
```

其他场景中的物体，在脚本中可以用它的名称操作它。

```js
$(hp).slider(100)     			# 加满血条
```

![preview](https://raw.githubusercontent.com/DASTUDIO/Hyperspace-Invasion/master/img/preview.png)
