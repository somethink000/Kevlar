// Created by Crowbar 0.74

$modelname "weapons\fas2\world\machineguns\rpk.mdl"

$bodygroup "studio"
{
	studio "rpk.smd"
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
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "45rnd.smd"
	studio "75rnd.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.115 -4.607 4.506

$cdmaterials "models\weapons\fas2\rifles\ak-47\"
$cdmaterials "models\weapons\fas2\accessories\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -20.859 -7.258 -7.274 30.073 7.488 16.286

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000158 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 33.696075 -0.791663 -8.095486 10.000177 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 8.888364 -0.335485 -4.482819 10.000177 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"rpk_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "rpk_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
