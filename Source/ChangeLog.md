# DEMO APP Changelog

##2.1.1.103
# 1/27/21
Updated SDK 2.1.2.148

##2.1.1.101
# 1/25/21
Updated SDK 2.1.2.146
Added serial number report to RKI output messages

##2.1.1.100
# 1/20/21
Updated SDK 2.1.2.143

##2.1.1.99
# 1/19/21
Updated SDK 2.1.2.142

##2.1.1.98
# 1/19/21
Updated SDK 2.1.2.141
add timeout parameter to pin_capturePinExt SWCSHAR-527

##2.1.1.97
Updated SDK 2.1.2.140

##2.1.1.96
Updated SDK 2.1.2.139

##2.1.1.95
Updated SDK 2.1.2.137

##2.1.1.94
Updated SDK 2.1.2.136
Fixed passthrough mode switching so command tree populates correctly

##2.1.1.93
Updated SDK 2.1.2.135

##2.1.1.92
Updated SDK 2.1.2.134

##2.1.1.91
Moved device connection to app level logging window <SWCSHAR-514>
Updated SDK 2.1.2.132
Added RKI read/write delays to SecureMag (Config menu)


##2.1.1.90
Fixed L80/L100 Command Tree Population <SWCSHAR-512>
Updated SDK 2.1.2.131

##2.1.1.89
Updated SDK 2.1.2.130

##2.1.1.88
Added signed message for pin_getAmount
Removed Execute Legacy RKI from L80 <SWCSHAR-495>
Updated SDK 2.1.2.129
Removed Symmetric RKI from L80 <SWCSHAR-496>
Removed device_SymmetricRKI
Added device_StartRKI
Added device_Symmetric_RKI
Added device_PKI_RKI

##2.1.1.87
Updated SDK 2.1.2.127

##2.1.1.86
Updated SDK 2.1.2.125
Fixed Save Prompt Response <SWCSHAR-490>

##2.1.1.85
Updated SDK 2.1.2.118

##2.1.1.84
Updated SDK 2.1.2.117
Added EMV options to Augusta KB

##2.1.1.83
Updated SDK 2.1.2.116
Put try/catch block around refreshTab <SWCSHAR-485>
Added dialog boxes for mode change <VC-176>

##2.1.1.82
Updated SDK 2.1.2.115

##2.1.1.81
Updated SDK 2.1.2.114

##2.1.1.80
Updated SDK 2.1.2.113

##2.1.1.79
Updated SDK 2.1.2.111
Added RKI support to SREDKey
Added Remote Connection Functions to connection menu

##2.1.1.78
Updated SDK 2.1.2.109

##2.1.1.77
Updated SDK 2.1.2.108
Updated file transfers to include SD Card option
Added Multi-App Contoller option <SWCSHAR-473>
Added L80 support <SWCSHAR-475>
Fixed whitelist capture Augusta <VC-172>
Added Set Whitelist From BDK for Augusta

##2.1.1.76
Updated SDK 2.1.2.106

##2.1.1.75
Updated SDK 2.1.2.105
Added C7-82, C7-83, msr get/set configuration <SWCSHAR-468>

##2.1.1.74
Updated SDK 2.1.2.104

##2.1.1.73
Updated SDK 2.1.2.102

##2.1.1.72
Updated SDK 2.1.2.101

##2.1.1.71
Updated SDK 2.1.2.100

##2.1.1.70
Updated SDK 2.1.2.99

##2.1.1.69
Updated SDK 2.1.2.98

##2.1.1.68
Updated SDK 2.1.2.97

##2.1.1.67
Updated SDK 2.1.2.96

##2.1.1.66
Updated SDK 2.1.2.95
removed set/get merchant record for SREDKey2 <SWCSHAR-458>
Fixed msr_getTerminalData to request Tag value input <SWCSHAR-457>
Removed unsupported command from command tree when in SREDKey2 KB  mode <SWCSHAR-459>

##2.1.1.65
Updated SDK 2.1.2.94

