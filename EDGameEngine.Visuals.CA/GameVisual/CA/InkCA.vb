﻿Imports System.Numerics
Imports EDGameEngine.Core.Graphics
Imports Microsoft.Graphics.Canvas.Geometry
Imports Windows.UI
''' <summary>
''' 正方形网格元胞自动机
''' </summary>
Public Class InkCA
    Inherits GeometyCABase

    Public Property Size As Integer = 1

    Dim ColorArray As Color()

    Public Overrides Sub StartEx()

        Width = CInt(Image.Bounds.Width)
        Height = CInt(Image.Bounds.Height)

        ColorArray = Image.GetPixelColors

        Geometry = CanvasGeometry.CreateRectangle(CType(Scene.World, IObjectWithResourceCreator).ResourceCreator, New Rect(-Size / 2, -Size / 2, Size, Size))

        ReDim Cells(Width - 1, Height - 1)
        For i = 0 To Width - 1
            For j = 0 To Height - 1
                If ColorArray(CInt(j * Image.Bounds.Width + i)).R = 0 Then
                    Cells(i, j) = New Cell With {.Location = New Vector2(i * Size, j * Size),
                                                 .Color = Colors.Black,
                                                 .Size = Size}
                    Cells(i, j).Color = ColorArray(CInt(j * Image.Bounds.Width + i))
                Else
                    Cells(i, j) = Nothing
                End If
            Next
        Next

        Rect = New Rect(0, 0, Width * Size, Height * Size)
    End Sub

    Public Overrides Sub UpdateEx()
        Static count As Integer = 0
        If count < 3 Then
            count += 1
            Exit Sub
        Else
            count = 0
        End If

        Dim generation(Width - 1, Height - 1) As ICell
        For i = 0 To Width - 1
            For j = 0 To Height - 1
                Dim temp As Integer = GetSquareAroud(Cells, i, j, Width, Height)
                If Cells(i, j) Is Nothing Then
                    If temp = 3 Then
                        generation(i, j) = New Cell With {.Location = New Vector2(i * Size, j * Size), .Size = Size}
                        generation(i, j).Color = GetAroundColor(Cells, i, j, Width, Height)
                    End If
                Else
                    If temp = 2 OrElse temp = 3 OrElse temp = 4 Then
                        generation(i, j) = Cells(i, j)
                    End If
                End If
            Next
        Next
        Cells = generation
    End Sub

    ''' <summary>
    ''' 返回正方形网格细胞邻居数量
    ''' </summary>
    Private Function GetSquareAroud(ByRef cellArr(,) As ICell, x As Integer, y As Integer, w As Integer, h As Integer) As Integer
        Static xArray() As Integer = {-1, 0, 1, 1, 1, 0, -1, -1}
        Static yArray() As Integer = {-1, -1, -1, 0, 1, 1, 1, 0}
        Dim dx, dy, count As Integer
        For i = 0 To 7
            dx = x + xArray(i)
            dy = y + yArray(i)
            If dx >= 0 AndAlso dy >= 0 AndAlso dx < w AndAlso dy < h Then
                If cellArr(dx, dy) IsNot Nothing Then
                    count += 1
                End If
            End If
        Next
        Return count
    End Function


    ''' <summary>
    ''' 返回正方形网格细胞邻居均色
    ''' </summary>
    Private Function GetAroundColor(ByRef cellArr(,) As ICell, x As Integer, y As Integer, w As Integer, h As Integer) As Color
        Static xArray() As Integer = {-1, 0, 1, 1, 1, 0, -1, -1}
        Static yArray() As Integer = {-1, -1, -1, 0, 1, 1, 1, 0}
        Dim dx, dy, count As Integer
        Dim a, r, g, b As Integer
        For i = 0 To 7
            dx = x + xArray(i)
            dy = y + yArray(i)
            If dx >= 0 AndAlso dy >= 0 AndAlso dx < w AndAlso dy < h Then
                If cellArr(dx, dy) IsNot Nothing Then
                    count += 1
                    a += cellArr(dx, dy).Color.A
                    r += cellArr(dx, dy).Color.R
                    g += cellArr(dx, dy).Color.G
                    b += cellArr(dx, dy).Color.B
                End If
            End If
        Next

        If count > 0 Then
            a = CInt(a / count) - 10
            If a < 0 Then a = 0
            r = CalcRGB(r, count)
            g = CalcRGB(g, count)
            b = CalcRGB(b, count)
        End If
        Return Color.FromArgb(CByte(a), CByte(r), CByte(g), CByte(b))
    End Function
    Private Function CalcRGB(value As Integer, res As Integer) As Integer
        value = CInt(value / res) + Rnd.Next(1， 10) - 5
        If value < 0 Then value = 0
        If value > 255 Then value = 255
        Return value
    End Function
End Class
