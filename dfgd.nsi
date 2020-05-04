


Function nsActivate

	nsDialogs::Create 1018
	Pop cnfActivateWindow

	${If} cnfActivateWindow == error
		Abort
	${EndIf}

	${NSD_CreateCheckbox} 0 0 100% 12u% "Создать файл активации firstrun (не требуется при обновлении)"
	Pop $cnfActivate
	${NSD_OnClick} $cnfActivate cnfActivateClick
 
	${NSD_CreateLabel} 0 16u 140u 12u "@Почта"
	Pop $lbACTIVATION_EMAIL
	${NSD_CreateText} 145u 16u 150u 12u "username@domain.com"
	Pop $edACTIVATION_EMAIL

	${NSD_CreateLabel} 0 30u 140u 12u "Пароль активации"
	Pop $lbACTIVATION_PASSWORD
	${NSD_CreateText} 145u 30u 150u 12u ""
	Pop $edACTIVATION_PASSWORD

	${NSD_CreateLabel} 0 44u 140u 12u "Пароль доступа к asterisk"
	Pop $lbASTERISK_MANAGER_PASSWORD
	${NSD_CreateText} 145u 44u 150u 12u ""
	Pop $ASTERISK_MANAGER_PASSWORD

	${NSD_CreateLabel} 0 58u 140u 12u "База MYSQL"
	Pop $lbMYSQL_DATABASE
	${NSD_CreateText} 145u 58u 150u 12u "asteriskcdrdb"
	Pop $edMYSQL_DATABASE

	${NSD_CreateLabel} 0 72u 140u 12u "IP адрес сервера БД"
	Pop $lbMYSQL_DataSource
	${NSD_CreateText} 145u 72u 150u 12u "192.168.0.2"
	Pop $edMYSQL_DataSource

	${NSD_CreateLabel} 0 86u 140u 12u "MySQL логин"
	Pop $lbMYSQL_UserId
	${NSD_CreateText} 145u 86u 150u 12u "1"
	Pop $edMYSQL_UserId

	${NSD_CreateLabel} 0 100u 140u 12u "MySQL пароль"
	Pop $lbMYSQL_Password
	${NSD_CreateText} 145u 100u 150u 12u "15000"
	Pop $edMYSQL_Password



	${If} ${FileExists} "$APPDATA\AsteriskNotifier\protected.db"

	EnableWindow $lbACTIVATION_EMAIL 0
	EnableWindow $edACTIVATION_EMAIL 0
	            
	EnableWindow $lbACTIVATION_PASSWORD 0
	EnableWindow $edACTIVATION_PASSWORD 0
	            
	EnableWindow $lbASTERISK_MANAGER_PASSWORD 0
	EnableWindow $edASTERISK_MANAGER_PASSWORD 0
	            
	EnableWindow $lbMYSQL_DATABASE 0
	EnableWindow $edMYSQL_DATABASE 0
	            
	EnableWindow $lbMYSQL_DataSource 0
	EnableWindow $edMYSQL_DataSource 0
	            
	EnableWindow $lbMYSQL_UserId 0
	EnableWindow $edMYSQL_UserId 0
	            
	EnableWindow $lbMYSQL_Password 0
	EnableWindow $edMYSQL_Password 0

 	${NSD_SetState} $cnfActivate 0
${Else}
        
	EnableWindow $lbACTIVATION_EMAIL 1
	EnableWindow $edACTIVATION_EMAIL 1
	            
	EnableWindow $lbACTIVATION_PASSWORD 1
	EnableWindow $edACTIVATION_PASSWORD 1
	            
	EnableWindow $lbASTERISK_MANAGER_PASSWORD 1
	EnableWindow $edASTERISK_MANAGER_PASSWORD 1
	            
	EnableWindow $lbMYSQL_DATABASE 1
	EnableWindow $edMYSQL_DATABASE 1
	            
	EnableWindow $lbMYSQL_DataSource 1
	EnableWindow $edMYSQL_DataSource 1
	            
	EnableWindow $lbMYSQL_UserId 1
	EnableWindow $edMYSQL_UserId 1
	            
	EnableWindow $lbMYSQL_Password 1
	EnableWindow $edMYSQL_Password 1

 	${NSD_SetState} $cnfActivate 1

