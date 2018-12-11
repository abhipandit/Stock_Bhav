Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Data.OleDb
Imports System.Data.SqlClient

Imports Excel = Microsoft.Office.Interop.Excel          ' EXCEL APPLICATION.


Public Class Form1
	Dim xlApp As Excel.Application
	Dim xlWorkBook As Excel.Workbook
	Dim xlWorkSheet As Excel.Worksheet

	Dim downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		'Try
		CreateDates()
			excelData()
			'MsgBox(downloadpath)
		'Form2.Visible = True
		'Me.Close()
		''Catch ex As Exception
		'	MsgBox("Data not available for one of these dates")
		'End Try
	End Sub




	Public Function CreateDates()

		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If

		Dim currentDate_1 As DateTime

		Dim date_ctr = 0

		Dim con_chk As New SqlConnection


		con_chk.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True"
		con_chk.Open()

		For date_ctr = 1 To 3

			If date_ctr = 1 Then
				currentDate_1 = DateTimePicker1.Value
			End If
			If date_ctr = 2 Then
				currentDate_1 = DateTimePicker2.Value
			End If
			If date_ctr = 3 Then
				currentDate_1 = DateTimePicker3.Value
			End If

			Dim day_val = ""
			If currentDate_1.Day < 10 Then
				day_val = "0" & currentDate_1.Day
			Else
				day_val = currentDate_1.Day
			End If


			Dim file_name_1 = "cm" & day_val & MonthName(currentDate_1.Month, True).ToUpper() & currentDate_1.Year & "bhav.csv.zip"
			Dim file_name_2 = currentDate_1.Year & "/" & MonthName(currentDate_1.Month, True).ToUpper() & "/cm" & day_val & MonthName(currentDate_1.Month, True).ToUpper() & currentDate_1.Year & "bhav.csv.zip"

			Dim cmd_chk_1 As New SqlCommand
			cmd_chk_1.Connection = con_chk
			cmd_chk_1.CommandText = "select count(*) as t1 From bhavcopy where cast(TIMESTAMP as date)= '" & currentDate_1 & "'"
			If cmd_chk_1.ExecuteScalar = 0 Then
				DownloadBhavCopy(file_name_1, file_name_2, currentDate_1)
			End If

			Dim dat_name_1 = "MTO_" & day_val & currentDate_1.Month & currentDate_1.Year & ".DAT"
			Dim cmd_chk_2 As New SqlCommand
			cmd_chk_2.Connection = con_chk
			cmd_chk_2.CommandText = "select count(*) From Delivery_Position where cast(TIMESTAMP as date)= '" & currentDate_1 & "'"
			If cmd_chk_2.ExecuteScalar = 0 Then
				DownloadSecurityDat(dat_name_1, dat_name_1, currentDate_1)
			End If

			Dim vol_name_1 = "CMVOLT_" & day_val & currentDate_1.Month & currentDate_1.Year & ".CSV"
			Dim cmd_chk_3 As New SqlCommand
			cmd_chk_3.Connection = con_chk
			cmd_chk_3.CommandText = "select count(*) From CMVOLT where cast(TIMESTAMP as date)= '" & currentDate_1 & "'"
			If cmd_chk_3.ExecuteScalar = 0 Then
				DownloadVolt(vol_name_1, vol_name_1, currentDate_1)
			End If

			Dim fobhavcopy_1 = "fo" & day_val & MonthName(currentDate_1.Month, True).ToUpper() & currentDate_1.Year & "bhav.csv.zip"
			Dim fobhavcopy_2 = currentDate_1.Year & "/" & MonthName(currentDate_1.Month, True).ToUpper() & "/fo" & day_val & MonthName(currentDate_1.Month, True).ToUpper() & currentDate_1.Year & "bhav.csv.zip"


			Dim cmd_chk_4 As New SqlCommand
			cmd_chk_4.Connection = con_chk
			cmd_chk_4.CommandText = "select count(*) From fo_bhavcopy where cast(TIMESTAMP as date)= '" & currentDate_1 & "'"
			If cmd_chk_4.ExecuteScalar = 0 Then
				DownloadFOCopy(fobhavcopy_1, fobhavcopy_2, currentDate_1)
			End If

			Dim indClose_1 = "ind_close_all_" & day_val & currentDate_1.Month & currentDate_1.Year & ".csv"
			Dim cmd_chk_5 As New SqlCommand
			cmd_chk_5.Connection = con_chk
			cmd_chk_5.CommandText = "select count(*) From index_close where cast(index_date as date)= '" & currentDate_1 & "'"
			If cmd_chk_5.ExecuteScalar = 0 Then
				DownloadIndexClose(indClose_1, indClose_1, currentDate_1)
			End If

		Next

		con_chk.Close()
		MsgBox("Download Done")

	End Function

	Public Function DownloadVolt(filename As String, filepath As String, downloadDt As DateTime)

		Dim wc As New WebClient

		Dim fileurl As String = "https://www.nseindia.com/archives/nsccl/volt/" & filepath

		downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"
		Dim downloadDay = ""
		If downloadDt.Day < 10 Then
			downloadDay = "0" & downloadDt.Day
		Else
			downloadDay = downloadDt.Day
		End If

		downloadpath = downloadpath & "\" & downloadDt.Month & "" & downloadDay & "" & downloadDt.Year

		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If

		Dim filelocation As String = downloadpath & "\" & filename

		wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
		wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1"

		wc.DownloadFile(fileurl, filelocation)

			ToDataTable(filelocation, "CMVOLT")

	End Function

	Public Function DownloadFOCopy(filename As String, filepath As String, downloadDt As DateTime)

		Dim wc As New WebClient

		Dim fileurl As String = "https://www.nseindia.com/content/historical/DERIVATIVES/" & filepath

		downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"

		Dim downloadDay = ""
		If downloadDt.Day < 10 Then
			downloadDay = "0" & downloadDt.Day
		Else
			downloadDay = downloadDt.Day
		End If

		downloadpath = downloadpath & "\" & downloadDt.Month & "" & downloadDay & "" & downloadDt.Year


		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If
		Dim filelocation As String = downloadpath & "\" & filename

		wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
		wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1"


		wc.DownloadFile(fileurl, filelocation)

			ExtractZip(filelocation, "fo_bhavcopy")

	End Function
	Public Function DownloadBhavCopy(filename As String, filepath As String, downloadDt As DateTime)

		Dim wc As New WebClient

		Dim fileurl As String = "https://www.nseindia.com/content/historical/EQUITIES/" & filepath

		downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"

		Dim downloadDay = ""
		If downloadDt.Day < 10 Then
			downloadDay = "0" & downloadDt.Day
		Else
			downloadDay = downloadDt.Day
		End If

		downloadpath = downloadpath & "\" & downloadDt.Month & "" & downloadDay & "" & downloadDt.Year

		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If
		Dim filelocation As String = downloadpath & "\" & filename

		wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
		wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1"

		wc.DownloadFile(fileurl, filelocation)

		ExtractZip(filelocation, "bhavcopy")
	End Function
	Public Function DownloadIndexClose(filename As String, filepath As String, dat_date As DateTime)

		Dim wc As New WebClient
		wc.Proxy = WebRequest.GetSystemWebProxy()
		Dim fileurl As String = "https://www.nseindia.com/content/indices/" & filepath

		downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"

		Dim downloadDay = ""
		If dat_date.Day < 10 Then
			downloadDay = "0" & dat_date.Day
		Else
			downloadDay = dat_date.Day
		End If

		downloadpath = downloadpath & "\" & dat_date.Month & "" & downloadDay & "" & dat_date.Year

		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If
		Dim filelocation As String = downloadpath & "\" & filename

		wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
		wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1"

		wc.DownloadFile(fileurl, filelocation)

		ToDataTable(filelocation, "index_close")

	End Function
	Public Function DownloadSecurityDat(filename As String, filepath As String, dat_date As DateTime)

		Dim wc As New WebClient

		Dim fileurl As String = "https://www.nseindia.com/archives/equities/mto/" & filepath

		downloadpath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\Downloads") & "\stock_files"

		Dim downloadDay = ""
		If dat_date.Day < 10 Then
			downloadDay = "0" & dat_date.Day
		Else
			downloadDay = dat_date.Day
		End If

		downloadpath = downloadpath & "\" & dat_date.Month & "" & downloadDay & "" & dat_date.Year

		If (Not System.IO.Directory.Exists(downloadpath)) Then
			System.IO.Directory.CreateDirectory(downloadpath)
		End If
		Dim filelocation As String = downloadpath & "\" & filename

		wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
		wc.Headers("User-Agent") = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.83 Safari/537.1"

		wc.DownloadFile(fileurl, filelocation)

		ReadDat(filelocation, dat_date)

	End Function


	Public Function ReadDat(datPath As String, dat_date As DateTime)


		Dim folderPath = Path.GetDirectoryName(datPath)
		Dim FilePath = Path.GetFileName(datPath)

		folderPath = folderPath

		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		Dim lines As String() = File.ReadAllLines(datPath)


		Try
			con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True"
			con.Open()
			cmd.Connection = con

			cmd.CommandText = "Delete From Delivery_Position where cast(TIMESTAMP as date)= '" & dat_date & "'"
			cmd.ExecuteNonQuery()


			For i As Integer = 4 To lines.Length - 1

				Dim id1 As Integer = Convert.ToInt32(lines(i).Split(","c)(0))
				Dim id2 As Integer = Convert.ToInt32(lines(i).Split(","c)(1))
				Dim id3 As String = Convert.ToString(lines(i).Split(","c)(2))
				Dim id4 As String = Convert.ToString(lines(i).Split(","c)(3))
				Dim id5 As Double = Convert.ToDouble(lines(i).Split(","c)(4))
				Dim id6 As Double = Convert.ToDouble(lines(i).Split(","c)(5))

				If id4 = "EQ" Then

					cmd.CommandText = "insert into Delivery_Position values(" & id1 & "," & id2 & ",'" & id3 & "','" & id4 & "'," & id5 & "," & id6 & ",'" & dat_date & "')"
					cmd.ExecuteNonQuery()

				End If
			Next


		Catch ex As Exception
			MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")

		Finally

			con.Close()
		End Try




	End Function

	Public Function ReadIndex(datPath As String, dat_date As DateTime)


		Dim folderPath = Path.GetDirectoryName(datPath)
		Dim FilePath = Path.GetFileName(datPath)

		folderPath = folderPath

		Dim con As New SqlConnection
		Dim cmd As New SqlCommand

		Dim lines As String() = File.ReadAllLines(datPath)


		Try
			con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True"
			con.Open()
			cmd.Connection = con

			cmd.CommandText = "Delete From index_close where cast(index_date as date)= '" & dat_date & "'"
			cmd.ExecuteNonQuery()


			For i As Integer = 4 To lines.Length - 1

				Dim id1 As Integer = Convert.ToInt32(lines(i).Split(","c)(0))
				Dim id2 As Integer = Convert.ToInt32(lines(i).Split(","c)(1))
				Dim id3 As String = Convert.ToString(lines(i).Split(","c)(2))
				Dim id4 As String = Convert.ToString(lines(i).Split(","c)(3))
				Dim id5 As Double = Convert.ToDouble(lines(i).Split(","c)(4))
				Dim id6 As Double = Convert.ToDouble(lines(i).Split(","c)(5))

				Dim id7 As Double = Convert.ToDouble(lines(i).Split(","c)(6))
				Dim id8 As Double = Convert.ToDouble(lines(i).Split(","c)(7))
				Dim id9 As Double = Convert.ToDouble(lines(i).Split(","c)(8))
				Dim id10 As Double = Convert.ToDouble(lines(i).Split(","c)(9))
				Dim id11 As Double = Convert.ToDouble(lines(i).Split(","c)(10))
				Dim id12 As Double = Convert.ToDouble(lines(i).Split(","c)(11))

				cmd.CommandText = "insert into index_close values(" & id1 & ",'" & id2 & "'," & id3 & "," & id4 & "," & id5 & "," & id6 & "," & dat_date & ")"
				cmd.ExecuteNonQuery()

			Next


		Catch ex As Exception
			MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")

		Finally

			con.Close()
		End Try




	End Function


	Public Function ExtractZip(fileZip As String, TableName As String)
		Dim zipPath As String = fileZip
		Dim extractPath As String = fileZip.Replace(".zip", "")

		If (System.IO.Directory.Exists(extractPath)) Then

			Dim di As New IO.DirectoryInfo(extractPath)
			di.Delete(True)
		End If



		ZipFile.ExtractToDirectory(zipPath, extractPath)

		Dim csvFile = extractPath & "\" & Path.GetFileName(fileZip)
		csvFile = csvFile.Replace(".zip", "")
		ToDataTable(fileZip, TableName)
	End Function

	Public Function ToDataTable(FileName As String, TableName As String, Optional Delimiter As String = ",") As DataTable


		Dim folderPath = Path.GetDirectoryName(FileName.ToLower())
		Dim FilePath = Path.GetFileName(FileName).Replace(".zip", "")


		'If TableName = "CMVOLT" Then
		'folderPath = folderPath.Replace("\" & FileName, "")
		'End If

		If TableName = "bhavcopy" Or TableName = "fo_bhavcopy" Then

			folderPath = folderPath & "\" & FilePath
		End If

		Dim CnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folderPath & ";Extended Properties=""text;HDR=No;FMT=Delimited"";"
		Dim dt As New DataTable

		If TableName = "fo_bhavcopy" Then
			Using Adp As New OleDbDataAdapter("select * from [" & FilePath & "]", CnStr)
				Adp.Fill(dt)
			End Using
		Else
			Using Adp As New OleDbDataAdapter("select * from [" & FilePath & "]", CnStr)
				Adp.Fill(dt)
			End Using
		End If


		Dim test As String = ""
		test = ""

		Dim iRow As Integer = 0
		Dim iCol As Integer = 0


		Dim con As New SqlConnection



		'Try
		con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True"
			con.Open()

		Dim delFlag As Boolean = False
			For Each dr In dt.Rows
			Dim cmd As New SqlCommand
			cmd.Connection = con
			If iRow <> 0 Then

				If delFlag = False Then
					If TableName = "bhavcopy" Then
						cmd.CommandText = "Delete From " & TableName & " where cast(TIMESTAMP as date)= '" & dr.ItemArray(10) & "'"
						cmd.ExecuteNonQuery()
					End If
					If TableName = "fo_bhavcopy" Then
						cmd.CommandText = "Delete From " & TableName & " where cast(TIMESTAMP as date)= '" & dr.ItemArray(14) & "'"
						cmd.ExecuteNonQuery()
					End If
					If TableName = "CMVOLT" Then
						cmd.CommandText = "Delete From " & TableName & " where cast(TIMESTAMP as date)= '" & dr.ItemArray(0) & "'"
						cmd.ExecuteNonQuery()
					End If
					If TableName = "index_close" Then
						cmd.CommandText = "Delete From " & TableName & " where cast(index_date as date)= '" & dr.ItemArray(1) & "'"
						cmd.ExecuteNonQuery()
					End If
					delFlag = True
				End If

				If TableName = "index_close" Then
					cmd.CommandText = "insert into index_close values(@index_name,@index_date,@open_index_value,@high_index_value,@low_index_value,@closing_index_value,@points_change,@change_per,@volume,@turnover,@P_E,@P_B,@div_yeild)"

					cmd.Parameters.AddWithValue("@index_name", dr.ItemArray(0))
					cmd.Parameters.AddWithValue("@index_date", dr.ItemArray(1))
					cmd.Parameters.AddWithValue("@open_index_value", dr.ItemArray(2))
					cmd.Parameters.AddWithValue("@high_index_value", dr.ItemArray(3))
					cmd.Parameters.AddWithValue("@low_index_value", dr.ItemArray(4))
					cmd.Parameters.AddWithValue("@closing_index_value", dr.ItemArray(5))
					cmd.Parameters.AddWithValue("@points_change", dr.ItemArray(6))
					cmd.Parameters.AddWithValue("@change_per", dr.ItemArray(7))
					cmd.Parameters.AddWithValue("@volume", dr.ItemArray(8))
					cmd.Parameters.AddWithValue("@turnover", dr.ItemArray(9))
					cmd.Parameters.AddWithValue("@P_E", dr.ItemArray(10))
					cmd.Parameters.AddWithValue("@P_B", dr.ItemArray(11))
					cmd.Parameters.AddWithValue("@div_yeild", dr.ItemArray(12))

					cmd.ExecuteNonQuery()
				ElseIf TableName = "bhavcopy" And dr.ItemArray(1) = "EQ" Then
					cmd.CommandText = "insert into bhavcopy values('" & dr.ItemArray(0) & "','" & dr.ItemArray(1) & "'," & dr.ItemArray(2) & "," & dr.ItemArray(3) & "," & dr.ItemArray(4) & "," & dr.ItemArray(5) & "," & dr.ItemArray(6) & "," & dr.ItemArray(7) & "," & dr.ItemArray(8) & "," & dr.ItemArray(9) & ",'" & dr.ItemArray(10) & "'," & dr.ItemArray(11) & ",'" & dr.ItemArray(12) & "')"
					cmd.ExecuteNonQuery()
				ElseIf TableName = "CMVOLT" Then
					If dr.ItemArray(2).ToString() <> "" Then
						cmd.CommandText = "insert into CMVOLT values(@TIMESTAMP,@Symbol,@Underlying_Close_Price,@Underlying_Previous_Day_Close_Price,@Underlying_Log_Returns,@Previous_Day_Underlying_Volatility,@Current_Day_Underlying_Daily_Volatility,@Underlying_Annualised_Volatility)"
						cmd.Parameters.AddWithValue("@TIMESTAMP", dr.ItemArray(0))
						cmd.Parameters.AddWithValue("@Symbol", dr.ItemArray(1))
						cmd.Parameters.AddWithValue("@Underlying_Close_Price", dr.ItemArray(2))
						cmd.Parameters.AddWithValue("@Underlying_Previous_Day_Close_Price", dr.ItemArray(3))
						cmd.Parameters.AddWithValue("@Underlying_Log_Returns", dr.ItemArray(4))
						cmd.Parameters.AddWithValue("@Previous_Day_Underlying_Volatility", dr.ItemArray(5))
						cmd.Parameters.AddWithValue("@Current_Day_Underlying_Daily_Volatility", dr.ItemArray(6))
						cmd.Parameters.AddWithValue("@Underlying_Annualised_Volatility", dr.ItemArray(7))
						cmd.ExecuteNonQuery()
					End If
				ElseIf TableName = "fo_bhavcopy" And dr.ItemArray(0) = "FUTSTK" Then
					cmd.CommandText = "insert into fo_bhavcopy values('" & dr.ItemArray(0) & "','" & dr.ItemArray(1) & "','" & dr.ItemArray(2) & "'," & dr.ItemArray(3) & ",'" & dr.ItemArray(4) & "'," & dr.ItemArray(5) & "," & dr.ItemArray(6) & "," & dr.ItemArray(7) & "," & dr.ItemArray(8) & "," & dr.ItemArray(9) & "," & dr.ItemArray(10) & "," & dr.ItemArray(11) & "," & dr.ItemArray(12) & "," & dr.ItemArray(13) & ",'" & dr.ItemArray(14) & "')"
					cmd.ExecuteNonQuery()
				End If

			End If


			iRow = iRow + 1
			Next dr

			'Catch ex As Exception
			'	MessageBox.Show("Error CMVOLT Records..." & ex.Message, "")

			'		Finally

			con.Close()
		'End Try






	End Function

	Private Sub excelData()

		Dim excelPath_src = Directory.GetCurrentDirectory()
		Dim excelPath_name = "\Stock-Analysis_SwingTrading.xlsb"


		If System.IO.File.Exists(excelPath_src & "\Stock-Analysis_SwingTrading_new.xlsb") = True Then
			System.IO.File.Delete(excelPath_src & "\Stock-Analysis_SwingTrading_new.xlsb")
		End If

		Dim file = New FileInfo(excelPath_src & "\" & excelPath_name)
		file.CopyTo(Path.Combine(excelPath_src, "Stock-Analysis_SwingTrading_new.xlsb"), True)

		xlApp = New Excel.Application
		xlWorkBook = xlApp.Workbooks.Open(excelPath_src & "\" & "Stock-Analysis_SwingTrading_new.xlsb")           ' WORKBOOK TO OPEN THE EXCEL FILE.
		xlApp.Visible = True
		xlWorkSheet = xlWorkBook.Worksheets("Analysis")    ' THE NAME OF THE WORK SHEET. 
		Dim con As New SqlConnection

		'Try
		con.ConnectionString = "Data Source=(local);Initial Catalog=bhavcopy;Integrated Security=True;MultipleActiveResultSets=True"
		con.Open()

		Dim cmd1 As New SqlCommand("select distinct symbol as s1 from fo_bhavcopy", con)
		Dim rd1 As SqlDataReader = cmd1.ExecuteReader

		Dim i As Integer
		i = 0

		While rd1.Read()

				Dim sql_1 = "select t1.symbol,t1.series,"
				sql_1 = sql_1 & " t2.[LAST],t3.[LAST],t1.[LAST],"
				sql_1 = sql_1 & " t2.[TOTALTRADES],t3.[TOTALTRADES],t1.[TOTALTRADES],"
				sql_1 = sql_1 & " Round(t2.TOTTRDVAL/10000000,2) as n1,Round(t3.TOTTRDVAL/10000000,2) as n2,Round(t1.TOTTRDVAL/10000000,2) as n3,"
				sql_1 = sql_1 & " d1.percent_delivery,d2.percent_delivery,d3.percent_delivery"
				sql_1 = sql_1 & " ,f1.contracts,f2.contracts,f3.contracts"
				sql_1 = sql_1 & " ,(c1.Current_Day_Underlying_Daily_Volatility*100),(c2.Current_Day_Underlying_Daily_Volatility*100),(c3.Current_Day_Underlying_Daily_Volatility*100) "
				sql_1 = sql_1 & " ,f1.[CLOSE],f2.[CLOSE],f3.[CLOSE]"
				sql_1 = sql_1 & " from bhavcopy as t1 "
				sql_1 = sql_1 & " left join bhavcopy as t2 on t1.SYMBOL=t2.symbol"
				sql_1 = sql_1 & " and cast(t2.timestamp as date)=cast('" & DateTimePicker1.Value & "' as date) "
				sql_1 = sql_1 & " left join bhavcopy as t3 on t1.SYMBOL=t3.symbol "
				sql_1 = sql_1 & " and cast(t3.timestamp as date)=cast('" & DateTimePicker2.Value & "' as date) "
				sql_1 = sql_1 & " left join Delivery_Position as d1 on t1.SYMBOL=d1.Name_of_Security "
				sql_1 = sql_1 & " and cast(d1.timestamp as date)=cast('" & DateTimePicker1.Value & "' as date) "
				sql_1 = sql_1 & " left join Delivery_Position as d2 on t1.SYMBOL=d2.Name_of_Security "
				sql_1 = sql_1 & " and cast(d2.timestamp as date)=cast('" & DateTimePicker2.Value & "' as date) "
				sql_1 = sql_1 & " left join Delivery_Position as d3 on t1.SYMBOL=d3.Name_of_Security"
				sql_1 = sql_1 & " and cast(d3.timestamp as date)=cast('" & DateTimePicker3.Value & "' as date)"
				sql_1 = sql_1 & " left join fo_bhavcopy as f1 on t1.SYMBOL=f1.SYMBOL "
				sql_1 = sql_1 & " and cast(f1.timestamp as date)=cast('" & DateTimePicker1.Value & "' as date)"
				sql_1 = sql_1 & " and MONTH(GETDATE())=Month(f1.EXPIRY_DT)"
				sql_1 = sql_1 & " left join fo_bhavcopy as f2 on t1.SYMBOL=f2.SYMBOL"
				sql_1 = sql_1 & " and cast(f2.timestamp as date)=cast('" & DateTimePicker2.Value & "' as date)"
				sql_1 = sql_1 & " and MONTH(GETDATE())=Month(f2.EXPIRY_DT)"
				sql_1 = sql_1 & " left join fo_bhavcopy as f3 on t1.SYMBOL=f3.SYMBOL"
				sql_1 = sql_1 & " and cast(f3.timestamp as date)=cast('" & DateTimePicker3.Value & "' as date)"
				sql_1 = sql_1 & " and MONTH(GETDATE())=Month(f3.EXPIRY_DT)"
				sql_1 = sql_1 & " left join CMVOLT as c1 on t1.SYMBOL=c1.Symbol"
				sql_1 = sql_1 & " and cast(c1.timestamp as date)=cast('" & DateTimePicker1.Value & "' as date)"
				sql_1 = sql_1 & " left join CMVOLT as c2 on t1.SYMBOL=c2.Symbol"
				sql_1 = sql_1 & " and cast(c2.timestamp as date)=cast('" & DateTimePicker2.Value & "' as date)"
				sql_1 = sql_1 & " left join CMVOLT as c3 on t1.SYMBOL=c3.Symbol"
				sql_1 = sql_1 & " and cast(c3.timestamp as date)=cast('" & DateTimePicker3.Value & "' as date)"
				sql_1 = sql_1 & " where "
				sql_1 = sql_1 & " t1.symbol ='" & rd1(0) & "'"
				sql_1 = sql_1 & " and cast(t1.timestamp as date)=cast('" & DateTimePicker3.Value & "' as date)"
				sql_1 = sql_1 & " order by t1.TIMESTAMP"

				Dim cmd2 As New SqlCommand(sql_1, con)
				Dim rd2 As SqlDataReader = cmd2.ExecuteReader

				Dim j As Integer
				j = 0
				While rd2.Read()
					xlWorkSheet.Cells(i + 5, 1) = rd2(0).ToString()
					xlWorkSheet.Cells(i + 5, 5) = rd2(2).ToString()
					xlWorkSheet.Cells(i + 5, 6) = rd2(3).ToString()
					xlWorkSheet.Cells(i + 5, 7) = rd2(4).ToString()
					xlWorkSheet.Cells(i + 5, 10) = rd2(5).ToString()
					xlWorkSheet.Cells(i + 5, 11) = rd2(6).ToString()
					xlWorkSheet.Cells(i + 5, 12) = rd2(7).ToString()

					xlWorkSheet.Cells(i + 5, 17) = rd2(8).ToString()
					xlWorkSheet.Cells(i + 5, 18) = rd2(9).ToString()
					xlWorkSheet.Cells(i + 5, 19) = rd2(10).ToString()

					xlWorkSheet.Cells(i + 5, 24) = rd2(11).ToString()
					xlWorkSheet.Cells(i + 5, 25) = rd2(12).ToString()
					xlWorkSheet.Cells(i + 5, 26) = rd2(13).ToString()

					xlWorkSheet.Cells(i + 5, 33) = rd2(14).ToString()
					xlWorkSheet.Cells(i + 5, 34) = rd2(15).ToString()
					xlWorkSheet.Cells(i + 5, 35) = rd2(16).ToString()

					xlWorkSheet.Cells(i + 5, 40) = rd2(17).ToString()
					xlWorkSheet.Cells(i + 5, 41) = rd2(18).ToString()
					xlWorkSheet.Cells(i + 5, 42) = rd2(19).ToString()

					xlWorkSheet.Cells(i + 5, 47) = rd2(20).ToString()
					xlWorkSheet.Cells(i + 5, 48) = rd2(21).ToString()
					xlWorkSheet.Cells(i + 5, 49) = rd2(22).ToString()

					j = j + 1

				End While
				rd2.Close()
				cmd2 = Nothing
				i = i + 1
			End While
			rd1.Close()


			xlWorkSheet = xlWorkBook.Worksheets("BHAV_COPY")

			Dim cmd3 As New SqlCommand("select * from bhavcopy where cast(timestamp as date)=cast('" & DateTimePicker3.Value & "' as date)", con)
		Dim rd3 As SqlDataReader = cmd3.ExecuteReader

		Dim k As Integer
		k = 1

		Dim fArray(1, 12) As String

		While rd3.Read()
			fArray(0, 0) = rd3(0).ToString()

			fArray(0, 1) = rd3(1).ToString()
			fArray(0, 2) = rd3(2).ToString()
			fArray(0, 3) = rd3(3).ToString()
			fArray(0, 4) = rd3(4).ToString()
			fArray(0, 5) = rd3(5).ToString()
			fArray(0, 6) = rd3(6).ToString()
			fArray(0, 7) = rd3(7).ToString()
			fArray(0, 8) = rd3(8).ToString()
			fArray(0, 9) = rd3(9).ToString()
			fArray(0, 10) = rd3(10).ToString()
			fArray(0, 11) = rd3(11).ToString()
			fArray(0, 12) = rd3(12).ToString()


			xlWorkSheet.Range("A" & (k + 1) & ":M" & (k + 1 + 13) & "").Value2 = fArray


			k = k + 1
		End While


		'Catch ex As Exception
		'	MessageBox.Show("Error CMVOLT Records..." & ex.Message, "")
		'Finally
		con.Close()



		'End Try


		'xlWorkBook.Close() : xlApp.Quit()

		' CLEAN UP. (CLOSE INSTANCES OF EXCEL OBJECTS.)
		'System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp) : xlApp = Nothing
		'System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook) : xlWorkBook = Nothing
		'System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet) : xlWorkSheet = Nothing


		MsgBox("excel done")

	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Form3.Visible = True

		If DateTime.Now.TimeOfDay.Hours <= 20 Then
			DateTimePicker1.Value = Convert.ToDateTime(Now().AddDays(-3))
			DateTimePicker2.Value = Convert.ToDateTime(Now().AddDays(-2))
			DateTimePicker3.Value = Convert.ToDateTime(Now().AddDays(-1))
		Else
			DateTimePicker1.Value = Convert.ToDateTime(Now().AddDays(-2))
			DateTimePicker2.Value = Convert.ToDateTime(Now().AddDays(-1))
			DateTimePicker3.Value = Convert.ToDateTime(Now())

		End If

	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		AllBhavCopy.Visible = True
	End Sub
End Class
