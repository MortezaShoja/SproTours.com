Imports Microsoft.VisualBasic
Imports System.Data

Public Class MemberInfo

    Public Function GetMemberType(ByVal MemberID As String) As String
        Dim Value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Try
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.CommandText = "Select UserType from Members where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", MemberID, ex.StackTrace, ex.Message, Cmd.CommandText, "MemberInfo", "GetMemberType")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Return Value
    End Function

    Public Function GetMobileNumber(ByVal MemberID As String) As String
        Dim Value As String = String.Empty

        Dim SqlCon As New SqlConnectionSite
        Dim Cmd As New SqlClient.SqlCommand

        Try
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(MemberID)
            Cmd.CommandText = "Select Mobile from Members where ID=@ID"
            Cmd.Connection = SqlCon.SqlCon
            SqlCon.SqlCon.Open()
            Dim sdr As SqlClient.SqlDataReader = Cmd.ExecuteReader
            If sdr.Read Then
                Value = sdr(0).ToString
            End If
        Catch ex As Exception
            Dim ERM As New ErrorLog
            ERM.Log(Nothing, "Error", MemberID, ex.StackTrace, ex.Message, Cmd.CommandText, "MemberInfo", "GetMobileNumber")
        Finally
            SqlCon.SqlCon.Close()
        End Try

        Dim Tmp As String = GetArabicNumber(Value)
        If IsNumeric(Tmp) = False Then
            Value = String.Empty

        End If
        Return Value
    End Function

    Private Function GetArabicNumber(ByVal Number As String)
        Dim Value As String = Number
        Value = Value.Replace("۰", "0")
        Value = Value.Replace("۱", "1")
        Value = Value.Replace("۲", "2")
        Value = Value.Replace("۳", "3")
        Value = Value.Replace("۴", "4")
        Value = Value.Replace("۵", "5")
        Value = Value.Replace("۶", "6")
        Value = Value.Replace("۷", "7")
        Value = Value.Replace("۸", "8")
        Value = Value.Replace("۹", "9")
        Return Value
    End Function

End Class
