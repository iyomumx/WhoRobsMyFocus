Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Interop

Module NativeMethods
    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Private Declare Unicode Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthW" (<[In]> ByVal hWnd As IntPtr) As Integer
    Private Declare Unicode Function GetWindowText Lib "user32" Alias "GetWindowTextW" (<[In]> ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.LPWStr), Out> ByVal lpString As StringBuilder, <[In]> ByVal nMaxCount As Integer) As Integer
    Private Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer

    Public Function GetTopWindowInfo() As WindowInfo
        Try
            Dim hWnd = GetForegroundWindow()
            If hWnd = IntPtr.Zero Then Return Nothing
            Dim lpdwProcessId As Integer
            GetWindowThreadProcessId(hWnd, lpdwProcessId)
            If lpdwProcessId = 0 Then Return Nothing
            Dim oProcess = Process.GetProcessById(lpdwProcessId)
            Dim length = GetWindowTextLength(hWnd)
            Dim text As New StringBuilder(length + 1)
            If GetWindowText(hWnd, text, text.Capacity) > 0 Then
                Return New WindowInfo() With {.ExecFileName = IO.Path.GetFileName(oProcess.MainModule.FileName), .WindowTitle = text.ToString(), .PID = lpdwProcessId, .LogTime = Date.Now}
            Else
                Return New WindowInfo() With {.ExecFileName = IO.Path.GetFileName(oProcess.MainModule.FileName), .WindowTitle = "<无标题窗口>", .PID = lpdwProcessId, .LogTime = Date.Now}
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Declare Function SendMessage Lib "user32" (ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    Private Declare Function LoadIcon Lib "user32" (ByVal hInstance As IntPtr, ByVal lpIconName As IntPtr) As IntPtr
    Private Declare Function GetClassLongPtr Lib "user32" (ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    Private Const WM_GETICON As UInteger = &H7F
    Private Const GCL_HICON As Integer = -14
    Private ReadOnly ICON_SMALL2 As IntPtr = New IntPtr(2)
    Private ReadOnly IDI_APPLICATION As IntPtr = New IntPtr(&H7F00)
    Private ReadOnly DefaultImageSource As ImageSource = BitmapImage.Create(32, 32, 96, 96, PixelFormats.Indexed1, New BitmapPalette(New List(Of Color)({Colors.Transparent})), Enumerable.Repeat(0, 32 * 32).ToArray(), 4)
    Public Function GetWindowIcon(ByVal hWnd As IntPtr) As ImageSource
        Try
            Dim hIcon As IntPtr = SendMessage(hWnd, WM_GETICON, ICON_SMALL2, IntPtr.Zero)
            If hIcon = IntPtr.Zero Then hIcon = GetClassLongPtr(hWnd, GCL_HICON)
            If hIcon = IntPtr.Zero Then hIcon = LoadIcon(IntPtr.Zero, IDI_APPLICATION)
            If hIcon <> IntPtr.Zero Then
                Return Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
            Else
                Return DefaultImageSource
            End If
        Catch ex As Exception
            Return DefaultImageSource
        End Try
    End Function
End Module
