   M S B A M L   `   `   `  ����  DownloadManager$    DownloadManager.Views.HomeView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Download Manager��5   	   $	��460��5   	   $	��670��5	   	   $	��460��5
   	   $	��670��5   	    � Icon$&  ../Resources/ico-download-96.png��5   	   ��5      �� 5   
    �� ImageSource$! ../Resources/background.jpg��6   6A   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��67* �6   �� 5      $	��67* �6   �� 5      $	��67* �6   �� 5      $	��14* �6   �� 5      $
��116* �6   �� 5      $
��331* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6   .+�5   
   �� $��1��6B   $��6��6O   $	��381��6c   $��Bottom=�6p   $��670px��6�   ��6   �� *	FilesList+ �� Mode$ TwoWay=� �� View 5      �� 5       .P�5!      �� $��#��6%    �� Width$
 50px��60    �� DisplayMemberBinding 6=   �� 	 �� Path$	 ID��� 5"      $	��Url��6%   $ 300px��62    6@   �� $		 Url��� 5#      $��	File name��6%   $
 90px��68    6E   �� $	 FileName��� 5$      $
��Size��6%   $
 70px��63    6@   �� $	 FileSize��� 5%      $��	Date time��6%   $ 130px��68    6F   �� $	 DateTime�5&      5(      �� 5)   
   $
��17,3q�6,   $��Center=�6:   $��0��6W   $��0��6g   ���	#FF18CBE8$��33��6�   ��6   �� *AddUrl+.��5*      �� $&�� ../Resources/ico-add-link-80.png��6   5+      �� 5,   
   $
��17,3q�6/   $��Center=�6=   $��1��6Z   $��0��6j   ���	#FF18CBE8$��33��6�   ��6   �� *	RemoveUrl+.��5-      �� $)��#../Resources/ico-delete-link-80.png��6   5.      �� 5/   
   $
��17,3q�61   $��Center=�6?   $��2��6\   $��0��6l   ���	#FF18CBE8$��33��6�   ��6   �� *OpenSetting+.��50      �� $&�� ../Resources/ico-settings-64.png��6   51      �� 52   
   $��4,4,0,4q�6.   $
��Left=�6?   $��5��6Z   $��0��6j   ���	#FF18CBE8$��44��6�   ��6   �� *
AllFiles+.��6�   	All Files54      �� 55   
   $��7,4,1,4q�60   $��Center=�6A   $��4��6^   $��0��6n   ���	#FF18CBE8$	��108��6�   ��6   �� *
TodayFiles+.��6�   Downloaded today57      �� 58   
   $��56,4,0,4q�62   $
��Left=�6D   $��5��6_   $��0��6o   ���	#FF18CBE8$��70��6�   ��6   �� *BiggestFiles+.��6�   Biggest Files5:      �� 5;   
   $��	136,4,0,4q�60   $
��Left=�6C   $��5��6^   $��0��6n   ���	#FF18CBE8$��64��6�   ��6   �� *
GroupFiles+.��6�   Group Files5=      �� 5>   
   $��	210,4,0,4q�6-   $
��Left=�6@   $��5��6[   $��0��6k   ���	#FF18CBE8$��49��6�   ��6   �� *	Network+.��6�   	Network5@      5A      5B      