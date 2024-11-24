Imports System.IO
Imports System.Net.Mail
Imports System.Reflection
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Module MainInterface

    Dim FFXIV_ID As String
    Dim amountToCraft, userOption As Object
    Dim startTime As Object
    Dim totalTimeForCraft As Object
    Dim CraftingRotation As TextFileReader.readRotationFromTextFile = New readRotationFromTextFile()
    Dim MappedKeys As KeyboardMapperFFXIV.KeyboardMapper = New KeyboardMapper()

    Dim abilityRotationKeys() As String
    Dim abilityCooldownValues() As Double

    Dim isRunning As Boolean

    Sub Main()

        ' Shift is "+{}"
        ' CTRL is "^{}"
        ' ALT is "%{}"

        Dim exitOrContinue As String

        FolderCreatorUser.CreateOrAccessFolder()

        FFXIV_ID = "FINAL FANTASY XIV"
        AppActivate(FFXIV_ID)

        MappedKeys.Run("D:\\Dummy FXIV Crafter\\Keyboard-Mapping.txt")

        isRunning = True
        While isRunning

            ConsoleMenuNavigation.PrintMenu(0)

            CraftingRotation.setRotationFileName(FolderCreatorUser.getChosenCraftDirectory)
            CraftingRotation.readRotationTextFile()

            amountToCraft = ConsoleMenuNavigation.getAmountToMake()

            RotationBuilder()
            Craft(amountToCraft)

            Console.Write("Enter 'exit' to quit or press anything to continue with another craft: ")
            exitOrContinue = Console.ReadLine()

            If exitOrContinue = "exit" Or exitOrContinue = "Exit" Then

                isRunning = False

            End If

        End While

    End Sub

    Private Sub waitTimeCooldown(timeInSeconds As Double)

        startTime = Microsoft.VisualBasic.Timer

        While Microsoft.VisualBasic.Timer < startTime + timeInSeconds

            'wait for time

        End While

    End Sub

    Private Sub RotationBuilder()

        ReDim abilityRotationKeys(CraftingRotation.getLineCounter)
        ReDim abilityCooldownValues(CraftingRotation.getLineCounter)
        Dim searchingIndex, index As Integer
        Dim abilityClean1(2), abilityClean2(2) As String
        index = 0

        While index < CraftingRotation.getLineCounter

            searchingIndex = 0

            abilityClean1 = Split(CraftingRotation.getLineInput(index), " <")
            abilityClean2 = Split(abilityClean1(0), "/ac ")

            If InStr(abilityClean1(1), "2") Then

                abilityCooldownValues(index) = 2.1

            Else

                abilityCooldownValues(index) = 2.5

            End If

            While searchingIndex < MappedKeys.getIndexAbility

                If abilityClean2(1) = MappedKeys.getAbilityName(searchingIndex) Then

                    abilityRotationKeys(index) = MappedKeys.getabilityKeyboardMapping(searchingIndex)

                    searchingIndex = MappedKeys.getIndexAbility

                End If

                searchingIndex = searchingIndex + 1

            End While

            index = index + 1

        End While

    End Sub

    Private Sub Craft(amountToCraft As Integer)

        Dim itemsMade, craftingStep As Integer
        itemsMade = 0

        AppActivate(FFXIV_ID)
        My.Computer.Keyboard.SendKeys("{,}", True)

        While itemsMade < amountToCraft

            waitTimeCooldown(0.5)
            AppActivate(FFXIV_ID)
            My.Computer.Keyboard.SendKeys("{f}", True)
            waitTimeCooldown(2.2)

            craftingStep = 0

            While craftingStep < CraftingRotation.getLineCounter

                CraftingIsHappening(FolderCreatorUser.getNameOfCraftPicked, craftingStep, CraftingRotation.getLineCounter, itemsMade, amountToCraft)

                AppActivate(FFXIV_ID)
                My.Computer.Keyboard.SendKeys(abilityRotationKeys(craftingStep), abilityCooldownValues(craftingStep))
                waitTimeCooldown(2.5)
                'Console.WriteLine(abilityRotationKeys(craftingStep) + " " + Str(abilityCooldownValues(craftingStep)))
                craftingStep = craftingStep + 1

            End While

            waitTimeCooldown(3.4)
            AppActivate(FFXIV_ID)
            My.Computer.Keyboard.SendKeys("{f}", True)

            itemsMade = itemsMade + 1
        End While

    End Sub

End Module
