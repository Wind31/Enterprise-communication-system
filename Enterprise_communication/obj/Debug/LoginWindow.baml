   M S B A M L   `   `   `  ����S  OEnterprise_communication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Enterprise_communicationEnterprise_communication  5   	   *    $Enterprise_communication.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Enterprise_communication     5   	   -   5        $	��300��5   	   $	��450��6     � WindowStartupLocation$  CenterScreen=�6"   .��5
      � .+�5   
   (� .��5      �� -   5        $��firstSP��5      .+�5      �� $��Images\head.jpg��6   $
��Fill=�61   $��Center=�6A   $	��100��6^   $	��392��6k    J� RenderTransformOrigin$ 0.5,0.5&�6w   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -0.389Q�6,   �� 5      T� 5       T� Y$ -1.135Q�61   5      5      �� 5      -   5         ��Name$ secondSp��5       �� Orientation$ 
Horizontal=�6/   $��30��6H   .+�5      �� $
��Wrap=�6    $��用户名：��64   $��29��6@   $��60,6,0,0q�6L   $ 1.268,0.243&�6^   ���	#FF020F156�   �� 5      -   5         ��Name$ UserName��5      $��22��60    �� TextWrapping$
 Wrap=�6<   $	��160��6P   $��20,0,0,2q�6\   ���	#FF5C5F60$��Bottom=�6�   5      �� 5      -   5        $ thirdSp��5      $ 
Horizontal=�6.   .+�5      �� $
��Wrap=�6    $��   密码：��64   $��29��6B   $��60,6,0,0q�6N   $ 1.268,0.243&�6`   ���	#FF02141D6�   G� 5      -   5         G�Name$ passWord��5   "   $��24��64   $	��159��6A   $��21,0,0,2q�6M   ���	#FF5C5F606_   �� 5      -   5        	 ��Name$	 btnRegister��5      $��注册��63   $��Right=�6@   $��45��6]   $��
20,1,0,0.4q�6h   ���	#FF0094DA$��12(�6�   
���������6�   Z� 6�   5      �� 5       -   5        $��fourSP��5       $ 
Horizontal=�6+   $��0,0,0,5q�6D   .+�5!      �� -	   5        $	 Login��5!   .   
 �� 	IsDefault
 . $��登录��6=   $	��Top=�6J   $��28��6c   ���	#FF0094DA���	#FFC0DFE6$��Microsoft YaHei)�6�   
�������$��
130,10,0,0q�6�   $
��Left=�6�   $��55��6�   6	  �� 5"      -
   5        $
	 Exit��5"      $��退出��6,   $	��Top=�69   $��28��6R   ���	#FF0094DA���	#FFC0DFE6$��Microsoft YaHei)�6�   
�������$��	45,10,0,0q�6�   $
��Left=�6�   $��55��6�   6�   5#      �� 5$      -   5        $��fiveSP��5$      $��Bottom=�6+   $��Center=�6F   $��	18,0,10,5q�6c   $ 
Horizontal=�6v   .+�5%      �� .��6   服务器地址6#   �� 5&      -   5        $ ServerIp��5&   "   $��22��64   $
 Wrap=�6@   $	��160��6T   ���	#FF5C5F606a   �� 5'      .��6   服务器端口6#   �� 5(      -   5        $ 
ServerPort��5(      $��22��62   $
 Wrap=�6>   $��80��6R   ���	#FF5C5F606^   5)      5*      5+      5,      5-      