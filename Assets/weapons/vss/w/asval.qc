// Created by Crowbar 0.74

$modelname "weapons\fas2\world\rifles\asval.mdl"

$bodygroup "weapon"
{
	studio "asval.smd"
}
$bodygroup "Sights"
{
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "10rnd.smd"
	studio "20rnd.smd"
	studio "30rnd.smd"
}
$bodygroup "Foregrip"
{
	blank
	studio "foregrip.smd"
}


$surfaceprop "weapon"

$contents "solid"

$illumposition -0.017 4.885 3.831

$cdmaterials "models\weapons\fas2\snipers\vss\"
$cdmaterials "models\weapons\fas2\rifles\asval\"
$cdmaterials "models\weapons\fas2\rifles\sr3m\"
$cdmaterials "models\weapons\fas2\smgs\mp5\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -23.597 -1.735 -7.294 15.066 1.471 14.313

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000158 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 27.144678 -0.791663 -6.848924 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 8.34234 -0.445332 -3.84495 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"asval_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "asval_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
