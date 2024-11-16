// Created by Crowbar 0.74

$modelname "weapons\fas2\view\rifles\aks74u.mdl"

$bodygroup "studio"
{
	studio "aks74u.smd"
}
$bodygroup "Hands"
{
	studio "hand_red.smd"
	studio "hand_blue.smd"
	studio "hand_red2.smd"
	studio "hand_blue2.smd"
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


$surfaceprop "default"

$contents "solid"

$illumposition -1.516 -9.935 -8.063

$cdmaterials "models\weapons\fas2\rifles\aks74u\"
$cdmaterials "models\weapons\fas2\rifles\m4a1\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\fas2\hands\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "FLASH" -3.8 0 0.15 rotate 0 0 0
$attachment "ejector" "EJECT" 0 0.65 0.2 rotate 0 0 90
$attachment "muzzle_suppressor" "FLASH" -3.8 0 0.15 rotate 0 0 0
$attachment "Sight1" "FLASH" 0 -2.2 0.4 rotate -0.9 0 0
$attachment "Sight2" "FLASH" 0 -2.2 -0.31 rotate 0 0 0

$cbox 0 0 0 0 0 0

$bbox -10.855 -13.871 -16.917 25.344 10.347 -0.077

$definebone "ValveBiped.Bip01_R_SF" "" 0 0 0 0 179.999978 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Forearm" "ValveBiped.Bip01_R_SF" -11.000001 0 0 0 0 90.000098 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_UpperArm" "ValveBiped.Bip01_R_Forearm" -9.999999 0.000001 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger12" "" 0 0 0.000001 -0.000001 -0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger11" "" 0 0 0.000001 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger1" "" 0 0 -0.000001 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger22" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger21" "" 0 0 0.000002 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger2" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger32" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger31" "" 0 0 0.000001 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger3" "" 0 0 0.000001 -0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger42" "" 0 0 0 -0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger41" "" 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger4" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger02" "" -0.000002 0.000002 0 0.928239 1.727645 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger01" "" -0.000002 0 0 0.928238 1.72764 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger0" "" 0 0.000002 0 0.928238 1.727639 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Hand" "" 0.002054 -0.00006 -0.008102 9.999604 -179.935214 -89.931803 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_SF" "" 0 0 0 -0.000002 179.999978 89.999982 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Forearm" "ValveBiped.Bip01_L_SF" -10.999994 -0.000001 0 0 0.000002 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_UpperArm" "ValveBiped.Bip01_L_Forearm" -10.000002 0 0 -0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger12" "" 0 0 0 -0.000001 0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger11" "" 0 0 0 -0.000001 0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger1" "" 0 0 0 0 0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger22" "" 0 0 0 0 -0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger21" "" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger2" "" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger32" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger31" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger3" "" 0 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger42" "" 0 0 0 0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger41" "" 0 0 0 0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger4" "" 0 0 0 0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger02" "" 0 0 0 0.928257 1.727637 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger01" "" 0 0 0 0.928255 1.727634 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger0" "" 0 0 0 0.928255 1.727632 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Hand" "" 0.002007 -0.000042 -0.008113 -9.999656 0.041425 89.923204 0 0 0 0 0 0
$definebone "MAGAZINE" "" -2.20186 -12.285959 -2.914475 74.504229 -89.999121 90.000897 0 0 0 0 0 0
$definebone "MAGAZINE_BULLETS" "MAGAZINE" -1.165301 -0.786233 -0.000005 0 0 0 0 0 0 0 0 0
$definebone "ak_frame" "" -2.203236 -8.294739 -2.96563 0 0 0 0 0 0 0 0 0
$definebone "ak_bolt" "" -2.330202 -13.048573 -1.791194 0.000057 -179.999978 0 0 0 0 0 0 0
$definebone "EJECT" "" -2.501539 -11.417139 -1.609154 -24.999925 -179.999978 0 0 0 0 0 0 0
$definebone "FLASH" "" -2.190773 -18.306492 -2.055648 0 -89.999982 0 0 0 0 0 0 0
$definebone "MAGAZINE_2" "" -2.20186 3.669313 -11.181532 74.504168 -89.99878 90.001129 0 0 0 0 0 0
$definebone "Right Hand" "" -5.81565 -10.090681 -3.135012 -0.642171 89.642968 -179.659739 0 0 0 0 0 0
$definebone "Right Lower Arm2" "Right Hand" 0.001853 -0.011042 0.000007 -2.096853 -2.79443 0 0 0 0 0 0 0
$definebone "Right Demonstratus Phalanges1" "Right Hand" -2.69311 0.598943 -0.105603 -5.218101 175.165802 -88.556469 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange2" "Right Demonstratus Phalanges1" 0.668916 -0.00023 0.000988 0.898224 0.209415 0.603496 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange3" "Right Demonstratus Phalange2" 0.620678 -0.000353 0.000185 -0.268032 -0.515091 0.367266 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges1" "Right Hand" -2.735406 0.046616 -0.154426 -5.927653 -179.679915 -88.760214 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges2" "Right Impudicus Phalanges1" 0.693267 -0.001514 0.000457 0.476701 1.580616 -0.389898 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges3" "Right Impudicus Phalanges2" 0.708673 0 0.000002 -0.273759 -1.91082 -1.257929 0 0 0 0 0 0
$definebone "Right Annularis Phalanges1" "Right Hand" -2.579788 -0.470325 -0.041398 -0.877141 -174.239751 -86.902758 0 0 0 0 0 0
$definebone "Right Annularis Phalanges2" "Right Annularis Phalanges1" 0.698668 -0.00031 -0.00017 -0.230842 0.417858 -1.70094 0 0 0 0 0 0
$definebone "Right Annularis Phalanges3" "Right Annularis Phalanges2" 0.666527 -0.000001 0.000002 -1.43577 -0.607393 -0.392992 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges1" "Right Hand" -2.466994 -1.051962 0.081881 -0.942974 -166.863229 -87.708836 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges2" "Right Auricularis Phalanges1" 0.572366 -0.000202 0.001443 3.261903 0.471945 -1.601647 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges3" "Right Auricularis Phalanges2" 0.515589 -0.000002 0 -2.449059 -0.143755 -1.142478 0 0 0 0 0 0
$definebone "Right Polex Phalange2" "Right Hand" -1.538959 1.031096 0.649 -32.588284 158.43024 149.022365 0 0 0 0 0 0
$definebone "Right Polex Phalange3" "Right Polex Phalange2" 0.720601 -0.000998 -0.002573 -6.876923 2.674572 5.135876 0 0 0 0 0 0
$definebone "Left Hand" "" 1.260293 -10.043264 -3.142162 0.309397 -89.581954 0.200822 0 0 0 0 0 0
$definebone "Left Lower Arm 2" "Left Hand" -0.001849 0.00067 0.000002 4.118879 179.118692 0.000057 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges1" "Left Hand" 2.653172 -0.698469 0.113865 4.563667 -5.408607 89.90298 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges2" "Left Demonstratus Phalanges1" 0.704214 -0.000158 -0.001868 -1.523783 0.12685 -0.679012 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges3" "Left Demonstratus Phalanges2" 0.621944 0.000002 0 1.906228 -0.394825 1.217192 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges1" "Left Hand" 2.696817 -0.150655 0.155081 4.614087 0.186269 89.226832 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges2" "Left Impudicus Phalanges1" 0.759132 -0.000237 0.000019 0.034721 0.451144 0.871927 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges3" "Left Impudicus Phalanges2" 0.692896 -0.000004 0 0 -1.66628 0 0 0 0 0 0 0
$definebone "Left Annularis Phalanges1" "Left Hand" 2.64257 0.371995 0.042957 3.892903 6.2355 89.042854 0 0 0 0 0 0
$definebone "Left Annularis Phalanges2" "Left Annularis Phalanges1" 0.678049 0.00048 -0.001802 -2.115017 -0.569807 1.356019 0 0 0 0 0 0
$definebone "Left Annularis Phalanges3" "Left Annularis Phalanges2" 0.668667 -0.000002 0 0.732125 -0.309341 -1.104262 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges1" "Left Hand" 2.45263 0.938828 -0.082467 -0.668413 10.637705 89.485819 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges2" "Left Auricularis Phalanges1" 0.601522 0.000082 -0.001163 -0.046467 -1.102084 0.765357 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges3" "Left Auricularis Phalanges2" 0.550749 -0.000001 0 -0.317595 1.758866 -0.401586 0 0 0 0 0 0
$definebone "Left Polex Phalange1" "Left Hand" 0.912807 -0.922066 -0.179032 31.362193 -24.248278 -142.961528 0 0 0 0 0 0
$definebone "Left Polex Phalange2" "Left Polex Phalange1" 0.868581 -0.002155 -0.000869 -1.638603 4.068863 -2.680983 0 0 0 0 0 0
$definebone "Left Polex Phalange3" "Left Polex Phalange2" 0.674674 0.00034 0.000568 2.28186 -1.369894 -5.013951 0 0 0 0 0 0

$bonemerge "ValveBiped.Bip01_R_SF"
$bonemerge "ValveBiped.Bip01_R_Forearm"
$bonemerge "ValveBiped.Bip01_R_UpperArm"
$bonemerge "ValveBiped.Bip01_R_Finger12"
$bonemerge "ValveBiped.Bip01_R_Finger11"
$bonemerge "ValveBiped.Bip01_R_Finger1"
$bonemerge "ValveBiped.Bip01_R_Finger22"
$bonemerge "ValveBiped.Bip01_R_Finger21"
$bonemerge "ValveBiped.Bip01_R_Finger2"
$bonemerge "ValveBiped.Bip01_R_Finger32"
$bonemerge "ValveBiped.Bip01_R_Finger31"
$bonemerge "ValveBiped.Bip01_R_Finger3"
$bonemerge "ValveBiped.Bip01_R_Finger42"
$bonemerge "ValveBiped.Bip01_R_Finger41"
$bonemerge "ValveBiped.Bip01_R_Finger4"
$bonemerge "ValveBiped.Bip01_R_Finger02"
$bonemerge "ValveBiped.Bip01_R_Finger01"
$bonemerge "ValveBiped.Bip01_R_Finger0"
$bonemerge "ValveBiped.Bip01_R_Hand"
$bonemerge "ValveBiped.Bip01_L_SF"
$bonemerge "ValveBiped.Bip01_L_Forearm"
$bonemerge "ValveBiped.Bip01_L_UpperArm"
$bonemerge "ValveBiped.Bip01_L_Finger12"
$bonemerge "ValveBiped.Bip01_L_Finger11"
$bonemerge "ValveBiped.Bip01_L_Finger1"
$bonemerge "ValveBiped.Bip01_L_Finger22"
$bonemerge "ValveBiped.Bip01_L_Finger21"
$bonemerge "ValveBiped.Bip01_L_Finger2"
$bonemerge "ValveBiped.Bip01_L_Finger32"
$bonemerge "ValveBiped.Bip01_L_Finger31"
$bonemerge "ValveBiped.Bip01_L_Finger3"
$bonemerge "ValveBiped.Bip01_L_Finger42"
$bonemerge "ValveBiped.Bip01_L_Finger41"
$bonemerge "ValveBiped.Bip01_L_Finger4"
$bonemerge "ValveBiped.Bip01_L_Finger02"
$bonemerge "ValveBiped.Bip01_L_Finger01"
$bonemerge "ValveBiped.Bip01_L_Finger0"
$bonemerge "ValveBiped.Bip01_L_Hand"


$sectionframes 30 130

$sequence "idle" {
	"aks74u_anims\idle.smd"
	activity "ACT_VM_IDLE" 1
	fadein 0.2
	fadeout 0.2
	fps 30
}

$sequence "idle_scoped" {
	"aks74u_anims\idle_scoped.smd"
	activity "ACT_VM_IDLE_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	fps 30
}

$sequence "deploy" {
	"aks74u_anims\deploy.smd"
	activity "ACT_VM_DRAW" 1
	fadein 0.2
	fadeout 0.2
	fps 70
}

$sequence "holster" {
	"aks74u_anims\holster.smd"
	activity "ACT_VM_HOLSTER" 1
	fadein 0.2
	fadeout 0.2
	fps 90
}

$sequence "fire" {
	"aks74u_anims\fire.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "fire_scoped" {
	"aks74u_anims\fire_scoped.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "fix" {
	"aks74u_anims\fix.smd"
	activity "ACT_VM_FIX" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 36
}

$sequence "reload" {
	"aks74u_anims\reload.smd"
	activity "ACT_VM_RELOAD" 1
	fadein 0.2
	fadeout 0.2
	fps 36
}

$sequence "reload_empty" {
	"aks74u_anims\reload_empty.smd"
	activity "ACT_VM_RELOAD_EMPTY" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 36
}

$sequence "reload_nomen" {
	"aks74u_anims\reload_nomen.smd"
	activity "ACT_VM_RELOAD_NOMEN" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 34
}

$sequence "reload_empty_nomen" {
	"aks74u_anims\reload_empty_nomen.smd"
	activity "ACT_VM_RELOAD_EMPTY_NOMEN" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 34
}

$sequence "idle_grip" {
	"aks74u_anims\idle_grip.smd"
	activity "ACT_VM_IDLE_grip" 1
	fadein 0.2
	fadeout 0.2
	fps 30
}

$sequence "idle_scoped_grip" {
	"aks74u_anims\idle_scoped_grip.smd"
	activity "ACT_VM_IDLE_SCOPED_grip" 1
	fadein 0.2
	fadeout 0.2
	fps 30
}

$sequence "deploy_grip" {
	"aks74u_anims\deploy_grip.smd"
	activity "ACT_VM_DRAW_grip" 1
	fadein 0.2
	fadeout 0.2
	fps 70
}

$sequence "holster_grip" {
	"aks74u_anims\holster_grip.smd"
	activity "ACT_VM_HOLSTER_grip" 1
	fadein 0.2
	fadeout 0.2
	fps 90
}

$sequence "fire_grip" {
	"aks74u_anims\fire_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "fire_scoped_grip" {
	"aks74u_anims\fire_scoped_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "fix_grip" {
	"aks74u_anims\fix_grip.smd"
	activity "ACT_VM_FIX_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 36
}

$sequence "reload_grip" {
	"aks74u_anims\reload_grip.smd"
	activity "ACT_VM_RELOAD_grip" 1
	fadein 0.2
	fadeout 0.2
	fps 36
}

$sequence "reload_empty_grip" {
	"aks74u_anims\reload_empty_grip.smd"
	activity "ACT_VM_RELOAD_EMPTY_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 36
}

$sequence "reload_nomen_grip" {
	"aks74u_anims\reload_nomen_grip.smd"
	activity "ACT_VM_RELOAD_NOMEN_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 34
}

$sequence "reload_empty_nomen_grip" {
	"aks74u_anims\reload_empty_nomen_grip.smd"
	activity "ACT_VM_RELOAD_EMPTY_NOMEN_grip" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 34
}
