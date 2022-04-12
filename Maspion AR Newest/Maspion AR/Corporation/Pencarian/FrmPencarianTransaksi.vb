Public Class FrmPencarianTransaksi
    Property Key As KeyPencarian
    Property ParamKode As String
    Property ParamSupplier As String
    Property ParamGudang As String
    Property ParamCustomer As String
    Property ParamNumber As Double
    Property ParamDate As DateTime
    Property Bagian As EBagian

    Public Enum KeyPencarian
        Transaksi_Purchase_Order = 1
        Transaksi_Nota_Penjualan_Untuk_Pembelian = 2
        Transaksi_Nota_Pembelian = 3
        Transaksi_DO_BON_Perwakilan = 4
        Transaksi_Nota_Perwakilan = 5
        Transaksi_Stuffing = 6
        Transaksi_DO_BON_Pusat = 7
        Transaksi_Nota_Refund = 8
        Transaksi_TTB = 9
        Transaksi_Nota_Titip_Barang = 10
        Transaksi_Titip_Barang = 11
        Transaksi_Transfer_Gudang = 12
        Transaksi_TTB_Retur_Pembelian = 14
        Transaksi_DO_BON_Perwakilan_PO = 15
        Transaksi_Transfer_Barang_Retur = 16
        Transaksi_Retur_Pembelian = 27
        Transaksi_Retur_Pusat = 28
        'AR
        Transaksi_Create_DSR = 17
        Transaksi_Create_DSR_Belum_Jurnal = 18
        Transaksi_Permintaan_Dibuatkan_Faktur = 19
        Transaksi_Tanda_Terima = 20
        Transaksi_Create_DSR_Pembelian = 21
        Transaksi_Create_DSR_Pembelian_Belum_jurnal = 22
        Transaksi_Lap_Retur_penjualan = 23
        Transaksi_Lap_retur_penjualan_Belum_jurnal = 24
        Transaksi_Lap_Retur_Pembelian = 25
        Transaksi_Lap_Retur_Pembelian_Belum_Jurnal = 26
    End Enum

    Private Sub ProsesDetail()
        On Error Resume Next
        If GridView1.RowCount > 0 Then
            Select Case Key
                Case KeyPencarian.Transaksi_Purchase_Order
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.DISC,A.DISKON_SATUAN FROM V_D_PO_T_DO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("ID Barang", 15, , , False)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Disc%", 20, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Diskon Satuan", 60, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian
                    TBDetailCari.DataSource = SelectCon.execute("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.HARGA,A.DISC,A.DISKON_SATUAN FROM V_D_NOTA_T_PEMBELIAN A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ST=0 AND A.ID_NOTA='" & GridView1.GetFocusedRow(0) & "' ORDER BY [URUTAN]")
                    GridView2.Columns(0).Caption = "ID Barang"
                    GridView2.Columns(0).Width = 35
                    GridView2.Columns(0).Visible = False
                    GridView2.Columns(1).Caption = "Kode Barang"
                    GridView2.Columns(1).Width = 60
                    GridView2.Columns(2).Caption = "Nama Barang"
                    GridView2.Columns(2).Width = 125
                    GridView2.Columns(3).Caption = "Satuan"
                    GridView2.Columns(3).Width = 60
                    GridView2.Columns(4).Caption = "Koli"
                    GridView2.Columns(4).Width = 30
                    GridView2.Columns(5).Caption = "Qty"
                    GridView2.Columns(5).Width = 30
                    GridView2.Columns(6).Caption = "Pcs"
                    GridView2.Columns(6).Width = 30
                    GridView2.Columns(7).Caption = "Harga"
                    GridView2.Columns(7).Width = 75
                    GridView2.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView2.Columns(7).DisplayFormat.FormatString = "n2"
                    GridView2.Columns(8).Caption = "Disc %"
                    GridView2.Columns(8).Width = 30
                    GridView2.Columns(9).Caption = "Disc Satuan"
                    GridView2.Columns(9).Width = 60
                    GridView2.Columns(9).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView2.Columns(9).DisplayFormat.FormatString = "n2"

                Case KeyPencarian.Transaksi_DO_BON_Perwakilan
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QTY,A.SATUAN,A.PCS-A.PCS_T AS PCS FROM V_D_DB_PERW_T_STUFF A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Nota_Pembelian
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.SATUAN,A.KOLI_NOTA,A.QTY_NOTA,A.PCS_NOTA,A.KOLI_CLAIM,A.QTY_CLAIM,A.PCS_CLAIM FROM V_D_PB_T_CLAIM A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 25)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli Nota", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Qty Nota", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs Nota", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Koli Claim", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Qty Claim", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs Claim", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Nota_Perwakilan
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T FROM V_D_NOTA_T_SJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY URUTAN")
                        LoadDataToGrid.Init("Kode Barang", 15)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Stuffing
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T FROM V_D_STUFF_T_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY URUTAN")
                        LoadDataToGrid.Init("Kode Barang", 15)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_DO_BON_Pusat
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QTY,A.SATUAN,A.PCS-A.PCS_T AS PCS FROM V_D_DB_PUSAT_T_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_Nota_Refund
                    TBDetailCari.DataSource = SelectCon.execute("SELECT A.URUTAN,A.ID_BARANG,B.KODE,B.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.HARGA,A.DISC,A.DISKON_SATUAN,ROUND(A.QUANTITY * (A.HARGA * ((100 - (A.DISC / A.HARGA) * 100)) / 100),2) AS SUBTOTAL FROM DETAIL_NOTA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY URUTAN")
                    GridView2.Columns(0).Caption = "No."
                    GridView2.Columns(0).Width = 15
                    GridView2.Columns(1).Caption = "ID Barang"
                    GridView2.Columns(1).Width = 50
                    GridView2.Columns(2).Caption = "Kode Barang"
                    GridView2.Columns(2).Width = 50
                    GridView2.Columns(3).Caption = "Nama Barang"
                    GridView2.Columns(3).Width = 150
                    GridView2.Columns(4).Caption = "Koli"
                    GridView2.Columns(4).Width = 40
                    GridView2.Columns(5).Caption = "Kuantum"
                    GridView2.Columns(5).Width = 40
                    GridView2.Columns(6).Caption = "Satuan"
                    GridView2.Columns(6).Width = 50
                    GridView2.Columns(7).Caption = "Harga"
                    GridView2.Columns(7).Width = 60
                    GridView2.Columns(8).Caption = "Disc %"
                    GridView2.Columns(8).Width = 30
                    GridView2.Columns(9).Caption = "Disc Satuan"
                    GridView2.Columns(9).Width = 60
                    GridView2.Columns(10).Caption = "Subtotal"
                    GridView2.Columns(10).Width = 70
                    GridView2.Columns(10).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GridView2.Columns(10).DisplayFormat.FormatString = "n2"

                Case KeyPencarian.Transaksi_TTB
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.SATUAN,A.PCS-A.PCS_T FROM V_D_TTB_T_RJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_Retur_Pembelian
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.SATUAN,A.PCS-A.PCS_T FROM V_D_RB_T_RP A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Nota_Titip_Barang
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.HARGA FROM V_D_NOTA_T_TITIP A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("ID", 15, , , False)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Harga", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_Titip_Barang
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.SATUAN,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T,A.HARGA FROM V_D_TITIP_T_SJ A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("ID", 15, , , False)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Harga", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using

                Case KeyPencarian.Transaksi_Transfer_Gudang
                    TBDetailCari.DataSource = SelectCon.execute("SELECT A.ID_BARANG,B.KODE,B.NAMA,A.QUANTITY-A.QUANTITY_T,A.SATUAN FROM V_D_TRANSFER_T_TERIMA A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ")
                    GridView2.Columns(0).Caption = "ID Barang"
                    GridView2.Columns(0).Width = 35
                    GridView2.Columns(1).Caption = "Kode Barang"
                    GridView2.Columns(1).Width = 50
                    GridView2.Columns(2).Caption = "Nama Barang"
                    GridView2.Columns(2).Width = 150
                    GridView2.Columns(3).Caption = "Quantity"
                    GridView2.Columns(3).Width = 40
                    GridView2.Columns(4).Caption = "Satuan"
                    GridView2.Columns(4).Width = 50

                Case KeyPencarian.Transaksi_TTB_Retur_Pembelian
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.SATUAN,A.PCS-A.PCS_T FROM V_D_TTB_T_RB_N_TBR A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_DO_BON_Perwakilan_PO
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI-A.KOLI_T AS KOLI,A.QUANTITY-A.QUANTITY_T AS QTY,A.SATUAN,A.PCS-A.PCS_T AS PCS FROM V_D_DB_PERW_T_PO A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND A.ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Transfer_Barang_Retur
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT ID_TTB,NO_TTB,B.KODE,B.NAMA,A.KOLI-A.KOLI_T,A.QUANTITY-A.QUANTITY_T,A.PCS-A.PCS_T FROM V_D_TRANSFER_T_TERIMA_RETUR A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' AND ST=0 ORDER BY URUTAN")
                        LoadDataToGrid.Init("Id TTB", 50)
                        LoadDataToGrid.Init("No. TTB", 150)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Retur_Pusat
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,B.KODE,B.NAMA,A.KOLI,A.QUANTITY,A.SATUAN,A.PCS FROM DETAIL_RETUR_PUSAT A LEFT JOIN BARANG B ON A.ID_BARANG=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Kode Barang", 50)
                        LoadDataToGrid.Init("Nama Barang", 150)
                        LoadDataToGrid.Init("Koli", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Kuantum", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Satuan", 30)
                        LoadDataToGrid.Init("Pcs", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using


                'AR
                Case KeyPencarian.Transaksi_Create_DSR
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("DO", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Std. Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Add. Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Cash Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Create_DSR_Pembelian
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, A.NO_NOTA, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Nota", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Klaim Bersih", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Terima", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Create_DSR_Pembelian_Belum_jurnal
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, A.NO_NOTA, B.NAMA, A.NILAI_NOTA, A.DISKON, A.KLAIM_BERSIH, A.NILAI_TERIMA FROM AR_DSR_DETAIL_PEMBELIAN A JOIN SBU B ON A.ID_SUPPLIER=B.KODE WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Nota", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Klaim Bersih", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Terima", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Lap_Retur_penjualan
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,  A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("No. TTB", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Lap_retur_penjualan_Belum_jurnal
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,  A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PENJUALAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("No. TTB", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Lap_Retur_Pembelian
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,  A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("No. TTB", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Lap_Retur_Pembelian_Belum_Jurnal
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN,  A.NO_NOTA,A.NO_TTB, B.NAMA, A.NILAI_BRUTO, A.NILAI_DISKON, A.NILAI_NETTO FROM AR_LAP_RETUR_PEMBELIAN_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedDataRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("No. TTB", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Nilai Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Diskon", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Nilai Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Create_DSR_Belum_Jurnal
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, B.NAMA, A.BRUTO, A.STD_DISC, A.ADD_DISC, A.CASH_DISC, A.NETTO FROM AR_DSR_DETAIL A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("Nota", 35)
                        LoadDataToGrid.Init("DO", 35)
                        LoadDataToGrid.Init("Nama", 150)
                        LoadDataToGrid.Init("Bruto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Std. Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Add. Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Cash Disc", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.Init("Netto", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Permintaan_Dibuatkan_Faktur
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, dbo.GetNoPO(B.KETERANGAN_CETAK), B.NO_NOTA, B.TGL_PENGAKUAN, B.DPP+B.PPN TOTAL FROM AR_PERMOHONAN_FAKTUR_DETAIL A JOIN NOTA B ON A.ID_NOTA=B.ID_TRANSAKSI WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("No. PO", 35)
                        LoadDataToGrid.Init("No. Nota", 35)
                        LoadDataToGrid.Init("Tgl. Pengakuan", 35, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                        LoadDataToGrid.Init("Total", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case KeyPencarian.Transaksi_Tanda_Terima
                    Using LoadDataToGrid As New _LoadDataToGrid
                        LoadDataToGrid.BeginInit("SELECT A.URUTAN, A.NO_NOTA, A.NO_DO, A.NETTO FROM AR_TANDA_TERIMA_DETAIL A WHERE A.ID_TRANSAKSI='" & GridView1.GetFocusedRow(0) & "' ORDER BY A.URUTAN")
                        LoadDataToGrid.Init("No.", 15)
                        LoadDataToGrid.Init("No. Nota", 35)
                        LoadDataToGrid.Init("No. DO", 35)
                        LoadDataToGrid.Init("Total", 40, DevExpress.Utils.FormatType.Numeric, "n")
                        LoadDataToGrid.EndInit(TBDetailCari, GridView2)
                    End Using
                Case Else
                    MsgBox("Key Tidak Terdaftar !!!")
            End Select
        End If
    End Sub

    Private Sub Proses()
        On Error GoTo keluar
        Me.Show()
        ProgressPanel1.Visible = True
        TBCari.DataSource = Nothing
        Application.DoEvents()

        Select Case Key
            Case KeyPencarian.Transaksi_Purchase_Order
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_PO,A.TGL,A.TGL_PENGAKUAN,C.NAMA,A.DPP+A.PPN AS TOTAL FROM PURCHASE_ORDER A INNER JOIN V_D_PO_T_DO B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE A.BATAL=0 AND B.STK=0 AND D.ID_USER='" & UserID & "' " & IIf(EnumDescription(Bagian).Contains("Langganan"), " AND A.BAGIAN LIKE '%Langganan%' ", " AND A.BAGIAN LIKE '%Supermarket%' ") & " ORDER BY A.TGL_PENGAKUAN")
                    LoadDataToGrid.Init("ID PO", 25, , , False)
                    LoadDataToGrid.Init("No. PO", 50)
                    LoadDataToGrid.Init("Tgl. PO", 40, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Pengakuan", 40, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 125)
                    LoadDataToGrid.Init("Total", 125)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Nota_Penjualan_Untuk_Pembelian
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.ID_DO,A.NO_DO,A.TGL_PENGAKUAN,C.NAMA,C.ALAMAT_KANTOR,DPP+PPN AS TOTAL FROM NOTA A INNER JOIN V_D_NOTA_T_PEMBELIAN B ON A.ID_TRANSAKSI=B.ID_NOTA LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE A.BATAL=0 AND STK=0 AND D.ID_USER='" & UserID & "' AND " & IIf(EnumDescription(Bagian).Contains("Langganan"), " A.BAGIAN LIKE '%Langganan%' ", " A.BAGIAN LIKE '%Supermarket%' "))
                GridView1.Columns(0).Caption = "ID Nota"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Caption = "No. Nota/SJ"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "ID D.O."
                GridView1.Columns(2).Width = 50
                GridView1.Columns(2).Visible = False
                GridView1.Columns(3).Caption = "No. D.O."
                GridView1.Columns(3).Width = 50
                GridView1.Columns(4).Caption = "Tgl Nota"
                GridView1.Columns(4).Width = 40
                GridView1.Columns(5).Caption = "Nama Customer"
                GridView1.Columns(5).Width = 75
                GridView1.Columns(6).Caption = "Alamat Kantor"
                GridView1.Columns(6).Width = 125
                GridView1.Columns(7).Caption = "Total"
                GridView1.Columns(7).Width = 60
                GridView1.Columns(7).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns(7).DisplayFormat.FormatString = "n2"
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_DO_BON_Perwakilan
                BtnClosing.Visible = True
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,C.NAMA,A.KETERANGAN_INTERNAL,A.TOTAL FROM (SELECT DELIVERY_ORDER.ID_TRANSAKSI,NO_DO,DELIVERY_ORDER.TGL,TGL_PENGAKUAN,DELIVERY_ORDER.KODE_CUSTOMER,KETERANGAN_INTERNAL,DPP+PPN AS TOTAL,BAGIAN,DIVISI FROM DELIVERY_ORDER LEFT JOIN VI_PAY_KONTAN ON DELIVERY_ORDER.ID_TRANSAKSI=VI_PAY_KONTAN.ID_TRANSAKSI WHERE VI_PAY_KONTAN.STATUS_LUNAS=1 OR VI_PAY_KONTAN.STATUS_LUNAS IS NULL AND DELIVERY_ORDER.BATAL=0 UNION ALL SELECT ID_TRANSAKSI,NO_BON,BON_PESANAN.TGL,TGL_PENGAKUAN,KODE_CUSTOMER,KETERANGAN_INTERNAL,DPP+PPN AS TOTAL,BAGIAN,DIVISI FROM BON_PESANAN WHERE BON_PESANAN.BATAL=0) A INNER JOIN V_D_DB_PERW_T_STUFF B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID LEFT JOIN LINK_USER_DIVISI D ON D.KODE_DIVISI=A.DIVISI LEFT JOIN LINK_USER_GUDANG E ON E.KODE_GUDANG=B.GUDANG OR B.GUDANG IS NULL WHERE NOT EXISTS (SELECT * FROM CLOSING_TRANSAKSI WHERE A.ID_TRANSAKSI=ID_TRANSAKSI) AND B.STK=0 AND D.ID_USER='" & UserID & "' AND A.BAGIAN='" & EnumDescription(Bagian) & "' AND E.ID_USER='" & UserID & "' ORDER BY A.TGL")
                GridView1.Columns(0).Caption = "ID Transaksi"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Caption = "No. DO"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Transaksi"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Nama Customer"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Ket. Internal"
                GridView1.Columns(5).Width = 125
                GridView1.Columns(6).Caption = "Total"
                GridView1.Columns(6).Width = 60
                GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns(6).DisplayFormat.FormatString = "n2"
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Nota_Pembelian
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,B.NO_NOTA_PENJUALAN,B.TGL_PENGAKUAN,C.NAMA,C.ALAMAT,B.ALAMAT_KIRIM FROM V_D_PB_T_CLAIM A INNER JOIN PEMBELIAN B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN SBU C ON B.KODE_SUPPLIER=C.KODE LEFT JOIN LINK_USER_DIVISI D ON B.DIVISI=D.KODE_DIVISI WHERE STK=0 AND D.ID_USER='" & UserID & "' AND " & IIf(EnumDescription(Bagian).Contains("Langganan"), " B.BAGIAN LIKE '%Langganan%' ", " B.BAGIAN LIKE '%Supermarket%' "))
                GridView1.Columns(0).Caption = "ID Nota"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "No. Nota"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "No. Nota/SJ"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Nama Supplier"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Alamat Kantor"
                GridView1.Columns(5).Width = 125
                GridView1.Columns(6).Caption = "Alamat Kirim"
                GridView1.Columns(6).Width = 125
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Nota_Perwakilan
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL,A.TGL_PENGAKUAN,A.NO_DO,A.TGL_DO,C.NAMA,A.ALAMAT_KIRIM FROM NOTA A INNER JOIN V_D_NOTA_T_SJ B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE B.STK=0 AND A.BATAL=0 AND A.BAGIAN='" & EnumDescription(Bagian) & "' AND D.ID_USER='" & UserID & "'")
                    LoadDataToGrid.Init("ID Nota", 25, , , False)
                    LoadDataToGrid.Init("No. Nota", 50)
                    LoadDataToGrid.Init("Tgl. Nota", 40, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Pengakuan", 40, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("No. D.O.", 40)
                    LoadDataToGrid.Init("Tgl. D.O.", 40, DevExpress.Utils.FormatType.DateTime)
                    LoadDataToGrid.Init("Nama Customer", 125)
                    LoadDataToGrid.Init("Alamat Kirim", 125)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    'GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Stuffing
                BtnClosing.Visible = True
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_STUFFING,A.TGL,A.TGL_PENGAKUAN,A.NO_DO,A.TGL_DO,C.NAMA,A.ALAMAT_KIRIM FROM STUFFING A INNER JOIN V_D_STUFF_T_NOTA B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID LEFT JOIN LINK_USER_DIVISI D ON A.DIVISI=D.KODE_DIVISI WHERE D.ID_USER='" & UserID & "' AND BATAL=0 AND NOT EXISTS (SELECT * FROM CLOSING_TRANSAKSI WHERE A.ID_TRANSAKSI=ID_TRANSAKSI) AND B.STK=0 AND A.BATAL=0 AND A.BAGIAN='" & EnumDescription(Bagian) & "' ORDER BY 3")
                    LoadDataToGrid.Init("ID Stuffing", 25, , , False)
                    LoadDataToGrid.Init("No. Stuffing", 70)
                    LoadDataToGrid.Init("Tgl. Stuffing", 40, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", False)
                    LoadDataToGrid.Init("Tgl. Pengakuan", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("No. D.O.", 40)
                    LoadDataToGrid.Init("Tgl. D.O.", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Nama Customer", 100)
                    LoadDataToGrid.Init("Alamat Kirim", 50, , , False)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_DO_BON_Pusat
                BtnClosing.Visible = True
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,C.NAMA,A.KETERANGAN_INTERNAL,A.TOTAL FROM (SELECT DELIVERY_ORDER.ID_TRANSAKSI,NO_DO,DELIVERY_ORDER.TGL,TGL_PENGAKUAN,DELIVERY_ORDER.KODE_CUSTOMER,KETERANGAN_INTERNAL,DPP+PPN AS TOTAL,BAGIAN FROM DELIVERY_ORDER LEFT JOIN VI_PAY_KONTAN ON DELIVERY_ORDER.ID_TRANSAKSI=VI_PAY_KONTAN.ID_TRANSAKSI LEFT JOIN LINK_USER_DIVISI Z ON DELIVERY_ORDER.DIVISI=Z.KODE_DIVISI WHERE  Z.ID_USER='" & UserID & "' AND DELIVERY_ORDER.BATAL=0 AND (VI_PAY_KONTAN.STATUS_LUNAS=1 OR VI_PAY_KONTAN.STATUS_LUNAS IS NULL) UNION ALL SELECT ID_TRANSAKSI,NO_BON,BON_PESANAN.TGL,TGL_PENGAKUAN,KODE_CUSTOMER,ALAMAT_KIRIM,DPP+PPN AS TOTAL,BAGIAN FROM BON_PESANAN LEFT JOIN LINK_USER_DIVISI X ON BON_PESANAN.DIVISI=X.KODE_DIVISI WHERE X.ID_USER='" & UserID & "' AND BON_PESANAN.BATAL=0) A INNER JOIN V_D_DB_PUSAT_T_NOTA B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID WHERE B.STK=0 AND NOT EXISTS (SELECT * FROM CLOSING_TRANSAKSI WHERE A.ID_TRANSAKSI=ID_TRANSAKSI) AND A.BAGIAN='" & EnumDescription(Bagian) & "' ORDER BY A.TGL")
                GridView1.Columns(0).Caption = "ID Transaksi"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Caption = "No. DO"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Transaksi"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Nama Customer"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Ket. Intern."
                GridView1.Columns(5).Width = 50
                GridView1.Columns(6).Caption = "Total"
                GridView1.Columns(6).Width = 60
                GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns(6).DisplayFormat.FormatString = "n2"
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Nota_Refund
                TBCari.DataSource = SelectCon.execute("SELECT A.ID_TRANSAKSI, A.NO_NOTA, A.TGL, A.TGL_PENGAKUAN, B.NAMA, B.ALAMAT_KANTOR, A.ALAMAT_KIRIM FROM NOTA A LEFT JOIN CUSTOMER B ON A.KODE_CUSTOMER=B.ID WHERE A.BATAL=0 AND BAGIAN LIKE '%Supermarket%'")
                GridView1.Columns(0).Caption = "ID Nota"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Caption = "No. Nota"
                GridView1.Columns(1).Width = 100
                GridView1.Columns(2).Caption = "Tgl Transaksi"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(2).Visible = False
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 30
                GridView1.Columns(4).Caption = "Nama Customer"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Alamat Kantor"
                GridView1.Columns(5).Width = 50
                GridView1.Columns(5).Visible = False
                GridView1.Columns(6).Caption = "Alamat Kirim"
                GridView1.Columns(6).Width = 50
                GridView1.Columns(6).Visible = False
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_TTB
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL_PENGAKUAN,C.NAMA,D.NAMA,D.ALAMAT_KANTOR FROM TTB A INNER JOIN V_D_TTB_T_RJ B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE LEFT JOIN CUSTOMER D ON A.KODE_CUSTOMER=D.ID WHERE B.STK=0 AND A.BATAL=0")
                    LoadDataToGrid.Init("ID TTB", 25, , , False)
                    LoadDataToGrid.Init("No. TTB", 50)
                    LoadDataToGrid.Init("Tgl TTB", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Customer", 40, DevExpress.Utils.FormatType.DateTime)
                    LoadDataToGrid.Init("Alamat Customer", 125)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Retur_Pembelian
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_RETUR,A.TGL_PENGAKUAN,C.NAMA  FROM RETUR_PEMBELIAN A INNER JOIN V_D_RB_T_RP B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE  WHERE B.STK=0 AND A.BATAL=0")
                    LoadDataToGrid.Init("ID Retur Pembelian", 25, , , False)
                    LoadDataToGrid.Init("No. Retur Pembelian", 50)
                    LoadDataToGrid.Init("Tgl Retur Pembelian", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Nota_Titip_Barang
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL,A.TGL_PENGAKUAN,C.NAMA,C.ALAMAT_KANTOR,A.ALAMAT_KIRIM FROM NOTA A INNER JOIN V_D_NOTA_T_TITIP B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID WHERE A.BATAL=0 AND B.STK=0")
                GridView1.Columns(0).Caption = "ID Nota"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "No. Nota"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Transaksi"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Nama Customer"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Alamat Kantor"
                GridView1.Columns(5).Width = 125
                GridView1.Columns(6).Caption = "Alamat Kirim"
                GridView1.Columns(6).Width = 125
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Titip_Barang
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TITIP,A.TGL_PENGAKUAN,A.NO_NOTA,A.TGL_NOTA,C.NAMA,A.ALAMAT_KIRIM FROM TITIP_BARANG A INNER JOIN V_D_TITIP_T_SJ B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID WHERE A.BATAL=0 AND B.STK=0 ORDER BY A.TGL_PENGAKUAN")
                GridView1.Columns(0).Caption = "ID Titip"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "No. Titip"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Titip"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "No. Nota"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Tgl. Nota"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Nama Customer"
                GridView1.Columns(5).Width = 125
                GridView1.Columns(6).Caption = "Alamat Kirim"
                GridView1.Columns(6).Width = 125
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Transfer_Gudang
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSFER,A.TGL_PENGAKUAN,B.NAMA FROM V_D_TRANSFER_T_TERIMA A LEFT JOIN TRANSFER_GUDANG C ON A.ID_TRANSAKSI=C.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN LINK_USER_DIVISI D ON D.KODE_DIVISI=C.DIVISI WHERE A.STK=0 AND BATAL=0 AND D.ID_USER='" & UserID & "'")
                GridView1.Columns(0).Caption = "ID Transfer"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(1).Caption = "No. Transfer"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Transfer"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Divisi"
                GridView1.Columns(3).Width = 40
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_TTB_Retur_Pembelian
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_NOTA,A.TGL_PENGAKUAN,C.NAMA,D.NAMA,D.ALAMAT_KANTOR FROM TTB A INNER JOIN V_D_TTB_T_RB_N_TBR B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN DIVISI C ON A.DIVISI=C.KODE LEFT JOIN CUSTOMER D ON A.KODE_CUSTOMER=D.ID WHERE B.STK=0 AND A.BATAL=0" & IIf(ParamKode <> "", " AND A.DIVISI = '" & ParamKode & "'", ""))
                    LoadDataToGrid.Init("ID TTB", 25, , , False)
                    LoadDataToGrid.Init("No. TTB", 50)
                    LoadDataToGrid.Init("Tgl TTB", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Customer", 40, DevExpress.Utils.FormatType.DateTime)
                    LoadDataToGrid.Init("Alamat Customer", 125)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_DO_BON_Perwakilan_PO
                BtnClosing.Visible = True
                TBCari.DataSource = SelectCon.execute("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_DO,A.TGL,A.TGL_PENGAKUAN,C.NAMA,A.KETERANGAN_INTERNAL,A.TOTAL FROM (SELECT DELIVERY_ORDER.ID_TRANSAKSI,NO_DO,TGL,TGL_PENGAKUAN,DELIVERY_ORDER.KODE_CUSTOMER,KETERANGAN_INTERNAL,DPP+PPN AS TOTAL,BAGIAN,DIVISI FROM DELIVERY_ORDER UNION ALL SELECT ID_TRANSAKSI,NO_BON,TGL,TGL_PENGAKUAN,KODE_CUSTOMER,KETERANGAN_INTERNAL,DPP+PPN AS TOTAL,BAGIAN,DIVISI FROM BON_PESANAN) A INNER JOIN V_D_DB_PERW_T_PO B ON A.ID_TRANSAKSI=B.ID_TRANSAKSI LEFT JOIN CUSTOMER C ON A.KODE_CUSTOMER=C.ID LEFT JOIN LINK_USER_DIVISI D ON D.KODE_DIVISI=A.DIVISI LEFT JOIN LINK_USER_GUDANG E ON E.KODE_GUDANG=B.GUDANG OR B.GUDANG IS NULL WHERE NOT EXISTS (SELECT * FROM CLOSING_TRANSAKSI WHERE A.ID_TRANSAKSI=ID_TRANSAKSI) AND B.STK=0 AND D.ID_USER='" & UserID & "' AND E.ID_USER='" & UserID & "' AND A.DIVISI='" & ParamKode & "' AND A.BAGIAN LIKE '" & IIf(EnumDescription(Bagian).Contains("Supermarket"), "%Supermarket%", "%Langganan%") & "' ORDER BY 3")
                GridView1.Columns(0).Caption = "ID Transaksi"
                GridView1.Columns(0).Width = 50
                GridView1.Columns(0).Visible = False
                GridView1.Columns(1).Caption = "No. DO"
                GridView1.Columns(1).Width = 50
                GridView1.Columns(2).Caption = "Tgl Transaksi"
                GridView1.Columns(2).Width = 40
                GridView1.Columns(3).Caption = "Tgl Pengakuan"
                GridView1.Columns(3).Width = 40
                GridView1.Columns(4).Caption = "Nama Customer"
                GridView1.Columns(4).Width = 75
                GridView1.Columns(5).Caption = "Ket. Internal"
                GridView1.Columns(5).Width = 125
                GridView1.Columns(6).Caption = "Total"
                GridView1.Columns(6).Width = 60
                GridView1.Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns(6).DisplayFormat.FormatString = "n2"
                GridView1.BestFitColumns()
                GridView1.Columns(1).BestFit()

            Case KeyPencarian.Transaksi_Transfer_Barang_Retur
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_TRANSAKSI,A.NO_TRANSAKSI,A.TGL_PENGAKUAN,B.NAMA,C.NAMA_GUDANG,D.NAMA_GUDANG FROM TRANSFER_BARANG_RETUR A INNER JOIN V_D_TRANSFER_T_TERIMA_RETUR AB ON A.ID_TRANSAKSI=AB.ID_TRANSAKSI LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG_SUMBER=C.KODE LEFT JOIN GUDANG D ON A.GUDANG_TUJUAN=D.KODE LEFT JOIN LINK_USER_DIVISI E ON A.DIVISI=E.KODE_DIVISI WHERE AB.STK=0 AND E.ID_USER='" & UserID & "' AND A.BATAL=0" & IIf(ParamKode <> "", " AND A.DIVISI = '" & ParamKode & "'", ""))
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Transfer", 50)
                    LoadDataToGrid.Init("Tanggal", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gdg Sumber", 40)
                    LoadDataToGrid.Init("Gdg Tujuan", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Retur_Pusat
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_RETUR_PUSAT, TGL, TGL_PENGAKUAN, B.NAMA  FROM RETUR_PUSAT A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE  WHERE ID_TRANSAKSI NOT IN (SELECT ID_RETUR_PUSAT FROM AR_PELUNASAN_RETUR) ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Retur Pusat", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Retur Pusat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            'AR
            Case KeyPencarian.Transaksi_Create_DSR
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_VALIDASI_DSR) AND A.JENIS='" & ParamKode & "' ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. DSR", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. DSR", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Create_DSR_Pembelian
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR_PEMBELIAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN)  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. DSR", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. DSR", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Create_DSR_Pembelian_Belum_jurnal
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR_PEMBELIAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI IN (SELECT ID_DSR FROM AR_VALIDASI_DSR_PEMBELIAN)AND ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_PROSES_JURNAL)  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. DSR", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. DSR", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Lap_Retur_penjualan
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_PENJUALAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI NOT IN (SELECT ID_LAP FROM [AR_VALIDASI_LAP_RETUR_PENJUALAN])  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Laporan", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Laporan", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Lap_Retur_Pembelian
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_PEMBELIAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI NOT IN (SELECT ID_LAP FROM [AR_VALIDASI_LAP_RETUR_PEMBELIAN])  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Laporan", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Laporan", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Lap_Retur_Pembelian_Belum_Jurnal
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_PEMBELIAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI IN (SELECT ID_LAP FROM [AR_VALIDASI_LAP_RETUR_PEMBELIAN])  AND ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_PROSES_JURNAL)  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Laporan", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Laporan", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Lap_retur_penjualan_Belum_jurnal
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_LAP, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_LAP_RETUR_PENJUALAN A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI  IN (SELECT ID_LAP FROM [AR_VALIDASI_LAP_RETUR_PENJUALAN]) AND ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_PROSES_JURNAL)  ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Laporan", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. Laporan", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case KeyPencarian.Transaksi_Create_DSR_Belum_Jurnal
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT ID_TRANSAKSI, NO_DSR, TGL, TGL_PENGAKUAN, B.NAMA, C.NAMA_GUDANG FROM AR_DSR A LEFT JOIN DIVISI B ON A.DIVISI=B.KODE LEFT JOIN GUDANG C ON A.GUDANG=C.KODE WHERE ID_TRANSAKSI IN (SELECT ID_DSR FROM AR_VALIDASI_DSR) AND ID_TRANSAKSI NOT IN (SELECT ID_DSR FROM AR_PROSES_JURNAL) ORDER BY ID_TRANSAKSI")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. DSR", 50)
                    LoadDataToGrid.Init("Tgl. Dibuat", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Tgl. DSR", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Divisi", 25)
                    LoadDataToGrid.Init("Gudang", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Permintaan_Dibuatkan_Faktur
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT DISTINCT A.ID_PERMOHONAN, A.NO_PERMOHONAN, A.TGL_PERMOHONAN, B.NAMA
        FROM V_AR_DSR_T_PENYERAHAN A JOIN CUSTOMER B ON A.ID_CUSTOMER=B.ID WHERE A.BF=1 AND A.KF=0")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Permintaan", 50)
                    LoadDataToGrid.Init("Tgl. Dokumen", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Customer", 40)
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using

            Case KeyPencarian.Transaksi_Tanda_Terima
                Using LoadDataToGrid As New _LoadDataToGrid
                    LoadDataToGrid.BeginInit("SELECT A.ID_TRANSAKSI, A.NO_TT, A.TGL_PENGAKUAN, C.KODE_APPROVE, C.NAMA, A.TOTAL FROM AR_TANDA_TERIMA A LEFT JOIN CUSTOMER C ON A.ID_CUSTOMER=C.ID")
                    LoadDataToGrid.Init("ID Transaksi", 25, , , False)
                    LoadDataToGrid.Init("No. Tanda Terima", 50)
                    LoadDataToGrid.Init("Tanggal", 30, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy")
                    LoadDataToGrid.Init("Kode Customer", 20)
                    LoadDataToGrid.Init("Customer", 40)
                    LoadDataToGrid.Init("Tagihan", 30, DevExpress.Utils.FormatType.Numeric, "n2")
                    LoadDataToGrid.EndInit(TBCari, GridView1)
                    GridView1.BestFitColumns()
                    GridView1.Columns(1).BestFit()
                End Using
            Case Else
                MsgBox("Key Tidak Terdaftar !!!")
        End Select

        con.CloseConn()
        'GridView1.BestFitColumns()
        GridView1.FindFilterText = TxtCari.Text
        Frame1.Text = "[ " & GridView1.DataRowCount & " " & Replace(Key.ToString, "_", " ") & " ]"
        ProsesDetail()
        ProgressPanel1.Visible = False
        If GridView1.RowCount = 0 Then
            TxtCari.Focus()
        Else
            TBCari.Focus()
        End If
        Exit Sub
keluar:
        MsgBox(Err.Description)
        ResultOfSearch = ""
        Me.Dispose()
    End Sub

    Private Sub FrmPencarian_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Call Proses()
        ResultOfSearch = ""
    End Sub

    Private Sub FrmPencarian_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Application.DoEvents()
        ProgressPanel1.Visible = True
    End Sub

    Private Sub _Toolbar1_Button1_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button1.Click
        On Error Resume Next
        ResultOfSearch = GridView1.GetFocusedDataRow(0)
        Me.Dispose()
    End Sub

    Private Sub _Toolbar1_Button9_Click(sender As System.Object, e As System.EventArgs) Handles _Toolbar1_Button9.Click
        On Error Resume Next
        ResultOfSearch = ""
        Me.Dispose()
    End Sub

    Private Sub TBCari_DoubleClick(sender As Object, e As System.EventArgs) Handles TBCari.DoubleClick, GridView1.DoubleClick
        On Error Resume Next
        ResultOfSearch = GridView1.GetFocusedDataRow(0)
        Me.Dispose()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        ProsesDetail()
    End Sub

    Private Sub TBCari_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TBCari.KeyDown, GridView1.KeyDown
        Dim KeyCode As Integer = e.KeyCode
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F11
                e.Handled = False
                _Toolbar1_Button1_Click(sender, e)
            Case System.Windows.Forms.Keys.F12, System.Windows.Forms.Keys.Escape
                e.Handled = False
                _Toolbar1_Button9_Click(sender, e)
            Case 13
                On Error Resume Next
                ResultOfSearch = GridView1.GetFocusedDataRow(0)
                Me.Dispose()
            Case 65
                TxtCari.Focus()
        End Select
    End Sub

    Private Sub TxtCari_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCari.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        Select Case KeyAscii
            Case Asc("/"), Asc("\"), Asc("?"), Asc("*"), Asc("+"), Asc(":"), Asc("<"), Asc(">"), Asc("|")
                e.Handled = False
                e.KeyChar = Nothing
            Case Asc("'")
                e.KeyChar = ChrW(Asc("`"))
            Case 13
                Try
                    Call Proses()
                Catch ex As Exception
                End Try
            Case Else
                KeyAscii = 0
        End Select
        ProsesDetail()
    End Sub

    Private Sub TxtCari_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TxtCari.EditValueChanged
        GridView1.FindFilterText = TxtCari.Text
        Frame1.Text = "[ " & GridView1.DataRowCount & " " & Key.ToString & " ]"
    End Sub

    Private Sub BtnClosing_Click(sender As System.Object, e As System.EventArgs) Handles BtnClosing.Click
        If MsgBox("Apakah anda yakin closing nomor " & GridView1.GetFocusedDataRow(1) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Using SQLServer As New SQLServerTransaction
            SQLServer.InitTransaction()
            'Header
            If SQLServer.InsertHeader({ToObject(GridView1.GetFocusedDataRow(0)), ToObject(GridView1.GetFocusedDataRow(1)), UserID, ToSyntax("CURRENT_TIMESTAMP")}, "CLOSING_TRANSAKSI") = False Then Exit Sub
            Log.Insert(Me, GridView1.GetFocusedDataRow(0))
            SQLServer.EndTransaction()
            Log.Closing(Me, GridView1.GetFocusedDataRow(0))
        End Using
    End Sub
End Class