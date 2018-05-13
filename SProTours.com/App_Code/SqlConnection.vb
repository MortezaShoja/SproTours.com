Imports Microsoft.VisualBasic

Public Class SqlConnectionSite
    'Public SqlCon As New System.Data.SqlClient.SqlConnection("server=localhost;user id=sa;pwd=SqlServer2008Master;data source=localhost;database=Sprotours")
    Public SqlCon As New System.Data.SqlClient.SqlConnection("server=185.48.183.100,1433;user id=sa;pwd=SqlServer2008Master;data source=185.48.183.100,1433;database=Sprotours")
End Class

Public Class SqlConnectionHotels
    'Public SqlCon As New System.Data.SqlClient.SqlConnection("server=localhost;user id=sa;pwd=SqlServer2008Master;data source=localhost;database=Hotel")
    Public SqlCon As New System.Data.SqlClient.SqlConnection("server=185.48.183.100,1433;user id=sa;pwd=SqlServer2008Master;data source=185.48.183.100,1433;database=Hotel")
End Class

Public Class SqlConnectionTurkorder
    'Public SqlCon As New System.Data.SqlClient.SqlConnection("server=localhost;user id=sa;pwd=SqlServer2008Master;data source=localhost;database=TurkOrderWeb")
    Public SqlCon As New System.Data.SqlClient.SqlConnection("server=185.48.183.100,1433;user id=sa;pwd=SqlServer2008Master;data source=185.48.183.100,1433;database=TurkOrderWeb")
End Class
