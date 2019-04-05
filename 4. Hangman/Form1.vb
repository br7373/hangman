Public Class Form1
    Dim word As String 'input
    Dim body As New Collection
    Dim wcount As Byte '= 1
    Dim ecount As Byte
    Dim warray(9) As Char
    Dim labels As New Collection
    Dim found As Boolean 'checks if the letter selected from the listbox is found or not
    Dim letter As String 'for putting selected numbers in invisible list box   
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'right and left leg
        lineRL.Visible = False
        lineLL.Visible = False
        'left and right arm
        lineRA.Visible = False
        lineLA.Visible = False
        'head and body
        lineH.Visible = False
        lineB.Visible = False

        'making all of the labels invisible
        lbl1.Visible = False
        lbl2.Visible = False
        lbl3.Visible = False
        lbl4.Visible = False
        lbl5.Visible = False
        lbl6.Visible = False
        lbl7.Visible = False
        lbl8.Visible = False
        lbl9.Visible = False
        lbl10.Visible = False

        'adding the labels into a collection
        labels.Add(lbl1)
        labels.Add(lbl2)
        labels.Add(lbl3)
        labels.Add(lbl4)
        labels.Add(lbl5)
        labels.Add(lbl6)
        labels.Add(lbl7)
        labels.Add(lbl8)
        labels.Add(lbl9)
        labels.Add(lbl10)

        'adding the body parts into the collection
        body.Add(lineH)
        body.Add(lineB)
        body.Add(lineRA)
        body.Add(lineLA)
        body.Add(lineRL)
        body.Add(lineLL)

        Do
            word = InputBox("Enter a word that is 10 letters or less.")
        Loop While (IsNumeric(word) = True Or word = "")

        For i As Byte = 1 To word.Count
            labels(i).show()
        Next

        For i As Byte = 0 To word.Length - 1
            warray(i) = UCase(word.Substring(i, 1))
        Next

    End Sub
    Private Sub lstWords_Click(sender As Object, e As EventArgs) Handles lstWords.Click
        Dim found As Boolean

        letter = lstWords.SelectedItem
        lstClicked.Items.Add(letter)
        lstWords.Items.Remove(letter)

        For i As Byte = 0 To word.Length - 1
            If letter = warray(i) Then
                found = True
            ElseIf letter <> warray(i) Then
                found = False
            End If
            If found = True Then
                labels(i + 1).text = warray(i)
            End If
        Next

        If found = False Then
            wcount += 1
            body(wcount).visible = True
            If wcount > 7 Then
                MsgBox("You lose")
            End If
        End If

        If found = True Then
            wcount -= 1

        End If

        '   body(wcount).visible = True

        '  For i As Byte = 0 To 6

        '  Next


        lblTest2.Text = wcount

        'If found = True Then
        '    lblTest.Text = "found"
        '    MsgBox("You Guessed the Word Correctly!")
        '    wcount = 0
        'End If

        'If wcount = 1 Then
        '    lineH.Visible = True
        '    Exit Sub
        'ElseIf wcount = 2 Then
        '    lineB.Visible = True
        '    Exit Sub
        'ElseIf wcount = 3 Then
        '    lineLA.Visible = True
        '    Exit Sub
        'ElseIf wcount = 4 Then
        '    lineRA.Visible = True
        '    Exit Sub
        'ElseIf wcount = 5 Then
        '    lineLL.Visible = True
        '    Exit Sub
        'ElseIf wcount = 6 Then
        '    lineRL.Visible = True
        '    Exit Sub
        'ElseIf wcount > 6 Then
        '    MsgBox("You Lost!")
        '    Exit Sub
        'End If


    End Sub

    Private Sub reset()
        wcount = 0
        For i As Byte = 0 To 5
            body(i).visible = False
        Next

    End Sub
End Class