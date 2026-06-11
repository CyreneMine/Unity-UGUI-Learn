# AGENTS.md

## 项目定位

本项目是 Unity 学习项目，用于跟随唐老狮教程学习 `UGUI` 以及相关 UI 系统练习。

项目目标不是快速完成成品，而是记录学习过程、理解 Unity UGUI 组件、保留练习代码、整理学习进度，方便后续复盘。

## Codex 工作原则

除非我明确要求，否则你只能进行：

- 阅读代码
- 检查代码
- 分析问题
- 给出修改建议
- 解释 Unity / C# / UGUI / API 原理
- 总结学习内容
- 编写 README / LearningProgress.md / Notes 复盘文档

禁止在未经我明确允许的情况下直接修改任何代码文件。

## 本地教程文件夹读取规则

本项目中会放入我下载好的教程视频和资源包。

你需要主动查看项目根目录以及相关文件夹，例如：

- `Videos/`
- `教程视频/`
- `Course/`
- `CourseFiles/`
- `Resources/`
- `资源包/`
- `Assets/`
- 压缩包、unitypackage、示例工程等资源

请根据文件名、编号和资源包内容，整理 UGUI 学习路线。

你需要识别：

1. 视频编号
2. 视频标题
3. 所属阶段
4. 对应知识点
5. 当前完成状态
6. 是否需要写入 `LearningProgress.md`

如果视频文件名已经包含课程顺序，请优先按照文件名顺序整理课程目录。

## 代码修改限制

默认情况下，不允许直接修改：

- `.cs` 脚本
- Unity 场景文件
- Prefab 文件
- ProjectSettings
- Packages 配置
- 任何会影响项目运行结果的文件

如果发现问题，请先告诉我：

1. 问题在哪里
2. 为什么会有问题
3. 推荐怎么改
4. 修改后的参考代码片段

只有当我明确说出以下类似指令时，才可以直接改代码：

- “直接修改”
- “帮我改”
- “按你的方案改”
- “可以动代码”
- “直接修复”
- “提交修改”

## UGUI 学习重点

检查和总结时，请重点关注：

- Canvas
- RectTransform
- Anchor 锚点
- Pivot 轴心点
- Image
- RawImage
- Text
- Button
- Toggle
- Slider
- Scrollbar
- Dropdown
- InputField
- ScrollView
- EventSystem
- CanvasScaler
- GraphicRaycaster
- UI 事件监听
- UI 面板显示与隐藏
- UI 组件引用绑定
- 简单 UI 管理器
- UI 与游戏逻辑的解耦

不要一开始就引入复杂 UI 框架，优先帮助我理解 UGUI 原理和基础用法。

## 教程练习题检查规则

我完成教程中的练习题后，你需要帮我检查：

- 功能是否符合题目要求
- UI 组件是否正确绑定
- 代码逻辑是否正确
- 是否有明显 bug
- 是否存在空引用风险
- 是否重复注册 UI 事件
- 命名是否清晰
- 是否有重复代码
- 是否符合 Unity UGUI 常见实践

检查时优先解释原因，不要只给结论。

## GitHub 管理规则

当我完成一个阶段学习后，你可以帮我：

- 整理 README
- 更新 LearningProgress.md
- 总结本次学习内容
- 生成 commit message
- 提醒我是否需要提交 Git

除非我明确要求，否则不要自动 commit，也不要自动 push。

当我明确要求 push 时，需要先总结本次提交内容，再执行 Git 操作。

## 学习记录要求

建议维护以下文档：

- `README.md`：项目说明
- `LearningProgress.md`：学习进度
- `Notes/`：知识点笔记
- `Screenshots/`：运行效果截图，可选
- `CourseResources/`：课程资源说明，可选

README 编写规则：

- README 应优先说明项目定位、学习目标、Unity 版本、目录结构、学习记录入口和当前状态
- README 不记录一次性的 Git 首次绑定步骤，除非我明确要求保留
- README 中指向 `LearningProgress.md`、`Notes/`、`Screenshots/` 的入口应使用 Markdown 链接，方便在 GitHub 上直接点击跳转
- 如果需要保留空目录，例如 `Screenshots/`，可以使用 `.gitkeep`

## LearningProgress.md 维护规则

请仿照之前 PlayerPrefs 仓库的进度表结构维护学习进度。

`LearningProgress.md` 应包含：

```md
# UGUI 学习进度

本文件用于记录唐老狮 UGUI 课程的学习路线和完成情况。

状态说明：

- 未开始：还没有正式学习
- 学习中：正在看课、写练习或调试
- 已完成：已完成本节学习和基础复盘
- 待复盘：学完但还需要整理理解、检查代码或补充笔记

## 课程目录

| 序号 | 课程内容 | 阶段 | 状态 | 学习日期 | 备注 |
| --- | --- | --- | --- | --- | --- |