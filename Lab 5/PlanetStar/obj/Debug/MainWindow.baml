   M S B A M L   `   `   `  ����R  NSharpGL.WPF, Version=2.4.0.0, Culture=neutral, PublicKeyToken=27fc851303210b27>.clr-namespace:SharpGL.WPF;assembly=SharpGL.WPFSharpGL.WPF  5   	   E APlanetStar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PlanetStar
PlanetStar 5   	      PlanetStar.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =gl.clr-namespace:SharpGL.WPF;assembly=SharpGL.WPF     5   	   *localclr-namespace:PlanetStar     5   	     � Title$D  >Лабораторна робота номер 5, Драгуш��5	   	   $	��470��64   $	��720��6A   .��5
      � $��	0,0,-8,-7q�6    � ColumnDefinitions 5   
   �� 5      $	��61* �6   �� 5      $
��114* �6   �� 5      $
��185* �6   .+�5   
      SharpGL.WPF.OpenGLControl  -   5           DrawFPS .    	FrameRate$ 60Q�5   �   $��10,10,35,78q�6�   $��3��6�   �� 5   
   -   5         ��Name$ checkBox��5   !   $��20(�6   $��Обертати зорю��63   $
��Left=�6K   $	��Top=�6g   $��
10,373,0,0q�6    d� 	IsChecked$ FalseY�6�   $y�Hidden=�6�   $��2��6�   �� 5   
   -   5        $ checkBox_Copy��5   !   $��20(�6   $%��Обертати планету��68   $
��Left=�6S   $	��Top=�6o   $��57.748,373,0,0q�6�   $ FalseY�6�   $y�Hidden=�6�   $��2��6�   $��1��6�   �� 5   
   -   5        $ checkBox_Copy1��5   !   $��20(�6   $-��'Увімкнути освітлення��69   $
��Left=�6X   $	��Top=�6t   $��
36,373,0,0q�6�   $
 TrueY�6�   $y�Hidden=�6�   $��2��6�   �� 5   
   -   5         ��Name$ Button_star��5      $��20(�6   $��Крутись!��64   $
��Left=�6G   $	��Top=�6c   $��
27,375,0,0q�6{   $��55��6�   $	��144��6�   $��2��6�   �� 5   
   -   5        $ Button_planet��5      $��20(�6   $%��Обертати планету��66   $
��Left=�6Q   $	��Top=�6m   $��73.748,399,0,0q�6�   $y�Hidden=�6�   $��2��6�   $��1��6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��47��6>   $��279,375,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $��5��6s   $	��Top=�6|   $��56��6�   $��24(�6�   $��2��6�   �� 5   
   $��Швидкість = ��6   $
��Left=�6'   $��111,382,0,0q�6B   $	��Top=�6W   $��22(�6o   $��2��6}   5      5      