// Created by Crowbar 0.74

$modelname "weapons\fas2\world\shotguns\remington870_tact.mdl"

$bodygroup "studio"
{
	studio "remington870_tact.smd"
}
$bodygroup "Muzzle"
{
	blank
	studio "suppressor.smd"
	studio "choke.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition -4.38 -10.065 -8.55

$cdmaterials "models\weapons\fas2\shotguns\remington870_tact\"
$cdmaterials "models\weapons\fas2\hands\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -15 -90 90

$cbox 0 0 0 0 0 0

$bbox -28.871 -1.397 -13.687 46.381 1.631 21.544

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 5.074734 10.000158 -90.000016 180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 41.167763 -0.708243 -10.493095 10.000177 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 10.240091 -0.168461 -4.895535 10.000177 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"remington870_tact_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "remington870_tact_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
