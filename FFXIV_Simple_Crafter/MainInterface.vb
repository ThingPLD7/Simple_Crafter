Imports System.IO
Imports System.Net.Mail
Imports System.Threading
Imports Microsoft.VisualBasic.Devices

Module MainInterface

    Dim FFXIV_ID As String
    Dim amountToCraft, userOption As Object
    Dim startTime As Object
    Dim totalTimeForCraft As Object

    Sub Main()

        Dim itemsMade As Integer
        itemsMade = 0

        ' Shift is "+{}"
        ' CTRL is "^{}"
        ' ALT is "%{}"

        FFXIV_ID = "FINAL FANTASY XIV"

        AppActivate(FFXIV_ID)

        Console.WriteLine("The document ID is: " + FFXIV_ID)
        Console.WriteLine("-------------------------------------------------------------")

        Console.WriteLine("Tracking food timer: ")
        userOption = Console.ReadLine(userOption)

        Console.WriteLine("Tracking food timer: ")
        Console.WriteLine("Tracking pot timer: ")
        Console.WriteLine("-------------------------------------------------------------")
        Console.WriteLine("Will print notepad.txts below")
        Console.WriteLine("-------------------------------------------------------------")
        Console.WriteLine("1. Use Food")
        Console.WriteLine("2. Use Pots")
        Console.WriteLine("3. Choose the Textfile Above")
        Console.WriteLine("Enter an option from above:")


        KeyboardMapperFFXIV.Run("D:\\Dummy FXIV Crafter\\Keyboard-Mapping.txt")

        Console.WriteLine("The ability name is: " + KeyboardMapperFFXIV.getAbilityName(2) + ". The mapping is: " + KeyboardMapperFFXIV.getabilityKeyboardMapping(2))

        Dim CraftingRotation As TextFileReader.readRotationFromTextFile = New readRotationFromTextFile()
        CraftingRotation.setRotationFileName("D:\\Dummy FXIV Crafter\\Mastercraft_Level_70.txt")
        CraftingRotation.readRotationTextFile()
        CraftingRotation.printTextFileToConsole()

        Dim abilityRotationKeys(CraftingRotation.getLineCounter) As String
        Dim searchingIndex, index As Integer
        Dim abilityClean1(2), abilityClean2(2) As String
        index = 0

        While index < CraftingRotation.getLineCounter
            searchingIndex = 0

            abilityClean1 = Split(CraftingRotation.getLineInput(index), " <")
            abilityClean2 = Split(abilityClean1(0), "/ac ")

            While searchingIndex < KeyboardMapperFFXIV.indexAbility

                If abilityClean2(1) = KeyboardMapperFFXIV.getAbilityName(searchingIndex) Then

                    abilityRotationKeys(index) = KeyboardMapperFFXIV.getabilityKeyboardMapping(searchingIndex)
                    Console.WriteLine(abilityRotationKeys(index))

                    searchingIndex = KeyboardMapperFFXIV.indexAbility

                End If

                searchingIndex = searchingIndex + 1

            End While

            index = index + 1

        End While



        If userOption > 0 Then

            'create push back

        End If

        Console.WriteLine(Microsoft.VisualBasic.Timer)

        amountToCraft = 55

        My.Computer.Keyboard.SendKeys("{,}", True)

        While itemsMade < amountToCraft

            My.Computer.Keyboard.SendKeys("{f}", True)
            waitTimeCooldown(4)
            My.Computer.Keyboard.SendKeys("+{5}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("+{-}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("+{8}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("{9}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("{5}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("{5}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("{5}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("+{2}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("{5}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("%{9}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("%{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("%{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("%{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("+{=}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("%{9}", True)
            waitTimeCooldown(2.1)
            My.Computer.Keyboard.SendKeys("%{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("%{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("+{6}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("+{3}", True)
            waitTimeCooldown(2.5)
            My.Computer.Keyboard.SendKeys("{2}", True)

            waitTimeCooldown(5.0)
            My.Computer.Keyboard.SendKeys("{f}", True)
            itemsMade = itemsMade + 1
        End While

    End Sub

    Private Sub waitTimeCooldown(timeInSeconds As Double)

        startTime = Microsoft.VisualBasic.Timer

        While Microsoft.VisualBasic.Timer < startTime + timeInSeconds

            'wait for time

        End While

    End Sub

End Module
