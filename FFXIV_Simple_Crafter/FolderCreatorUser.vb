Imports System.IO

Module FolderCreatorUser

    Dim CurrentFilePathLocation As String
    Dim CraftingListsFilePath As String
    Dim ListOfCrafts As Object
    Dim baseFolderName As String
    Dim ChosenCraftDirectory As String

    Sub New()

        baseFolderName = "\Crafting Lists"

    End Sub

    Public Sub CreateOrAccessFolder()

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
        Dim splitCraft() As String
        i = 0

        While i < ListOfCrafts.Length

            splitCraft = Split(ListOfCrafts(i), baseFolderName + "\")
            Console.WriteLine("Press " + i + " to setup variables to craft " + splitCraft(1))

            i += 1
        End While

    End Sub

    Public Function CraftingChosen(userOption As Integer)

        If userOption > ListOfCrafts.Length Or userOption < 0 Then

            Return False

        Else

            ChosenCraftDirectory = ListOfCrafts(userOption)
            Return True

        End If

    End Function

    Public Function getChosenCraftDirectory()

        Return ChosenCraftDirectory

    End Function


End Module
