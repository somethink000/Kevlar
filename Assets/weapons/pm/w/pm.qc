// Created by Crowbar 0.74

$modelname "weapons\fas2\world\pistols\pm.mdl"

$bodygroup "pm"
{
	studio "pm.smd"
}
$bodygroup "Barrel"
{
	blank
	studio "supressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.024 5.846 5.051

$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\fas2\pistols\pm\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -45 -90 90

$cbox 0 0 0 0 0 0

$bbox -13.544 -0.738 0.059 1.852 0.976 10.043

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000211 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 10.147681 -0.804855 -4.630339 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 4.739129 -0.75701 -4.422195 10.000233 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"pm_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "pm_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
