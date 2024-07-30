// Created by Crowbar 0.74

$modelname "weapons\fas2\view\snipers\m110.mdl"

$bodygroup "studio"
{
	studio "m110.smd"
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
$bodygroup "Mount"
{
	studio "iron.smd"
	blank
}
$bodygroup "Grip"
{
	blank
	studio "foregrip.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 12.789 -0.785 -6.786

$cdmaterials "models\weapons\fas2\snipers\m110\"
$cdmaterials "models\weapons\fas2\rifles\l85\"
$cdmaterials "models\weapons\fas2\rifles\m4a1\"
$cdmaterials "models\weapons\fas2\hands\"
$cdmaterials "models\weapons\fas2\accessories\"
$cdmaterials "models\weapons\shells\"

$attachment "muzzle" "bone_flash" 0 0.15 0 rotate 0 0 0
$attachment "ejector" "Bone17" 0 0.2 -0.2 rotate -80 -90 -180

$cbox 0 0 0 0 0 0

$bbox -2.639 -14.615 -20.752 29.399 12.025 -1.168

$definebone "Dummy01" "" -2.030936 -7.544808 -2.878655 0 -89.999982 89.999982 0 0 0 0 0 0
$definebone "Dummy03" "Dummy01" -0.722724 1.151087 0.008483 0 0 0 0 0 0 0 0 0
$definebone "Bone23" "Dummy01" 1.0666 -0.576401 0.012807 -0.001547 -86.321707 0.000057 0 0 0 0 0 0
$definebone "Bone13" "Dummy01" 1.829091 -0.263794 0.316714 0 0.451147 0 0 0 0 0 0 0
$definebone "Bone15" "Dummy01" 1.86165 0.111955 -0.400131 0 89.999982 -0.000172 0 0 0 0 0 0
$definebone "Bone17" "Dummy01" 2.718707 0.627289 0.470863 -9.86811 -89.999982 0.000057 0 0 0 0 0 0
$definebone "Bone09" "Dummy01" 1.700212 0.858166 0.012808 0 0.266483 0 0 0 0 0 0 0
$definebone "Dummy05" "Dummy01" 2.915986 -2.131287 0.008488 0 0 0 0 0 0 0 0 0
$definebone "Dummy04" "Dummy05" -0.127879 0.788581 0 0 0 0 0 0 0 0 0 0
$definebone "bone16" "Dummy05" -0.127879 1.269422 0 0 0 0 0 0 0 0 0 0
$definebone "Right Hand" "" -5.81565 -10.090681 -3.135012 -0.642114 89.643084 -179.659739 0 0 0 0 0 0
$definebone "Right Lower Arm2" "Right Hand" 0.001853 -0.011043 0.000007 -2.096854 -2.794373 0 0 0 0 0 0 0
$definebone "Right Demonstratus Phalanges1" "Right Hand" -2.693112 0.598938 -0.105602 -5.218156 175.165802 -88.556422 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange2" "Right Demonstratus Phalanges1" 0.668921 -0.00023 0.000988 0.898168 0.209355 0.603439 0 0 0 0 0 0
$definebone "Right Demonstratus Phalange3" "Right Demonstratus Phalange2" 0.620682 -0.000352 0.000185 -0.267973 -0.515151 0.367323 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges1" "Right Hand" -2.735406 0.046611 -0.154424 -5.927539 -179.679792 -88.760159 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges2" "Right Impudicus Phalanges1" 0.693262 -0.001516 0.000457 0.476529 1.5805 -0.39007 0 0 0 0 0 0
$definebone "Right Impudicus Phalanges3" "Right Impudicus Phalanges2" 0.708672 0 0 -0.273416 -1.910703 -1.257642 0 0 0 0 0 0
$definebone "Right Annularis Phalanges1" "Right Hand" -2.579771 -0.47033 -0.041396 -0.877428 -174.239628 -86.902751 0 0 0 0 0 0
$definebone "Right Annularis Phalanges2" "Right Annularis Phalanges1" 0.69866 -0.00031 -0.000168 -0.23096 0.417801 -1.701055 0 0 0 0 0 0
$definebone "Right Annularis Phalanges3" "Right Annularis Phalanges2" 0.666529 0 0.000002 -1.43566 -0.607335 -0.392877 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges1" "Right Hand" -2.466993 -1.051966 0.081883 -0.942573 -166.863065 -87.70872 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges2" "Right Auricularis Phalanges1" 0.572366 -0.000204 0.001442 3.261791 0.471544 -1.601876 0 0 0 0 0 0
$definebone "Right Auricularis Phalanges3" "Right Auricularis Phalanges2" 0.515575 0 0 -2.448937 -0.143583 -1.142363 0 0 0 0 0 0
$definebone "Right Polex Metacarpal" "Right Hand" -0.205823 0.527907 0.046739 44.660169 -89.716427 -89.094306 0 0 0 0 0 0
$definebone "Right Polex Phalange1" "Right Polex Metacarpal" -0.218396 0.054786 -0.682163 48.019191 -165.497082 114.931894 0 0 0 0 0 0
$definebone "Right Polex Phalange2" "Right Polex Phalange1" 0.873056 0.002831 -0.000315 -0.371924 -3.348994 -2.481186 0 0 0 0 0 0
$definebone "Right Polex Phalange3" "Right Polex Phalange2" 0.720598 -0.000998 -0.002572 -6.877053 2.674685 5.135781 0 0 0 0 0 0
$definebone "Left Hand" "" 1.260293 -10.043264 -3.142162 0.30934 -89.581838 0.200764 0 0 0 0 0 0
$definebone "Left Lower Arm 2" "Left Hand" -0.001859 0.00067 0.000001 4.118822 179.118528 0 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges1" "Left Hand" 2.65317 -0.698475 0.113861 4.564186 -5.408722 89.90298 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges2" "Left Demonstratus Phalanges1" 0.704206 -0.000156 -0.001868 -1.523781 0.127255 -0.679012 0 0 0 0 0 0
$definebone "Left Demonstratus Phalanges3" "Left Demonstratus Phalanges2" 0.62195 0 0 1.906286 -0.39488 1.217192 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges1" "Left Hand" 2.696805 -0.150661 0.155077 4.614086 0.186154 89.226887 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges2" "Left Impudicus Phalanges1" 0.759121 -0.000239 0.000019 0.034721 0.4508 0.871927 0 0 0 0 0 0
$definebone "Left Impudicus Phalanges3" "Left Impudicus Phalanges2" 0.692899 -0.000001 0 0 -1.665936 0 0 0 0 0 0 0
$definebone "Left Annularis Phalanges1" "Left Hand" 2.642564 0.371989 0.042955 3.893362 6.235328 89.042915 0 0 0 0 0 0
$definebone "Left Annularis Phalanges2" "Left Annularis Phalanges1" 0.678044 0.000483 -0.001802 -2.11496 -0.569693 1.356019 0 0 0 0 0 0
$definebone "Left Annularis Phalanges3" "Left Annularis Phalanges2" 0.668664 0 0 0.732123 -0.309055 -1.104319 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges1" "Left Hand" 2.452626 0.938823 -0.082469 -0.668413 10.637536 89.485751 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges2" "Left Auricularis Phalanges1" 0.601521 0.000082 -0.001163 -0.046409 -1.102142 0.765414 0 0 0 0 0 0
$definebone "Left Auricularis Phalanges3" "Left Auricularis Phalanges2" 0.550749 0 0 -0.317588 1.759152 -0.401643 0 0 0 0 0 0
$definebone "Left Polex Metacarpal" "Left Hand" 0.219836 -0.599415 -0.044417 44.800655 -90.1085 90.437947 0 0 0 0 0 0
$definebone "Left Polex Phalange1" "Left Polex Metacarpal" 0.322868 0.125605 -0.694551 51.101191 -11.870806 77.08643 0 0 0 0 0 0
$definebone "Left Polex Phalange2" "Left Polex Phalange1" 0.868587 -0.002157 -0.000869 -1.638581 4.068973 -2.680983 0 0 0 0 0 0
$definebone "Left Polex Phalange3" "Left Polex Phalange2" 0.674673 0.000337 0.000567 2.28188 -1.370229 -5.014005 0 0 0 0 0 0
$definebone "Right shoulder" "" -5.758168 7.237389 -3.577589 0.431323 -1.66851 179.738982 0 0 0 0 0 0
$definebone "Right Upper Arm" "Right shoulder" 0 0 0 -1.190664 -89.788103 0.003667 0 0 0 0 0 0
$definebone "Right Lower Arm" "Right Upper Arm" -9.996894 0 0 -0.054717 -3.963264 -0.000172 0 0 0 0 0 0
$definebone "bone_flash" "Dummy01" 17.651857 0.3621 0.000009 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_SF" "Right Lower Arm2" 0 0 0 0 179.999978 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Forearm" "ValveBiped.Bip01_R_SF" -11.000001 0 0 0 0 90.000098 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_UpperArm" "ValveBiped.Bip01_R_Forearm" -9.999998 0.000001 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger12" "Right Demonstratus Phalange3" 0 0 0.000001 -0.000001 -0.000007 -0.000001 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger11" "Right Demonstratus Phalange2" 0 0 0.000001 0 -0.000004 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger1" "Right Demonstratus Phalanges1" 0 0 -0.000001 0 -0.000004 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger22" "Right Impudicus Phalanges3" 0.000001 0 0 0 -0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger21" "Right Impudicus Phalanges2" 0 0 0.000002 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger2" "Right Impudicus Phalanges1" 0 0 0 0 -0.000003 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger32" "Right Annularis Phalanges3" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger31" "Right Annularis Phalanges2" 0 0 0.000001 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger3" "Right Annularis Phalanges1" 0 0 0.000001 -0.000005 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger42" "Right Auricularis Phalanges3" 0 0 0 -0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger41" "Right Auricularis Phalanges2" 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger4" "Right Auricularis Phalanges1" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger02" "Right Polex Phalange3" -0.000002 0.000001 0 0.928229 1.72765 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger01" "Right Polex Phalange2" -0.000003 0 0 0.928224 1.727642 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger0" "Right Polex Phalange1" 0 0.000002 0 0.928221 1.727632 -126.069446 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Hand" "Right Hand" 0.002051 -0.00006 -0.008102 9.999604 -179.935214 -89.931803 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_SF" "Left Lower Arm 2" 0 0 0 -0.000005 179.999978 89.999982 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Forearm" "ValveBiped.Bip01_L_SF" -10.999991 -0.000001 0 0 0.000004 -89.999921 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_UpperArm" "ValveBiped.Bip01_L_Forearm" -10.000003 0 0 -0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger12" "Left Demonstratus Phalanges3" 0 0 0 -0.000003 0.000005 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger11" "Left Demonstratus Phalanges2" 0 0 0 -0.000001 0.000002 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger1" "Left Demonstratus Phalanges1" 0 0 0 0 0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger22" "Left Impudicus Phalanges3" 0 0 0 0 -0.000005 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger21" "Left Impudicus Phalanges2" 0 0 0 0 -0.000004 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger2" "Left Impudicus Phalanges1" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger32" "Left Annularis Phalanges3" 0 0 0 -0.000001 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger31" "Left Annularis Phalanges2" 0 0 0 0 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger3" "Left Annularis Phalanges1" 0 0 0 -0.000001 -0.000001 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger42" "Left Auricularis Phalanges3" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger41" "Left Auricularis Phalanges2" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger4" "Left Auricularis Phalanges1" 0 0 0 0.000003 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger02" "Left Polex Phalange3" -0.000001 0 0 0.928265 1.727634 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger01" "Left Polex Phalange2" 0 0 0 0.928267 1.727627 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger0" "Left Polex Phalange1" 0 0 0 0.928272 1.727627 143.930555 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Hand" "Left Hand" 0.002007 -0.000042 -0.008113 -9.999653 0.041425 89.923204 0 0 0 0 0 0

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


$sequence "idle" {
	"m110_anims\idle.smd"
	activity "ACT_VM_IDLE" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "deploy" {
	"m110_anims\deploy.smd"
	activity "ACT_VM_DRAW" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "holster" {
	"m110_anims\holster.smd"
	activity "ACT_VM_HOLSTER" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 60
}

$sequence "deploy_empty" {
	"m110_anims\deploy_empty.smd"
	activity "ACT_VM_DRAW_EMPTY" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "holster_empty" {
	"m110_anims\holster_empty.smd"
	activity "ACT_VM_HOLSTER_EMPTY" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 60
}

$sequence "idle_scoped" {
	"m110_anims\idle_scoped.smd"
	activity "ACT_VM_IDLE_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 20
}

$sequence "idle_empty" {
	"m110_anims\idle_empty.smd"
	activity "ACT_VM_IDLE_EMPTY" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "idle_empty_scoped" {
	"m110_anims\idle_empty_scoped.smd"
	activity "ACT_VM_IDLE_SCOPED_EMPTY" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "reload" {
	"m110_anims\reload.smd"
	activity "ACT_VM_RELOAD" 1
	fadein 1
	fadeout 0.2
	fps 30
}

$sequence "reload_empty" {
	"m110_anims\reload_empty.smd"
	activity "ACT_VM_RELOAD_EMPTY" 1
	fadein 1
	fadeout 0.2
	fps 30
}

$sequence "shoot" {
	"m110_anims\shoot.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot2" {
	"m110_anims\shoot2.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot3" {
	"m110_anims\shoot3.smd"
	activity "ACT_VM_PRIMARYATTACK" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot_last" {
	"m110_anims\shoot_last.smd"
	activity "ACT_VM_FIRE_LAST" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot1_scoped" {
	"m110_anims\shoot1_scoped.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot2_scoped" {
	"m110_anims\shoot2_scoped.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot3_scoped" {
	"m110_anims\shoot3_scoped.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot_last_scoped" {
	"m110_anims\shoot_last_scoped.smd"
	activity "ACT_VM_FIRE_LAST_SCOPED" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "idle_grip" {
	"m110_anims\idle_grip.smd"
	activity "ACT_VM_IDLE_GRIP" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "deploy_grip" {
	"m110_anims\deploy_grip.smd"
	activity "ACT_VM_DRAW_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "holster_grip" {
	"m110_anims\holster_grip.smd"
	activity "ACT_VM_HOLSTER_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 60
}

$sequence "deploy_empty_grip" {
	"m110_anims\deploy_empty_grip.smd"
	activity "ACT_VM_DRAW_EMPTY_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "holster_empty_grip" {
	"m110_anims\holster_empty_grip.smd"
	activity "ACT_VM_HOLSTER_EMPTY_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 60
}

$sequence "idle_scoped_grip" {
	"m110_anims\idle_scoped_grip.smd"
	activity "ACT_VM_IDLE_SCOPED_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 20
}

$sequence "idle_empty_grip" {
	"m110_anims\idle_empty_grip.smd"
	activity "ACT_VM_IDLE_EMPTY_GRIP" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "idle_empty_scoped_grip" {
	"m110_anims\idle_empty_scoped_grip.smd"
	activity "ACT_VM_IDLE_SCOPED_EMPTY_GRIP" 1
	fadein 0.2
	fadeout 0.2
	fps 20
}

$sequence "reload_grip" {
	"m110_anims\reload_grip.smd"
	activity "ACT_VM_RELOAD_GRIP" 1
	fadein 1
	fadeout 0.2
	fps 30
}

$sequence "reload_empty_grip" {
	"m110_anims\reload_empty_grip.smd"
	activity "ACT_VM_RELOAD_EMPTY_GRIP" 1
	fadein 1
	fadeout 0.2
	fps 30
}

$sequence "shoot_grip" {
	"m110_anims\shoot_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot2_grip" {
	"m110_anims\shoot2_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot3_grip" {
	"m110_anims\shoot3_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot_last_grip" {
	"m110_anims\shoot_last_grip.smd"
	activity "ACT_VM_FIRE_LAST_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot1_scoped_grip" {
	"m110_anims\shoot1_scoped_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot2_scoped_grip" {
	"m110_anims\shoot2_scoped_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot3_scoped_grip" {
	"m110_anims\shoot3_scoped_grip.smd"
	activity "ACT_VM_PRIMARYATTACK_SCOPED_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "shoot_last_scoped_grip" {
	"m110_anims\shoot_last_scoped_grip.smd"
	activity "ACT_VM_FIRE_LAST_SCOPED_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 30
}

$sequence "fix" {
	"m110_anims\fix.smd"
	activity "ACT_VM_FIX" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}

$sequence "fix_grip" {
	"m110_anims\fix_grip.smd"
	activity "ACT_VM_FIX_GRIP" 1
	fadein 0.2
	fadeout 0.2
	snap
	fps 40
}
