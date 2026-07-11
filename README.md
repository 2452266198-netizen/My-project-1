# 🎮 3D 推箱子 (Sokoban)

基于 Unity 6 开发的 3D 推箱子游戏，采用事件驱动架构，支持键盘与串口双模式控制。

---

## 🎯 游戏玩法

- 使用方向键或 **WASD** 控制玩家移动
- 将**所有箱子**推到目标点上即可通关
- 按 **R 键**随时重置关卡

## 🛠 技术栈

| 类别 | 技术 |
|------|------|
| 引擎 | Unity 6000.0.78f1 |
| 渲染管线 | Universal Render Pipeline (URP) |
| 语言 | C# |
| 架构 | 事件驱动 (Event-Driven) |

## 📁 项目结构

```
Assets/
├── Prefabs/
│   ├── Scripts/                 # 游戏核心脚本
│   │   ├── SokobanController.cs # 玩家移动控制
│   │   ├── BoxLogic.cs          # 箱子行为与目标检测
│   │   ├── GameManager.cs       # 游戏状态管理与胜负判定
│   │   ├── MapGenerator.cs      # 关卡地图生成
│   │   ├── Gameevents.cs        # 事件系统
│   │   └── SerialManager.cs     # 串口通信管理
│   ├── Player.prefab            # 玩家预制体
│   ├── box (3).prefab           # 箱子预制体
│   ├── Goal.prefab              # 目标点预制体
│   ├── wall.prefab              # 墙壁预制体
│   └── ...                      # 模型与材质
├── Scenes/
│   └── SampleScene.unity        # 主场景
├── Settings/                    # URP 渲染设置
└── TextMesh Pro/                # 文字渲染
```

## 🧩 核心系统

### 事件系统 (`GameEvents`)
使用静态事件在模块间解耦通信：
- `OnMoveCommand` — 移动指令
- `OnResetCommand` — 重置指令
- `OnMoveFinished` — 移动完成通知
- `OnBoxGoalChanged` — 箱子目标状态变更
- `OnAllBoxesInPlace` — 全部箱子归位

### 关卡生成 (`MapGenerator`)
通过二维数组定义关卡布局，运行时自动生成墙壁、箱子和目标点。

```csharp
// 0=空地, 1=墙壁, 2=箱子, 3=目标点
private readonly int[,] levelData = { ... };
```

### 串口支持 (`SerialManager`)
预留串口通信接口，可通过外部硬件（如 Arduino）发送指令控制游戏。

## 🚀 快速开始

1. 使用 **Unity Hub** 打开项目（需要 Unity 6000.0.78f1 或更高版本）
2. 打开 `Assets/Scenes/SampleScene.unity`
3. 点击 **Play** 运行游戏
4. 使用方向键 / WASD 开始推箱子！

## 🤝 协作开发

```bash
# 克隆仓库
git clone git@github.com:2452266198-netizen/My-project-1.git

# 注意：大文件使用 Git LFS 管理，请确保已安装
git lfs install
git lfs pull
```

**注意事项：**
- `Library/`、`Logs/`、`UserSettings/` 等 Unity 生成目录已在 `.gitignore` 中排除
- `.fbx`、`.obj`、`.zip` 等大文件通过 **Git LFS** 管理
- 首次打开项目需等待 Unity 重新生成 Library 目录
