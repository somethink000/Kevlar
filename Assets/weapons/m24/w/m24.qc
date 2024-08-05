// Created by Crowbar 0.74

$modelname "weapons\fas2\world\snipers\m24.mdl"

$bodygroup "studio"
{
	studio "m24.smd"
}
$bodygroup "Barrel"
{
	blank
	studio "suppressor.smd"
}
$bodygroup "Bipod"
{
	blank
	studio "bipod.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition -0.127 -6.53 5.281

$cdmaterials "models\weapons\fas2\snipers\m24\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -35 -90 90

$cbox 0 0 0 0 0 0

$bbox -24.016 -2.257 -8.511 37.076 1.784 19.072

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000266 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 41.988548 -0.791628 -10.7931 10.000289 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 9.959096 -0.573439 -5.259923 10.000289 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"m24_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "m24_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
