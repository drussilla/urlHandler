   M S B A M L   `   `   `  ����  urlHandler.Configurator0    *urlHandler.Configurator.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main� � 	Resources 5        ImageButtonBase �� 
TargetType �� Property �� Value  RemoveButtonStyle �� BasedOn  AddButtonStyle	 �� Orientation  RuleTemplate
 � ColumnDefinitions(  "Xceed.Wpf.Toolkit.WatermarkTextBox   	Watermark  ListViewItemStyle1 �� 
TargetType��%*  &	       &	 u     7  &	 f    7  &	 �    7  &	 P    �� 5	   
   " ��6(   .�5
      ��  � ��$ 16��6'   �� 5       �@�Cursor$
 Hand��6'   5      �� 5   
   " ��6*   8   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 0 0 5 0q�6'   �� 5       � �� 5      �� 5      .R�5      �� $��/Images/remove.png��6    6>   5      5      5      �� 5   
   " ��6'   8   .�5      ��  � ��$
 Left=�64   �� 5       � ��$ 5q�6'   �� 5       � �� 5      �� 5      .R�5       �� $	 
Horizontal=�5!      .+�5"      �� $��/Images/add.png��6$   �� 5#      $��5 0 0 0q�5$   !   $��Add new rule��5%   !   5&      5'      5)      5*      �� 5+   
   .R�5,      � 
 5-      �� 5.      �� 5/      �� 50      $��21 �6'   .+�52        $��0��53      $��5q�54      $
 test��55      ��56      �� *Rule+  57      $��1��58      $��5q�59      $ test2��5:      ��5;      �� *Application+�� 5<      $��2��5=      8��  ��5?      �� *RemoveItemCommand+5@      5A      5B      �� 5C   
   " ��6+   .�5D      ��  � �� 5E      �� 5F      " ��6&   .R�5G      � .+�5H      �� 5I      5J      5L      5M      5N      .��5O      �  � RowDefinitions 5P   
   �� 5Q      �� 5R      .+�5T   
   �� $��0��5U      $��5q�5V      $��Rules:��5W      .��5X      �  5Y      �� 5Z      �� 5[      $
��Auto �6$   .+�5]      �� $��0��5^      #��[ 5_      #���  5`   6   ��6   �� *
RuleList+66   �� 5a      $��1��5b      #��[ 5d      ��5c      �� *AddNewRuleCommand+5d      5e      5f      �� 5g   
   $��1��5h      $��5q�5i      $��Default Applications:��5j      5l      5m      5n      