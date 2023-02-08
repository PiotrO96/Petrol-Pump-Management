Imports System.Data.OleDb
Imports System.Data

Public Class productstockdetail
    Dim conn As New OleDbConnection(MDIform.con)
    Dim ad As New OleDbDataAdapter
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim i As Integer
    Dim ds As DataSet

    Private Sub productstockdetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd = New OleDbCommand("select proid from prodetail ", conn)
        conn.Open()
        dr = cmd.ExecuteReader()
        If (dr.HasRows) Then
            While (dr.Read())
                ComboBox1.Items.Add(dr(0).ToString())
            End While
        End If
        dr.Close()
        conn.Close()

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        conn.Open()
        Dim str As String = "insert into prodetail(proid,proname,des,prorate,uofmea,maquantity,miquality,olevel,quantity)values('" & ComboBox1.Text & "','" & txtname.Text & "','" & txtdes.Text & "','" & txtrate.Text & "','" & txtunit.Text & "','" & txtqty.Text & "','" & txtqty1.Text & "','" & txtorderlevel.Text & "','" & txtqty2.Text & "' )"


        cmd = New OleDbCommand(str, conn)
        cmd.ExecuteNonQuery()
        MessageBox.Show("record save")
        conn.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Dim i As Integer = 0
        cmd = New OleDbCommand("select max(proid) from prodetail ", conn)
        conn.Open()
        dr = cmd.ExecuteReader()
        If (dr.HasRows) Then
            While (dr.Read())
                i = Convert.ToInt32(dr(0).ToString())
                i = i + 1
                ComboBox1.Text = i
                ComboBox1.Items.Add(i)
            End While
        End If
        dr.Close()
        conn.Close()
        txtname.Text = ""
        txtdes.Text = ""
        txtrate.Text = ""
        txtunit.Text = ""
        txtqty.Text = ""
        txtqty1.Text = ""
        txtorderlevel.Text = ""
        txtqty2.Text = ""
        txtname.Focus()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        cmd = New OleDbCommand("delete from prodetail where proid = " & ComboBox1.Text & "", conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        MessageBox.Show(" Record Delete ")
        conn.Close()
        txtname.Text = ""
        txtdes.Text = ""
        txtrate.Text = ""
        txtunit.Text = ""
        txtqty.Text = ""
        txtqty1.Text = ""
        txtorderlevel.Text = ""
        txtqty2.Text = ""
        conn.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            MessageBox.Show("contains only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New OleDbCommand("select * from prodetail where proid = " & ComboBox1.Text & "", conn)
        conn.Open()
        dr = cmd.ExecuteReader()
        If (dr.Read) = True Then
            ComboBox1.Text = dr("proid").ToString
            txtname.Text = dr("proname").ToString
            txtdes.Text = dr("des").ToString
            txtrate.Text = dr("prorate").ToString
            txtunit.Text = dr("uofmea").ToString
            txtqty.Text = dr("maquantity").ToString
            txtqty1.Text = dr("miquality").ToString
            txtorderlevel.Text = dr("olevel").ToString
            txtqty2.Text = dr("quantity").ToString
        ElseIf (dr.Read) = False Then
            txtname.Text = ""
            txtdes.Text = ""
            txtrate.Text = ""
            txtunit.Text = ""
            txtqty.Text = ""
            txtqty1.Text = ""
            txtorderlevel.Text = ""
            txtqty2.Text = ""

        End If
        conn.Close()
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        cmd = New OleDbCommand("update prodetail set proname = '" & txtname.Text & "',des = '" & txtdes.Text & "',prorate= " & txtrate.Text & ",uofmea='" & txtunit.Text & "',maquantity=" & txtqty.Text & ",miquality=" & txtqty1.Text & ",olevel='" & txtorderlevel.Text & "',quantity=" & txtqty2.Text & " where proid = " & ComboBox1.Text & "", conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        MessageBox.Show("record successfully updated")
        conn.Close()

    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub btnorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnorder.Click
        productdetailshow.Show()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If Char.IsDigit(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged

    End Sub

    Private Sub txtdes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdes.TextChanged

    End Sub

    Private Sub txtorderlevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtorderlevel.TextChanged

    End Sub

    Private Sub txtunit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunit.KeyPress
        If Char.IsDigit(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("contains only letter", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtunit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtunit.TextChanged

    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            MessageBox.Show("contains only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrate.TextChanged

    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            MessageBox.Show("contains only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged

    End Sub

    Private Sub txtqty1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty1.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            MessageBox.Show("contains only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtqty1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty1.TextChanged

    End Sub

    Private Sub txtqty2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty2.KeyPress
        If Char.IsLetter(e.KeyChar) = True Then
            MessageBox.Show("contains only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
        If Char.IsSymbol(e.KeyChar) = True Then
            MessageBox.Show("only Digits", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
        End If
    End Sub

    Private Sub txtqty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty2.TextChanged

    End Sub
End Class