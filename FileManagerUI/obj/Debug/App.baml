   M S B A M L   `   `   `  ����H  DFileManagerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FileManagerUIFileManagerUI  5          FileManagerUI.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -localclr-namespace:FileManagerUI     5        �� 	Resources  5         ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton �� Angle��%�  &	        '�� C    �� 5   
   " n�6%   .�5	      ��  � �� 5
      �� 5      " n�6&   .R�5      � $
 Grid��6   .+�5      �� $��Stretch=�6(   $��Stretch=�6F   $
��Auto��6b   $
��Auto��6o   
������ 6}   �� 5      $ 
Rectangle1��6%   $ 5��69   $��Stretch=�6J   $��Stretch=�6h   $
��Auto��6�   $
��Auto��6�   #��z��6�   5       5      P� 5      	 �@�Tag$
 
Horizontal��65   . �5   "   �� $ 
Rectangle1��6)    � ��$
 Auto��6R   �� 5   "   $ 
Rectangle1��6)    � ��$ 7��6S   5      5      5      5      �� 5   
   " ��6+   .�5      ��  �@��IsFlicksEnabled .  67   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6+   �� 5        � ��$ 10��6&   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      � $ GridRoot��6   $��8��61   #��z��6;    5%      �� 5&   "   $��* �60   .+�5)      ]� $ 
PART_Track��6$   $��0��68   ��. |�.   5*   "   n� 5+   &   $ Thumb��6,   #��z��6;   #���   6e    5-   "   �� 5.   &   $ PageUp��63   $��ScrollBar.PageUpCommand��6C   $ 0Q�6e   |�.  6q    50   "   �� 51   &   $ PageDown��63   $��ScrollBar.PageDownCommand��6E   $ 0Q�6i   |�.  6u   53      54       55      P� 56      	 � {�
 .  . �57   "   �� $ Thumb��6)    � y�$ 	Collapsed=�6R   58      P� 59      	 �@��Orientation$
 
Horizontal=�6=   . �5:   "   �� $ GridRoot��6)    �@�LayoutTransform 5;   &   �� 5<   *   $	 -90Q�6:   5>   #   �� 5?   "   $ 
PART_Track��6)    �@�LayoutTransform 5@   &   �� 5A   *   $	 -90Q�6:   5C   #   �� 5D   "    � ��$
 Auto��6:   �� 5E   "    � ��$ 12��6;   �� 5F   "   $ Thumb��6)    �@�Tag$ 
Horizontal��6K   �� 5G   "   $ PageDown��6)    � ��$ ScrollBar.PageLeftCommand��6R   �� 5H   "   $ PageUp��6)    � ��$  ScrollBar.PageRightCommand��6P   5I      5K      5M      5N      5Q      5R      