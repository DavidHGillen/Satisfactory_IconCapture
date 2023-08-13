# Icon Capture

## Installing:
1. Clone this repository, or download the current build.
2. Find the `SFIconCapture` folder at the top level.
3. Copy or symlink the folder into `<your project>/Plugins/` in your modding environment.
4. Goto `FactoryGame.uproject` right-click and `Generate Visual Studio Project Files`.
5. Once it's complete open Visual Studio and build for Editor at least.
6. Open Your modding environment, you're good to go.


## How To Use:
1. Open the editor and go to the `Satisfactory Icon Capture Content` folder.
2. We'll need a scene to perform the capture, there's two ways.
  * Duplicate `IconCapture_Environment` to another folder in your project (preferred).
  * Or: Add `IconCapture_Functionality` to your existing level (advanced).
3. Open the editor widget `IconCapture_UserInterfaceWidget`.
4. Assign an instance of `IconCapture_Functionality` to the widget at the top.
5. Place something into the scene and hit `Run Capture`.
6. Check the listed output folder for the expected files.

There's several configuration options and a batch rendering mode which are covered in more detail below.
The assets used for capturing are flagged as editor only and can be safely included and saved into your mod folder without affecting your released content.

## Camera Settings:
Listed are several properties of the capture camera to provide easy access. It's recommended to use the UI to prevent any changes to the scene elements getting accidentally overwritten.

* **Distance:** How far back from the object the camera should be.
* **FOV:** What Field of View should be used, keep in mind this is often best smaller than a player's FOV.
* **Rotation:** What orientation the camera should face.
* **Offset:** How far to pan the camera away from the origin of the capture.
* **[Snap To View]:** Read the editor camera's position and apply it. Framing may differ due to the editor windows's FOV.
* **[Auto Focus]:** (unimplemented)Attempt to find the bounds of the object in scene and frame it.
* **[Reset]:** Revert the camera to the plugin default values.

### Camera Data Assets
While it is encouraged to potentially have multiple capture environments, it may be tedious to manually set multiple camera parameters, remember them between sessions, or deal with batches.
To counter this you can save and load the Camera's settings with `Camera Data Assets`. They're simple to use:

1. Open the Content Browser and go to any folder
2. Right Click and create a `Miscellaneous > Data Asset` of the type `IconCapture_CameraDataAsset`
3. Give it whatever name is convenient, and save it.
4. Go back to your capture scene, open the widget, and assign the capture actor if it not there already.
5. Adjust the camera to your preferred settings.
6. Select your data asset from the list in the `Cam Data` picker.
7. Click the `[Write]` button to save your current data to the asset.
8. You now have these settings saved! Go ahead and change them, and then `[Load]` just to test it out.

Once you have created a library of `Camera Data Assets` you will find it easy to setup batches and capture new elements.
There is a small library provided of some attempts to mirror the default values for some things found in vanilla.


## Batch Settings:
Batch mode is for more advanced usage, if you have a lot of things to capture it'll save time.

1. To use batch mode, start by making sure your scene is empty of anything you don't want showing in all your icons.
2. Then go ahead and set `Capture Mode` to `Class Batch`, you will see some of the UI change slightly to add new features.
3. Most of these new features are covered in the Output Settings and handle generating the file/folder names relative to the entry.
4. You may wish to temporarily add something from the batch to the scene to find your initial framing.
5. Now fill the `Build List` and `Desc List` with your desired entries and optionally their camera settings.
6. Click Run Capture.

While it can be tempting to batch everything in your mod at once, it's recommended to have a few distinct levels.
This will let you more easily control things like lighting settings and not have an overwhelming list that takes a long time to run.
Batches currently only support `Buildings` and `Items`, for Buildings provide a reference to the `Build_` class, for Items provide the `Desc_` class.
Unless entries in a batch share the same framing it is recommended to use `Camera Data Assets` to save and re-use different camera framing setups, check the Camera Settings for more information.

## Output Settings
The output settings consist of a series of check boxes for the desired size of image to render, and entries for the path and file name desired.

Several common sizes are listed as defualt check boxes. In Satisfactory the sizes for Building icons are **512 & 256*, the sizes for Item icons are **256 & 128**.
The custom option is also available if anything else is desired.
If no sizes are checked no images will be captured but the UI will assume success.

The output name and path for the scene mode are visible by default, please set them to something you prefer.
The defaults include a replacement token %size%, this is necessary to stop multiple sizes overwriting each other as captured.
More detail can be found in the Adjustment Tokens section.

### Output Batches
When performing batch exports the filename and path may not be simple. While read from the entry in the batch you may have all your icons in a shared folder, or have unique naming setups.
While handling all possible combinations is a bit beyond the purview of the generator, hopefully these simple adjustment rules may help.

* Prefix: Append this to the start of the entry's name/path.
* Suffix: Append this to the end of the entry's name/path.
* Replace: Take the provided key, search the entry's name/path and replace it with the provided value.

While they may seem simple together they should allow you to reformat your batch properly, especially when combined with Adjustment Tokens.
If different entries in a batch require incompatible naming rules, consider making a new set of batches for the rules.
These use Unreal utility functions and thus support all unreal path features like `.\` to go up a folder in the hierarchy.

The default settings for batches will strip off an entries sub path via the rule `Replace: "%any%" : ""`, removing this rule will reveal the path relative to your plugin folder. E.g. `/mymodref/buildings/foundations`.

Having both a root path and a path prefix is arguably redundant; however, the prefix has been left in case the separation proves valuable.

### Adjustment Tokens
Replacement tokens start and end with `%` and are automatically replaced after the full path or name has been assembled by the other rules.
Below is a list of the currently implemented ones:

* `%size%`: The pixel dimension of the image currently being saved; 512, 256, etc.
* `%all%`: Special case that only works as a replacement key. Will replace the generated file/path with the entered text.

## FAQ
* **Why doesn't my output perfectly match the viewport:** This is because Unreal lighting is complex, and capturing the view in editor is not a perfect context. Please adjust the lighting and post processing settings until you are happy; however, note that sky lights will not work.
* **Why can't I get folders working for a batch export:** Please be sure you removed the default %any% rule from the folder export, or that you only placed new rules after it.
* **Can I get regex for the path rules:** I thought about this, but as it doesn't ship natively with Unreal I held off on it for now.
* **Can I use this in other games, in other version of Unreal, for paid mods:** I'm currently only directly supporting UE5 & Satisfactory, but. So long as you don't sell this project itself and you give credit to where you got it from: feel free to fork/port, this or even sell anything you used this tool to generate.
* **Where can I get help:** Feel free to ping me (Angry Beaver) on discord directly, but I do recommend the [Satisfactory Modding Discord](https://discord.gg/WuUnswMNYN) as others may be available when I am not.
