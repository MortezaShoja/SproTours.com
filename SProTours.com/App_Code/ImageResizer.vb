Imports System.IO

Public Class ImageResizer
    Private strSource As String
    Private strDestination As String


    Public Sub ImageResize(ByVal strImageSrcPath As String, ByVal strImageDesPath As String, Optional ByVal intWidth As Integer = 0, Optional ByVal intHeight As Integer = 0)
        If System.IO.File.Exists(strImageSrcPath) = False Then Exit Sub

        Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(strImageSrcPath)

        If intWidth > objImage.Width Then intWidth = objImage.Width
        If intHeight > objImage.Height Then intHeight = objImage.Height
        If intWidth = 0 And intHeight = 0 Then
            intWidth = objImage.Width
            intHeight = objImage.Height
        ElseIf intHeight = 0 And intWidth <> 0 Then
            intHeight = Fix(objImage.Height * intWidth / objImage.Width)
        ElseIf intWidth = 0 And intHeight <> 0 Then
            intWidth = Fix(objImage.Width * intHeight / objImage.Height)
        End If

        Dim imgOutput As New Drawing.Bitmap(objImage, intWidth, intHeight)
        Dim imgFormat = objImage.RawFormat

        objImage.Dispose()
        objImage = Nothing

        If strImageSrcPath = strImageDesPath Then System.IO.File.Delete(strImageSrcPath)
        ' send the resized image to the viewer
        imgOutput.Save(strImageDesPath, imgFormat)
        imgOutput.Dispose()

        'Return strImageDesPath

    End Sub

    Public Sub ImageResizeExact(ByVal strImageSrcPath As String, ByVal strImageDesPath As String, Optional ByVal intWidth As Integer = 0, Optional ByVal intHeight As Integer = 0)
        If System.IO.File.Exists(strImageSrcPath) = False Then Exit Sub

        Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(strImageSrcPath)

        'If intWidth > objImage.Width Then intWidth = objImage.Width
        'If intHeight > objImage.Height Then intHeight = objImage.Height
        'If intWidth = 0 And intHeight = 0 Then
        '    intWidth = objImage.Width
        '    intHeight = objImage.Height
        'ElseIf intHeight = 0 And intWidth <> 0 Then
        '    intHeight = Fix(intWidth)
        'ElseIf intWidth = 0 And intHeight <> 0 Then
        '    intWidth = Fix(intHeight)
        'End If

        Dim imgOutput As New Drawing.Bitmap(objImage, intWidth, intHeight)
        Dim imgFormat = objImage.RawFormat

        objImage.Dispose()
        objImage = Nothing

        If strImageSrcPath = strImageDesPath Then System.IO.File.Delete(strImageSrcPath)
        ' send the resized image to the viewer
        imgOutput.Save(strImageDesPath, imgFormat)
        imgOutput.Dispose()

        'Return strImageDesPath

    End Sub
End Class
