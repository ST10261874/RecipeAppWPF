   M S B A M L   `   `   `  ����R  NST10261874_PROG6221_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ST10261874_PROG6221_POEST10261874_PROG6221_POE  5   	   *    $ST10261874_PROG6221_POE.EnterDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ST10261874_PROG6221_POE     5   	     � Title$  EnterDetails��5   	   $	��650��6   $	��950��6+    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6+   � 5      $ #673AB7��6   $ 1Q�6+   5      .��5      �� .��5   
   � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $��* �6    �� 5"      $
��Auto �6    .+�5&      �� $��0��6   	 �� Orientation$	 
Horizontal=�6&   .+�5(      �� -   5        $��/Icons/info.jpg��5(      $��30��6I   $��30��6T   $
��Left=�6`   $	��Top=�6{   $��10q�6�   
 � ToolTip
 5*      _� 5+      .��5,      �� $<��6Click here for instructions on how to use this window.��6(   $
��Wrap=�6f   5-      5/      �� 50      $��Recipe Name:��6   
�������$��Center=�6C   �� 51      -   5         ��Name$ RecipeNameTextBox��51      $	��200��65   $��10q�6A   $��26��6M   �� 52      -   5        $��OK��52      
����� �$��50��68   $��38��6X   53      �� 56      -   5         ��Name$ IngredientCountPanel��56   V   $��1��6   $	 
Horizontal=�6&   $y�	Collapsed=�6?   .+�58      �� $��Number of Ingredients:��6   
�������$��Center=�6M   �� 59      -   5        $ IngredientCountTextBox��59      $	��100��6:   $��10q�6F   �� 5:      -   5        $��OK��5:      
����� �$��50��68   6C   5;      �� 5>      -   5        $ IngredientsPanel��5>   =   $��2��6   $y�	Collapsed=�6&   .+�5@      �� $��Ingredients:��6   
�������$
��0 10q�6C   �� 5A      -   5        $ IngredientInputsPanel��5A   4   $	 Vertical=�6   64   �� 5B      -	   5        $��Add Ingredients��5B      
����� �$��5q�6\   $	��150��6g   $��Center=�6s   5C      �� 5F      -
   5        $ StepCountPanel��5F   V   $��3��6   $	 
Horizontal=�6&   $y�	Collapsed=�6?   .+�5H      �� $��Number of Steps:��6   
�������$��Center=�6G   �� 5I      -   5        $ StepCountTextBox��5I      $	��100��64   $��10q�6@   �� 5J      -   5        $��OK��5J      
����� �$��50��68   6C   5K      �� 5N      -   5        $ 
StepsPanel��5N   =   $��4��6   $y�	Collapsed=�6&   .+�5P      �� $��Steps:��6   
�������$
��0 10q�6=   �� 5Q      -   5        $ StepInputsPanel��5Q   4   $	 Vertical=�6   64   �� 5R      -   5        $��	Add Steps��5R      
����� �$��5q�6V   $	��150��6a   $��Center=�6m   5S      &   System.Windows.Controls.DataGrid  5V      -   5        $��IngredientsDataGrid��5V   $   $��5��6      AutoGenerateColumns .  $
��0 10q�6[   $y�	Collapsed=�6i      Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ Quantity��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Quantity+6b     5Z      $ 
Ingredient��6)   $ * 6V   
 �   � 6=   �� *Name+6`     5[      $
 Unit��6)   $ * 6P   
 �   � 67   �� *Unit+6Z     5\      $ Calories��6)   $ * 6X   
 �   � 6;   �� *
Calories+6b     5]      $ 
Food Group��6)   $ * 6[   
 �   � 6=   �� *	FoodGroup+6e   5_        5`      -   5        $��StepsDataGrid��5`   $   $��5��6    .  $
��0 10q�6U   $y�	Collapsed=�6c    5b        5c      $ Description��6)   $ * 6^   
 �   � 6>   �� *Description+6h   5e      �� 5h      $��6��6   $	 
Horizontal=�6&   $��Center=�6?   $
��0 20q�6\   .+�5j      �� -   5        $��Save Recipe��5j      
���/���$	��150��6H   $��5q�6T   6_   �� 5k      -   5        $��Cancel��5k      
��� E��$	��150��6A   $��5q�6M   6X   �� 5l      -   5        $��Display Recipe List��5l      
����i��$	��171��6L   $��5q�6X   $��30��6z   5m      5n      5o      5p      