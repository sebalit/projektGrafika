   M S B A M L   `   `   `  ����I  EprojektGrafika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:projektGrafikaprojektGrafika  5   	       projektGrafika.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:projektGrafika  5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1024��6)    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6[    � 
ResizeMode$ NoResize=�6n   .��5      � -   5        ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ #3832EE��6    � Offset$ 1Q�6/   � 5      $ #3C9DED��6   $ 0Q�6/   5      .+�5   
   � $��	0,5,0,550q�6   .+�5      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   $��214,0,212,0q�6O   $	��598��6d   .+�5      �� $8��2Aplikacja dla opiekunów osób starszych i chorych��6   $��Center=�6T   $��23(�6o   $��Mongolian Baiti)�6}   	 J� Opacity$		 0.7Q�6�   $
��20 0q�6�   5      �� 5      $ 
Horizontal=�6   $��Center=�62   $��	931,0,0,0q�6O   $��93��6b   .+�5      �� -   5        
 ��Name$
 buttonMinimize��5      $��45��61   $��45��6<   $��0q�6u   
���   ���6H   Z� ��6^   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6.   $��25��6D   $��21��6O   5      �� 5      -   5        $
 
buttonPOFF��5      $��45��6-   $��45��68   $��0q�6q   
���   ���6D   Z� ��6Z   Z� .��5        $ Power=�6.   $��25��6;   $��21��6F   5      5      5       � 5!   
   ���#1F5DC6$��0,50,803,510q�6$   .+�5"      �� $��PACJENCI��6   $��Center=�6(   $��Center=�6C   $��20(�6`   $��Mongolian Baiti)�6n   $		 0.7Q�6�   5$      5%      �� 5&   
   -   5        $��pacjentList��5'      $
��Left=�5&      $	��221��6-   $��0,90,0,0q�5'   =   $��16(�6   ��6%   �� 6   �� 5(   
   -   5        $��refreshButton��5+   O   $��Center=�5(      $��772,145,0,0q�6.      MaterialDesignRaisedButton#��[  6C   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��6w   ���#1F5DC6
���   �$��15(�5)   :   
���   �$	��Top=�5*      $	��252��6)   $��40��65   $!��Odśwież listę pacjentów��5+      6O   � 5,   
   ���#1F5DC6$��226,50,388,510q�6$   .+�5-      �� $��LEKI ORAZ DAWKOWANIE��6   $��Center=�64   $��Center=�6O   $��20(�6l   $��Mongolian Baiti)�6z   $		 0.7Q�6�   5/      50      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ 	dawkaGrid��52      ���#3C9DED$
��Left=�51   )   $	��310��6D   $��
226,90,0,0q�6Q   $	��Top=�6e   $	��410��6}   $��14(�52   8      GridLinesVisibility$	 All=�6G      
IsReadOnly . {�.  ��6    �� 6s   �� 53   
   -   5        $
 	addButton��56      $��Dodaj pacjenta��53      $
��Left=�6*   $��772,100,0,0q�6E   #��[  6Z   $ 0��6�   $	��Top=�54      $	��252��6)   $��40��65   $��15(�6A   
���   ����#1F5DC6
���   �56       �� 58   
   -   5        $��	dawkaText��59      $��2��58      $
��Left=�6$   $��
49,145,0,0q�6?   $
��Wrap=�6S   $	��Top=�6g   $	��255��6   $	��134��6�   ��59   %   �� �� 5:   
   $��2��6   $��	188,0,0,0q�6%   � 5;   
   ���#1F5DC6$��221,442,393,118q�6$   .+�5<      �� $��Uwagi do pacjenta��6   $��Center=�61   $��Center=�6L   $��20(�6i   $��Mongolian Baiti)�6w   $		 0.7Q�6�   5>      5?      �� 5@   
   -	   5        $��uwagiBox��5A      $
��Left=�5@      $��79��6-   $��221,498,0,0q�69    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��410��6�   
�������$��15(�5A   6    �� 
IsReadOnly . 6D   �� 5C   
   -
   5        $��addDawkaButton��5D      $��Dodaj dawkowanie��5C      $
��Left=�6,   $	��Top=�6G   $	��252��6_   $��772,190,0,0q�6k   $��40��5D   D   ���#1F5DC6
���   �$��15(�6y   
���   �6�   � 5F   
   ���#1F5DC6$��772,55,0,505q�6$   .+�5G      �� $��FUNKCJE��6   $��Center=�6'   $��Center=�6B   $��20(�6_   $��Mongolian Baiti)�6m   $		 0.7Q�6�   5I      5J      �� 5K   
   -   5        $
 refreshDawkaButton��5L      $��Odśwież dawkowanie��5K      $
��Left=�6.   $	��Top=�6I   $	��252��6a   $��772,235,0,0q�6m   $��40��5L   J   ���#1F5DC6
���   �$��15(�6   
���   �6�   �� 5M   
   -   5        $
 refreshDawkaButton_Copy1��5N      $��Usuń pacjenta��5M      $
��Left=�6)   $	��Top=�6D   $	��252��6\   $��772,280,0,0q�6h   $��40��5N   J   ���#1F5DC6
���   �$��15(�6   
���   �6�   5O      5P      