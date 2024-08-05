// Created by Crowbar 0.74

$modelname "weapons\fas2\world\snipers\svd.mdl"

$bodygroup "studio"
{
	studio "svd.smd"
}
$bodygroup "Sights"
{
	blank
	studio "mount.smd"
	studio "pso1.smd"
}
$bodygroup "Barrel"
{
	blank
	studio "suppressor.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.081 -7.657 5.219

$cdmaterials "models\weapons\fas2\snipers\svd\"
$cdmaterials "models\weapons\fas2\accessories\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -21.022 -1.968 -7.159 36.336 1.881 17.597

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000158 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 42.533749 -0.793721 -10.016345 10.000177 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 11.115462 -0.239544 -5.023635 10.000177 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"svd_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "svd_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
