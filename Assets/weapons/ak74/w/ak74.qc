// Created by Crowbar 0.74

$modelname "weapons\fas2\world\rifles\ak74.mdl"

$bodygroup "weapon"
{
	studio "ak74.smd"
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
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "30rnd.smd"
	studio "45rnd.smd"
	studio "60rnd.smd"
}


$surfaceprop "weapon"

$contents "solid"

$illumposition -0.188 -1.998 3.622

$cdmaterials "models\weapons\fas2\rifles\ak-47\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -20.977 -2.146 -7.904 24.973 1.52 15.148

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 30.852995 -0.791681 -7.920416 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 9.688213 -0.33549 -4.815147 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"ak74_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "ak74_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
