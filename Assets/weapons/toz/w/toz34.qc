// Created by Crowbar 0.74

$modelname "weapons\fas2\world\shotguns\toz34.mdl"

$bodygroup "studio"
{
	studio "toz34.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 0.118 -0.524 3.937

$cdmaterials "models\weapons\fas2\shotguns\toz34\"
$cdmaterials "models\weapons\fas2\accessories\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate 90 -180 0

$cbox 0 0 0 0 0 0

$bbox -27.951 -0.995 -9.619 29 1.23 17.494

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000158 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 40.878899 -0.793717 -9.390675 10.000177 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 6.931866 -0.239543 -4.107071 10.000177 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"toz34_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "toz34_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
