   M S B A M L   `   `   `  ????B  >HangMen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:HangMenHangMen  5   	       HangMen.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:HangMen     5   	     ? Title$!  Hang Men Game Made By Łysy??5   	   $	??650??6,   $	??900??69   $	??650??6E   $	??800??6U    ? WindowStyle$ ThreeDBorderWindow=?5	   	    ? 
ResizeMode$ NoResize=?5
   	    ? 	Resources 5       ?? 
TargetType   
BasicHover ?? Property ?? Value ?? 
TargetType ?? CornerRadius	 ?? Padding
 ?? Triggers P? Property P? Value??%?  &	        ?? 5   
   " ??6   .?5      ??  ? ?? ?#FFC4826+   ?? 5       ? ??$ Franklin Gothic)?6+   ?? 5       ? ??$ 16(?6)   ?? 5       ? ??$	 190??6&   ?? 5       ? ??$ 60??6'   ?? 5       ? ??$ 
15,0,15,30q?6'   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? #??z??6!   $ 10??5      $??1q?5      $	 5q?5      ???#000._?5      ?? $??Center=?6+   $??Center=?5   +   5      5       5"      
 5%      P? 5&       ?@J?IsMouseOver$
 True??61   . ?5'      ??  ? ?? ?	#FFBD813D63   ?? 5(       ? ??$ 18(?61   5)      5+      5,      ??5.      ?? 5/   
    ?? ImageSource$ img/bc_png.png??6    j? Stretch$
 fill=?62   .??52      ? $??20q?6    ? ColumnDefinitions 53   
   ?? 54      $
??auto ?6   ?? 55      $??* ?6    ? RowDefinitions 58   
   ?? 59      $
??auto ?6   ?? 5:      $??* ?6   .+?5=   
   ?? $??HANG MEN THE GAME!??6   $??	monospace)?5>      $??50(?5?      $??0??5@      $??0??5A      $??2??5B      $
??bold"?5C      $??Center=?5D      ???	#FFF3C5F35E      ?? 5F   
   $??0??6   $??0??6%   ???	#C129274C$??2??6I   $??Center=?6Z   $??10q?6u   .+?5G      ?? $
??Play??6   $??15,30,15,30q?5H      #??[  5J      $
??Home??5K      ??5I      ?? *UpdateViewCommand+5K      ?? 5M      $??Ranking??6   #??[  5O      $??Account??5P      ??5N      ?? *UpdateViewCommand+5P      ?? 5R      $??Password Managment??6   #??[  5T      $??PasswordOperations??5U      ??5S      ?? *UpdateViewCommand+5U      5V      ?? 5X   
   $??1??6?   $??1??6O   ??6   ?? *SelectedViewModel+6O   5Y      5Z      