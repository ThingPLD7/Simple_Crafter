Imports System.IO

Module TextFileReader
    Class readRotationFromTextFile

        Dim lineInput(100) As String
        Dim rotationFileName As String
        Dim fileNameTrue As Boolean
        Dim lineCounter, lineInputSize As Integer

        Public Sub New()

            Console.WriteLine("readRotationFromTextFile has initalized")

            'Initialize the input line counter
            lineCounter = 0

            'Set to ensure that the user as picked a text file to read from
            fileNameTrue = False

            'Set the value of the lineInputSize to allow increases - completely overkill
            lineInputSize = 100

        End Sub

        Public Sub setRotationFileName(userFileName As String)

            rotationFileName = userFileName
            fileNameTrue = True

        End Sub

        Public Function getRotationFileName() As String

            Return rotationFileName

        End Function

        Public Function getLineCounter() As String

            Return lineCounter

        End Function

        Public Function getLineInput(indexValue As Integer) As String

            If indexValue >= 0 & indexValue <= lineCounter Then

                Return lineInput(indexValue)

            Else

                Console.WriteLine("The indexValue is invalid.")

            End If

        End Function

        Private Sub setLineInput(theLineInput As String)

            lineInput(lineCounter) = theLineInput
            lineCounter = lineCounter + 1

            If lineCounter > lineInputSize Then

                lineInputSize = lineInputSize + 100

                ReDim Preserve lineInput(lineInputSize)

            End If

        End Sub

        Public Sub readRotationTextFile()

            Dim theReadLine As String

            If fileNameTrue = False Then

                Console.WriteLine("Select a valid filepath for the rotation. No rotation was loaded.")

            Else

                Using reader As StreamReader = New StreamReader(getRotationFileName)

                    theReadLine = reader.ReadLine

                    While theReadLine <> Nothing

                        setLineInput(theReadLine)
                        theReadLine = reader.ReadLine

                    End While

                End Using

            End If

        End Sub

        Public Sub printTextFileToConsole()

            Dim index_i As Integer
            index_i = 0

            While index_i < lineCounter

                Console.WriteLine(getLineInput(index_i))

                index_i = index_i + 1

            End While

        End Sub

    End Class

End Module
