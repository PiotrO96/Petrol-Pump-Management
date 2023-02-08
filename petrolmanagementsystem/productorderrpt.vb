Imports System.Data.OleDb
Imports System.Data

Public Class productorderrpt
    Dim conn As New OleDbConnection(MDIform.con)
    Dim da As OleDbDataAdapter
    Dim ds16 As New DataSet()
    Dim rpt As CrystalReport13
    Private Sub productorderrpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            da = New OleDbDataAdapter("select * from suppwithdraw ", conn)
            da.Fill(ds16, "suppwithdraw")
            rpt = New CrystalReport13
            rpt.SetDataSource(ds16)
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class