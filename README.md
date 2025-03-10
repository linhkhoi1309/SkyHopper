# Sky Hopper

#### This game is served for ***educational purposes*** only. Please contact to *linhkhoiluong@gmail.com* before using it as references.
---
### Key Mechanics + Techniques

- Scriptable Render Pipeline (URP)
- New Input System
- Cinemachine (Virtual Camera + Confiner + Impulse)
- Trail Renderer + Line Renderer
- Edge Collider
- Particle Effect
- Post-processing (Bloom)
- Hinge Joint 2D
- Skinning Editor
- Texture + Shader + Material
- Unity UI tookit
- Save & Loading System
- Audio Mixer
- Optimization Techniques
- Design Pattern / Game Programming Pattern: Singleton, Object Pool
- Unity Ads + Monetization
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