<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

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
		Me.components = New System.ComponentModel.Container()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
		Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
		Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.BhavcopyDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.BhavcopyDataSet = New WindowsApp1.bhavcopyDataSet()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BhavcopyDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BhavcopyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(293, 52)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(134, 23)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Download Data"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Location = New System.Drawing.Point(12, 12)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker1.TabIndex = 1
		'
		'DateTimePicker2
		'
		Me.DateTimePicker2.Location = New System.Drawing.Point(258, 12)
		Me.DateTimePicker2.Name = "DateTimePicker2"
		Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker2.TabIndex = 2
		'
		'DateTimePicker3
		'
		Me.DateTimePicker3.Location = New System.Drawing.Point(487, 12)
		Me.DateTimePicker3.Name = "DateTimePicker3"
		Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
		Me.DateTimePicker3.TabIndex = 3
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(293, 94)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(134, 23)
		Me.Button2.TabIndex = 4
		Me.Button2.Text = "Populate Grid"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToAddRows = False
		Me.DataGridView1.AllowUserToDeleteRows = False
		Me.DataGridView1.AutoGenerateColumns = False
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.DataSource = Me.BhavcopyDataSetBindingSource
		Me.DataGridView1.Location = New System.Drawing.Point(12, 135)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.ReadOnly = True
		Me.DataGridView1.Size = New System.Drawing.Size(873, 307)
		Me.DataGridView1.TabIndex = 5
		'
		'BhavcopyDataSetBindingSource
		'
		Me.BhavcopyDataSetBindingSource.DataSource = Me.BhavcopyDataSet
		Me.BhavcopyDataSetBindingSource.Position = 0
		'
		'BhavcopyDataSet
		'
		Me.BhavcopyDataSet.DataSetName = "bhavcopyDataSet"
		Me.BhavcopyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(897, 454)
		Me.Controls.Add(Me.DataGridView1)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.DateTimePicker3)
		Me.Controls.Add(Me.DateTimePicker2)
		Me.Controls.Add(Me.DateTimePicker1)
		Me.Controls.Add(Me.Button1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BhavcopyDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BhavcopyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents DateTimePicker1 As DateTimePicker
	Friend WithEvents DateTimePicker2 As DateTimePicker
	Friend WithEvents DateTimePicker3 As DateTimePicker
	Friend WithEvents Button2 As Button
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents BhavcopyDataSetBindingSource As BindingSource
	Friend WithEvents BhavcopyDataSet As bhavcopyDataSet
End Class
