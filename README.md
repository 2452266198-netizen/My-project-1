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

### 导入到 Unity

1. 克隆仓库到本地（**必须用 Git LFS 克隆，否则模型文件无法显示**）：
   ```bash
   git lfs clone git@github.com:2452266198-netizen/My-project-1.git
   ```
   > ⚠️ **不要用普通 `git clone`**，否则 `.obj` 和 `.fbx` 模型文件只有几 KB 的指针，Unity 中看不到模型。

   **如果你已经用普通 `git clone` 拉下来了，执行以下修复：**
   ```bash
   git lfs install
   git lfs fetch --all
   git lfs checkout
   ```

   **验证是否修复成功：** 检查模型文件大小，正常应该 > 100 MB：
   ```bash
   ls -lh Assets/Prefabs/*.obj
   # 正常输出: 100M ...（而不是 134 字节）
   ```

2. 打开 **Unity Hub**，点击右上角 **"Add"** 按钮
3. 选择刚才克隆的 `My-project-1` 文件夹，点击 **"Select Folder"**
4. Unity Hub 会自动识别项目，点击项目名称打开
   > ⚠️ 确保已安装 **Unity 6000.0.78f1**。详见下方版本兼容说明。

### 版本兼容

本项目基于 **Unity 6000.0.78f1** 开发。版本不匹配时需要处理：

| 情况 | 表现 | 解决方法 |
|------|------|----------|
| 未安装此版本 | Unity Hub 项目列表显示黄色警告三角 | 在 Unity Hub → **Installs** → **Install Editor** → 选择 **6000.0.78f1** 安装 |
| 安装了更高的小版本（如 6000.0.80f1） | 打开时提示升级，一般安全 | 点击 **"Continue"** 即可，Unity 6.x 小版本间 API 兼容 |
| 安装了 Unity 5.x 或更早版本 | API 大量变化，大概率报错 | 必须安装 Unity 6（6000.x.x），建议用 Hub 统一版本 |
| 多人协作版本不一致 | 场景/Prefab 合并冲突 | 团队统一使用 **6000.0.78f1**，将此版本号写入团队文档 |

**推荐的统一方式：**

1. 打开 **Unity Hub** → 左侧 **Installs**
2. 点击 **Install Editor** → 找到 **6000.0.78f1** → **Install**
3. 勾选 **Microsoft Visual Studio**（如果有）以便脚本编辑
4. 等待安装完成，重新打开项目即可

### 运行游戏

1. 在 Project 窗口中打开 `Assets/Scenes/SampleScene.unity`
2. 点击工具栏 **▶ Play** 按钮
3. 使用方向键 / WASD 开始推箱子！
4. 按 **R 键**可随时重置关卡

## 🤝 协作开发

**注意事项：**
- `Library/`、`Logs/`、`UserSettings/` 等 Unity 生成目录已在 `.gitignore` 中排除
- `.fbx`、`.obj`、`.zip` 等大文件通过 **Git LFS** 管理，克隆后需执行 `git lfs pull`
- 首次打开项目需等待 Unity 重新生成 Library 目录（可能需要 5-10 分钟）
- 团队所有成员务必使用相同版本 **Unity 6000.0.78f1**，避免场景和 Prefab 冲突
