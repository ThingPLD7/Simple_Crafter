Module KeyboardMapperFFXIV

    Class KeyboardMapper

        Dim abilityName() As String
        Dim abilityKeyboardMapping() As String
        Dim KeyboardMappingTextFile As TextFileReader.readRotationFromTextFile = New readRotationFromTextFile()
        Dim indexAbility As Integer

        Public Sub Initialize()

            ' Initialize the KeyboardMapperFFXIV

        End Sub

        Public Sub Run(keyboardMappingFilePath As String)

            KeyboardMappingTextFile.setRotationFileName(keyboardMappingFilePath)
            KeyboardMappingTextFile.readRotationTextFile()
            'KeyboardMappingTextFile.printTextFileToConsole()

            ReDim abilityName(KeyboardMappingTextFile.getLineCounter)
            ReDim abilityKeyboardMapping(KeyboardMappingTextFile.getLineCounter)

            KeyboardRotationMap()

        End Sub

        Public Sub KeyboardRotationMap()

            Dim strLine As String

            Dim strSeperationHolder(2) As String

            indexAbility = 0

            While indexAbility < KeyboardMappingTextFile.getLineCounter

                strLine = KeyboardMappingTextFile.getLineInput(indexAbility)
                strSeperationHolder = Split(strLine, ": ")

                setAbilityName(strSeperationHolder(0), indexAbility)
                setabilityKeyboardMapping(strSeperationHolder(1), indexAbility)

                indexAbility = indexAbility + 1

            End While

        End Sub

        Private Sub setAbilityName(buttonName As String, index As Integer)

            abilityName(index) = buttonName

        End Sub

        Public Function getAbilityName(index As Integer) As String

            Return abilityName(index)

        End Function

        Private Sub setabilityKeyboardMapping(buttonMapping As String, index As Integer)

            abilityKeyboardMapping(index) = buttonMapping

        End Sub

        Public Function getabilityKeyboardMapping(index As Integer) As String

            Return abilityKeyboardMapping(index)

        End Function

        Public Function getIndexAbility() As Integer

            Return indexAbility

        End Function

    End Class

End Module