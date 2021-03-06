﻿Imports System.Numerics
Imports EDGameEngine.Core
''' <summary>
''' 平面变换脚本
''' </summary>
Public Class TransformScript
    Inherits BehaviorBase
    Public Overrides Sub Start()
        Target.Transform.Center = New Vector2(CSng(Target.Rect.Width / 2), CSng(Target.Rect.Height / 2))
    End Sub

    Public Overrides Sub Update()
        Static value As Single
        value = CSng((value + 0.08F) Mod (Math.PI * 2))
        Target.Transform.Translation = New Vector2(Target.Scene.Width / 2, Target.Scene.Height / 2) - Target.Transform.Center
        'Target.Transform.Rotation = CSng((Target.Transform.Rotation + 0.001) Mod （Math.PI * 2))
        'Target.Transform.Center = New Vector2(Target.Rect.Width / 2, Target.Rect.Height / 2)
        'Target.Transform.Scale = New Vector2(CSng(Math.Sin(Target.Transform.Rotation)), CSng(Math.Cos(Target.Transform.Rotation)))
        'Target.Transform.Scale = Vector2.One * (1 + Math.Sin(value) * 0.1F)
    End Sub
End Class
