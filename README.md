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
- Optimization Techniques (Profiler)
- Texture + Shader + Material
- Scene Transition
- UI (Unity UI tookit + Unity UI)
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

- Common Attributes:
    + System.Serializable✅
    + SerializeField ✅
    + ColorUsage(showAlpha = true, hdr = true)
    + GradientUsage(hdr = true)
    + HideInInspector ✅
    + Min(min) ✅
    + Range(min, max)
    + Header(header) 
    + Space(height (in pixels))
    + Tooltip(tooltip)✅
    + TextArea(minLines, maxLines)
    + RequireComponent(typeof(Component))✅
    + DisallowMultipleComponent✅