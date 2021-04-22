Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim open As New OpenFileDialog
        open.Title = "exe File"
        open.FileName = "Open New Process"
        open.Filter = "Exe File (.exe)|*.exe|Bat File (.bat)|*.bat"
        If open.ShowDialog = Windows.Forms.DialogResult.OK Then
            Process.Start(open.FileName)
            Button3.PerformClick()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox(ListBox1.SelectedItem & " Kapatılsın mı ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each selProcess As Process In Process.GetProcesses
                If selProcess.ProcessName = ListBox1.SelectedItem Then
                    selProcess.Kill()
                    Button3.PerformClick()
                    Exit For
                End If
            Next
        Else
            Button3.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        For Each dongu As Process In Process.GetProcesses
            ListBox1.Items.Add(dongu.ProcessName)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        For Each dongu As Process In Process.GetProcesses
            ListBox1.Items.Add(dongu.ProcessName)
        Next
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim cpu As Integer = 0
        Dim ram As Integer = 0

        cpu = cpuinfo.NextValue
        ram = raminfo.NextValue

        Label1.Text = "Cpu Kullanımı " & cpu & "%"
        Label2.Text = "Ram Kullanımı " & ram & "%"

        ProgressBar1.Value = cpu
        ProgressBar2.Value = ram
    End Sub
End Class
