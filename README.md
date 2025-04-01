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
- Post-processing (Bloom)
- Joint (Hinge Joint 2D)
- Effector (Area Effector 2D)
- Skinning Editor
- Design Pattern / Game Programming Pattern: Singleton, Object Pool
- UI (Unity UI tookit + Unity UI)
- Texture + Shader + Material
- Boids
- Job System
- Burst Compiler
- Morton Code
- Quadtree
- Optimization Techniques (Profiler)
- Debugging Techniques (Gizmo)
- Scene Transition (3 ways : Shader, USS, Animator)
- Save & Loading System
- SQLite-net + SQLite
- Audio Mixer
- Unity Ads + In-App purchase + Monetization
- Push Notifications
- Vibration
- Localization

### Ongoing features
- Raycast
- Addressable
- Daily Rewards
- Inventory + Shop

### Metrics

- Boids Algorithm with number of boids = 300

+ Without using any optimization techniques
![Boids Without Any Optimizations](https://private-user-images.githubusercontent.com/58393822/425807100-45d0538c-756c-454e-ac85-093dc4bc326d.PNG?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDI3MTczMDMsIm5iZiI6MTc0MjcxNzAwMywicGF0aCI6Ii81ODM5MzgyMi80MjU4MDcxMDAtNDVkMDUzOGMtNzU2Yy00NTRlLWFjODUtMDkzZGM0YmMzMjZkLlBORz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMjMlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzIzVDA4MDMyM1omWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTZhMDA5Y2M2MDM0ZTkwNjU5YmYzNzZjMWNiYmEyYWIzY2FhODJhYjgyNWE0YmVkZTkyMjdhYjY5ZmZlYmQ0ZmImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.EUFsG0qQW9n87Tu-GwnkfiA5_gmpvJqbBBAi6JF0JxY)

+ When intergrating Job System + Burst Compiler in Unity

+ When intergrating

### Notes

- Making a chain effect:
    + Sprite Editor -> Skinning Editor -> Create Bones -> Auto Geometry -> Generate For Selected
    + Create Chain object -> Assign Sprite Skin component -> Create bones -> Assign Hinge Joint 2D component for each children bone object -> Assign its connected rigidbody (in Hinge Joint 2D component) for each bone consecutively -> Bone_0 assign with an Anchor object
    + Tuning for better effect (Rigidbody's mass, Hinge Joint 2D's Angle limits)
- Script Execution Order:
    + Edit -> Project Settings -> Script Excution Order
    + Lower value -> more prioritized
- Shield Effect
    + Create Shield Shader (Create -> Shader Graph -> URP -> Unlit Shader Graph)
    ![Shield Shader Graph](https://private-user-images.githubusercontent.com/58393822/423108471-63b15c32-47fe-4a7a-b7bb-bd93186f7c02.PNG?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NDIwNDY5MDMsIm5iZiI6MTc0MjA0NjYwMywicGF0aCI6Ii81ODM5MzgyMi80MjMxMDg0NzEtNjNiMTVjMzItNDdmZS00YTdhLWI3YmItYmQ5MzE4NmY3YzAyLlBORz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNTAzMTUlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjUwMzE1VDEzNTAwM1omWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWRmY2QwYzVkNGFmMzQxZmM0NDJjNjc3MDk2MWEwNDc1NzMyYzA1OWFiZGY1ODg0MzFmMmQ2MzkzMWQ5YjAwNzYmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.z9vPiD_mI6X9PGv2k8X3i6G09wpziUykmuzE51Q7goA)
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
- [OBJECT POOLING in Unity, Brackeys](https://www.youtube.com/watch?v=tdSmKaJvCoA&t=832s&ab_channel=Brackeys)
- [Get started with UI Toolkit in Unity, Sasquatch B Studios](https://www.youtube.com/watch?v=_jtj73lu2Ko&t=317s&ab_channel=SasquatchBStudios)
- [Boids, ECE 4760, Spring 2020, Adams/Land](https://people.ece.cornell.edu/land/courses/ece4760/labs/s2021/Boids/Boids.html)
- [SQLite-net, Frank A. Krueger](https://github.com/praeclarum/sqlite-net)

