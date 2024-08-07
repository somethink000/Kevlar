// Created by Crowbar 0.74

$modelname "weapons\fas2\world\pistols\glock20.mdl"

$bodygroup "weapon"
{
	studio "glock20.smd"
}
$bodygroup "Barrel"
{
	blank
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Sights"
{
	blank
	studio "tritium.smd"
}
$bodygroup "Mount"
{
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "15rnd.smd"
	studio "33rnd.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.059 5.609 3.733

$cdmaterials "models\weapons\fas2\pistols\glock20\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\fas2\hands\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -75 -90 90

$cbox 0 0 0 0 0 0

$bbox -14.031 -0.678 -2.866 2.814 0.972 10.333

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 9.110605 -0.781809 -4.159578 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 3.620073 -0.795105 -3.949341 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"glock20_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "glock20_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
