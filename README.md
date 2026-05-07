# Sky Hopper

Sky Hopper is a 2D vertical arcade game built with Unity, focused on responsive controls, readable obstacle patterns, and performance-aware gameplay systems.

## Gameplay Overview

Players tap to propel a bouncing ball upward through moving obstacle combinations. The game rewards timing, rhythm, and quick adaptation as difficulty increases.

## Scope & Current Build (7 Levels)

This project currently includes **7 fully implemented and playtested levels**.  
The goal of this build is to deliver a polished gameplay vertical slice and prove production-ready engineering practices, not just maximize level count.

- 7 shipped levels with progressive obstacle combinations and tuned difficulty
- Reusable, data-driven obstacle setup that supports fast level expansion
- Focus on game feel, readability, and consistency across level progression
- Production systems included: save/load, localization.

## What This Project Demonstrates

- End-to-end Unity game development from gameplay prototype to shippable systems
- Clean system design using reusable prefabs, scriptable data, and pooling
- Production-oriented features: saving/loading, localization, ads.

## Core Features (Implemented)

- Tap-based movement using Unity Input System
- Multi-pattern obstacle gameplay (rotating, moving, projectile, boid-style)
- Physics-driven interactions with Rigidbody2D, joints, colliders, and effectors
- Camera feedback using Cinemachine (confiner + impulse shake)
- Visual polish with URP, Shader Graph materials, particles, trails, and bloom
- UI built with both uGUI and UI Toolkit
- Save/load pipeline using SQLite-net, StreamingAssets, and PlayerPrefs
- Localization support for multi-language UI/content
- Monetization integration via Google AdMob

## Technical Stack

- **Engine:** Unity (URP)
- **Language:** C#
- **Tooling:** Git, Unity Profiler, Gizmos
- **Animation/Feedback:** Cinemachine, Particle System
- **Architecture Patterns:** Singleton, Object Pool

## Gameplay & Level Design Snapshot

Current obstacle set includes rotating lines, crushers, fans, clock hands, flow streams, boid zones, homing threats, trapdoors, and chain-based hazards.  
Difficulty progression is authored by combining obstacle behaviors and tuning movement/rotation parameters per stage.

## Key Engineering Notes

- Designed obstacle logic to be data-driven and reusable across levels
- Used pooling to reduce Instantiate/Destroy overhead during active gameplay
- Combined physics + tweening carefully to keep controls responsive

## References

- [SCREEN SHAKE in Unity using Cinemachine, Sasquatch B Studios](https://www.youtube.com/watch?v=CgyLIWyDXqo&list=PLfmYNuLHEy-PQ6j6kki9kmM3Z5CayRSI0&index=4&ab_channel=SasquatchBStudios)
- [Unity Manual, Unity](https://docs.unity3d.com/6000.0/Documentation/Manual/)
- [Unity Universal RP Manual, Unity](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.1/manual/index.html)
- [Unity Localization Package Manual, Unity](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/index.html)
- [Unity Shader Graph Manual, Unity](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/index.html)
- [OBJECT POOLING in Unity, Brackeys](https://www.youtube.com/watch?v=tdSmKaJvCoA&t=832s&ab_channel=Brackeys)
- [Get started with UI Toolkit in Unity, Sasquatch B Studios](https://www.youtube.com/watch?v=_jtj73lu2Ko&t=317s&ab_channel=SasquatchBStudios)
- [Boids, ECE 4760, Spring 2020, Adams/Land](https://people.ece.cornell.edu/land/courses/ece4760/labs/s2021/Boids/Boids.html)
- [SQLite-net, Frank A. Krueger](https://github.com/praeclarum/sqlite-net)
- [NativeQuadtree, Marijn Zwemmer](https://github.com/marijnz/NativeQuadtree)
- [DOTween Documentation](https://dotween.demigiant.com/documentation.php)
- [Unity Localization: Add support for Multiple Languages, Root Games](https://www.youtube.com/watch?v=qcXuvd7qSxg)
- [Mobile Ads SDK (Unity), Google AdMob](https://developers.google.com/admob/unity/quick-start)
- [Unity MCP, Justin P Barnett](https://github.com/justinpbarnett/unity-mcp)
- [Audios](https://opengameart.org/)
- [Fonts](https://fonts.google.com/)
- [Sprites](https://www.kenney.nl/assets)

## Contact

For educational or portfolio reference questions, contact: `linhkhoiluong@gmail.com`