   M S B A M L   `   `   `  ����J  FFinalAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FinalAssignment.ViewsFinalAssignment.Views  5      )    #FinalAssignment.Views.InventoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:FinalAssignment.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      .+�5   
   �� -   5        $��InventoryListView��5       �� View 5      �� 5       �� ColumnHeaderStringFormat$  ��6   .P�5      ��  �� Width$	 100��6%   $��Item Number��61    �� DisplayMemberBinding 5   %   ��  �� Path$ 
ItemNumber��� 5      $ 75��6%   $
��Name��60    5   %   �� $
 Name��� 5      $ 75��6%   $
��Cost��60    5   %   �� $
 Cost��� 5      $	 150��6%   $��Quantity on Hand��61    5   %   �� $ QuantityOnHand�5      5      5      5      