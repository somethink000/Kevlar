// Created by Crowbar 0.74

$modelname "weapons\fas2\view\pistols\m1911.mdl"

$bodygroup "weapon"
{
	studio "m1911.smd"
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
	blank
	studio "suppressor.smd"
	studio "muzzlebrake.smd"
	studio "flashhider.smd"
}
$bodygroup "Mount"
{
	blank
	studio "mount.smd"
}
$bodygroup "Magazine"
{
	studio "7rnd.smd"
	studio "11rnd.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition -3.934 -2.299 -6.187

$cdmaterials "models\weapons\fas2\pistols\m1911\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\fas2\hands\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "Barrel_BONE" 1.2 0 0 rotate 0 0 0
$attachment "ejector" "Frame_BONE" 1.31 1.12 0.06 rotate -45 100 -90
$attachment "muzzle_suppressor" "Suppressor_BONE" 0 0 0 rotate 0 0 0
$attachment "Sight1" "Frame_BONE" 2 -1.86 1.03 rotate 0 0 0

$cbox 0 0 0 0 0 0

$bbox -13.127 -20.041 -11.393 17.725 12.173 -0.981

$definebone "Frame_BONE" "" -1.864785 -8.374489 -2.811725 -0.099962 -90.000016 90.000016 0 0 0 0 0 0
$definebone "Trigger_BONE" "Frame_BONE" 1.007936 0.509237 0 0 0 0 0 0 0 0 0 0
$definebone "MagRelease_BONE" "Frame_BONE" 0.683147 0.194226 0 0 0 0 0 0 0 0 0 0
$definebone "SlideStop_BONE" "Frame_BONE" 1.434844 0.890085 0 0 0 0 0 0 0 0 0 0
$definebone "Hammer_BONE" "Frame_BONE" -0.514959 0.956055 0 0 0 0 0 0 0 0 0 0
$definebone "Safety_BONE" "Frame_BONE" -0.685158 0.804212 0 0.000019 -180.000005 180.000005 0 0 0 0 0 0
$definebone "Magazine_BONE" "Frame_BONE" -0.333329 -1.161368 0 0 0 0 0 0 0 0 0 0
$definebone "Bullet_BONE" "Magazine_BONE" 0.890887 2.304715 0 0 0 0 0 0 0 0 0 0
$definebone "Barrel_BONE" "Frame_BONE" 2.769669 1.388998 -0.000001 0 -0.099981 0 0 0 0 0 0 0
$definebone "Suppressor_BONE" "Barrel_BONE" 6.591043 -0.001582 0 0 0 0 0 0 0 0 0 0
$definebone "Slide_BONE" "Frame_BONE" -0.075435 1.716427 -0.000001 0 0 0 0 0 0 0 0 0
$definebone "Right Hand" "" -5.81565 -10.090681 -3.135012 -0.642114 89.643084 -179.659739 0 0 0 0 0 0
$definebone "Right Lower Arm2" "Right Hand" 0.001853 -0.011043 0.000007 -2.096854 -2.794373 0 0 0 0 0 0 0
$definebone "Right Demonstratus Phalanges1" "Right Hand" -2.693112 0.598938 -0.105602 -5.218156 175.165802 -88.556422 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange2" "Right Demonstratus Phalanges1" 0.66892 -0.00023 0.000988 0.898168 0.209354 0.603439 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange3" "Right Demonstratus Phalange2" 0.620681 -0.000352 0.000185 -0.267973 -0.515152 0.367323 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges1" "Right Hand" -2.735406 0.046611 -0.154424 -5.92754 -179.679792 -88.760159 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges2" "Right Impudicus Phalanges1" 0.693262 -0.001516 0.000457 0.476529 1.580499 -0.39007 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges3" "Right Impudicus Phalanges2" 0.708671 0 0 -0.273416 -1.910703 -1.257642 0 0 0 0 0 0
$definebone "Right Annularis Phalanges1" "Right Hand" -2.579781 -0.47033 -0.041396 -0.877428 -174.239628 -86.902758 0 0 0 0 0 0
$definebone "Right Annularis Phalanges2" "Right Annularis Phalanges1" 0.698667 -0.00031 -0.000169 -0.23096 0.417801 -1.701055 0 0 0 0 0 0
$definebone "Right Annularis Phalanges3" "Right Annularis Phalanges2" 0.666528 0 0 -1.435661 -0.607335 -0.392877 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges1" "Right Hand" -2.466993 -1.051966 0.081883 -0.942573 -166.863065 -87.70872 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges2" "Right Auricularis Phalanges1" 0.572366 -0.000204 0.001442 3.261791 0.471544 -1.601876 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges3" "Right Auricularis Phalanges2" 0.515581 0 0 -2.448937 -0.143583 -1.142363 0 0 0 0 0 0
$definebone "Right Polex Metacarpal" "Right Hand" -0.205823 0.527907 0.046739 44.660169 -89.716427 -89.094306 0 0 0 0 0 0
$definebone "Right Polex Phalange1" "Right Polex Metacarpal" -0.218396 0.054786 -0.682163 48.019184 -165.497068 114.93188 0 0 0 0 0 0
$definebone "Right Polex Phalange2" "Right Polex Phalange1" 0.873055 0.002833 -0.000315 -0.371878 -3.349001 -2.481192 0 0 0 0 0 0
$definebone "Right Polex Phalange3" "Right Polex Phalange2" 0.7206 -0.000998 -0.002572 -6.877014 2.674679 5.135772 0 0 0 0 0 0
$definebone "Left Hand" "" 1.260293 -10.043264 -3.142162 0.30934 -89.581838 0.200764 0 0 0 0 0 0
$definebone "Left Lower Arm 2" "Left Hand" -0.001853 0.00067 0.000001 4.118822 179.118528 0 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges1" "Left Hand" 2.65317 -0.698475 0.113861 4.564182 -5.408722 89.90298 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges2" "Left Demonstratus Phalanges1" 0.704209 -0.000156 -0.001868 -1.523781 0.127258 -0.679012 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges3" "Left Demonstratus Phalanges2" 0.621946 0 0 1.906287 -0.394879 1.217192 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges1" "Left Hand" 2.696814 -0.150661 0.155077 4.614087 0.186154 89.226887 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges2" "Left Impudicus Phalanges1" 0.759127 -0.000239 0.000019 0.034721 0.450799 0.871927 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges3" "Left Impudicus Phalanges2" 0.692899 -0.000001 0 0 -1.665937 0 0 0 0 0 0 0
$definebone "Left Annularis Phalanges1" "Left Hand" 2.64257 0.371989 0.042955 3.893362 6.235328 89.042915 0 0 0 0 0 0
$definebone "Left Annularis Phalanges2" "Left Annularis Phalanges1" 0.678047 0.000483 -0.001802 -2.11496 -0.569693 1.356019 0 0 0 0 0 0
$definebone "Left Annularis Phalanges3" "Left Annularis Phalanges2" 0.668665 0 0 0.732122 -0.309055 -1.104319 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges1" "Left Hand" 2.452632 0.938823 -0.082469 -0.668413 10.637536 89.485751 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges2" "Left Auricularis Phalanges1" 0.601524 0.000082 -0.001163 -0.046409 -1.102142 0.765414 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges3" "Left Auricularis Phalanges2" 0.550749 0 0 -0.317588 1.759152 -0.401644 0 0 0 0 0 0
$definebone "Left Polex Metacarpal" "Left Hand" 0.219842 -0.599415 -0.044417 44.800645 -90.10848 90.437927 0 0 0 0 0 0
$definebone "Left Polex Phalange1" "Left Polex Metacarpal" 0.322868 0.125605 -0.694551 51.101174 -11.870824 77.08643 0 0 0 0 0 0
$definebone "Left Polex Phalange2" "Left Polex Phalange1" 0.868583 -0.002157 -0.000869 -1.6386 4.069003 -2.680982 0 0 0 0 0 0
$definebone "Left Polex Phalange3" "Left Polex Phalange2" 0.674673 0.000336 0.000567 2.281856 -1.370216 -5.014004 0 0 0 0 0 0
$definebone "Right shoulder" "" -5.758168 7.237389 -3.577589 0.431323 -1.66851 179.738982 0 0 0 0 0 0
$definebone "Right Upper Arm" "Right shoulder" 0 0 0 -1.190663 -89.788103 0.003667 0 0 0 0 0 0
$definebone "Right Lower Arm" "Right Upper Arm" -9.996882 0 0 -0.054718 -3.963264 -0.000172 0 0 0 0 0 0
$definebone "weapon_main" "" -1.661013 -4.104281 -1.840956 0 0 0 0 0 0 0 0 0
$definebone "muzzle_flash" "weapon_main" 0.018343 -12.465143 0.170823 0 -89.999921 89.999982 0 0 0 0 0 0
$definebone "muzzle_flash_s" "weapon_main" 0.020954 -15.937212 0.172096 0 -89.999921 89.999982 0 0 0 0 0 0
$definebone "shell_ejection" "weapon_main" -0.462016 1.560124 0.303226 -23.969205 -170.752858 93.0446 0 0 0 0 0 0
$definebone "weapon_bolt" "weapon_main" -0.367283 0.826143 0.327579 0 0 0 0 0 0 0 0 0
$definebone "weapon_magazine_release" "weapon_main" 0.383088 1.906894 -0.712329 0 0 0 0 0 0 0 0 0
$definebone "weapon_trigger" "weapon_main" 0.014977 -3.059695 -0.873445 0 0 0 0 0 0 0 0 0
$definebone "weapon_magazine" "weapon_main" -0.003328 1.354425 -0.637806 0 0 0 0 0 0 0 0 0
$definebone "weapon_mag_bullet" "weapon_magazine" -0.018118 -0.076926 0.710881 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_SF" "Right Lower Arm2" 0 0 0 0 179.999978 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Forearm" "ValveBiped.Bip01_R_SF" -11.000001 0 0 0 0 90.000098 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_UpperArm" "ValveBiped.Bip01_R_Forearm" -9.999998 0.000001 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger12" "Right Demonstratus Phalange3" 0 0 0.000001 -0.000001 -0.000005 -0.000001 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger11" "Right Demonstratus Phalange2" 0 0 0.000001 0 -0.000003 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger1" "Right Demonstratus Phalanges1" 0 0 -0.000001 0 -0.000003 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger22" "Right Impudicus Phalanges3" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger21" "Right Impudicus Phalanges2" 0 0 0.000002 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger2" "Right Impudicus Phalanges1" 0 0 0 0 -0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger32" "Right Annularis Phalanges3" 0 0 0 -0.000002 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger31" "Right Annularis Phalanges2" 0 0 0.000001 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger3" "Right Annularis Phalanges1" 0 0 0.000001 -0.000004 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger42" "Right Auricularis Phalanges3" 0 0 0 -0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger41" "Right Auricularis Phalanges2" 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger4" "Right Auricularis Phalanges1" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger02" "Right Polex Phalange3" -0.000001 0.000002 0 0.928227 1.727647 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger01" "Right Polex Phalange2" -0.000003 0.000001 0 0.928222 1.727637 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger0" "Right Polex Phalange1" 0 0.000003 0 0.928221 1.727632 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Hand" "Right Hand" 0.002052 -0.00006 -0.008102 9.999604 -179.935214 -89.931803 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_SF" "Left Lower Arm 2" 0 0 0 -0.000004 179.999978 89.999982 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Forearm" "ValveBiped.Bip01_L_SF" -10.999992 -0.000001 0 0 0.000003 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_UpperArm" "ValveBiped.Bip01_L_Forearm" -10.000002 0 0 -0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger12" "Left Demonstratus Phalanges3" 0 0 0 -0.000001 0.000004 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger11" "Left Demonstratus Phalanges2" 0 0 0 -0.000001 0.000003 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger1" "Left Demonstratus Phalanges1" 0 0 0 0 0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger22" "Left Impudicus Phalanges3" 0 0 0 0 -0.000005 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger21" "Left Impudicus Phalanges2" 0 0 0 0 -0.000003 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger2" "Left Impudicus Phalanges1" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger32" "Left Annularis Phalanges3" 0 0 0 -0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger31" "Left Annularis Phalanges2" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger3" "Left Annularis Phalanges1" 0 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger42" "Left Auricularis Phalanges3" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger41" "Left Auricularis Phalanges2" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger4" "Left Auricularis Phalanges1" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger02" "Left Polex Phalange3" 0 0 0 0.928257 1.727614 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger01" "Left Polex Phalange2" 0 0 0 0.928255 1.727612 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger0" "Left Polex Phalange1" 0 0 0 0.928262 1.727615 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Hand" "Left Hand" 0.002007 -0.000042 -0.008113 -9.999654 0.041425 89.923204 0 0 0 0 0 0

$bonemerge "Right Hand"
$bonemerge "Right Lower Arm2"
$bonemerge "Right Demonstratus Phalanges1"
$bonemerge "Right Demonstratus Phalange2"
$bonemerge "Right Demonstratus Phalange3"
$bonemerge "Right Impudicus Phalanges1"
$bonemerge "Right Impudicus Phalanges2"
$bonemerge "Right Impudicus Phalanges3"
$bonemerge "Right Annularis Phalanges1"
$bonemerge "Right Annularis Phalanges2"
$bonemerge "Right Annularis Phalanges3"
$bonemerge "Right Auricularis Phalanges1"
$bonemerge "Right Auricularis Phalanges2"
$bonemerge "Right Auricularis Phalanges3"
$bonemerge "Right Polex Metacarpal"
$bonemerge "Right Polex Phalange1"
$bonemerge "Right Polex Phalange2"
$bonemerge "Right Polex Phalange3"
$bonemerge "Left Hand"
$bonemerge "Left Lower Arm 2"
$bonemerge "Left Demonstratus Phalanges1"
$bonemerge "Left Demonstratus Phalanges2"
$bonemerge "Left Demonstratus Phalanges3"
$bonemerge "Left Impudicus Phalanges1"
$bonemerge "Left Impudicus Phalanges2"
$bonemerge "Left Impudicus Phalanges3"
$bonemerge "Left Annularis Phalanges1"
$bonemerge "Left Annularis Phalanges2"
$bonemerge "Left Annularis Phalanges3"
$bonemerge "Left Auricularis Phalanges1"
$bonemerge "Left Auricularis Phalanges2"
$bonemerge "Left Auricularis Phalanges3"
$bonemerge "Left Polex Metacarpal"
$bonemerge "Left Polex Phalange1"
$bonemerge "Left Polex Phalange2"
$bonemerge "Left Polex Phalange3"
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


$sequence "Idle" {
	"m1911_anims\Idle.smd"
	activity "ACT_VM_IDLE" 1
	fadein 0.1
	fadeout 0.2
	fps 30
	loop
}

$sequence "Idle_Iron" {
	"m1911_anims\Idle_Iron.smd"
	activity "ACT_VM_IDLE_SCOPED" 1
	fadein 0.1
	fadeout 0.2
	fps 30
	loop
}

$sequence "Idle_Empty" {
	"m1911_anims\Idle_Empty.smd"
	activity "ACT_VM_IDLE_EMPTY" 1
	fadein 0.1
	fadeout 0.2
	fps 30
	loop
}

$sequence "Idle_Empty_Iron" {
	"m1911_anims\Idle_Empty_Iron.smd"
	activity "ACT_VM_IDLE_EMPTY_SCOPED" 1
	fadein 0.1
	fadeout 0.2
	fps 30
	loop
}

$sequence "Draw" {
	"m1911_anims\Draw.smd"
	activity "ACT_VM_DRAW" 1
	fadein 0.1
	fadeout 0.2
	fps 30
}

$sequence "Draw_Empty" {
	"m1911_anims\Draw_Empty.smd"
	activity "ACT_VM_DRAW_EMPTY" 1
	fadein 0.1
	fadeout 0.2
	fps 30
}

$sequence "Holster" {
	"m1911_anims\Holster.smd"
	activity "ACT_VM_HOLSTER" 1
	fadein 0.1
	fadeout 0.2
	fps 30
}

$sequence "Holster_Empty" {
	"m1911_anims\Holster_Empty.smd"
	activity "ACT_VM_HOLSTER_EMPTY" 1
	fadein 0.1
	fadeout 0.2
	fps 30
}

$sequence "Fire1" {
	"m1911_anims\Fire1.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Fire2" {
	"m1911_anims\Fire2.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Fire3" {
	"m1911_anims\Fire3.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Fire_Last" {
	"m1911_anims\Fire_Last.smd"
	activity "ACT_VM_FIRE_LAST" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Fire_Iron" {
	"m1911_anims\Fire_Iron.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Fire_Last_Iron" {
	"m1911_anims\Fire_Last_Iron.smd"
	activity "ACT_VM_FIRE_LAST_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "Reload" {
	"m1911_anims\Reload.smd"
	activity "ACT_VM_RELOAD" 1
	fadein 0.05
	fadeout 0.2
	fps 30
}

$sequence "Reload_Empty" {
	"m1911_anims\Reload_Empty.smd"
	activity "ACT_VM_RELOAD_EMPTY" 1
	fadein 0.05
	fadeout 0.2
	fps 30
}

$sequence "Reload_Nomen" {
	"m1911_anims\Reload_Nomen.smd"
	activity "ACT_VM_RELOAD_NOMEN" 1
	fadein 0.05
	fadeout 0.2
	fps 45
}

$sequence "Reload_Empty_Nomen" {
	"m1911_anims\Reload_Empty_Nomen.smd"
	activity "ACT_VM_RELOAD_EMPTY_NOMEN" 1
	fadein 0.05
	fadeout 0.2
	fps 45
}

$sequence "Reload_11rnd" {
	"m1911_anims\Reload_11rnd.smd"
	activity "ACT_VM_RELOAD_11RND" 1
	fadein 0.05
	fadeout 0.2
	fps 30
}

$sequence "Reload_11rnd_Empty" {
	"m1911_anims\Reload_11rnd_Empty.smd"
	activity "ACT_VM_RELOAD_11RND_EMPTY" 1
	fadein 0.05
	fadeout 0.2
	fps 30
}

$sequence "Reload_11rnd_Nomen" {
	"m1911_anims\Reload_11rnd_Nomen.smd"
	activity "ACT_VM_RELOAD_11RND_NOMEN" 1
	fadein 0.05
	fadeout 0.2
	fps 45
}

$sequence "Reload_11rnd_Empty_Nomen" {
	"m1911_anims\Reload_11rnd_Empty_Nomen.smd"
	activity "ACT_VM_RELOAD_11RND_EMPTY_NOMEN" 1
	fadein 0.05
	fadeout 0.2
	fps 45
}
