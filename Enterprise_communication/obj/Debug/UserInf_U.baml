   M S B A M L   `   `   `  ����S  OEnterprise_communication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Enterprise_communicationEnterprise_communication  5   	   (    "Enterprise_communication.UserInf_U   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Enterprise_communication     5   	     � Title$  查看信息��5   	   $	��650��6   $	��450��6#    � 
ResizeMode$ CanMinimize=�6/    � WindowStartupLocation$ CenterScreen=�6H   .��5	      � -   5        $��gridEdit��5	      .+�5   
   �� -   5         ��Name$ Labe2��5      $��	用户名��6   $��10q�6-   $��2��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -   5        $ Labe3��5      $��	姓   名��6   $��10q�6/   $��3��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -   5        $ Labe4��5      $��	部   门��6   $��10q�6/   $��4��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -   5        $ Labe5��5      $��	姓   别��6   $��10,10.333,9.667,49.667q�6/   $��5��5      $��15(�6   $��2��6+   �� 5   
   -   5        $ Labe6��5      $��工  号��6   $��10q�6.   $��6��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -   5        $ Labe7��5      $��	手机号��6   $��10q�6-   $��7��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -   5        $ Labe15��5      $��	职   位��6    $��10q�60   $��8��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -	   5        $ Labe16��5      $��	权   限��6    $��10q�60   $��9��5      $��40��6   $	��Top=�6)   $��15(�6A   �� 5   
   -
   5        $ 
lbUsername��5      $��10q�6$   $��2��5      $��40��6   $	��Top=�6)   $��15(�6A   $��1��5      $��2��6    �� 5   
   -   5        $ lbName��5      $��10q�6!   $��3��5       $��40��6   $	��Top=�6)   $��15(�6A   $��1��5!      $��2��6    �� 5"   
   -   5        $ lbDep��5"      $��10q�6    $��4��5#      $��40��6   $	��Top=�6)   $��15(�6A   $��1��5$      $��2��6    �� 5%   
   -   5        $ lbGender��5%      $��10q�6#   $��5��5&      $��40��6   $	��Top=�6)   $��15(�6A   $��1��5'      $��2��6    �� 5(   
   -   5        $ 	lbWorknum��5(      $��10q�6#   $��6��5)      $��40��6   $	��Top=�6)   $��15(�6A   $��1��5*      $��2��6    �� 5+   
   -   5        $ lbPhone��5+      $��10q�6"   $��7��5,      $��40��6   $	��Top=�6)   $��15(�6A   $��1��5-      $��2��6    �� 5.   
   -   5        $ 
lbPosition��5.      $��10q�6$   $��8��5/      $��40��6   $	��Top=�6)   $��15(�6A   $��1��50      $��2��6    �� 51   
   -   5        $ 	lbControl��51      $��10q�6#   $��9��52      $��40��6   $	��Top=�6)   $��15(�6A   $��1��53      $��2��6    �� 54   
   -   5         ��Name$ image2��54      $��Images\background.jpg��6    $��UniformToFill=�6?   $
��Left=�55      $	��100��6(   $	��Top=�65   $	��450��56      $��3��6   �� 57   
   -   5        $ image1��57      $��Images\214743981.jpg��6    $��80��58      $��80��6   $��0��6(   $
��Left=�59      $��Bottom=�6+   $��1��6F   $��10q�6W    � RowDefinitions 5:   
   �� 5;      $	��2*  �6   6,   �� 5<      $
��0.3* �6   6-   �� 5=      $��* �6   6*   �� 5>      $��* �6   6*   �� 5?      $��* �6   6*   �� 5@      $��* �6   6*   �� 5A      $��* �6   6*   �� 5B      $��* �6   6*   �� 5C      $��* �6   6*   �� 5D      $��* �6   6*   �� 5E      $
��1.5* �6   6-    � ColumnDefinitions 5G   
   �� 5H      $�� Auto �6   $��150.667��6-   6B   �� 5I      $
��Auto �6   $	��158��6,   6=   �� 5J      $
��Auto �6   $��356.667��6,   6A   5O      5P      