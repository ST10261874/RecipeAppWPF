   M S B A M L   `   `   `  ����R  NST10261874_PROG6221_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ST10261874_PROG6221_POEST10261874_PROG6221_POE  5   	   #    ST10261874_PROG6221_POE.Scale   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ST10261874_PROG6221_POE     5   	     � Title$  Scale Recipe��5   	   $	��600��6   $	��950��6+    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6+   � 5      $ #673AB7��6   $ 1Q�6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Scale Recipe��6   $��24(�6(   $
��Bold"�66   $
��Left=�6H   $��
71,25,0,15q�6c   ���	#FFFAFAFA6w   �� 5"   
   -   5        $��/Icons/info.jpg��5"      $��30��6A   $��30��6L   $
��Left=�6X   $	��Top=�6s   $��10q�6�   	 � ToolTip	 5$      _� 5%      .��5&      �� $<��6Click here for instructions on how to use this window.��6    $
��Wrap=�6^   5'      5)      �� 5,   
   $��0��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $
��0,20q�6X   .+�5.      �� -   5         ��Name$ RecipeComboBox��5.      $	��200��6/   �� 50      -   5        $ ScalingFactorComboBox��50      $	��100��66   $��5q�6B   $��Center=�6M   .@�51      �� $	��0.5��6   �� 52      $��2��6   �� 53      $��3��6   54      �� 56      -   5        $��Scale Recipe��56      
������$	��150��6B   $��5q�6N   6Y   57      � 5:   
   -   5         �Name$ ComparisonGrid��5:   ?   $��1��6   $��20q�6   $y�	Collapsed=�6(    � ColumnDefinitions 5;      �� 5<      $��* �6#   �� 5=      $��* �6#   .+�5A      �� $��0��6   $��20q�6)   .+�5B      �� $��Original Recipe��6   $��18(�63   $
��Bold"�6A   $
��0,10q�6S   �� 5C      -   5         ��Name$ OriginalRecipeRichTextBox��5C      $	��400��6A   $	��300��6M   $	��0,5q�6Z   5D      �� 5G      $��1��6   $��20q�6)   .+�5H      �� $��Scaled Recipe��6   $��18(�61   $
��Bold"�6?   $
��0,10q�6Q   �� 5I      -   5        $ ScaledRecipeRichTextBox��5I      $	��400��6?   $	��300��6K   $	��0,5q�6X   5J      5K      �� 5N   
   $��1��6   $
 
Horizontal=�6"   $��Center=�6;   $��
0,116,0,20q�6X   $	��770��6l   .+�5P      �� -   5        $��Back to Recipe Menu��5P      
�������$	��150��6J   $��38��6V   $��Bottom=�6b   6}   �� 5R      -	   5         ��Name$ ResetButton��5R      
��� ���$��Reset Recipe��6>   $
��Bold"�6U   $��18(�6g   $��Center=�6u   $	��250��6�   $��50��6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5T      -
   5        $ OkButton��5T      
���/���$��OK��6@   $	��150��6M   $��Bottom=�6Y   $��30��6t   $��5q�6�   $y�	Collapsed=�6�   5U      5V      5W      