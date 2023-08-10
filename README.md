# Icon Capture

## Installing:
1. Clone this repository, or download the current build
2. Find the `SFIconCapture` folder at the top level
2. Copy or symlink the folder into `<your project>/Plugins/` in UE5
3. Note that this is plugins not mods and UE5

## How To Use:
1. Open the editor and go to the `IconCapture Content` folder.
2. Create a scene to perform the capture
  * Duplicate `IconCapture_Environment` to another folder in your project
  * Or: Add `IconCapture_Functionality` to your existing level
3. Open the editor widget `IconCapture_UserInterfaceWidget`
4. Assign an instance of `IconCapture_Functionality` to the widget at the top
5. Move the camera around, set the output folder, and render

## Camera Settings:
Save to data asset, so handy

## Batch Settings:
Many picture, snap snap