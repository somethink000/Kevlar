// Created by Crowbar 0.74

$modelname "weapons\fas2\world\snipers\m40a3.mdl"

$bodygroup "studio"
{
	studio "m40a3.smd"
}
$bodygroup "Muzzle"
{
	blank
	studio "suppressor.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition -0.533 -8.812 5.156

$cdmaterials "models\weapons\fas2\snipers\m40a3\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -35 -90 90

$cbox 0 0 0 0 0 0

$bbox -26.439 -2.486 -11.09 44.062 1.347 21.402

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.713944 5.643739 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 46.937363 -0.781809 -11.381253 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 10.340411 -0.447119 -4.916103 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"m40a3_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "m40a3_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
