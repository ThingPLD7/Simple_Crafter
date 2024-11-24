Module ConsoleMenuNavigation

    Dim FoodTimer As Double
    Dim PotTimer As Double
    Dim isFoodTimer As Boolean
    Dim isPotTimer As Boolean
    Dim menuState As Integer
    Dim craftToMake As Integer
    Dim amountToMake As Integer

    Sub New()
        isFoodTimer = False
        isPotTimer = False
    End Sub

    Public Sub PrintMenu(state As Integer)

        Dim userSelect As String
        Dim runMenu As Boolean
        runMenu = True
        menuState = state

        Dim isCase0Complete As Boolean
        Dim isCase1Complete As Boolean
        Dim isCase2Complete As Boolean
        Dim isCase3Complete As Boolean

        While runMenu = True
            ' The menu system
            Select Case menuState
            ' The start menu
                Case 0
                    isCase0Complete = False

                    While isCase0Complete = False

                        Console.Clear()
                        Console.WriteLine("-------------------------------------------------------------")
                        Console.WriteLine("1. Craft an item")
                        Console.WriteLine("2. Use food: " + CStr(isFoodTimer))
                        Console.WriteLine("3. Use pots: " + CStr(isPotTimer))
                        Console.WriteLine("-------------------------------------------------------------")
                        Console.Write("Please select something you would like to do: ")
                        userSelect = Console.ReadLine()
                        Try
                            If CInt(userSelect) >= 0 And CInt(userSelect) <= 3 Then

                                menuState = CInt(userSelect)
                                isCase0Complete = True

                            Else

                                Console.WriteLine("Not a valid option. Enter anything to continue.")
                                Console.ReadLine()

                            End If

                        Catch ex As Exception

                            Console.WriteLine("Not a valid option. Enter anything to continue.")
                            Console.ReadLine()

                        End Try
                    End While

                ' Select a craft menu
                Case 1
                    isCase1Complete = False

                    While isCase1Complete = False
                        Console.Clear()
                        Console.WriteLine("Select a craft or enter 'back' to go back: ")
                        Console.WriteLine("-------------------------------------------------------------")
                        FolderCreatorUser.printListOfCrafts()
                        Console.Write("Enter an option from above:")
                        userSelect = Console.ReadLine()
                        Try
                            If userSelect = "Back" Or userSelect = "back" Then

                                menuState = 0
                                isCase1Complete = True

                            ElseIf CInt(userSelect) >= 0 And CInt(userSelect) < FolderCreatorUser.getNumOfCrafts Then

                                craftToMake = CInt(userSelect)
                                runMenu = False
                                isCase1Complete = True
                                FolderCreatorUser.CraftChosen(userSelect)
                                AmountofCraftsToMake()

                            Else

                                Console.Write("Not a valid option. Enter any value to continue.")
                                Console.ReadLine()

                            End If

                        Catch ex As Exception

                            Console.Write("Not a valid option. Enter any value to continue.")
                            Console.ReadLine()

                        End Try

                    End While

            ' Turn food on
                Case 2
                    isCase2Complete = False

                    While isCase2Complete = False
                        Console.Clear()
                        Console.WriteLine("Using food is: " + CStr(isFoodTimer))
                        Console.WriteLine("1. Turn on food usage" + CStr(isFoodTimer))
                        Console.WriteLine("2. Turn off food usage")
                        Console.Write("Select 1 or 2: ")
                        userSelect = Console.ReadLine()

                        Try
                            If CInt(userSelect) = 1 Then

                                menuState = 0
                                isFoodTimer = True
                                isCase2Complete = True

                            ElseIf CInt(userSelect) = 2 Then

                                menuState = 0
                                isFoodTimer = False
                                isCase2Complete = True

                            Else

                                Console.WriteLine("Select 1 or 2. Enter anything to continue.")
                                Console.ReadLine()

                            End If

                        Catch ex As Exception

                            Console.WriteLine("Select 1 or 2. Enter anything to continue.")
                            Console.ReadLine()

                        End Try

                    End While

            ' Turn pots on
                Case 3
                    isCase3Complete = False

                    While isCase3Complete = False
                        Console.Clear()
                        Console.WriteLine("Using pots is: " + CStr(isFoodTimer))
                        Console.WriteLine("1. Turn on pots usage" + CStr(isFoodTimer))
                        Console.WriteLine("2. Turn off pots usage")
                        Console.Write("Select 1 or 2: ")
                        userSelect = Console.ReadLine()

                        Try
                            If CInt(userSelect) = 1 Then

                                menuState = 0
                                isPotTimer = True
                                isCase3Complete = True

                            ElseIf CInt(userSelect) = 2 Then

                                menuState = 0
                                isPotTimer = False
                                isCase3Complete = True

                            Else

                                Console.WriteLine("Select 1 or 2. Enter anything to continue.")
                                Console.ReadLine()

                            End If

                        Catch ex As Exception

                            Console.WriteLine("Select 1 or 2. Enter anything to continue.")
                            Console.ReadLine()

                        End Try

                    End While

            End Select

        End While
    End Sub

    Public Sub CraftingIsHappening(craftBeingMade As String, stepOn As Object, stepTotal As Object, onCraft As Object, craftToGo As Object)

        Console.Clear()
        Console.WriteLine("The item being crafted is: " + craftBeingMade)
        Console.WriteLine("-------------------------------------------------------------")
        Console.WriteLine("Items left to make: " + CStr(onCraft) + "/" + CStr(craftToGo))
        Console.WriteLine("Step " + CStr(stepOn) + "/" + CStr(stepTotal))

    End Sub

    Private Sub AmountofCraftsToMake()

        Dim isCraftsToMake As Boolean
        isCraftsToMake = False

        While isCraftsToMake = False

            Try
                Console.Clear()
                Console.Write("Enter an amount of crafts to make: ")
                amountToMake = CInt(Console.ReadLine())
                isCraftsToMake = True

            Catch ex As Exception

                Console.Write("Please enter a valid number, press enter to continue.")
                Console.ReadLine()

            End Try

        End While

    End Sub


    Public Sub setAmountToMake(tempAmount As Object)

        amountToMake = tempAmount

    End Sub

    Public Function getAmountToMake()

        Return amountToMake

    End Function

    Public Function getFoodTimer()

        Return FoodTimer

    End Function

    Public Sub setFoodtimer(tempTime As Object)

        FoodTimer = tempTime

    End Sub

    Public Function getPotTimer()

        Return PotTimer

    End Function

    Public Sub setPotTimer(tempTime As Object)

        PotTimer = tempTime

    End Sub

    Public Function getCraftToMake()

        Return craftToMake

    End Function

End Module
