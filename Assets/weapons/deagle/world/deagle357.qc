// Created by Crowbar 0.74

$modelname "weapons\fas2\world\pistols\deagle357.mdl"

$bodygroup "weapon"
{
	studio "deagle357.smd"
}
$bodygroup "Muzzle"
{
	blank
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Sights"
{
	blank
	studio "tritium.smd"
}
$bodygroup "Mount"
{
	blank
	studio "mount.smd"
}


$surfaceprop "weapon"

$contents "solid"

$illumposition 0.119 4.968 5.008

$cdmaterials "models\weapons\fas2\pistols\desert_eagle\"
$cdmaterials "models\weapons\fas2\pistols\deagle357\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "muzzle" 0 0 0 rotate 0 0 0
$attachment "eject" "eject" 0 0 0 rotate -75 -90 90

$cbox 0 0 0 0 0 0

$bbox -13.566 -0.949 -0.371 3.63 1.187 10.386

$definebone "ValveBiped.Bip01_R_Hand" "" -0.678304 13.183071 4.586786 10.000159 -90.000016 -180.000005 0 0 0 0 0 0
$definebone "muzzle" "ValveBiped.Bip01_R_Hand" 11.271745 -0.79168 -4.542553 10.000178 0 -179.999978 0 0 0 0 0 0
$definebone "eject" "ValveBiped.Bip01_R_Hand" 3.595505 -0.751373 -3.705226 10.000178 0 -179.999978 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "muzzle"
$bonemerge "eject"


$sequence "idle" {
	"deagle357_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
}

$collisionmodel "deagle357_physics.smd"
{
	$mass 8
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone " "

}
