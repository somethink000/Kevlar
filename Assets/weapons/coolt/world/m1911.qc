// Created by Crowbar 0.74

$modelname "weapons\fas2\world\pistols\m1911.mdl"

$bodygroup "weapon"
{
	studio "m1911.smd"
}
$bodygroup "Barrel"
{
	blank
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Mount"
{
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "7rnd.smd"
	studio "11rnd.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.065 4.365 3.816

$cdmaterials "models\weapons\fas2\pistols\m1911\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -50 -90 90

$cbox 0 0 0 0 0 0

$bbox -13.945 -0.776 -2.795 5.215 1.007 10.426

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000211 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 10.418865 -0.791671 -4.026407 10.000232 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 4.330244 -0.751369 -3.834785 10.000232 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"m1911_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "m1911_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
