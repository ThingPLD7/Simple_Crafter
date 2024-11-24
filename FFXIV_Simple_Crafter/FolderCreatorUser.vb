Imports System.IO

Module FolderCreatorUser

    Dim CurrentFilePathLocation As String
    Dim CraftingListsFilePath As String
    Dim ListOfCrafts As Object
    Dim baseFolderName As String
    Dim ChosenCraftDirectory As String
    Dim numOfCrafts As Integer
    Dim nameOfCraftPicked As String

    Public Sub CreateOrAccessFolder()

        baseFolderName = "\Crafting Lists"

        ' Set up file path location or confirm it already exists
        CurrentFilePathLocation = My.Computer.FileSystem.CurrentDirectory
        setCraftingListsDirectory(CurrentFilePathLocation + baseFolderName)

        If My.Computer.FileSystem.DirectoryExists(getCraftingListsDirectory) = False Then

            My.Computer.FileSystem.CreateDirectory(getCraftingListsDirectory)

            Console.WriteLine("Directory has been made.")

        Else

            Console.WriteLine("Directory already exists.")

        End If

        ' Now get a list of documents out of the folder
        ListOfCrafts = My.Computer.FileSystem.GetFiles(getCraftingListsDirectory)

    End Sub

    Public Function getCraftingListsDirectory()

        Return CraftingListsFilePath

    End Function

    Private Sub setCraftingListsDirectory(filePathofCraftingList As String)

        CraftingListsFilePath = filePathofCraftingList

    End Sub

    Public Function getListOfCrafts(index As Integer)

        Return ListOfCrafts(index)

    End Function

    Public Sub printListOfCrafts()

        Dim i As Integer
        Dim isComplete As Boolean
        isComplete = False
        Dim splitCraft1(), splitCraft2() As String
        i = 0

        While isComplete = False

            Try

                splitCraft1 = Split(ListOfCrafts(i), baseFolderName + "\")
                splitCraft2 = Split(splitCraft1(1), ".txt")
                nameOfCraftPicked = splitCraft2(0)
                Console.WriteLine("Press " + CStr(i) + " to setup variables to craft " + splitCraft2(0))

            Catch ex As Exception

                numOfCrafts = i - 1
                isComplete = True

            End Try

            i += 1
        End While

    End Sub

    Public Function CraftChosen(userOption As String)

        Dim userOptionToInteger As Integer

        Try

            userOptionToInteger = CInt(userOption)

        Catch ex As Exception

            Return False

        End Try


        If CInt(userOption) > numOfCrafts Or CInt(userOption) < 0 Then

            Return False

        Else

            ChosenCraftDirectory = ListOfCrafts(CInt(userOption))
            Return True

        End If

    End Function

    Public Function getChosenCraftDirectory()

        Return ChosenCraftDirectory

    End Function

    Public Function getNumOfCrafts()

        Return numOfCrafts

    End Function

    Public Function getNameOfCraftPicked()

        Return nameOfCraftPicked

    End Function

End Module
