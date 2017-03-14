﻿''' <summary>
''' 关卡
''' </summary>
Public Class Mission
    Implements IMission
    ''' <summary>
    ''' 地图块集合
    ''' </summary>
    Public Property Blocks As IBlock(,) Implements IMission.Blocks
    ''' <summary>
    ''' 角色集合
    ''' </summary>
    Public Property Characters As List(Of ICharacter) Implements IMission.Characters
    ''' <summary>
    ''' 背景音乐
    ''' </summary>
    Public Property Music As ResourceId
    ''' <summary>
    ''' 背景贴图
    ''' </summary>
    Public Property Background As ResourceId

    Public Sub New()
        Characters = New List(Of ICharacter)
    End Sub

    ''' <summary>
    ''' 返回指定名称的角色
    ''' </summary>
    Public Function FindCharacterByName(name As String) As ICharacter
        For Each SubCharacter In Characters
            If SubCharacter.Name = name Then
                Return SubCharacter
            End If
        Next
        Return Nothing
    End Function
End Class
