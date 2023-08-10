// Copyright David "AngryBeaver" Gillen. All Rights Reserved.

using UnrealBuildTool;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Text;
using EpicGames.Core;

public class SFIconCapture : ModuleRules
{
	public SFIconCapture(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

/*		PublicIncludePaths.AddRange(
			new string[] {}
		);

		PrivateIncludePaths.AddRange(
			new string[] {}
		);*/

		PublicDependencyModuleNames.AddRange(
			new string[] {
				"Core", 
				"CoreUObject",
				"Engine",
				"FactoryGame"
			}
		);

		PrivateDependencyModuleNames.AddRange(
			new string[] {
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
			}
		);

/*		DynamicallyLoadedModuleNames.AddRange(
			new string[] {
			}
		);*/
	}
}
