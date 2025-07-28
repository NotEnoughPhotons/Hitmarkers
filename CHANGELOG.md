# Changelog

This is the changelog for Hitmarkers! This changelog only features public release versions.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.10.1] - 7/28/2025

### Added
- A changelog!

## [2.10.0] - 7/26/2025

### Added
- Fusion support for Hitmarkers!

### Fixed
- Fixed a bug with Fusion hitmarkers not spawning in the right locations
- Fixed an issue with players getting death markers for you, even though you had nothing to do with their death
- Fixed another issue with markers being spawned from other players
- Fixed a null reference occurring when the player either dies or kills himself
- Finisher/hit markers never spawn on the local player

### Changed
- Made the HitmarkerManager a static class

## [2.9.1] - 7/12/2025

### Changed
- Adjusted the Thunderstore description to show people where to put skins

## [2.9.0] - 7/12/2025

### Added
- Melee support for Hitmarkers!

### Fixed
- Fixed an issue with the Hitmarker shaders not compiling/showing on Quest

### Changed
- All methods that were emitting warnings about IL2CPP no longer appear in the console

## [2.8.3] - 8/5/2024

### Fixed
- Updated the mod to work with BoneLib 3.1.0

## [2.8.2] - 8/3/2024

### Fixed
- Fixed an issue with MelonPreferences not being created

## [2.8.1] - 8/3/2024

### Changed
- Changed description

## [2.8.0] - 8/3/2024

### Added
- New skin system with proper support in BoneMenu
- Persistent settings that save after the game closes
- Favorite skin selection

### Fixed
- Fixes and improvements that use new functions from Patch 5

## [2.7.5] - 4/21/2023

### Added
- A hitmarkers proxy component to add to any collider for hitmarkers to spawn upon hit

## [2.7.0] - 4/6/2023

### Added
- BONELAB Fusion support
- Distance scaling

## [2.3.2] - 1/1/2023

### Added
- BONEWORKS compatibility

## [2.3.1] - 1/1/2023

### Fixed
- Fixed an issue with JeviLib conflicts (credit: extraes)

## [2.3.0] - 12/29/2022

### Added
- Patch 3 Quest support!

## [2.2.1] - 12/15/2022

### Fixed
- Fixed BoneLib support

## [2.2.0] - 11/24/2022

### Added
- Separate versions for both BONEWORKS and BONELAB

### Fixed
- Fixed Hitmarkers not working properly on BONEWORKS

## [2.1.6] - 11/19/2022

### Added
- A version that supports the public beta branch
- A vresion that supports the main branch

## [2.1.6] - 11/19/2022

### Changed
- Changed the Thunderstore description

## [2.1.5] - 10/21/2022

### Added
- No death animation integration

## [2.1.0] - 10/19/2022

### Added
- New textures (finisher, marker, skull)
- Custom sound support

### Changed
- Debloated the asset bundle

## [2.0.0] - 10/19/2022

Official release for BONELAB

## [1.2.0] - 1/23/2022

### Added
- Custom hitmarker image support!
- Animation playback speed and audio controls

### Fixed
- Fixed an issue with audio where it wouldn't play correctly with time

### Changed
- Changed the way that hitmarker audio was handled

## [1.1.8] - 12/21/2021

### Changed
- Updated the Thunderstore page

## [1.1.7] - 12/22/2021

### Changed
- Removed the BASS.NET dependency
- Replaced it with AudioImportLib

## [1.1.6] - 12/3/2021

### Added
- Entanglement custom player model support

### Fixed
- Fixed a bug that caused hitmarkers to spawn from other players guns

## [1.1.5] - 12/3/2021

### Added
- Hitmarker scaling based on distance
- Entanglement support! (No finisher markers yet)

## [1.1.0] - 11/27/2021

### Added
- A BoneMenu option to enable/disable the mod
- An option to change the base scale of markers

## Changed
- MTINM became a dependency
- Scaling and animations, they are now improved

## [1.0.3] - 11/26/2021

### Added
- BASS.NET library for custom audio loading

## [1.0.2] - 11/26/2021

### Fixed
- Fixed a bug where a hitmarker would spawn when an NPC dies by any other way except for player gunshots

## [1.0.1] - 11/26/2021

### Changed
- Thunderstore page

## [1.0.0] - 11/26/2021

Initial release!