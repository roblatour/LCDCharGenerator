
' Copyright(c) 2020 Rob Latour
' www.rlatour.com

'MIT License

'Permission Is hereby granted, free Of charge, to any person obtaining a copy
'of this software And associated documentation files (the "Software"), to deal
'in the Software without restriction, including without limitation the rights
'to use, copy, modify, merge, publish, distribute, sublicense, And/Or sell
'copies of the Software, And to permit persons to whom the Software Is
'furnished to do so, subject to the following conditions:

'The above copyright notice And this permission notice shall be included In all
'copies Or substantial portions of the Software.

'THE SOFTWARE Is PROVIDED "AS IS", WITHOUT WARRANTY Of ANY KIND, EXPRESS Or
'IMPLIED, INCLUDING BUT Not LIMITED To THE WARRANTIES Of MERCHANTABILITY,
'FITNESS FOR A PARTICULAR PURPOSE And NONINFRINGEMENT. IN NO EVENT SHALL THE
'AUTHORS Or COPYRIGHT HOLDERS BE LIABLE For ANY CLAIM, DAMAGES Or OTHER
'LIABILITY, WHETHER In AN ACTION Of CONTRACT, TORT Or OTHERWISE, ARISING FROM,
'OUT OF Or IN CONNECTION WITH THE SOFTWARE Or THE USE Or OTHER DEALINGS IN THE
'SOFTWARE.

Imports System.ComponentModel
Imports System.Resources

