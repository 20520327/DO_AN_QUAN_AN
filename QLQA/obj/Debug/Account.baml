   M S B A M L   `   `   `  ����?  ;QLQA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       
UI.account   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Account��5	   	   $	��800��6   $
��1200��6&    � WindowStyle$
 None=�63    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\    � AllowsTransparency .  � Icon$ image/bistro1.png��5
   	   ��5	   �   Z� .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��10q�6      UniformCornerRadius$ 15Q�6*   ���	#FFFFFEEE.��5      � .+�5      �� $��image/bg2.png��6   $
��1500��6/   $��-130,0,-190,0q�6<    J� Opacity$
 0.45Q�6S   � 5      $��110,0,0,730q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Food=�6.   $��22��6:   $��22��6F   $��	10,12,0,0q�6Q   �� 5      $$��BATI RESTAURANT MANAGER SYSTEM��6    $
��Left=�6F   $	��Top=�6a   $��	40,13,0,0q�6y   $��18(�6�   $��Medium"�6�   $��Showcard Gothic)�6�   5      � 5      $��100,50,472,120q�6   
�������.+�5      �� $��Gilroy)�6   $��16(�63   	 �� View	 5      �� 5      .P�5   "   �� 
 �� Width$	
 200��61   $��Username��5   %    �� DisplayMemberBinding 5   %   �� *uname+5   %   �� 5   "   $	
 200��61   $��Displayname��5   %    5   %   �� *dname+5   %   �� 5   "   $	
 120��61   $
��Type��5   %    5   %   �� *type+5   %   5       5"      5#      � 5$      $��106,660,472,0q�6   .+�5%      �� -   5         ��Name$
 them��5%       $   MaterialDesignRaisedAccentButton#��[  5&      $��Thêm��6S   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 9��5'       � ToolTip$5 /Resource name: MaterialDesignRaisedAccentButton��5(      $��20,45,468,40q�6S   ���#7025D9���#7025D9���	#DDFFFFFF$��16(�5)      $��SemiBold"�6'   $
��Auto��6=    J� RenderTransformOrigin$ 0.5,0.5&�6K    J� Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+         Color$ #7025D9��6/      Opacity$	 0.3Q�6?   5-      �� 5.      -   5        $	 xoa��5.      #��[  5/      $
��Xóa��6S   $ 9��50      $5 /Resource name: MaterialDesignRaisedAccentButton��51      $��168,45,320,40q�6S   ���#7025D9���#7025D9���	#DDFFFFFF$��16(�52      $��SemiBold"�6'   $
��Auto��6=   $ 0.5,0.5&�6K    53        54      $ #7025D9��6/   $	 0.3Q�6?   56      �� 57      -   5        $	 sua��57      #��[  58      $��Sửa��6S   $ 9��59      $5 /Resource name: MaterialDesignRaisedAccentButton��5:      $��318,45,170,40q�6S   ���#7025D9���#7025D9���	#DDFFFFFF$��16(�5;      $��SemiBold"�6'   $
��Auto��6=   $ 0.5,0.5&�6K    5<        5=      $ #7025D9��6/   $	 0.3Q�6?   5?      �� 5@      -   5        $	 xem��5@      #��[  5A      $	��Xem��6S   $ 9��5B      $5 /Resource name: MaterialDesignRaisedAccentButton��5C      $��469,45,19,40q�6S   ���#7025D9���#7025D9���	#DDFFFFFF$��16(�5D      $��SemiBold"�6'   $
��Auto��6=   $ 0.5,0.5&�6K    5E        5F      $ #7025D9��6/   $	 0.3Q�6?   5H      5J      �� 5K      $	��780��6   $	��Top=�6*   $��
0,0,1075,0q�6B    �� RadiusY$ 15��6V    �� RadiusX$ 15��6c   ��5L      �� 5M       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5N      �  � Color$ #049DBF��6+   � 5O      $ #F2CB05��6+    � Offset$ 1Q�6;   � 5P      $ #F2E205��6+   $	 0.5Q�6;   5Q      5S      �� 5T       * &MaterialDesignFloatingActionMiniButton#��[ 5U      $
��Left=�5V      $, &MaterialDesignFloatingActionMiniButton��5W      $��50��6G   $��28,698,0,32q�6S   $��50��6h   ���	#FF049DBF���	#FF049DBF.��5X        $
 Home=�5Y      $��24��5Z      $��24��5[      $��Center=�6%   5\      �� 5]      #��[ 5^      $��Right=�5_      $	��Top=�61   $��	0,10,10,0q�5`      $, &MaterialDesignFloatingActionMiniButton��5a      $��25��6F   $��25��6R   ���	#FFEB4343���	#FFEB4343.��5b        $ Close=�5c      $��15��5d      $��15��5e      $��Center=�6$   5f      �� 5g      #��[ 5h      $��Right=�5i      $	��Top=�61   $��	0,10,45,0q�5j      $, &MaterialDesignFloatingActionMiniButton��5k      $��25��6F   $��25��6R   ���	#FFF2CB05���	#FFF2CB05.��5l        $ WindowMinimize=�5m      $��15��5n      $��15��5o      $��Center=�6$   5p      � 5q      $��
730,50,0,0q�6   .+�5r        $ AccountMultiple=�6.   $��28��6E   $��28��6Q   $��	11,17,0,0q�6\   �� 5s      $��Account��6    $
��Left=�6/   $	��Top=�6J   $��	45,15,0,0q�6b   $��24(�6u   $��Medium"�6�   $��Showcard Gothic)�6�   �� 5t      
�������$
��Left=�6-   $	��260��6H   $��
10,196,0,0q�5u       $
 21.5��64   $
 21.5��6C   ���	#FF2AA9C6$	��Top=�6e   $	��419��5v       � 5w      $��10,196,24,70q�6   .+�5x      �� $	��Top=�6%   $��20,5,19.4,-0.6q�6=   $	��460��6U   .+�5y      �� -   5         ��Name$ usernam��5y   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��67    % !MaterialDesignFloatingHintTextBox#��[ 6a   $
��0,10q�6�    �� 
CaretBrush �	#FF0DA0B8���	#FF0DA0B8���	#FF0DA0B8 �� SelectionBrush �	#FF0DA0B8$��18(�6  $��60��6  $��Gilroy)�6%  �� 5z      -   5        $ dpname��5z   &   $ Displayname��66   #��[ 6c   $
��0,10q�6�    �	#FF0DA0B8���	#FF0DA0B8���	#FF0DA0B8 �	#FF0DA0B8$��18(�6  $��60��6  $��Gilroy)�6'  � 5{      $��60��6#   $��0,0,0,0q�6/   .+�5|   "   �� $��Loại tài khoản��6,   $��Gilroy)�6B   $��Center=�5}   "   $��18(�6F   ���	#FF84D9E76T   �� 5~   "   $��40��5�      $��Gilroy)�5�      $��Right=�5�      $��22(�65   $	��220��6C   ���	#FF0B8497
�������$��Center=�6z   $	 0.8Q�6�   $��0,10,24.6,10q�6�   ���	#FF0B8497-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ShowSelectedItem 5      �� *	IsChecked+ �� ElementName$! DisplaySelectedItemCheckBox�� 5�   &     5�   *   $	 0.4Q�6;   .@�5�   &   ��  �� 
IsSelected . $�� Người quản trị��5�   +   �� 5�   &   $�� Nhân viên��63   5�   #   �� 5�   "   ���	#FF0B8497$��1q�6A   $��1��6U   $��	1,60,0,-1q�6`   ���	#FF1392A66s   5�      5�      5�      5�      5�      5�      5�      5�      