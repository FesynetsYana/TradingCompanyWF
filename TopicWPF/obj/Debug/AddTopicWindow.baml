   M S B A M L   `   `   `  ����C  ?TopicWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TopicWPFTopicWPF  5   	       TopicWPF.AddTopicWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TopicWPF     5   	     � Title$  AddTopicWindow��5   	   
�������$	��400��63   $	��400��6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6"   .@�5      �� $��Topic Information��6   .��5      �  5      �� 5      $
��Auto �6+   �� 5       5      �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5!      �� $��Title��6    $��0��6-   $��0��6:   $��Center=�6J   $��10q�6e   �� 5"      $
��Text��6    $��1��6,   $��0��69   $��Center=�6I   $��10q�6d   �� 5#      $��Comment��6    $��2��6/   $��0��6<   $��Center=�6L   $��10q�6g   �� 5%      $��20(�6@   $��0��6O   $��1��6\   $��10q�6l   ��6   ��  �� Path$ Topic.Title�6l   �� 5&      $��1��6   $��1��5'      $��10q�5(       �� DisplayMemberPath$
 Text��5+       �� SelectedValuePath$ GenreID��5,      ��5*      �� $ Genres� �� SelectedValue 5-      �� $ Movie.GenreID��� 5/      $��20(�6?   $��2��6M   $��1��6Z   $��10q�6j   ��6   �� $ 
Movie.Year�6j   51      52      55      �� 57   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   $��Center=�6K   .+�58      �� -   5        $��Cancel��58      
������  �� IsCancel . $	��150��6O   $��20q�6[   6g   �� 59      -   5        $
��Save��59      
������ $	��150��6=   $��20q�6_   5:      5;      5<      