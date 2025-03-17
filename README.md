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
- Morton Code
- Quadtree
- Optimization Techniques (Profiler)
- Scene Transition
- Save & Loading System
- Audio Mixer
- Unity Ads + In-App purchase
- Push Notifications
- Vibration
- Localization

### Ongoing features
- Raycast
- Addressable

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
- Lerp
    + Used to move one value towards another over time such as animating movements, changing slider values or fading out audio source
    + When t = 0, Vector3.Lerp(a, b, t) returns a.
    + When t = 1, Vector3.Lerp(a, b, t) returns b.
    + When t = 0.5, Vector3.Lerp(a, b, t) returns the point midway between a and b.

### References
- [SCREEN SHAKE in Unity using Cinemachine, Sasquatch B Studios](https://www.youtube.com/watch?v=CgyLIWyDXqo&list=PLfmYNuLHEy-PQ6j6kki9kmM3Z5CayRSI0&index=4&ab_channel=SasquatchBStudios)
- [Unity Manual](https://docs.unity3d.com/6000.0/Documentation/Manual/)
- [Unity Universal RP Manual](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/index.html)
- [OBJECT POOLING in Unity, Brackeys](https://www.youtube.com/watch?v=tdSmKaJvCoA&t=832s&ab_channel=Brackeys)
- [Get started with UI Toolkit in Unity, Sasquatch B Studios](https://www.youtube.com/watch?v=_jtj73lu2Ko&t=317s&ab_channel=SasquatchBStudios)
    
