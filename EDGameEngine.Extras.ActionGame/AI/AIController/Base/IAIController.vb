﻿''' <summary>
''' AI控制器接口
''' </summary>
Public Interface IAIController
    ''' <summary>
    ''' 开始
    ''' </summary>
    Sub Start(mission As IMission)
    ''' <summary>
    ''' 更新
    ''' </summary>
    Sub Update(mission As IMission)
End Interface