##2.1.1.64
Updated SDK 2.1.2.93

##2.1.1.63
Updated SDK 2.1.2.92
Added device_setTransArmorEncryption to SREDKey2
Added msr_setTerminalData to SREDKey2
Added msr_getTerminalData to SREDKey2
Added msr_resetTerminalData to SREDKey2
Added msr_startSwipeTransaction to SREDKey2
Added msr_cancelTransaction to SREDKey2
Added msr_startKeyedTransaction for SREDKey2


##2.1.1.62
Updated SDK 2.1.2.91

##2.1.1.61
Updated SDK 2.1.2.90
Added Set Poll Mode to SREDKey2 Commands

##2.1.1.60
Updated SDK 2.1.2.89

##2.1.1.59
Updated SDK 2.1.2.88

##2.1.1.58
Updated SDK 2.1.2.87

##2.1.1.57
Updated SDK 2.1.2.86

##2.1.1.56
Updated SDK 2.1.2.85

##2.1.1.55
Updated SDK 2.1.2.84
added Set/Get Merchant Record for SREDKey2 <SWCSHAR-454>
Added VP3300 to RS-232 Tree  <SWCSHAR-453>

##2.1.1.54
Updated SDK 2.1.2.83

##2.1.1.53
Updated SDK 2.1.2.82

##2.1.1.52
Updated SDK 2.1.2.81
Updated PIP menu with get/set poll mode
Removed startTrans from CTLS PIP menu
Added setBaud to KioskIII/Vendi/VendIII

##2.1.1.51
Updated SDK 2.1.2.80

##2.1.1.50
Updated SDK 2.1.1.79
Fixed Install Rules initilizatiaon

##2.1.1.49
Updated SDK 2.1.1.78
Added get/set ICC settings to Augusta ICC tree

##2.1.1.48
Updated SDK 2.1.1.77
Fixed logging commands on device reboot

##2.1.1.47
Updated SDK 2.1.1.76
Fixed Default Configuration Listing KioskIII <SWCSHAR-445>

##2.1.1.46
Updated SDK 2.1.1.74
Added Get/Set MSR Settings to SREDKey2 tree

##2.1.1.45
Updated SDK 2.1.1.72

##2.1.1.44
Updated SDK 2.1.1.71
Added Device Command and Verification Support

##2.1.1.43
Updated SDK 2.1.1.69
Added automatic reporting FW/SN upon device connection

##2.1.1.42
Updated SDK 2.1.1.68

##2.1.1.41
Updated SDK 2.1.1.67
Added Verify Function to ViVOconfig

##2.1.1.40
Updated SDK 2.1.1.65
Fixed getSwipeEncryption to recognize TransArmor <SWCSHAR-426>
Updated COM port detection <SWUS-28>

##2.1.1.39
Updated SDK 2.1.1.64
Added Capture Pin Extended to NEOII-> PIN

##2.1.1.38
Updated SDK 2.1.1.63
Added CancelKeyPressed Device State recognition <SWCSHAR-415>
Added device_pollForToken to NEOII <SWCSHAR-421>

##2.1.1.37
Updated SDK 2.1.1.62
Added Install Rule Set Self Check Time
Added Install Rule Set Date Time

##2.1.1.36
Updated SDK 2.1.1.61
Added emv->Add Terminal Settings <VC-74>
Added configuration screen when capturing device info <VC-75>

##2.1.1.35
Updated SDK 2.1.1.60

##2.1.1.34
Updated SDK 2.1.1.59
Fixed crash when attempting to check for non-valid device <SWUS-28>
Updated PAE timeout <SWCSHAR-413>

##2.1.1.33
Updated SDK 2.1.1.57
Fixed app title name reporting when switching between devices

##2.1.1.32
Updated SDK 2.1.1.56

##2.1.1.31
Updated SDK 2.1.1.55
Fixed getIdent to avoid cross-threaded operation
Removed Felica for VP3300 <SWCSHAR-402>
fixed ctls_activateTransaction <CS-3348>
Allow only 1 running instance <VC-2>