Public Class LCDCharGeneratorForm

    Const numberOfRows As Integer = 8
    Const numberOfColumns As Integer = 5

    Dim myCharMatrix(numberOfRows, numberOfColumns) As Boolean

    Private Sub updateGrid()

        Dim SelectedColour As Color = Color.Blue
        Dim UnSelectedColour As Color = Color.White

        If myCharMatrix(1, 1) Then B11.BackColor = SelectedColour Else B11.BackColor = UnSelectedColour
        If myCharMatrix(1, 2) Then B12.BackColor = SelectedColour Else B12.BackColor = UnSelectedColour
        If myCharMatrix(1, 3) Then B13.BackColor = SelectedColour Else B13.BackColor = UnSelectedColour
        If myCharMatrix(1, 4) Then B14.BackColor = SelectedColour Else B14.BackColor = UnSelectedColour
        If myCharMatrix(1, 5) Then B15.BackColor = SelectedColour Else B15.BackColor = UnSelectedColour

        If myCharMatrix(2, 1) Then B21.BackColor = SelectedColour Else B21.BackColor = UnSelectedColour
        If myCharMatrix(2, 2) Then B22.BackColor = SelectedColour Else B22.BackColor = UnSelectedColour
        If myCharMatrix(2, 3) Then B23.BackColor = SelectedColour Else B23.BackColor = UnSelectedColour
        If myCharMatrix(2, 4) Then B24.BackColor = SelectedColour Else B24.BackColor = UnSelectedColour
        If myCharMatrix(2, 5) Then B25.BackColor = SelectedColour Else B25.BackColor = UnSelectedColour

        If myCharMatrix(3, 1) Then B31.BackColor = SelectedColour Else B31.BackColor = UnSelectedColour
        If myCharMatrix(3, 2) Then B32.BackColor = SelectedColour Else B32.BackColor = UnSelectedColour
        If myCharMatrix(3, 3) Then B33.BackColor = SelectedColour Else B33.BackColor = UnSelectedColour
        If myCharMatrix(3, 4) Then B34.BackColor = SelectedColour Else B34.BackColor = UnSelectedColour
        If myCharMatrix(3, 5) Then B35.BackColor = SelectedColour Else B35.BackColor = UnSelectedColour

        If myCharMatrix(4, 1) Then B41.BackColor = SelectedColour Else B41.BackColor = UnSelectedColour
        If myCharMatrix(4, 2) Then B42.BackColor = SelectedColour Else B42.BackColor = UnSelectedColour
        If myCharMatrix(4, 3) Then B43.BackColor = SelectedColour Else B43.BackColor = UnSelectedColour
        If myCharMatrix(4, 4) Then B44.BackColor = SelectedColour Else B44.BackColor = UnSelectedColour
        If myCharMatrix(4, 5) Then B45.BackColor = SelectedColour Else B45.BackColor = UnSelectedColour

        If myCharMatrix(5, 1) Then B51.BackColor = SelectedColour Else B51.BackColor = UnSelectedColour
        If myCharMatrix(5, 2) Then B52.BackColor = SelectedColour Else B52.BackColor = UnSelectedColour
        If myCharMatrix(5, 3) Then B53.BackColor = SelectedColour Else B53.BackColor = UnSelectedColour
        If myCharMatrix(5, 4) Then B54.BackColor = SelectedColour Else B54.BackColor = UnSelectedColour
        If myCharMatrix(5, 5) Then B55.BackColor = SelectedColour Else B55.BackColor = UnSelectedColour

        If myCharMatrix(6, 1) Then B61.BackColor = SelectedColour Else B61.BackColor = UnSelectedColour
        If myCharMatrix(6, 2) Then B62.BackColor = SelectedColour Else B62.BackColor = UnSelectedColour
        If myCharMatrix(6, 3) Then B63.BackColor = SelectedColour Else B63.BackColor = UnSelectedColour
        If myCharMatrix(6, 4) Then B64.BackColor = SelectedColour Else B64.BackColor = UnSelectedColour
        If myCharMatrix(6, 5) Then B65.BackColor = SelectedColour Else B65.BackColor = UnSelectedColour

        If myCharMatrix(7, 1) Then B71.BackColor = SelectedColour Else B71.BackColor = UnSelectedColour
        If myCharMatrix(7, 2) Then B72.BackColor = SelectedColour Else B72.BackColor = UnSelectedColour
        If myCharMatrix(7, 3) Then B73.BackColor = SelectedColour Else B73.BackColor = UnSelectedColour
        If myCharMatrix(7, 4) Then B74.BackColor = SelectedColour Else B74.BackColor = UnSelectedColour
        If myCharMatrix(7, 5) Then B75.BackColor = SelectedColour Else B75.BackColor = UnSelectedColour

        If myCharMatrix(8, 1) Then B81.BackColor = SelectedColour Else B81.BackColor = UnSelectedColour
        If myCharMatrix(8, 2) Then B82.BackColor = SelectedColour Else B82.BackColor = UnSelectedColour
        If myCharMatrix(8, 3) Then B83.BackColor = SelectedColour Else B83.BackColor = UnSelectedColour
        If myCharMatrix(8, 4) Then B84.BackColor = SelectedColour Else B84.BackColor = UnSelectedColour
        If myCharMatrix(8, 5) Then B85.BackColor = SelectedColour Else B85.BackColor = UnSelectedColour


    End Sub

    Private Sub CompressedCode()

        Dim myChar As String = "byte myChar[8] = {"

        Dim ws As String
        For r As Integer = 1 To numberOfRows

            myChar &= "0x"

            ws = ""
            For c As Integer = 1 To numberOfColumns
                If myCharMatrix(r, c) Then
                    ws &= "1"
                Else
                    ws &= "0"
                End If
            Next

            Dim decVal As Integer = Convert.ToInt32(ws, 2)

            myChar &= Hex(decVal) & ","

        Next

        myChar = myChar.TrimEnd(",")

        myChar &= "};" & vbCrLf

        TextBox1.Text = myChar

    End Sub

    Private Sub VerbouseCode()

        Dim myChar As String = "byte myChar[8] = {" & vbCrLf

        For r As Integer = 1 To numberOfRows

            myChar &= "B"

            For c As Integer = 1 To numberOfColumns

                If myCharMatrix(r, c) Then
                    myChar &= "1"
                Else
                    myChar &= "0"
                End If

            Next

            myChar &= "," & vbCrLf

        Next

        myChar = myChar.TrimEnd(",")

        myChar &= "};" & vbCrLf

        TextBox1.Text = myChar

    End Sub

    Sub updateArduinoCodeSnippet()

        If cbCompressCode.Checked Then
            CompressedCode()
        Else
            VerbouseCode()
        End If

    End Sub

    Private Sub updateForm()

        updateGrid()
        updateArduinoCodeSnippet()
        CopyButton.Select()

    End Sub

    Private Sub setAll(ByVal Value As Boolean)

        For r As Integer = 1 To numberOfRows
            For c As Integer = 1 To numberOfColumns
                myCharMatrix(r, c) = Value
            Next
        Next

    End Sub

    Private Sub SelectAll_Click(sender As Object, e As EventArgs) Handles SelectAll.Click

        setAll(True)
        updateForm()

    End Sub

    Private Sub ClearAll_Click(sender As Object, e As EventArgs) Handles ClearAll.Click

        setAll(False)
        updateForm()

    End Sub

    Private Sub buttonInTheGrid_Click(sender As Object, e As EventArgs) Handles _
            B11.Click, B12.Click, B13.Click, B14.Click, B15.Click,
            B21.Click, B22.Click, B23.Click, B24.Click, B25.Click,
            B31.Click, B32.Click, B33.Click, B34.Click, B35.Click,
            B41.Click, B42.Click, B43.Click, B44.Click, B45.Click,
            B51.Click, B52.Click, B53.Click, B54.Click, B55.Click,
            B61.Click, B62.Click, B63.Click, B64.Click, B65.Click,
            B71.Click, B72.Click, B73.Click, B74.Click, B75.Click,
            B81.Click, B82.Click, B83.Click, B84.Click, B85.Click

        'button names in the grid start with a B, and are followed by two digits; the first digit is the row number, the second digit is the column number
        Dim Row As Int16 = Mid(sender.name, 2, 1)
        Dim Column As Int16 = Mid(sender.name, 3, 1)

        myCharMatrix(Row, Column) = Not myCharMatrix(Row, Column)

        updateForm()

    End Sub

    Private Sub buttonInTheGrid_MouseEnter(sender As Object, e As EventArgs) Handles _
            B11.MouseEnter, B12.MouseEnter, B13.MouseEnter, B14.MouseEnter, B15.MouseEnter,
            B21.MouseEnter, B22.MouseEnter, B23.MouseEnter, B24.MouseEnter, B25.MouseEnter,
            B31.MouseEnter, B32.MouseEnter, B33.MouseEnter, B34.MouseEnter, B35.MouseEnter,
            B41.MouseEnter, B42.MouseEnter, B43.MouseEnter, B44.MouseEnter, B45.MouseEnter,
            B51.MouseEnter, B52.MouseEnter, B53.MouseEnter, B54.MouseEnter, B55.MouseEnter,
            B61.MouseEnter, B62.MouseEnter, B63.MouseEnter, B64.MouseEnter, B65.MouseEnter,
            B71.MouseEnter, B72.MouseEnter, B73.MouseEnter, B74.MouseEnter, B75.MouseEnter,
            B81.MouseEnter, B82.MouseEnter, B83.MouseEnter, B84.MouseEnter, B85.MouseEnter

        If My.Computer.Keyboard.ShiftKeyDown Then

            'button names in the grid start with a B, and are followed by two digits; the first digit is the row number, the second digit is the column number
            Dim Row As Int16 = Mid(sender.name, 2, 1)
            Dim Column As Int16 = Mid(sender.name, 3, 1)

            myCharMatrix(Row, Column) = Not myCharMatrix(Row, Column)

            updateForm()

        End If

    End Sub

    Private Sub cbCompressCode_CheckedChanged(sender As Object, e As EventArgs) Handles cbCompressCode.CheckedChanged
        updateForm()
    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(sender.Text & "?LCDCharGenerator")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("https://opensource.org/licenses/MIT")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("https://www.arduino.cc/en/Reference/LiquidCrystalCreateChar")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/roblatour/LCDCharGenerator")
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.cbCompressCode.Checked = My.Settings.CompressCode

        updateForm()

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        My.Settings.CompressCode = Me.cbCompressCode.Checked
        My.Settings.Save()

    End Sub

End Class
