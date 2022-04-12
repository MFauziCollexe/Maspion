<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanRekapSaldoPerDivisi
    Inherits FrmLaporanBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DTPeriode = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDivisi = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKodeDivisi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.DTPeriode)
        Me.XtraScrollableControl1.Controls.Add(Me.Label3)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.TxtKodeDivisi)
        Me.XtraScrollableControl1.Controls.Add(Me.Label4)
        Me.XtraScrollableControl1.Controls.Add(Me.BtnView)
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(390, 312)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.BtnView, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label4, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtKodeDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.TxtDivisi, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.Label3, 0)
        Me.XtraScrollableControl1.Controls.SetChildIndex(Me.DTPeriode, 0)
        '
        'DTPeriode
        '
        Me.DTPeriode.EditValue = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.DTPeriode.Location = New System.Drawing.Point(63, 69)
        Me.DTPeriode.Name = "DTPeriode"
        Me.DTPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPeriode.Properties.DisplayFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditFormat.FormatString = "MMMM yyyy"
        Me.DTPeriode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DTPeriode.Properties.EditValueChangedDelay = 3
        Me.DTPeriode.Size = New System.Drawing.Size(228, 20)
        Me.DTPeriode.TabIndex = 261
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Periode :"
        '
        'TxtDivisi
        '
        Me.TxtDivisi.Location = New System.Drawing.Point(159, 95)
        Me.TxtDivisi.Name = "TxtDivisi"
        Me.TxtDivisi.Properties.ReadOnly = True
        Me.TxtDivisi.Size = New System.Drawing.Size(131, 20)
        Me.TxtDivisi.TabIndex = 257
        '
        'TxtKodeDivisi
        '
        Me.TxtKodeDivisi.Location = New System.Drawing.Point(63, 95)
        Me.TxtKodeDivisi.Name = "TxtKodeDivisi"
        Me.TxtKodeDivisi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtKodeDivisi.Properties.ReadOnly = True
        Me.TxtKodeDivisi.Size = New System.Drawing.Size(90, 20)
        Me.TxtKodeDivisi.TabIndex = 259
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Divisi :"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(62, 131)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(228, 23)
        Me.BtnView.TabIndex = 256
        Me.BtnView.Text = "View"
        '
        'LaporanRekapSaldoPerDivisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 318)
        Me.Name = "LaporanRekapSaldoPerDivisi"
        Me.Text = "LaporanRekapSaldoPerDivisi"
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.DTPeriode.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKodeDivisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DTPeriode As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDivisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtKodeDivisi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
End Class
