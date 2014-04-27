Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports System.Windows.Threading

Module Extensions

    <Extension()>
    Public Function AddIfNotNull(Of T)(collection As IList(Of T), ByVal obj As T) As Boolean
        If obj IsNot Nothing Then
            collection.Add(obj)
            Return True
        Else
            Return False
        End If
    End Function

    <Extension()>
    Public Function AddIfNotNull(collection As IList, ByVal obj As Object) As Boolean
        If obj IsNot Nothing Then
            collection.Add(obj)
            Return True
        Else
            Return False
        End If
    End Function

    <Extension()>
    Public Sub Invoke(obj As DispatcherObject, action As Action)
        If obj Is Nothing Then
            Return
        End If
        If obj.CheckAccess() Then
            action()
        Else
            obj.Dispatcher.Invoke(DispatcherPriority.Normal, action)
        End If
    End Sub

    <Extension()>
    Public Sub Invoke(Of T)(obj As DispatcherObject, action As Action(Of T), arg As T)
        If obj Is Nothing Then
            Return
        End If
        If obj.CheckAccess() Then
            action(arg)
        Else
            obj.Dispatcher.Invoke(DispatcherPriority.Normal, action, arg)
        End If
    End Sub

    <Extension()>
    Public Function Invoke(Of TResult)(obj As DispatcherObject, action As Func(Of TResult)) As TResult
        If obj Is Nothing Then
            Return Nothing
        End If
        If obj.CheckAccess() Then
            Return action()
        Else
            Return obj.Dispatcher.Invoke(DispatcherPriority.Normal, action)
        End If
    End Function

    <Extension()>
    Public Sub AsyncInvoke(obj As DispatcherObject, action As Action)
        If obj Is Nothing Then Return
        obj.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action)
    End Sub

    <Extension()>
    Public Sub AsyncInvoke(Of T)(obj As DispatcherObject, action As Action(Of T), arg As T)
        If obj Is Nothing Then Return
        obj.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action, arg)
    End Sub

    <Extension()>
    Public Sub AsyncInvoke(Of T)(obj As DispatcherObject, action As Action(Of T), arg As T, priority As DispatcherPriority)
        If obj Is Nothing Then Return
        obj.Dispatcher.BeginInvoke(priority, action, arg)
    End Sub
End Module
