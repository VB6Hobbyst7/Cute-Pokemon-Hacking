Public Class Form1
    '=====================
    Sub readPointer()
        On Error Resume Next
        While True
            If ((Process.GetProcessesByName("皮卡丘打排球").Length <> 0)) Then
                 Label1.Text = ReadDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H40}, 3)
                Label2.Text = ReadDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H3C}, 3)

                ToolStripStatusLabel1.Text = "捕獲野生的皮卡丘!!XD"
            Else

                ToolStripStatusLabel1.Text = "尚未發現可愛的皮卡丘們T_T"
            End If

            Threading.Thread.Sleep(3000)
        End While
    End Sub

    Sub writePointer()
        On Error Resume Next
        While True
            If ((Process.GetProcessesByName("皮卡丘打排球").Length <> 0)) Then
                WriteDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H40}, TextBox1.Text, 3)
                WriteDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H3C}, TextBox2.Text, 3)
                
                ToolStripStatusLabel1.Text = "捕獲野生的皮卡丘!!XD"
            Else

                ToolStripStatusLabel1.Text = "尚未發現可愛的皮卡丘們T_T"
            End If

            Threading.Thread.Sleep(3000)
        End While
    End Sub
    '=====================
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If ((Process.GetProcessesByName("皮卡丘打排球").Length <> 0)) Then
                WriteDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H40}, TextBox1.Text, 3)
                WriteDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H3C}, TextBox2.Text, 3)
                Label1.Text = ReadDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H40}, 3)
                Label2.Text = ReadDMAInteger("皮卡丘打排球", &H411F28, {&H28, &H10, &H3C}, 3)

                ToolStripStatusLabel1.Text = "捕獲野生的皮卡丘!!XD"
            Else

                ToolStripStatusLabel1.Text = "尚未發現可愛的皮卡丘們T_T"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form.CheckForIllegalCrossThreadCalls = False

        Try
            writePointerT.Start()

            readPointerT.Start()
        Catch ex As Exception

        End Try
      
    End Sub
    Dim writePointerT As New Threading.Thread(AddressOf writePointer)
    Dim readPointerT As New Threading.Thread(AddressOf readPointer)
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://umworksite.blogspot.tw/")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            'Timer1.Enabled = True
            writePointerT.Start()
        Else
            writePointerT.Suspend()
        End If
    End Sub
End Class
