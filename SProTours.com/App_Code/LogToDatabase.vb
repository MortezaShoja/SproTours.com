Imports Microsoft.VisualBasic
Imports System.Data

Public Class LogToDatabase

    Private SqlCon As SqlConnectionSite
    Private SqlConHotels As SqlConnectionSite
    Private Cmd As SqlClient.SqlCommand

    Public Function GetRoomID(ByVal RoomType As String, ByVal HotelID As String) As Guid
        Dim Value As Guid = Guid.Empty

        Dim SqlConHotels As New SqlConnectionHotels
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select ID from Rooms Where HotelID='" & HotelID & "' and RoomType Like N'%" & RoomType.Trim & "%'"
            Cmd.Connection = SqlConHotels.SqlCon
            SqlConHotels.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConHotels.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Sub SetHotelRequestsStatus(ByVal RequestID As String, ByVal Status As String)
        Dim SqlConHotels As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "Update HotelRequests Set Status=N'" & Status & "',LastUpdate='" & Now.ToString & "' Where ID='" & RequestID & "'"
            Cmd.Connection = SqlConHotels.SqlCon
            SqlConHotels.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConHotels.SqlCon.Close()
        End Try
    End Sub

    Public Sub SetHotelRequestsPaymentStatus(ByVal RequestID As String, ByVal PaymentStatus As String)
        Dim SqlConHotels As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "Update HotelRequests Set PaymentStatus=N'" & PaymentStatus & "',LastUpdate='" & Now.ToString & "' Where ID='" & RequestID & "'"
            Cmd.Connection = SqlConHotels.SqlCon
            SqlConHotels.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConHotels.SqlCon.Close()
        End Try
    End Sub

    Public Function CheckMembersBalance(ByVal MemberID As String) As Array
        Dim Value(0) As String

        Dim SqlConBalance As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "select SUM(amount),CurrencyType from Accounting Where MemberID='" & MemberID & "' Group by CurrencyType"
            Cmd.Connection = SqlConBalance.SqlCon
            SqlConBalance.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            While sdr.Read
                Value(Value.Length - 1) = sdr(0) & " " & sdr(1)
                ReDim Preserve Value(Value.Length)
            End While
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConBalance.SqlCon.Close()
        End Try
        ReDim Preserve Value(Value.Length - 2)
        Return Value
    End Function

    Public Function CurrencyConvertor(ByVal FromCurrencyType As String, ByVal ToCurrencyType As String, ByVal Amount As Decimal) As Decimal
        Dim value As Decimal = 0

        Dim SqlConCorrencyConvertor As New SqlConnectionSite
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.CommandText = "Select Rate from CurrencyConvertor Where FromCurrencyType=N'" & FromCurrencyType & "' And ToCurrencyType=N'" & ToCurrencyType & "'"
            Cmd.Connection = SqlConCorrencyConvertor.SqlCon
            SqlConCorrencyConvertor.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = Amount * Decimal.Parse(sdr(0))
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlConCorrencyConvertor.SqlCon.Close()
        End Try

        Return value
    End Function


    Public Function LogHotelRequests(ByVal RequestID As String, ByVal MemberID As String, ByVal HotelID As String, ByVal CheckIn As String, ByVal CheckOut As String, ByVal NoOfRooms As String, ByVal NoOfAdults As String, ByVal NoOfChild As String, ByVal Description As String) As String
        Dim value As String = "Successful"

        'Public Sub LogHotelRequests(ByVal ID As String)
        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite
            Cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = RequestID
            Cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar).Value = MemberID
            Cmd.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = Now.ToString
            Cmd.Parameters.Add("@HotelID", SqlDbType.NVarChar).Value = HotelID
            Cmd.Parameters.Add("@CheckIn", SqlDbType.NVarChar).Value = CheckIn
            Cmd.Parameters.Add("@CheckOut", SqlDbType.NVarChar).Value = CheckOut
            Cmd.Parameters.Add("@NoOfAdults", SqlDbType.NVarChar).Value = NoOfAdults
            Cmd.Parameters.Add("@NoOfChild", SqlDbType.NVarChar).Value = NoOfChild
            Cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description

            Cmd.CommandText = "Insert Into HotelRequests (ID,MemberID,RequestDate,LastUpdate,HotelID,CheckIn,CheckOut,NoOfAdults,NoOfChild,[Description]) values (@ID,@MemberID,@RequestDate,@RequestDate,@HotelID,@CheckIn,@CheckOut,@NoOfAdults,@NoOfChild,@Description)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            value = ex.Message.ToString
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function


    Private Sub Withdraw(ByVal RequestID As String, ByVal MemberID As String, ByVal Amount As String)
        Dim tmpAmount() As String = Amount.ToString.Split(" ")

        If IsNumeric(tmpAmount(0).Replace(",", "")) Then
            Dim SqlConWithdraw As New SqlConnectionSite
            Try
                Dim Cmd As New SqlClient.SqlCommand
                Cmd.CommandText = "Insert Into Accounting (MemberID,Serial,Date,Amount,CurrencyType,Description,RegDate) Values ('" & MemberID & "','System','" & Now.ToString & "','" & (tmpAmount(0).Replace(",", "") * -1) & "',N'" & tmpAmount(1) & "','Withdraw','" & Now.ToString & "')"
                Cmd.Connection = SqlConWithdraw.SqlCon
                SqlConWithdraw.SqlCon.Open()
                Cmd.ExecuteNonQuery()
                SetHotelRequestsPaymentStatus(RequestID, "Paid")
                SetHotelRequestsStatus(RequestID, "Confirmed")
            Catch ex As Exception
                Dim ERM As New ErrorLog
                'ERM.Log()
            Finally
                SqlConWithdraw.SqlCon.Close()
            End Try
        End If
    End Sub

    Public Sub LogTourRequests(ByVal ID As String, ByVal RequestDate As String, ByVal MemberID As String, ByVal TourID As String, ByVal CheckIn As String, ByVal NoOfAdults As String, ByVal NoOfChild As String, ByVal ChildAge As Integer, ByVal Child1 As String, ByVal Child2 As String, ByVal Child3 As String, ByVal Child4 As String, ByVal Child5 As String, ByVal Child6 As String, ByVal Child7 As String, ByVal Name As String, ByVal Family As String, ByVal Phone As String, ByVal Email As String, ByVal Description As String, ByVal CurrencyType As String, ByVal CurrentRate As Decimal, ByVal AdultSinglePrice As Decimal, ByVal DiscountFromQTY As Integer, ByVal Discount As Decimal, ByVal AgencyCommission As Decimal, ByVal ChildDiscount As Decimal, ByVal ExtraServicesDetails As String, ByVal ExtraServicesTotal As Decimal, ByVal TotalPrice As Decimal, ByVal TotalTomanPrice As Decimal)
        'Public Sub LogHotelRequests(ByVal ID As String)
        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(ID)
            Cmd.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = RequestDate
            Cmd.Parameters.Add("@TourID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(TourID)
            Cmd.Parameters.Add("@MemberID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.Parameters.Add("@CheckIn", SqlDbType.Date).Value = CheckIn
            Cmd.Parameters.Add("@NoOfAdults", SqlDbType.Int).Value = NoOfAdults
            Cmd.Parameters.Add("@NoOfChild", SqlDbType.Int).Value = NoOfChild
            Cmd.Parameters.Add("@ChildAge", SqlDbType.Int).Value = ChildAge



            If Child1 = String.Empty Then
                Cmd.Parameters.Add("@Child1", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child1", SqlDbType.Int).Value = Child1
            End If

            If Child2 = String.Empty Then
                Cmd.Parameters.Add("@Child2", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child2", SqlDbType.Int).Value = Child2
            End If

            If Child3 = String.Empty Then
                Cmd.Parameters.Add("@Child3", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child3", SqlDbType.Int).Value = Child3
            End If

            If Child4 = String.Empty Then
                Cmd.Parameters.Add("@Child4", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child4", SqlDbType.Int).Value = Child4
            End If

            If Child5 = String.Empty Then
                Cmd.Parameters.Add("@Child5", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child5", SqlDbType.Int).Value = Child5
            End If

            If Child6 = String.Empty Then
                Cmd.Parameters.Add("@Child6", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child6", SqlDbType.Int).Value = Child6
            End If

            If Child7 = String.Empty Then
                Cmd.Parameters.Add("@Child7", SqlDbType.Int).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@Child7", SqlDbType.Int).Value = Child7
            End If

            Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name
            Cmd.Parameters.Add("@Family", SqlDbType.NVarChar).Value = Family
            Cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone
            Cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email
            Cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description

            Cmd.Parameters.Add("@CurrencyType", SqlDbType.NVarChar).Value = CurrencyType
            Cmd.Parameters.Add("@CurrentRate", SqlDbType.Decimal).Value = CurrentRate
            Cmd.Parameters.Add("@AdultSinglePrice", SqlDbType.Decimal).Value = AdultSinglePrice
            Cmd.Parameters.Add("@DiscountFromQTY", SqlDbType.Int).Value = DiscountFromQTY
            Cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount
            Cmd.Parameters.Add("@AgencyCommission", SqlDbType.Decimal).Value = AgencyCommission
            Cmd.Parameters.Add("@ChildDiscount", SqlDbType.Decimal).Value = ChildDiscount
            Cmd.Parameters.Add("@ExtraServicesDetails", SqlDbType.NVarChar).Value = ExtraServicesDetails
            Cmd.Parameters.Add("@ExtraServicesTotal", SqlDbType.Decimal).Value = ExtraServicesTotal
            Cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = TotalPrice
            Cmd.Parameters.Add("@TotalTomanPrice", SqlDbType.Decimal).Value = TotalTomanPrice

            Cmd.CommandText = "Insert Into TourRequests (ID,RequestDate,MemberID,TourID,CheckIn,NoOfAdults,NoOfChild,ChildAge,Child1,Child2,Child3,Child4,Child5,Child6,Child7,Name,Family,Phone,Email,Description,CurrencyType,CurrentRate,AdultSinglePrice,DiscountFromQTY,Discount,AgencyCommission,ChildDiscount,ExtraServicesDetails,ExtraServicesTotal,TotalPrice,TotalTomanPrice) values (@ID,@RequestDate,@MemberID,@TourID,@CheckIn,@NoOfAdults,@NoOfChild,@ChildAge,@Child1,@Child2,@Child3,@Child4,@Child5,@Child6,@Child7,@Name,@Family,@Phone,@Email,@Description,@CurrencyType,@CurrentRate,@AdultSinglePrice,@DiscountFromQTY,@Discount,@AgencyCommission,@ChildDiscount,@ExtraServicesDetails,@ExtraServicesTotal,@TotalPrice,@TotalTomanPrice)"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub

    Public Function GetTourRequestCode(ByVal RequestID As String) As Integer
        Dim value As Integer = 0

        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(RequestID)
            Cmd.CommandText = "Select RequestCode From TourRequests where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

    Public Function GetTourPaymentInfo(ByVal Code As Integer) As Integer
        Dim value As Integer = 0

        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = Code
            Cmd.CommandText = "Select TotalPrice From Payments where Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                value = sdr(0)
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return value
    End Function

    Public Sub UpdateTourPayment(ByVal PaymentCode As Integer, ByVal PaymentRefnum As String, ByVal EmailHtmlPath As String)
        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            Cmd.Parameters.Add("@PaymentRefnum", SqlDbType.NVarChar).Value = PaymentRefnum
            Cmd.CommandText = "Update Payments Set Status=N'پرداخت شد',PaymentRefnum=@PaymentRefnum where Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        '------------------------------------------
        Dim PaymentID As String = String.Empty
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@Code", SqlDbType.Int).Value = PaymentCode
            Cmd.CommandText = "Select ID from Payments Where Code=@Code"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                PaymentID = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
        '------------------------------------------
        Try
            Dim Cmd As New SqlClient.SqlCommand
            Cmd.Parameters.Add("@PaymentID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(PaymentID)
            Cmd.CommandText = "Update TourRequests Set Status=N'خریداری شد' Where PaymentID=@PaymentID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try

        SendTourVoucher(PaymentCode, PaymentRefnum, EmailHtmlPath)
    End Sub

    Private Sub SendTourVoucher(ByVal PaymentCode As Integer, ByVal PaymentRefnum As String, ByVal EmailHtmlPath As String)
        Dim CHE As New CreateHTMLEmail
        Dim HTMLDoc() As Object = CHE.CreateToursVoucher(PaymentCode, EmailHtmlPath)
        Dim SE As New SendEmail
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "EmailMaster2017", "Tours@SproTours.com", HTMLDoc(0), "Tour Reservation", "")
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "EmailMaster2017", HTMLDoc(1), HTMLDoc(0), "Tour Voucher", "")
        '-------------------------------------------------
        Dim ReceiptHtmlDoc As Object = CHE.CreateReceipt(PaymentCode, EmailHtmlPath)
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "EmailMaster2017", "Tours@SproTours.com", ReceiptHtmlDoc, "Payment Receipt", "")
        SE.Sender("noreply@SproTours.com", "Sprotours.com", "EmailMaster2017", HTMLDoc(1), ReceiptHtmlDoc, "Payment Receipt", "")

        ReceiptHtmlDoc = Nothing
        HTMLDoc = Nothing
    End Sub

    Public Sub LogFlightRequests(ByVal ID As String, ByVal RequestDate As String, ByVal FlyFrom As String, ByVal FlyTo As String, ByVal RaftDate As String, ByVal BargastDate As String, ByVal FlightClass As String, ByVal NoOfAdult As Integer, ByVal NoOfYouth As Integer, ByVal NoOfChild As Integer, ByVal Name As String, ByVal Family As String, ByVal Phone As String, ByVal Email As String, ByVal Descriptions As String)
        'Public Sub LogHotelRequests(ByVal ID As String)
        Try
            Cmd = New SqlClient.SqlCommand
            SqlCon = New SqlConnectionSite

            Cmd.CommandText = "Insert Into FlightRequests (ID,RequestDate,FlyFrom,FlyTo,RaftDate,BargashtDate,FlightClass,NoOfAdult,NoOfYouth,NoOfChild,Name,Family,Phone,Email,[Description]) values ('" & ID & "','" & RequestDate & "',N'" & FlyFrom & "',N'" & FlyTo & "','" & RaftDate & "','" & BargastDate & "',N'" & FlightClass & "','" & NoOfAdult & "','" & NoOfYouth & "','" & NoOfChild & "',N'" & Name & "',N'" & Family & "',N'" & Phone & "',N'" & Email & "',N'" & Descriptions & "')"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim ERM As New ErrorLog
            'ERM.Log()
        Finally
            SqlCon.SqlCon.Close()
        End Try
    End Sub



End Class