${EndIf}

	nsDialogs::Show

FunctionEnd

Function nsActivateLeave
	$edACTIVATION_EMAIL 
	$edACTIVATION_PASSWORD 
	$edASTERISK_MANAGER_PASSWORD 
	$edMYSQL_DATABASE 
	$edMYSQL_DataSource 
	$edMYSQL_UserId 
	$edMYSQL_Password 


        ${NSD_GetState} $cnfCheckBox $cnfCheckBox_State

        ${NSD_GetText} $edACTIVATION_EMAIL          $edACTIVATION_EMAIL_text         
        ${NSD_GetText} $edACTIVATION_PASSWORD       $edACTIVATION_PASSWORD_text      
        ${NSD_GetText} $edASTERISK_MANAGER_PASSWORD $edASTERISK_MANAGER_PASSWORD_text
        ${NSD_GetText} $edMYSQL_DATABASE            $edMYSQL_DATABASE_text           
        ${NSD_GetText} $edMYSQL_DataSource          $edMYSQL_DataSource_text         
        ${NSD_GetText} $edMYSQL_UserId              $edMYSQL_UserId_text
        ${NSD_GetText} $edMYSQL_Password            $edMYSQL_Password_text

;        MessageBox MB_OK $cnfCheckBox_State
 	${If} $cnfCheckBox_State == ${BST_CHECKED}
		FileOpen $1 $APPDATA\AsteriskNotifier\firstrun w
		FileWrite $1 'ACTIVATION_EMAIL=$edACTIVATION_EMAIL_text$\r$\n'
		FileWrite $1 'ACTIVATION_PASSWORD=$edACTIVATION_PASSWORD_text$\r$\n'
		FileWrite $1 'ASTERISK_MANAGER_PASSWORD=$edASTERISK_MANAGER_PASSWORD_text$\r$\n'
		FileWrite $1 'MYSQL_CONNECTION_STRING=Database=$edMYSQL_DATABASE_text;Data Source=$edMYSQL_DataSource_text;User Id=$edMYSQL_UserId_text;Password=$edMYSQL_Password_text$\r$\n'
		FileClose $1
	${EndIf}

FunctionEnd


Function EnDisableButton
	Pop $cnfActivate

	${NSD_GetState} $cnfActivate $0

	${If} $0 == 1
        
	EnableWindow $lbACTIVATION_EMAIL 1
	EnableWindow $edACTIVATION_EMAIL 1
	            
	EnableWindow $lbACTIVATION_PASSWORD 1
	EnableWindow $edACTIVATION_PASSWORD 1
	            
	EnableWindow $lbASTERISK_MANAGER_PASSWORD 1
	EnableWindow $edASTERISK_MANAGER_PASSWORD 1
	            
	EnableWindow $lbMYSQL_DATABASE 1
	EnableWindow $edMYSQL_DATABASE 1
	            
	EnableWindow $lbMYSQL_DataSource 1
	EnableWindow $edMYSQL_DataSource 1
	            
	EnableWindow $lbMYSQL_UserId 1
	EnableWindow $edMYSQL_UserId 1
	            
	EnableWindow $lbMYSQL_Password 1
	EnableWindow $edMYSQL_Password 1

	${Else}
	EnableWindow $lbACTIVATION_EMAIL 0
	EnableWindow $edACTIVATION_EMAIL 0
	            
	EnableWindow $lbACTIVATION_PASSWORD 0
	EnableWindow $edACTIVATION_PASSWORD 0
	            
	EnableWindow $lbASTERISK_MANAGER_PASSWORD 0
	EnableWindow $edASTERISK_MANAGER_PASSWORD 0
	            
	EnableWindow $lbMYSQL_DATABASE 0
	EnableWindow $edMYSQL_DATABASE 0
	            
	EnableWindow $lbMYSQL_DataSource 0
	EnableWindow $edMYSQL_DataSource 0
	            
	EnableWindow $lbMYSQL_UserId 0
	EnableWindow $edMYSQL_UserId 0
	            
	EnableWindow $lbMYSQL_Password 0
	EnableWindow $edMYSQL_Password 0
	${EndIf}

	${NSD_GetState} $cnfActivate $cnfActivate_State
        MessageBox MB_OK $cnfActivate_State
FunctionEnd
