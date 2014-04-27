Public Class WindowInfo
    Inherits PropertyChangedBase
    Implements IEquatable(Of WindowInfo)

    Private _WindowTitle As String
    Public Property WindowTitle As String
        Get
            Return _WindowTitle
        End Get
        Set(value As String)
            If value <> _WindowTitle Then
                _WindowTitle = value
                OnPropertyChanged("WindowTitle")
            End If
        End Set
    End Property

    Private _ExecFileName As String
    Public Property ExecFileName As String
        Get
            Return _ExecFileName
        End Get
        Set(value As String)
            If value <> _ExecFileName Then
                _ExecFileName = value
                OnPropertyChanged("ExecFileName")
            End If
        End Set
    End Property

    Private _PID As Integer
    Public Property PID As Integer
        Get
            Return _PID
        End Get
        Set(value As Integer)
            If value <> _PID Then
                _PID = value
                OnPropertyChanged("PID")
            End If
        End Set
    End Property

    Private _LogTime As Date
    Public Property LogTime As Date
        Get
            Return _LogTime
        End Get
        Set(value As Date)
            If value <> _LogTime Then
                _LogTime = value
                OnPropertyChanged("LogTime")
            End If
        End Set
    End Property


    Public Shared Operator =(ByVal objA As WindowInfo, ByVal objB As WindowInfo) As Boolean
        If objA Is objB Then Return True
        If objA Is Nothing OrElse objB Is Nothing Then Return False
        Return objA.Equals(objB)
    End Operator

    Public Shared Operator <>(ByVal objA As WindowInfo, ByVal objB As WindowInfo) As Boolean
        If objA Is objB Then Return False
        If objA Is Nothing OrElse objB Is Nothing Then Return True
        Return Not objA.Equals(objB)
    End Operator

    Public Overloads Function Equals(other As WindowInfo) As Boolean Implements IEquatable(Of WindowInfo).Equals
        If other Is Nothing Then Return False
        If Me.PID = other.PID AndAlso Me.ExecFileName = other.ExecFileName Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
