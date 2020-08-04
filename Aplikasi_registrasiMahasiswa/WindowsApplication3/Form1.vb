Private Sub Bersih()
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    TextBox4.Text = ""
    TextBox5.Text = ""
    TextBox2.Focus()
End Sub
Public Class Form1

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    Private Sub isiGrid()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM tbmahasiswa", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbmahasiswa")
        DataGridView1.DataSource = DS.Tables("tbmahasiswa")
        DataGridView1.Enabled = True
        TextBox2.Focus()
        isiTextBox()
    End Sub
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim simpan As String
        If TextBox1.Text = "" Then
            Databaru = True
        Else
            Databaru = False
        End If
        Me.Cursor = Cursors.WaitCursor

        If Databaru Then
            simpan = "INSERT INTO biodata(npm,nama,tgllahir,jurusan,alamat,telpon) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "') "
        Else
            simpan = "UPDATE biodata SET nama ='" & TextBox2.Text & "',nis ='" & TextBox3.Text & "',kelas ='" & TextBox4.Text & "',alamat ='" & TextBox5.Text & "' WHERE ID = " & TextBox1.Text & " "
        End If
        jalankansql(simpan)
        isiGrid()
        TextBox2.Focus()
        Me.Cursor = Cursors.Default
    End Sub
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim hapussql As String
        Dim pesan As Integer
        pesan = MsgBox("Apakah anda yakin akan menghapus Data ID " + TextBox1.Text, vbExclamation + vbYesNo, "perhatian")
        If pesan = vbNo Then Exit Sub
        hapussql = "DELETE FROM biodata WHERE ID = " & TextBox1.Text & ""
        jalankansql(hapussql)
        Me.Cursor = Cursors.WaitCursor
        Bersih()
        TextBox2.Focus()
        Me.Cursor = Cursors.Default
    End Sub
    End Sub
End Class
