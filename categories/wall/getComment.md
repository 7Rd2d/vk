---
layout: default
title: ����� Wall.GetComment
permalink: wall/getComment/
comments: true
---
# ����� Wall.GetComment
�������� ���������� � ����������� �� �����.

�������� ������������ ��������� [wall.getComment](https://vk.com/dev/wall.getComment).  
���� ����� ����� ������� � [������ ������� ������������](https://vk.com/dev/access_token).  
��������� [����� �������](https://vk.com/dev/permissions) wall.  

## ���������
``` csharp
public WallGetCommentsResult GetComments(WallGetCommentsParams @params, bool skipAuthorization = false)
```

## ���������
+ **OwnerId** - ������������� ��������� �����  
+ **CommentId** - ������������� �����������.  
+ **Fields** - ������ �������������� ����� ��� [��������](https://vk.com/dev/objects/user) � [���������](https://vk.com/dev/objects/group), ������� ���������� �������.  
�������� ��������, ���� �������� ����������� ������ ��� `extended = 1`.  
+ **Extended** -   
**true** � � ������ ����� ���������� �������������� ���� **profiles** � **groups**, ���������� ���������� � [�������������](https://vk.com/dev/objects/user) � [�����������](https://vk.com/dev/objects/user).   
�� ��������� false.

## ���������
���������� ������ ����������� �� �����.   
���� ��� ������� �������� `extended = 1`, ������������� ���������� ���� **groups** � **profiles**, ���������� ���������� � [�������������](https://vk.com/dev/objects/user) � [�����������](https://vk.com/dev/objects/user).
## ������
``` csharp
//�� �����������
```

## ������ ��������� API v.5.110
���� ����������: 23.06.2020 2:43
