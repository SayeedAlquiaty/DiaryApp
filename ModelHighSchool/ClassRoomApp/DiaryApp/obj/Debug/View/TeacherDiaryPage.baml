   M S B A M L   `   `   `  ����C  ?DiaryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DiaryApp.ViewModelDiaryApp.ViewModel  5      $    DiaryApp.View.TeacherDiaryPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DiaryApp.ViewModel     5        N� Title$  TeacherDiaryPage��5      $	��363��6   $	��382��6(    � DataContext 5	      .  (DiaryApp.ViewModel.TeacherDiaryPresenter  5
   
   .��5      � 
�������.+�5   
   �� $��Teacher's Page��6   $
��Left=�6)   $��
140,10,0,0q�6D   $	��Top=�6X   $��91��6p   �� 5   
   $!��Enter the Diary notes below��6   $
��Left=�66   $��	20,46,0,0q�6Q   $	��Top=�6d   $	��160��6|   �� 5   
   $
��Left=�60   $	��103��6K   $��	20,77,0,0q�6X    �� TextWrapping$
 Wrap=�6k   $	��Top=�6�   $	��333��6�   ��6   �� *
DiaryNotes+6�   �� 5   
   $��Select the Class��6   $
��Left=�6+   $��
20,185,0,0q�6F   $	��Top=�6Z   $	��129��6r   �� 5   
   $��Select the Student��6   $
��Left=�6-   $��246,185,0,0q�6H   $	��Top=�6]   �� 5   
   -   5        $��ClassListBox��5       �� SelectionMode$ Multiple=�6M   $
��Left=�6�   $	��100��6�   $��
20,216,0,0q�6�   $	��Top=�6�   $	��129��6�   ��6'   �� *ClassroomList+ �� SelectedItem 6g   �� *SelectedClassroom+��5      �� 5      .R�5      �� ��6   ��  �� Path$
 Item� d� 	IsChecked 6=   �� $ 
IsSelected� �� RelativeSource ��  �� AncestorType" ��5      5      �� 5   
   -   5        $��StudentListBox��5      $
��Left=�6)   $	��100��6D   $��224,216,0,0q�6Q   $	��Top=�6f   $	��129��6~   ��5      �� 5      .R�5      �� ��6   �� *Name+ 68   �� *	IsChecked+5      5       5"      5#      