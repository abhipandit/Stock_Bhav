Imports System.Data.SqlClient
Imports mshtml

Public Class Form2



	Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Dim con As New SqlConnection

		con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True;MultipleActiveResultSets=True"
		con.Open()

		Dim cmd1 As New SqlCommand("select distinct symbol as s1 from fo_bhavcopy", con)
		Dim rd1 As SqlDataReader = cmd1.ExecuteReader

		Dim i As Integer
		i = 0

		'While rd1.Read()
		DefineGlobals.symbol = "BEML"
		WebBrowser1.Url = New Uri("https://www.nseindia.com/products/content/equities/equities/eq_security.htm")
		'End While

	End Sub

	Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

		Dim head As HtmlElement = WebBrowser1.Document.GetElementsByTagName("head")(0)
		Dim scriptEl As HtmlElement = WebBrowser1.Document.CreateElement("script")
		Dim element As IHTMLScriptElement = CType(scriptEl.DomElement, IHTMLScriptElement)
		element.text = "function sayHello() { document.getElementById('symbol').value='" & DefineGlobals.symbol & "';document.getElementById('dateRange').selectedIndex=6; submitData();"

		element.text += " $.get('/products/dynaContent/common/productsSymbolMapping.jsp',{symbol:'" & DefineGlobals.symbol & "',segmentLink:3,symbolCount:1,series:'ALL',dateRange:'12month',fromDate:0,toDate:0,dataType:'priceVolumeDeliverable'}, "
		element.text += " 		function(html){ "
		element.text += " 			exportDivToCSV.apply( $(this), [$('#csvContentDiv').html(),$('#csvFileName').val()]); "
		element.text += " 		}); "
		element.text += " } "

		head.AppendChild(scriptEl)
		WebBrowser1.Document.InvokeScript("sayHello")


		'Form3.Visible = True

		'Form3.Visible = True



	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Form3.Visible = True
	End Sub
End Class