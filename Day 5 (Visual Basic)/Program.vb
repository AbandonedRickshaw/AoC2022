Imports System
Imports System.IO

Module Program
    Structure Instruction
        Public src As Integer
        Public crates As Integer
        Public dest As Integer
    End Structure

    Sub Main(args As String())
        Dim data = File.ReadAllText("/Volumes/Blue/Temp/input.txt")
        Dim parts = data.Split(vbLf & vbLf)
        Dim stacks = InitCrates(parts(0))

        For Each line In parts(1).Split(vbLf, StringSplitOptions.RemoveEmptyEntries)
            Dim instruction = ParseInstructions(line)
            Move1(instruction, stacks)
        Next

        Dim solution1 = New System.Text.StringBuilder(stacks.Length)

        For i As Integer = 0 To stacks.Length - 1
            solution1.Append(stacks(i).Pop())
        Next

        stacks = InitCrates(parts(0))

        For Each line In parts(1).Split(vbLf, StringSplitOptions.RemoveEmptyEntries)
            Dim instruction = ParseInstructions(line)
            Move2(instruction, stacks)
        Next

        Dim solution2 = New System.Text.StringBuilder(stacks.Length)

        For i As Integer = 0 To stacks.Length - 1
            solution2.Append(stacks(i).Pop())
        Next

        Console.WriteLine($"Solution 1: {solution1}")
        Console.WriteLine($"Solution 2: {solution2}")
    End Sub

    Private Function InitCrates(ByVal initString As String) As Stack(Of Char)()
        Dim initLines = initString.Split(vbLf).Reverse().Skip(1)
        Dim retval As Stack(Of Char)() = New Stack(Of Char)(initLines.Max(Function(e) e.Length) / 4 + 1 - 1) {}

        For i As Integer = 0 To retval.Length - 1
            retval(i) = New Stack(Of Char)()
        Next

        For Each item In initLines

            For i As Integer = 0 To retval.Length - 1
                Dim crate As String = item.Substring(i * 4, 3).Replace("[", "").Replace("]", "")
                If Not String.IsNullOrWhiteSpace(crate) Then retval(i).Push(crate.Trim().ToCharArray()(0))
            Next
        Next

        Return retval
    End Function

    Private Function ParseInstructions(ByVal line As String) As Instruction
        Dim parts = line.Replace("move", "").Replace("from ", "").Replace("to ", "").Split(" ", StringSplitOptions.RemoveEmptyEntries)
        Return New Instruction() With {
            .crates = Integer.Parse(parts(0)),
            .src = Integer.Parse(parts(1)) - 1,
            .dest = Integer.Parse(parts(2)) - 1
        }
    End Function

    Private Sub Move1(ByVal instruction As Instruction, ByVal stacks As Stack(Of Char)())
        For i As Integer = 0 To instruction.crates - 1
            Dim crate = stacks(instruction.src).Pop()
            stacks(instruction.dest).Push(crate)
        Next
    End Sub

    Private Sub Move2(ByVal instruction As Instruction, ByVal stacks As Stack(Of Char)())
        Dim tmp = New Stack(Of Char)()

        For i As Integer = 0 To instruction.crates - 1
            Dim crate = stacks(instruction.src).Pop()
            tmp.Push(crate)
        Next

        For Each item In tmp
            stacks(instruction.dest).Push(item)
        Next
    End Sub

End Module