##2.1.1.30
Updated SDK 2.1.1.54

##2.1.1.29
Updated SDK 2.1.1.53

##2.1.1.28
Updated SDK 2.1.1.52

##2.1.1.27
Updated SDK 2.1.1.51

##2.1.1.26
Updated SDK 2.1.1.50

##2.1.1.25
Add Ziosk RKI to SDK <SWCSHAR-399>
Updated SDK 2.1.1.48
fixed crash when com ports = 0

##2.1.1.24
Fixed Verify Checksum Validation <VC-55>
Corrected the fixing of missing hash <VC-56>
Updated SDK 2.1.1.47

##2.1.1.23
Added compatibility with SDK 2.1.1.46

##2.1.1.22
Added compatibility with SDK 2.1.1.44

##2.1.1.21
Added compatibility with SDK 2.1.1.43

##2.1.1.20
Fixed inability to choose second device when two or more devices are available  VC-43
Fixed cancel on Show Save Dialog prompting for loading VC-44
Fixed showing bad checksum validation when checksum verify is not selected VC-45
Treat hash="" as missing hash VC-46

##2.1.1.19
Fixed incorrct month error reporting  SWCSHAR-385
Filter out long path on message callback device identity  SWCSHAR-387
fixed PIP build tree issue <SWCSHAR-389>
fixed start up conflict reporting fw/sn <SWCSHAR-390>
Updated logic for tab windows to avoid tabs from non-connected devices

##2.1.1.18
Removed FastEMV defaulting to TRUE on device_startTransaction  SWCSHAR-384


##2.1.1.17
Added FeliCa commands  SWCSHAR-365
Fixed double enableMSR commands  SWCSHAR-369
Updated demo for multi-device access
Added success response for setting URL SWCSHAR-272
Removed AugustaKB startMSR/cancelMSR functions <SWCSHAR-373>
Update set whitelist sred device <SWCSHAR-375>
Fixed Set MSR Track cancel dialog issue <SWCSHAR-381>
Added VivoConfig routines
Added Decryption Utility
Added parsomatic link

##2.0.1.16
Kiosk III/IV Aid Text Name re-enabled  CS-3169


##2.0.1.15
Recognize either PEM or DER format for set transarmor ID  SWCSHAR-346
Added createFastEMVData API under EMV menu

##2.0.1.14
Recognize either PEM or DER format for set transarmor ID  SWCSHAR-346

##2.0.1.13
Added TransArmor input box SWCSHAR-346

##2.0.1.12
Updated firmware update tree/function for NEOII  SWCSHAR-344

##2.0.1.11
Update dialog box for FW update to specify bootloader for K81  SWCSHAR-345
Fixed pin amount entry result reporting SWCSHAR-347

##2.0.1.10
Fixed parameter checking  SWCSHAR-332
Fixed Saved AID dialog box showing SWCSHAR-343

##2.0.1.9
Updated LED On/Off parameters  SWCSHAR-342

##2.0.1.8
Restored Save AID input box SWCSHAR-331
Fixed bad input crash in demo SWCSHAR-332
Added Start Screen Saver SWCSHAR-338

##2.0.1.7
Added Clear Logs button
Restore App.config to source code SWCSHAR-328
Remove Clear White List  SWCSHAR-329
Report when output type is unknown SWCSHAR-326

##2.0.1.6
Updated K100 Command Tree

##2.0.1.5
Updated PIP AID Entry box <SWCSHARP-322>
Updated pip default terminal settings <SWCSHAR-321>

##2.0.1.4
Removed RKI URL from PIP <SWCSHARP-317>
Fixed swipe/manual typo <SWCSHAR-315>
Fixed timeout crash on device_pollForToken <SWCSHARP-318>

##2.0.1.3
Removed ASCII reporting of binary data <SWCSHARP-316>
Added device_clearWhiteList <SWCSHAR-316>
Added program verion reporting along with SDK version
