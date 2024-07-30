// Created by Crowbar 0.74

$modelname "weapons\fas2\world\snipers\m110.mdl"

$bodygroup "studio"
{
	studio "m110.smd"
}
$bodygroup "Barrel"
{
	studio "muzzle.smd"
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Mount"
{
	studio "iron.smd"
	blank
}
$bodygroup "Grip"
{
	blank
	studio "foregrip.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.121 -1.784 6.415

$cdmaterials "models\weapons\fas2\snipers\m110\"
$cdmaterials "models\weapons\fas2\rifles\l85\"
$cdmaterials "models\weapons\fas2\rifles\m4a1\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -22.532 -1.469 -4.28 26.1 1.728 17.109

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 5.074734 10.000159 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 31.730694 -0.781809 -8.732824 10.000179 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 7.606339 -0.239107 -4.636024 10.000179 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"m110_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "m110_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
