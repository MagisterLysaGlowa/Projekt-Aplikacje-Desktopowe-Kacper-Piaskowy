   M S B A M L   `   `   `  ????B  >HangMen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HangMen.ViewsHangMen.Views  5      &     HangMen.Views.PasswordOperations   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:HangMen.Views     5        ? 	Resources  5	       ?? 
TargetType   LogIn_Button ?? Property ?? Value ?? 
TargetType ?? CornerRadius ?? Padding ?? Triggers P? Property	 P? Value  passwordBox_rounded
 ??Name J? OpacityMask ??Name J? SnapsToDevicePixels   ScrollViewerControlTemplate1 ?? Triggers ?? 
TargetName??%X  &	        &	 (    ?? 5
   
   " ??6   .?5      ??  ? ?? ?	#FF14E68A6+   ?? 5       ? ??$ 20(?6)   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? #??z??6!   $ 10??5      $??1q?5      $ 5q?5      ???#000._?5      ?? $??Center=?6/   $??Center=?5   /   5      5      5       5      P? 5       ?@J?IsMouseOver$
	 True??61   . ?5      ??  ? ??$ 23(?61   ?? 5        ? ?? ?	#FF2EC35963   ?? 5!       ?@?Cursor$
 Hand??6/   5"      5$      ?? 5&   
   " G?6   .?5'      ??  ? ??$ 1q?60   ?? 5(       ? ??$ Center=?6;   ?? 5)       ? ??$ 1q?6(   ?? 5*       ? ?? 5+      ?? 5,      " G?6&   .R?5-      ?? $
 Bd??62   $ 6??6!   
?????? 
???????$??3q?6k    6   Z? ._?5.      ?? $ PART_ContentHost??6g   # z 6+   #???  6?   5/       50      P? 51       ? {?$	 false??6;   . ?52   "   ?? $ Bd??6?   # ? ??6O    ? ???? 53   "   # ? ??6?    ? ??54      56      58      59      5:      .??5;      ?  ? ColumnDefinitions 5<   
   ?? 5=      $??* ?6    ? RowDefinitions 5@   
   ?? 5A      $
??auto ?6   ?? 5B      $
??auto ?6   ?? 5C      $
??auto ?6   .+?5F   
   ?? $??Enter Admin Password??6   $??../Fonts/#Patrick Hand)?5G      $??0??5H      $??0??5I      $??	0,160,0,0q?5J      
???????$??25(?5L      $??Center=?5M      G? 5O   
   -   5         G?Name$
 pass??5O      $	??300??5P      $??60??5Q      $??1??5R      $??0??5S      $??Center=?5T      $??Center=?5U      $??20(?5V      
???????#??[ 5X      ?? 5Z   
   -   5        $??2??5Z      $??0??5[      $??Open Password Manager??5\      $	??210??5]      $??60??6   $??0,20,0,0q?5^      $??../Fonts/#Patrick Hand)?5_      #??[  5`      5a      5b      5c      