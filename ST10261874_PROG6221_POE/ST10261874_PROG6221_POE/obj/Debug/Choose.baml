   M S B A M L   `   `   `  ����R  NST10261874_PROG6221_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ST10261874_PROG6221_POEST10261874_PROG6221_POE  5   	   $    ST10261874_PROG6221_POE.Choose   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ST10261874_PROG6221_POE     5   	     � Title$  Choose��5   	   $	��450��6   $
��1100��6%    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6+   � 5      $ #673AB7��6   $ 1Q�6+   5      .��5      � $	��411��6   $	��Top=�6   $��0,39,0,0q�60    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5$   
   �� -   5        $��/Icons/info.jpg��5$      $��30��6A   $��72��6L   $
��Left=�6X   $	��Top=�6s   $��
10,-32,0,0q�6�   	 � ToolTip	 5&      _� 5'      .��5(      �� $<��6Click here for instructions on how to use this window.��6    $
��Wrap=�6^   5)      5+      �� 5.   
   -   5        $��FilterControls��5.   P   $��0��6   
 �� Orientation$
 
Horizontal=�6"   $��10,10,10,10q�6;   .+�5/      �� $��Keyword:��6   $��Center=�6(   
�������$	��5,0q�6V   �� 50      -   5         ��Name$ KeywordTextBox��50      $	��150��6.   $��5q�6:   $	 Enter a keyword to search��6E   �� 51      $��Recipe Name:��6   $��Center=�6,   
�������$	��5,0q�6Z   �� 52      -   5        $ RecipeNameTextBox��52      $	��150��61   $��5q�6=   $"	 Enter the name of the recipe��6H   �� 53      $��Food Group:��6   $��Center=�6+   
�������$	��5,0q�6Y   �� 55      -   5         ��Name$ FoodGroupComboBox��55      $	��150��62   $��5q�6>   $	 Select a food group��6I   .@�56      �� $	��All��6   �� 57      $��Starchy foods��6   �� 58      $��Vegetables and Fruits��6   �� 59      $'��!Dry beans, peas, lentils and soya��6   �� 5:      $"��Chicken, fish, meat and eggs��6   �� 5;      $��Milk and dairy products��6   �� 5<      $��Fats and oil��6   �� 5=      $��Water��6   5>      �� 5?      $��Max Calories:��6   $��Center=�6-   
�������$	��5,0q�6[   �� 5@      -   5        $ MaxCaloriesTextBox��5@      $��80��62   $��5q�6=   $	 Enter maximum calories��6H   �� 5B      -   5        $��Filter��5B      
��� ���$��80��6:   $��5q�6E   $	 Apply filters��6k   �� 5C      -   5        $��Reset��5C      
��� ���$��80��69   $��5q�6D   $	 Reset all filters��6i   5D      �� 5G   
   -	   5        $��RecipeListView��5G       $��1��6   $��10,0,188,10q�66   
���   �$��1q�6_    �� SelectionMode$ Single=�6s    �� View 5H      �� 5I      .P�5J      �� $��Recipe Name��6%    �� Width$	 200��6:    �� DisplayMemberBinding 6F   �� *Name+5K      5M      �� 5P   
   -
   5         ��Name$ ShowDetailsButton��5P      
����� �$��Show Details��6>   $	��150��6U   $��
0,256,33,0q�6a   $��Right=�6u   $	��Top=�6�   $��1��5Q   &   $��40��63   �� 5T   
   -   5        $��DetailsStackPanel��5T   F   $��2��6   $��10q�6"   $	��Top=�6.   $y�	Collapsed=�6_   .+�5U      �� $��Recipe Details:��6   
�������$
��Bold"�6B   $	��Top=�6T   $��16(�6l   $��Center=�6z   �� 5W      -   5         ��Name$ RecipeDetailsRichTextBox��5W       �� 
IsReadOnly . $
��0,10q�6N   $��Center=�6\   $	��400��6y   $	��150��6�   �� 5X      $��Steps:��6   
�������$
��Bold"�69   $��0,10,0,5q�6K   $��14(�6]   $��Center=�6k   �� 5Z      -   5         ��Name$ StepsListBox��5Z      $��0,0,0,10q�6,   $	��400��6>   $��Center=�6J   ��5[      �� 5\      .R�5]      �� $
 
Horizontal=�6%   .+�5_      �� $��Center=�6G   ��6'   �� *Description+6G   5`      5a      5c      �� 5e      -   5        $
��Done��5e      
���/���$	��150��6=   $��10q�6I   $��Right=�6U   6q   5f      5g      5h      