   M S B A M L   `   `   `  ����S  OEnterprise_communication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Enterprise_communicationEnterprise_communication  5   	   .    (Enterprise_communication.SelectGroupUser   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Enterprise_communication     5   	     � Title$  SelectGroupUser��5   	   $	��600��6!   $	��460��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   ��5      �� 5       j� Stretch$
 Fill=�6    �� ImageSource$ images\background.jpg��6,   .+�5      �� $��20(�6   $��40��6"   
�������$��Center=�6D   .��6a   选择用户6g   5      R� 5   
   -   5         R�Name$ departmentTree��5       $��1��6   $
��Auto=�68   $
��Auto=�6j   $��10q�6�   5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6#   $��Center=�6<   .+�5      �� $��请输入群名称��6   $	��200��6%   $��30��64   $��5q�6C   6P   �� 5      -   5        $��	GroupName��5      $	��250��6(   $	��150��67   $��30��6F   $��5q�6U   6b   5      � 5   
   $��3��6    5      �� 5      6"   �� 5       6"    � ColumnDefinitions 5"      �� 5#      6%   �� 5$      6%   .+�5&      �� -   5        $��0��5&      $��0��6"   $��Center=�62   $��30��6O   $��30��6^   $��10q�6l   .��6�   全选6�   �� 5'      $��1��6   $��2��6&   $ 
Horizontal=�6:   $��Center=�6S   .+�5(      �� -   5        $��30��5(      $��50��6)   $��10q�67   .��6Z   确定6^   �� 5)      -   5        $��30��5)      $��50��6)   $��10q�67   .��6^   取消6b   5*      5+      5,      5-      