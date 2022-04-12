Public Class FrmDetailDOTitipan

    Sub New(Id_DO As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Using dt As DataTable = SelectCon.execute("SELECT * FROM DELIVERY_ORDER WHERE ID_TRANSAKSI='" & Id_DO & "'")
            TextEdit1.Value = dt.Rows(0).Item("DPP")
        End Using

        Using dt As DataTable = SelectCon.execute("select ID_TRANSAKSI, NO_BON, TGL, TGL_PENGAKUAN, B.NAMA, DPP+PPN TOTAL, C.NAMA_USER from BON_PESANAN A JOIN DIVISI B ON A.DIVISI=B.KODE
JOIN USERS C ON A.CRUSER=C.ID_USER WHERE A.ID_DO='" & Id_DO & "'")
            GridControl1.DataSource = dt

            CalcEdit1.Value = dt.Compute("SUM(TOTAL)", "")
            CalcEdit2.Value = TextEdit1.Value - CalcEdit1.Value
        End Using
    End Sub
End Class