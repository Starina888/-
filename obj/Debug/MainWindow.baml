   M S B A M L   `   `   `  �����  �ИнформационнаяПодсистемаПреподавателей, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TeacherInformationSystemTeacherInformationSystem  5   	   )    #TeacherInformationSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8local&clr-namespace:TeacherInformationSystem     5   	     � Title$   Teacher Information System��5   	   $	��450��6,   $	��800��69   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Teachers��6   $��0,0,10,0q�6P   ��6(   �� *ShowTeachersCommand+6P   �� 5      $��Chairs��6   $��0,0,10,0q�6L   ��6&   �� *ShowChairsCommand+6L   �� 5      $��	Faculties��6   $��0,0,10,0q�6R   ��6)   �� *ShowFacultiesCommand+6R   �� 5      $��Posts��6   ��6%   �� *ShowPostsCommand+5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��10q�6;   .+�5      �� $	��Add��6   $��0,0,10,0q�6B   ��6#   �� *
AddCommand+6B   �� 5      $��Delete��6   ��6&   �� *DeleteCommand+5      &   System.Windows.Controls.DataGrid  5   
   $��2��6      AutoGenerateColumns . $��10q�6X   ��6    �� *Data+6X   5      5      