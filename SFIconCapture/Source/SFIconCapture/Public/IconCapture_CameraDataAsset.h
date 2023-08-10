#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "IconCapture_CameraDataAsset.generated.h"

/*
USTRUCT(BlueprintType)
struct FIconCapture_CameraData
{
	GENERATED_BODY()
};*/

/**
 * Provide an API for saving and loading camera data across usages
 */
UCLASS(BlueprintType)
class SFICONCAPTURE_API UIconCapture_CameraDataAsset : public UDataAsset
{
	GENERATED_BODY()
	
public:

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		float Distance;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		float FOV;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		FRotator Rotation;

	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		FVector Offset;
};
