﻿''' <summary>
''' 提供对某种游戏组件的统一管理
''' </summary>
Public Class TypedComponent(Of T As IGameComponent)
    Implements IGameComponent

    Public Property ComponentType As ComponentType Implements IGameComponent.ComponentType
    Public Property Target As IGameVisual Implements IGameComponent.Target
    Public Property Items As New List(Of T)

    Public Sub Start() Implements IGameComponent.Start
        For Each SubItem In Items
            SubItem.Start()
        Next
    End Sub
    Public Sub Update() Implements IGameComponent.Update
        For Each SubItem In Items
            SubItem.Update()
        Next
    End Sub
    Public Sub Add(item As T)
        item.Target = Target
        If Target.Scene?.State = SceneState.Loop Then
            item.Start()
        End If
        Items.Add(item)
    End Sub
End Class
