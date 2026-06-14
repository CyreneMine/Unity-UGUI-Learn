# UGUI-Learn

本项目用于跟随唐老狮教程学习 Unity UGUI，记录组件练习、知识点理解和阶段复盘。

学习目标不是快速搭建完整 UI 框架，而是先理解 UGUI 的基础组件、布局方式、事件系统和常见交互，再逐步完成简单 UI 管理器与登录选服案例。

## 项目信息

- Unity 版本：`6000.3.10f1`
- UGUI 包版本：`2.0.0`
- 教程：唐老狮《Unity 中的 UI 系统之 UGUI》
- 教程规模：61 节视频
- 当前状态：已完成第 1-46 节，正在制作提示面板逻辑

## 当前进度

- 已完成课程：`46 / 61`
- 当前阶段：五、综合 UI 案例
- 已完成阶段：一、UGUI 系统基础；二、常用 UI 控件；三、UI 进阶能力；四、简单 UI 管理
- 已学习内容：面板基类、CanvasGroup 淡入淡出、UIManager 动态创建与销毁、提示面板 Prefab
- 前置学习：已完成 [Unity JSON 持久化学习项目](https://github.com/CyreneMine/Unity-Json-Learn)
- 下一步：继续完成第 47 节《提示面板面板逻辑》
- 详细记录：查看 [`LearningProgress.md`](LearningProgress.md)
- 阶段复盘：查看 [`Notes/02-常用UI控件.md`](Notes/02-常用UI控件.md)、[`Notes/03-UI进阶能力.md`](Notes/03-UI进阶能力.md)、[`Notes/04-简单UI管理.md`](Notes/04-简单UI管理.md)

## 学习阶段

1. UGUI 系统基础：Canvas、CanvasScaler、GraphicRaycaster、EventSystem、RectTransform
2. 常用 UI 控件：Image、Text、RawImage、Button、Toggle、InputField、Slider、Scrollbar、ScrollView、Dropdown
3. UI 进阶能力：图集、事件监听、坐标转换、Mask、异形按钮、自动布局、CanvasGroup
4. 简单 UI 管理：面板基类、UI 管理器、面板显示与隐藏
5. 综合案例：提示、登录、注册、服务器和选服面板

## 关联学习项目

- [Unity JSON 持久化学习项目](https://github.com/CyreneMine/Unity-Json-Learn)：为 UGUI 实践项目中的配置、存档和数据读写提供前置知识。

## 目录结构

- [`Assets/`](Assets/)：Unity 工程资源与课程练习
- [`Assets/UGUI_Demo/`](Assets/UGUI_Demo/)：登录与选服综合案例
- [`LearningProgress.md`](LearningProgress.md)：61 节课程的学习进度
- [`Notes/`](Notes/)：知识点与阶段复盘
- [`CourseResources/`](CourseResources/)：本地教程和资料包说明
- [`Screenshots/`](Screenshots/)：练习运行效果截图

## 学习方式

- 已有多个项目中的 UGUI 使用经验，本次学习重点是系统梳理知识和补齐理解。
- 原则上按视频编号顺序学习，已经熟悉的基础操作可以记录原因后选择性跳过。
- 尽量完成课程中的所有练习题，并将练习题作为主要检查和复盘节点。
- 每完成一节，更新学习状态、日期和备注。
- 遇到练习题时，重点检查组件绑定、空引用风险和事件重复注册。
- 完成一个阶段后，再整理阶段复盘和 Git 提交。
