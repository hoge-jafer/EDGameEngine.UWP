﻿Imports Microsoft.Graphics.Canvas
Imports Windows.Graphics.Effects
''' <summary>
''' 效果器基类
''' </summary>
Public MustInherit Class EffectBase
    Inherits GameComponentBase
    Implements IEffect
    Public Overrides Property ComponentType As ComponentType = ComponentType.Effect
    Public MustOverride Function Effect(source As IGraphicsEffectSource, resourceCreator As ICanvasResourceCreator) As IGraphicsEffectSource Implements IEffect.Effect
    Public Overrides Sub Start()

    End Sub
    Public Overrides Sub Update()

    End Sub
End Class
