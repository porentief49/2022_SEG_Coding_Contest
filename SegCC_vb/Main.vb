Module Main

    Sub Main()
        Dim lDay1 As New Day_1 With {.InputFile = "abc"}
        Console.WriteLine(lDay1.Result(True))
    End Sub

End Module
