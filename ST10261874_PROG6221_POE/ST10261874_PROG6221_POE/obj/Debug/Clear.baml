   M S B A M L   `   `   `  ����R  NST10261874_PROG6221_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ST10261874_PROG6221_POEST10261874_PROG6221_POE  5   	   #    ST10261874_PROG6221_POE.Clear   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ST10261874_PROG6221_POE     5   	     � Title$  Clear��5   	   $	��450��6   $	��800��6$    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6+   � 5      $ #673AB7��6   $ 1Q�6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��
Clear Data��6   $��24(�6&   $
��Bold"�64   $��Center=�6F   $
��0,20q�6c   
�������6q   �� 5    
   -   5        $��/Icons/info.jpg��5       $��30��6A   $��30��6L   $
��Left=�6X   $	��Top=�6s   $��10q�6�   	 � ToolTip	 5!      _� 5"      .��5#      �� $<��6Click here for instructions on how to use this window.��6    $
��Wrap=�6^   5$      5&      �� 5)   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5+      �� $!��/Icons/trash-can_115312.png��6   $��Uniform=�69   $	��150��6K   $	��213��6W   �� 5.      
 �� Orientation$
 
Horizontal=�6   $��Center=�62   $
��0,10q�6O   .+�5/      �� -   5        $��Clear All Recipes��5/      
����� �$	��150��6N   $��41��6x   50      �� 53      -   5         ��Name$ RecipeSelectionListBox��53      $y�	Collapsed=�66    �� SelectionMode$ Multiple=�6M   $	��300��6f   $	��200��6r   $
��0,20q�6   �� 56      -   5         ��Name$ ConfirmationPanel��56      $y�	Collapsed=�64   $��Center=�6K   $��Center=�6h   .+�57      �� $1��+Are you sure you want to clear all recipes?��6   $��18(�6O   $
��0,20q�6]   
�������6k   �� 58      $
 
Horizontal=�6   $��Center=�66   $
��0,10q�6S   .+�59      �� -   5        $	��Yes��59      
���/���$	��100��6D   $��10q�6P   6\   �� 5:      -   5        $��No��5:      
�������$	��100��6<   $��10q�6H   6T   5;      5<      �� 5?      -   5        $ LoadingScreen��5?      $y�	Collapsed=�60   $��Center=�6G   $��Center=�6d   .+�5@      �� $��Clearing Data...��6   $��18(�64   $
��Bold"�6B   $��Center=�6T   $
��0,10q�6q   
�������6   � 5A      $	��300��6   $��20��6*    � IsIndeterminate . 66   5B      �� 5E      -   5        $ ClearedMessage��5E      $y�	Collapsed=�61   $��Center=�6H   $��Center=�6e   .+�5F      �� $ ��All data has been cleared.��6   $��18(�6>   $
��Bold"�6L   $��Center=�6^   $
��0,20q�6{   
�������6�   �� 5G      -	   5        $��Back to Recipe Menu��5G      
�������$	��200��6N   $
��0,10q�6Z   6h   5H      5I      5J      5K      