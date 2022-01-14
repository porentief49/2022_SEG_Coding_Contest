Friend Module Program

    Const INPUT_FOLDER_RELATIVE_TO_ASSEMBLY As String = "..\..\..\input\"

    Sub Main()
        Const INPUT_FILE As String = "input_00.txt"
        Dim mPuzzle = New Puzzle_00() With {.InputFile = INPUT_FOLDER_RELATIVE_TO_ASSEMBLY & INPUT_FILE}
        Console.WriteLine($"Final Result for part 1: {mPuzzle.Result(True)}")
        Console.WriteLine($"Final Result for part 2: {mPuzzle.Result(False)}")
    End Sub
End Module
