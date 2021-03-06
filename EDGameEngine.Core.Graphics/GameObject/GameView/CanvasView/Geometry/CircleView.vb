﻿Imports System.Numerics
Imports Microsoft.Graphics.Canvas
''' <summary>
''' 可视化圆的视图
''' </summary>
Public Class CircleView
    Inherits TypedCanvasView(Of VisualCircle)
    Public Overrides Sub OnDraw(drawingSession As CanvasDrawingSession)
        If Target.Fill.State Then
            drawingSession.FillCircle(Vector2.Zero, Target.Radius, Target.Fill.Color)
        End If
        If Target.Border.State Then
            drawingSession.DrawCircle(Vector2.Zero, Target.Radius + Target.Border.Width / 2, Target.Border.Color, Target.Border.Width)
        End If
    End Sub
End Class
