Public Class Form1
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Process Inputs
        Dim inputString As String = txtInput.Text
        inputString.Replace(" ", "")
        Dim InputSplit() As String = inputString.Split("=")

        If InputSplit.Length = 1 Then
            MessageBox.Show("Invalid input: does not contain (=)")
            Return
        End If

        Dim operationSymbol As Char
        Dim Subsplit() As String
        If InputSplit(0).Contains("+") Then
            operationSymbol = "+"
            Subsplit = InputSplit(0).Split(operationSymbol)
        ElseIf InputSplit(0).Contains("-") Then
            operationSymbol = "-"
            Subsplit = InputSplit(0).Split(operationSymbol)
        Else
            MessageBox.Show("Invalid Input: does not contain valid opeator (+/-)")
            Return
        End If

        'prepare parameters
        Dim charString As String = Subsplit(0)
        Dim varString As String = Subsplit(1)
        Dim resultList As New List(Of String)

        'Calculate results(Brute force)
        For i As Integer = 0 To 9
            For j As Integer = 0 To 9
                Dim DigitsAB As Integer = CInt(i.ToString & j.ToString)
                Dim DigitsBA As Integer = CInt(j.ToString & i.ToString)
                If operationSymbol.Equals("+"c) Then
                    If DigitsAB + varString = DigitsBA Then
                        resultList.Add(DigitsAB.ToString("00.##"))
                    End If
                Else operationSymbol.Equals("-"c)
                    If DigitsAB - varString = DigitsBA Then
                        resultList.Add(DigitsAB.ToString("00.##"))
                    End If
                End If
            Next j
        Next i


        'Calculate results explicit equation
        'If varString Mod 9 <> 0 Then
        '    lbOutput.Items.Clear()
        '    lbOutput.Items.Add("Příklad nemá řešení")
        '    Return
        'End If
        'For i As Integer = varString / 9 To 9
        '    If operationSymbol.Equals("+"c) Then
        '        Dim Digits As String = (i - varString / 9).ToString & (i).ToString
        '        resultList.Add(Digits)
        '    Else
        '        Dim Digits As String = (i).ToString & (i - varString / 9).ToString
        '        resultList.Add(Digits)
        '    End If
        'Next i




        'Ouput results
        lbOutput.Items.Clear()
        If resultList.Count = 0 Then
            lbOutput.Items.Add("Příklad nemá řešení")
        Else
            For Each res As String In resultList
                lbOutput.Items.Add(charString.Substring(0, 1) & " = " & res.Substring(0, 1) & ", " & charString.Substring(1, 1) & " = " & res.Substring(1, 1))
            Next res
        End If
        txtInput.Focus()

    End Sub
End Class
