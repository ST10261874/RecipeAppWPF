   M S B A M L   `   `   `  ����R  NST10261874_PROG6221_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ST10261874_PROG6221_POEST10261874_PROG6221_POE  5   	   %    ST10261874_PROG6221_POE.Display   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ST10261874_PROG6221_POE     5   	     � Title$  Display��5   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6+   � 5      $ #673AB7��6   $ 1Q�6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��/Icons/info.jpg��5      $��30��6A   $��30��6L   $
��Left=�6X   $	��Top=�6s   $��10q�6�   	 � ToolTip	 5      _� 5       .��5!      �� $<��6Click here for instructions on how to use this window.��6    $
��Wrap=�6^   5"      5$      �� 5'   
   $��Recipe List��6   $��20(�6'   $
��Bold"�65   $��Center=�6G   $
��0,10q�6d   
�������6r   �� 5*   
   $��1��6   
 �� Orientation$
 Vertical=�6"   $��Center=�69   $��	0,10,0,48q�6V   $	��248��6i   .+�5+      �� $
 
Horizontal=�6   .+�5-      �� -   5         ��Name$ SortByComboBox��5-      $	��150��63   $��5q�6?    �� SelectedIndex$ 0��6J   .@�5.      �� $��Sort by Name��6#   �� 5/      $��Sort by Date��6#   50      �� 52      -   5        $
��Sort��52      
��� E��$��80��6?   $��5q�6J   6U   53      54      �� 57   
   $��1��6   $
��Auto=�6$   $��0,41,0,0q�6G   $��2��6Y   .��58      �� -   5        $��RecipeListView��58      $��10,49,10,218q�6-   
���   �$��1q�6W   $	��237��6k    �� View 5:      �� 5;      .P�5<      �� $��Recipe Name��6)    �� Width$	 200��6>    �� DisplayMemberBinding 6J   �� *Name+�� 5=      $��Date and Time Added��6)   $	 200��6F    6R   �� *	DateAdded+5>      5@      5A      �� 5D   
   $��3��6   $
 
Horizontal=�6"   $��Center=�6;   $��Bottom=�6X   $
��0 20q�6s   .+�5F      �� -   5        $��Go Back to Recipe Menu��5F      $��205,0q�66   
�������$	��150��6`   6l   �� 5G      -   5        $��Add More Recipes��5G      $��205,0q�60   
����� �$	��150��6X   $��28��6y   5I      5J      5K      