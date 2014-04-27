Imports System.Timers

Class MainWindow
    Private WithEvents Timer As Timer = New Timer With {.Interval = 500, .AutoReset = False}
    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)

        ' Begin dragging the window
        Me.DragMove()
    End Sub

    Private Sub MainWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Key = Key.X Then
            Me.Close()
        End If
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Timer.Start()
    End Sub

    Private Sub Timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles Timer.Elapsed
        Dim winfo = GetTopWindowInfo()
        Me.AsyncInvoke(Sub(o)
                           MainViewModel.Default.AddInfo(o, Sub()
                                                                lsbInfos.ScrollIntoView(lsbInfos.Items.CurrentItem)
                                                                If expSettings.IsExpanded Then
                                                                    lsbInfos.Height = lsbInfos.MaxHeight
                                                                Else
                                                                    Try
                                                                        lsbInfos.Height = CType(lsbInfos.ItemContainerGenerator.ContainerFromItem(o), ListBoxItem).ActualHeight
                                                                    Catch
                                                                    End Try
                                                                End If
                                                            End Sub)
                       End Sub, winfo)
        Timer.Start()
    End Sub

    Private Sub expSettings_Collapsed(sender As Object, e As RoutedEventArgs) Handles expSettings.Collapsed
        Try
            lsbInfos.Height = CType(lsbInfos.ItemContainerGenerator.ContainerFromItem(lsbInfos.Items.CurrentItem), ListBoxItem).ActualHeight
        Catch
        End Try
    End Sub

    Private Sub expSettings_Expanded(sender As Object, e As RoutedEventArgs) Handles expSettings.Expanded
        lsbInfos.Height = lsbInfos.MaxHeight
    End Sub
End Class
