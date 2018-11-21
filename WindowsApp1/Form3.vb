Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class Form3
	Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load


		'Dim con As New SqlConnection

		'con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True;MultipleActiveResultSets=True"
		'con.Open()

		'Dim cmd1 As New SqlCommand("select distinct symbol as s1 from fo_bhavcopy", con)
		'Dim rd1 As SqlDataReader = cmd1.ExecuteReader

		'Dim i As Integer
		'i = 0

		'While rd1.Read()

		'	DefineGlobals.symbol = rd1(0).ToString()
		betaStock()
		'End While

	End Sub

	Public Sub betaStock()

		Dim inStream1, inStream2 As StreamReader
		Dim webRequest1, webRequest2 As WebRequest
		Dim webresponse1, webresponse2 As WebResponse

		webRequest2 = WebRequest.Create("https://www.nseindia.com/marketinfo/sym_map/symbolCount.jsp?symbol=" & DefineGlobals.symbol & "")
		webresponse2 = webRequest2.GetResponse()
		inStream2 = New StreamReader(webresponse2.GetResponseStream())

		webRequest1 = WebRequest.Create("https://www.nseindia.com/products/dynaContent/common/productsSymbolMapping.jsp?symbol=" & DefineGlobals.symbol & "&segmentLink=3&symbolCount=1&series=ALL&dateRange=12month&fromDate=&toDate=&dataType=PRICEVOLUMEDELIVERABLE")
		webresponse1 = webRequest1.GetResponse()
		inStream1 = New StreamReader(webresponse1.GetResponseStream())
		Dim str = inStream1.ReadToEnd()

		str = Mid(str, str.IndexOf("<table"), str.Length)
		str = Mid(str, 1, str.IndexOf("</table>") + 8)
		str = str.Replace("</table>", "")
		str = Mid(str, str.IndexOf("<tr"), str.Length)
		str = str.Replace(vbCrLf, "").Replace(vbTab, "")

		'TextBox1.Text = str

		Dim delim As String() = New String(0) {"</tr>"}
		Dim arr = str.Split(delim, StringSplitOptions.None)

		Dim txt = ""
		Dim i = 0
		For i = 0 To arr.Length - 1

			If arr(i).IndexOf("<th") = -1 Then

				Dim temp1 = arr(i).Replace("<tr>", "")

				Dim delim_1 As String() = New String(0) {"</td>"}
				Dim arr2 = temp1.Split(delim_1, StringSplitOptions.None)


				Dim j = 0
				For j = 0 To arr2.Length - 2
					Dim temp2 = arr2(j).Replace("<td class=""normalText"" nowrap>", "")
					temp2 = temp2.Replace("<td class=""date"" nowrap>", "").Replace("<td class=""number"" nowrap>", "")
					txt = txt & temp2 & ","
				Next
				txt = txt & vbCrLf

			End If

		Next

		TextBox1.Text = txt
	End Sub
End Class