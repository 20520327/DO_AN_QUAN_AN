   M S B A M L   `   `   `  ����?  ;QLQA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       
UI.revenue   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Revenue��5	   	   $	��800��6   $
��1200��6&    � WindowStyle$
 None=�63    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\    � AllowsTransparency .  � Icon$ image/bistro1.png��5
   	   ��5	   �   Z� .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��10q�6      UniformCornerRadius$ 15Q�6*   ���	#FFFFFEEE.��5      � .+�5      �� $��image/bg2.png��6   $
��1500��6/   $��-130,0,-190,0q�6<    J� Opacity$
 0.45Q�6S   � 5      $��110,0,0,730q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Food=�6.   $��22��6:   $��22��6F   $��	10,12,0,0q�6Q   �� 5      $$��BATI RESTAURANT MANAGER SYSTEM��6    $
��Left=�6F   $	��Top=�6a   $��	40,13,0,0q�6y   $��18(�6�   $��Medium"�6�   $��Showcard Gothic)�6�   5      �� 5      $	��780��6   $	��Top=�6*   $��
0,0,1075,0q�6B   	 �� RadiusY$	 15��6V   
 �� RadiusX$
 15��6c   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5      �  � Color$ #049DBF��6+   � 5      $ #F2CB05��6+    � Offset$ 1Q�6;   � 5      $ #F2E205��6+   $	 0.5Q�6;   5      5      �� 5      -   5         ��Name$
 Home��5       *  &MaterialDesignFloatingActionMiniButton#��[  5      $
��Left=�5       � ToolTip$, &MaterialDesignFloatingActionMiniButton��5       $��50��6G   $��28,698,0,32q�6S   $��50��6h   ���	#FF049DBF���	#FF049DBF.��5!        $
 Home=�5"      $��24��5#      $��24��5$      $��Center=�6%   5%      �� 5&      #��[  5'      $��Right=�5(      $	��Top=�61   $��	0,10,10,0q�5)      $, &MaterialDesignFloatingActionMiniButton��5*      $��25��6F   $��25��6R   ���	#FFEB4343���	#FFEB4343.��5+        $ Close=�5,      $��15��5-      $��15��5.      $��Center=�6$   5/      �� 50      -   5        $ Minimize��50      #��[  51      $��Right=�52      $	��Top=�61   $��	0,10,45,0q�53      $, &MaterialDesignFloatingActionMiniButton��54      $��25��6F   $��25��6R   ���	#FFF2CB05���	#FFF2CB05.��55        $ WindowMinimize=�56      $��15��57      $��15��58      $��Center=�6$   59      � 5:      $��
106,50,0,0q�6   .+�5;        $ BookOpen=�6.   $��28��6>   $��28��6J   $��	11,17,0,0q�6U   �� 5<      $��Revenue��6    $
��Left=�6/   $	��Top=�6J   $��	45,15,0,0q�6b   $��24(�6u   $��Medium"�6�   $��Showcard Gothic)�6�   �� 5=      -   5        $ thongke��5=       $  MaterialDesignRaisedAccentButton#��[ 5>      $��Thống kê��6O   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 9��5?      $5 /Resource name: MaterialDesignRaisedAccentButton��5@      $��814,63,139,630q�6O   ���#7025D9���#7025D9���	#DDFFFFFF$��16(�5A      $��SemiBold"�6#   $
��Auto��69    J� Effect 5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C         Color$ #7025D9��6/      Opacity$	 0.3Q�6?   5E      �� 5G      ���	#FFF4F4F5$
��Left=�61   $��47��6L   $��
373,57,0,0q�6X   ���	#FF7025D9$	��Top=�6   $	��144��6�   $
	 15.5��6�   $

 15.5��6�   (  "System.Windows.Controls.DatePicker  5H      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Pick Date��5I       ( $MaterialDesignFloatingHintDatePicker#��[ 5J      $��393,58,575,630q�6W   $��14(�6o   $��42��6}   $��Gilroy)�6�   �� 5K      $.��(Chọn thời gian muốn xem doanh thu:��6    $
��Left=�6J   $	��Top=�6e   $��	48,74,0,0q�6}   $��18(�6�   $��SemiBold"�6�   $��Gilroy)�6�   �� 5L      $��đến��6    $
��Left=�6+   $	��Top=�6F   $��
530,74,0,0q�6^   $��18(�6r   $��SemiBold"�6�   $��Gilroy)�6�   �� 5M      ���	#FFF4F4F5$
��Left=�61   $��47��6L   $��
580,57,0,0q�6X   ���	#FF7025D9$	��Top=�6   $	��144��6�   $
	 15.5��6�   $

 15.5��6�     5N      $ 	Pick Date��5O      #��[ 5P      $��600,58,367,630q�6W   $��14(�6o   $��42��6}   $��Gilroy)�6�   5Q      � 5R      $��106,178,100,50q�6   
�������.+�5S      �� $��Gilroy)�6   $��16(�63    �� View 5T      �� 5U      .P�5V   "   ��  �� Width$	 240��61   $��	Tên bàn��5X   %    �� DisplayMemberBinding 5W   %   �� *tenban+5X   %   �� 5Y   "   $	 240��61   $��Tổng tiền��5[   %    5Z   %   �� *sum+5[   %   �� 5\   "   $	 240��61   $��
Ngày vào��5^   %    5]   %   �� *datein+5^   %   �� 5_   "   $	 240��61   $��Ngày ra��5a   %    5`   %   �� *	dateout+5a   %   5b      5d      5e      5f      5g      5h      5i      