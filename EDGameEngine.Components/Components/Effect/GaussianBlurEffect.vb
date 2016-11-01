﻿Imports EDGameEngine.Core
Imports Microsoft.Graphics.Canvas
Imports Windows.Graphics.Effects
''' <summary>
''' 高斯模糊效果
''' </summary>
Public Class GaussianBlurEffect
    Inherits EffectBase
    ''' <summary>
    ''' 模糊半径
    ''' </summary>
    Public Property BlurAmount As Integer = 3
    Public Overrides Function Effect(source As IGraphicsEffectSource, resourceCreator As ICanvasResourceCreator) As IGraphicsEffectSource
        Dim rect = CType(source, ICanvasImage).GetBounds(resourceCreator)
        Using cac = New CanvasRenderTarget(CType(resourceCreator, ICanvasResourceCreatorWithDpi), New Size(rect.Width, rect.Height))
            Dim sizepx = cac.SizeInPixels
            Using ds = cac.CreateDrawingSession
                Using blur = New Effects.GaussianBlurEffect With {.Source = source, .BlurAmount = BlurAmount}
                    ds.Clear(Windows.UI.Colors.Transparent)
                    ds.DrawImage(blur)
                End Using
            End Using
            Return CanvasBitmap.CreateFromColors(resourceCreator, cac.GetPixelColors, CInt(sizepx.Width), CInt(sizepx.Height))
        End Using
    End Function

    Public Shared Function EffectStatic(source As IGraphicsEffectSource, resourceCreator As ICanvasResourceCreator, Optional blurAmount As Integer = 3) As IGraphicsEffectSource
        Dim rect = CType(source, ICanvasImage).GetBounds(resourceCreator)
        Using cac = New CanvasRenderTarget(CType(resourceCreator, ICanvasResourceCreatorWithDpi), New Size(rect.Width, rect.Height))
            Dim sizepx = cac.SizeInPixels
            Using ds = cac.CreateDrawingSession
                Using blur = New Effects.GaussianBlurEffect With {.Source = source, .BlurAmount = blurAmount}
                    ds.Clear(Windows.UI.Colors.Transparent)
                    ds.DrawImage(blur)
                End Using
            End Using
            Return CanvasBitmap.CreateFromColors(resourceCreator, cac.GetPixelColors, CInt(sizepx.Width), CInt(sizepx.Height))
        End Using
    End Function
End Class