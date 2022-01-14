Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO
Imports SegCC_Template

Public Class Puzzle_00
    Inherits SegCC_Template.Puzzle_base

    ' Assume the following puzzle
    '
    ' Part 1:
    ' Your sensors constantly measure the gamma ray intensity. To estimate the damage to your protection shields, you need to add all the
    ' measurements taken. The total sum Is your puzzle result for part 1.
    '
    ' Part 2:
    ' Your shields are actually exponentially impacted by the gamma ray intensity. To get the real damage, you need to multiply the
    ' measurements with themselves before adding up. The total sum of the sqared numbers Is your puzzle result for part 2.

    Public Overrides Sub Process(aPart As ePart)
        Dim lLines As String() = File.ReadAllLines(InputFile)
        If aPart = ePart.One Then
            Result = lLines.ToList().[Select](Function(x) Integer.Parse(x)).Sum().ToString()
        Else
            Result = lLines.ToList().[Select](Function(x) Math.Pow(Integer.Parse(x), 2)).Sum().ToString()
        End If
    End Sub
End Class
