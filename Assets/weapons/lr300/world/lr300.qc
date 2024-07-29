// Created by Crowbar 0.74

$modelname "weapons\fas2\world\rifles\lr300.mdl"

$bodygroup "studio"
{
	studio "lr300.smd"
}
$bodygroup "Barrel"
{
	studio "muzzle.smd"
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Sights"
{
	studio "ironsight.smd"
	blank
}
$bodygroup "Magazine"
{
	studio "30rnd.smd"
	studio "40rnd.smd"
	studio "60rnd.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.154 2.048 4.533

$cdmaterials "models\weapons\fas2\rifles\lr300\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -22.12 -2.044 -6.045 18.024 2.352 15.11

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 5.074734 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 22.444901 -0.781806 -6.506564 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 7.181018 -0.239106 -3.799844 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"lr300_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "lr300_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
