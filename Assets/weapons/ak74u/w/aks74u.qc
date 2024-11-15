// Created by Crowbar 0.74

$modelname "weapons\fas2\world\rifles\aks74u.mdl"

$bodygroup "weapon"
{
	studio "aks74u.smd"
}
$bodygroup "Barrel"
{
	studio "muzzle.smd"
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Magazine"
{
	studio "30rnd.smd"
	studio "45rnd.smd"
	studio "60rnd.smd"
}
$bodygroup "Handguard"
{
	studio "handguard.smd"
	studio "handguard_zenit.smd"
}
$bodygroup "Foregrip"
{
	blank
	studio "foregrip.smd"
}


$surfaceprop "weapon"

$contents "solid"

$illumposition -0.415 1.741 4.305

$cdmaterials "models\weapons\fas2\rifles\aks74u\"
$cdmaterials "models\weapons\fas2\rifles\m4a1\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -23.223 -2.472 -6.571 19.741 1.455 15.18

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 24.330061 -0.791681 -6.944499 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 10.138222 -0.33549 -5.2416 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"aks74u_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "aks74u_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
