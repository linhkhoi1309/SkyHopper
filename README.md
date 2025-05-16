# Sky Hopper

#### This game is served for ***educational purposes*** only. Please contact to *linhkhoiluong@gmail.com* before using it as references.
---
### Mechanics + Techniques

- Version Control (Git)
- Scriptable Render Pipeline (URP)
- New Input System
- Cinemachine (Virtual Camera + Confiner + Impulse)
- Renderer (Trail + Line + Sprite)
- Rigidbody 2D
- Collider (Edge + Circle + Box + Polygon + Capsule)
- Particle Effect
- Scriptable Object
- Prefab + Prefab Variant
- Coroutine
- UI (Unity UI tookit + uGUI)
- Texture + Shader + Material
- Post-processing (Bloom)
- Joint (Hinge Joint 2D)
- Effector (Area Effector 2D)
- Skinning Editor
- Design Pattern / Game Programming Pattern: Singleton, Object Pool
- Boids
- Multithreaded Programming (Job System)
- Burst Compiler
- Morton Code
- Quadtree
- A* pathfinding
- DOTween
- Optimization Techniques (Profiler)
- Debugging Techniques (Gizmo)
- Save & Loading System (SQLite-net + StreammingAssets, PlayerPrefs)
- Unity Web Request
- Scene Transition 
- Text Animation
- Unity Ads + In-App purchase + Monetization & Tracking tools
- Mobile Native API (Push Notifications, Vibration, Accelerometer)
- Localization

### Ongoing features
- Raycast
- Audio Mixer
- Addressable
- Daily Rewards
- Lucky Wheel
- Inventory + Shop
- Timeline
- Loading Screen

### Notes
- URP Setup:
    + Window -> Package Manager -> Unity Registry -> Universal RP
    + Assets -> Create -> Rendering -> URP asset
    + Edit -> Project Settings -> Graphics -> Assign URP asset
- Making a chain effect:
    + Sprite Editor -> Skinning Editor -> Create Bones -> Auto Geometry -> Generate For Selected
    + Create Chain object -> Assign Sprite Skin component -> Create bones -> Assign Hinge Joint 2D component for each children bone object -> Assign its connected rigidbody (in Hinge Joint 2D component) for each bone consecutively -> Bone_0 assign with an Anchor object
    + Tuning for better effect (Rigidbody's mass, Hinge Joint 2D's Angle limits)
- Script Execution Order:
    + Edit -> Project Settings -> Script Excution Order
    + Lower value -> more prioritized
- Shield Effect
    + Create Shield Shader (Create -> Shader Graph -> URP -> Unlit Shader Graph)
    + Create Shield Material
    + Create Shield Particle System (with only 1 particle generated and use Shield Material as material)
- Integrating Unity UI Toolkit
    + Hierachy -> UI Toolkit -> UI Document
    + Project -> Create -> UI Toolkit -> UI Document
    + Drag newly created Visual Tree Asset to UI Document component
    + Tuning settings in Panel Settings

### References
- [SCREEN SHAKE in Unity using Cinemachine, Sasquatch B Studios](https://www.youtube.com/watch?v=CgyLIWyDXqo&list=PLfmYNuLHEy-PQ6j6kki9kmM3Z5CayRSI0&index=4&ab_channel=SasquatchBStudios)
- [Unity Manual, Unity](https://docs.unity3d.com/6000.0/Documentation/Manual/)
- [Unity Universal RP Manual, Unity](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/index.html)
- [Unity Localization Package Manual, Unity](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/index.html)
- [Unity Shader GraphGraph Manual, Unity](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/index.html)
- [OBJECT POOLING in Unity, Brackeys](https://www.youtube.com/watch?v=tdSmKaJvCoA&t=832s&ab_channel=Brackeys)
- [Get started with UI Toolkit in Unity, Sasquatch B Studios](https://www.youtube.com/watch?v=_jtj73lu2Ko&t=317s&ab_channel=SasquatchBStudios)
- [Boids, ECE 4760, Spring 2020, Adams/Land](https://people.ece.cornell.edu/land/courses/ece4760/labs/s2021/Boids/Boids.html)
- [SQLite-net, Frank A. Krueger](https://github.com/praeclarum/sqlite-net)
- [NativeQuadtree, Marijn Zwemmer](https://github.com/marijnz/NativeQuadtree)
- [DOTween, Documentation](https://dotween.demigiant.com/documentation.php)
- [Audios](https://opengameart.org/)
- [Fonts](https://fonts.google.com/)
- [Sprites](https://www.kenney.nl/assets)