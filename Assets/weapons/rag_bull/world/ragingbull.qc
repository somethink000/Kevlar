// Created by Crowbar 0.74

$modelname "weapons\fas2\world\pistols\ragingbull.mdl"

$bodygroup "weapon"
{
	studio "ragingbull.smd"
}
$bodygroup "Sights"
{
	blank
	studio "mount.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.176 5.65 5.755

$cdmaterials "models\weapons\fas2\pistols\ragingbull\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -10 180 90
$attachment "eject2" "eject2" 0 0 0 rotate -10 180 90
$attachment "eject3" "eject3" 0 0 0 rotate -10 180 90
$attachment "eject4" "eject4" 0 0 0 rotate -10 180 90
$attachment "eject5" "eject5" 0 0 0 rotate -10 180 90

$cbox 0 0 0 0 0 0

$bbox -13.509 -0.981 0.235 2.208 1.333 11.275

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000211 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 14.431046 -0.804856 -6.169016 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 4.975513 -0.80905 -4.343895 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject2" "ValveBiped.Bip01_R_Hand" 5.036568 -0.298191 -3.997643 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject3" "ValveBiped.Bip01_R_Hand" 5.140685 -0.489413 -3.407177 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject4" "ValveBiped.Bip01_R_Hand" 5.145717 -1.181587 -3.37865 10.000233 0 -179.999978 0 0 0 0 0 0
$definebone "eject5" "ValveBiped.Bip01_R_Hand" 5.035584 -1.315549 -4.003222 10.000233 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"
$bonemerge "eject2"
$bonemerge "eject3"
$bonemerge "eject4"
$bonemerge "eject5"


$sequence "idle" {
	"ragingbull_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "ragingbull_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
