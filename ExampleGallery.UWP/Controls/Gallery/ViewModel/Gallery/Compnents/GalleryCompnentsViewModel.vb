﻿''' <summary>
''' 组件画廊
''' </summary>
Public Class GalleryCompnentsViewModel
    Implements IGalleryViewModel
    ''' <summary>
    ''' 示例组集合
    ''' </summary>
    Public Property SampleGroups As New ObservableCollection(Of SampleGroupViewModel) Implements IGalleryViewModel.SampleGroups

    Public Sub New()
        Dim image As New BitmapImage(New Uri("ms-appx:///Assets/StoreLogo.png"))

        Dim samples1 As New List(Of Sample)
        samples1.Add(New Sample() With {.Id = 1000, .Title = "高斯模糊", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1001, .Title = "磨砂玻璃", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1002, .Title = "残影效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1003, .Title = "光照效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1004, .Title = "像素变换", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1005, .Title = "水波效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1006, .Title = "阴影效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1007, .Title = "水流效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1008, .Title = "二值变换", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1009, .Title = "波纹效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1010, .Title = "对比度效果", .Description = "描述", .Image = image})
        samples1.Add(New Sample() With {.Id = 1011, .Title = "测试效果", .Description = "描述", .Image = image})

        Dim samples2 As New List(Of Sample)
        samples2.Add(New Sample() With {.Id = 2000, .Title = "标题2A", .Description = "描述", .Image = image})
        samples2.Add(New Sample() With {.Id = 2001, .Title = "标题2B", .Description = "描述", .Image = image})
        samples2.Add(New Sample() With {.Id = 2002, .Title = "标题2C", .Description = "描述", .Image = image})

        Dim samples3 As New List(Of Sample)
        samples3.Add(New Sample() With {.Id = 3000, .Title = "标题4A", .Description = "描述", .Image = image})
        samples3.Add(New Sample() With {.Id = 3001, .Title = "标题4B", .Description = "描述", .Image = image})
        samples3.Add(New Sample() With {.Id = 3002, .Title = "标题4C", .Description = "描述", .Image = image})

        Dim samples4 As New List(Of Sample)
        samples4.Add(New Sample() With {.Id = 4000, .Title = "音效控制", .Description = "描述", .Image = image})
        samples4.Add(New Sample() With {.Id = 4001, .Title = "创建物体", .Description = "描述", .Image = image})
        samples4.Add(New Sample() With {.Id = 4002, .Title = "物理仿真", .Description = "描述", .Image = image})
        samples4.Add(New Sample() With {.Id = 4003, .Title = "键盘输入", .Description = "描述", .Image = image})
        samples4.Add(New Sample() With {.Id = 4004, .Title = "平面变换", .Description = "描述", .Image = image})

        Dim samples5 As New List(Of Sample)
        samples5.Add(New Sample() With {.Id = 5000, .Title = "标题5A", .Description = "描述", .Image = image})
        samples5.Add(New Sample() With {.Id = 5001, .Title = "标题5B", .Description = "描述", .Image = image})
        samples5.Add(New Sample() With {.Id = 5002, .Title = "标题5C", .Description = "描述", .Image = image})

        SampleGroups.Add(New SampleGroupViewModel() With {.Title = "效果器", .Sameples = samples1})
        SampleGroups.Add(New SampleGroupViewModel() With {.Title = "音效器", .Sameples = samples2})
        SampleGroups.Add(New SampleGroupViewModel() With {.Title = "动画器", .Sameples = samples3})
        SampleGroups.Add(New SampleGroupViewModel() With {.Title = "行为器", .Sameples = samples4})
        SampleGroups.Add(New SampleGroupViewModel() With {.Title = "触发器", .Sameples = samples5})
    End Sub
End Class
