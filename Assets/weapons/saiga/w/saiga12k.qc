// Created by Crowbar 0.74

$modelname "weapons\fas2\world\shotguns\saiga12k.mdl"

$bodygroup "studio"
{
	studio "saiga12k.smd"
}
$bodygroup "Barrel"
{
	studio "muzzle.smd"
	studio "suppressor.smd"
	studio "choke.smd"
}
$bodygroup "Mount"
{
	blank
	studio "mount.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition -0.095 -1.982 5.064

$cdmaterials "models\weapons\fas2\shotguns\saiga12k\"
$cdmaterials "models\weapons\fas2\shotguns\remington870_tact\"
$cdmaterials "models\weapons\fas2\accessories\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -21.951 -1.85 -5.467 25.914 1.423 15.596

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000158 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 26.188997 -0.791661 -7.025299 10.000177 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 8.433601 -0.335484 -4.574515 10.000177 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"saiga12k_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "saiga12k_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
