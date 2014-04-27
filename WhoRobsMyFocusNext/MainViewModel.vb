Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class MainViewModel
    Inherits PropertyChangedBase

    Private Shared defaultInstance As MainViewModel
    Shared Sub New()
        defaultInstance = New MainViewModel()
    End Sub

    Private Sub New()
        Me.WindowInfos = New ObservableCollection(Of WindowInfo)()
        Me.AddInfo(GetTopWindowInfo())
    End Sub

    Public Shared ReadOnly Property [Default] As MainViewModel
        Get
            Return defaultInstance
        End Get
    End Property

    Private _WindowInfos As ObservableCollection(Of WindowInfo)
    Private _DefaultView As ICollectionView
    Public Property WindowInfos As ObservableCollection(Of WindowInfo)
        Get
            Return _WindowInfos
        End Get
        Set(value As ObservableCollection(Of WindowInfo))
            If value IsNot Nothing AndAlso value IsNot _WindowInfos Then
                _WindowInfos = value
                _DefaultView = CollectionViewSource.GetDefaultView(_WindowInfos)
                OnPropertyChanged("WindowInfos")
            End If
        End Set
    End Property

    Public Sub AddInfo(ByVal info As WindowInfo, Optional ByVal successCallback As Action = Nothing)
        If info IsNot Nothing AndAlso (_WindowInfos.Count = 0 OrElse _WindowInfos(0) <> info) Then
            _WindowInfos.Insert(0, info)
            _DefaultView.MoveCurrentTo(info)
            If successCallback IsNot Nothing Then
                successCallback()
            End If
        End If
    End Sub

    Private _TopMost As Boolean
    Public Property TopMost As Boolean
        Get
            Return _TopMost
        End Get
        Set(value As Boolean)
            If value <> _TopMost Then
                _TopMost = value
                OnPropertyChanged("TopMost")
            End If
        End Set
    End Property


End Class
