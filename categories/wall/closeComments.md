---
layout: default
title: ����� Wall.CloseComments
permalink: wall/closecomments/
comments: true
---
# ����� Wall.CloseComments
��������� ��������������� ������

�������� ������������ ��������� [wall.closeComments](https://vk.com/dev/wall.closeComments).

���� ����� ����� ������� � ������ ������� ������������, ���������� � [Standalone-����������](https://vk.com/dev/standalone) ����� [Implicit Flow](https://vk.com/dev/implicit_flow_user).  
���� ����� ����� ������� � [������ ������� ����������](https://vk.com/dev/access_token).   
��������� [����� �������](https://vk.com/dev/permissions) wall.  

## ���������
``` csharp
public bool CloseComments(long ownerId, long postId)
```

## ���������
+ **ownerId** - ������������� ������������ ��� ����������, �� ����� �������� ��������� ������.  
������������ ��������.  
+ **postId** - ������������� ������ �� �����. ������������� �����, ������������ ��������  
������������ ��������.  

## ���������
� ������ ������ ����� ������ **true**.

## ������
``` csharp
var result = Api.Wall.CloseComments(3, 3);
Console.WriteLine(result);
```

## ������ ��������� API v.5.110
���� ����������: 22.06.2020 23:08