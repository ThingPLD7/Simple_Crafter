Module KeyboardMapperFFXIV
    Dim abilityName() As String
    Dim abilityKeyboardMapping() As String
    Dim KeyboardMappingTextFile As TextFileReader.readRotationFromTextFile = New readRotationFromTextFile()

    Public Sub Run(keyboardMappingFilePath As String)

        KeyboardMappingTextFile.setRotationFileName(keyboardMappingFilePath)
        KeyboardMappingTextFile.readRotationTextFile()
        KeyboardMappingTextFile.printTextFileToConsole()

        ReDim abilityName(KeyboardMappingTextFile.getLineCounter)
        ReDim abilityKeyboardMapping(KeyboardMappingTextFile.getLineCounter)

        KeyboardRotationMap()

    End Sub

    Public Sub KeyboardRotationMap()

        Dim strLine As String
        Dim index As Integer
        Dim strSeperationHolder(2) As String

        index = 0

        While index < KeyboardMappingTextFile.getLineCounter

            strLine = KeyboardMappingTextFile.getLineInput(index)
            strSeperationHolder = Split(strLine, "=")

            setAbilityName(strSeperationHolder(0), index)
            setabilityKeyboardMapping(strSeperationHolder(1), index)

            index = index + 1

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

End Module