   M S B A M L   `   `   `  ����B  >Napelem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NapelemNapelem  5   	       Napelem.admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Napelem     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ admin��5	   	   $	��400��6   $	��450��6$    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      �� ���	#FF1B1919$��1q�6$    �� CornerRadius$ 30��68   ._�5   
   � $��Stretch=�6   $��Stretch=�6-   .+�5      �� -   5        $��nameTextBox��5      $��Center=�6)   $��0,97,0,0q�6F    �� TextWrapping$
 Wrap=�6X   $��Center=�6l   $��Center=�6�   $	��Top=�6�   $	��150��6�   $��20��6�   .��6�    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 5��69   5      5      .��6%   5      �� 5      -   5        $��userNameTextBox��5      $��Center=�6-   $��	0,157,0,0q�6J   $
 Wrap=�6]   $��Center=�6q   $��Center=�6�   $	��Top=�6�   $	��150��6�   $��20��6�   .��6�    5      ��%^   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 5��69   5      5      .��6%   5      �� 5      -   5        $��roleComboBox��5      $��Center=�6+   $��	0,212,0,0q�6H   $	��Top=�6[   $	��150��6s   $��20��6   .@�5      �� $��warehouse manager��6   �� 5      $��warehouse worker��6   �� 5       $��professional��6   5!      G� 5"      -   5        $��passTextBox��5"      $��Center=�6-   $��	0,262,0,0q�6J   $��Center=�6]   $��Center=�6   $	��Top=�6�   $	��150��6�   $��20��6�    � 
InputScope$ Default��6�   ��5#      �� 5$      " G�6    �� 	Resources 5%      ��%^   '��       �� 5&      " ��6$   .�5'   "   �� 	 �@��CornerRadius$
 8��6A   5(      5)      .�5*      �� 	 � ��
 5+      �� 5,   "    �� 
TargetType" G�62   .R�5-   &   ��  ��Name$ border��6-   $ 8��6=   #��z��6N   #��z��6z   #��z��6�    J� SnapsToDevicePixels$
 True��6�   ._�5.   *   ��  ��Name$ PART_ContentHost��67   $|�false��6Q   $��Hidden=�6c   $��Hidden=�6�   5/   '    �� Triggers 50   &   P� 51   *    P� Property � {� P� Value$ false��6G   . �52   .   ��  �� 
TargetName$ border��6H   	 �@J�Opacity$

 0.56Q�6\   53   +   P� 54   *    �@J�IsMouseOver$
 true��6I   . �55   .   �� $ border��6L   	 � ��
 �	#FF7EB4EA6`   56   +   P� 57   *    �@J�IsKeyboardFocused$
 true��6O   . �58   .   �� $ border��6L   	 � ��
 �	#FF569DE56`   59   +   5;   #   5=       �� Triggers 5>      ]� 5?       ]� 
Conditions 5@   "   �� 5A   &    �� Property+ �@G�#IsInactiveSelectionHighlightEnabled �� Value$
 true��6_   �� 5B   &    �@G�IsSelectionActive$ false��6M   ./�5D   "   �� 	 �@G�SelectionBrush#
 � /�6C   5E      5G      5J      �� 5K      -   5        $��addBtn��5L         RoundeButtonTemplate#��[  5K      $	��Add��5M      $��Center=�5N      $��	0,302,0,0q�5O      $��Center=�5P      $	��Top=�5Q      $	��124��5R      $��20��6   $
��Bold"�5S      
���   �
��� ���5V      �� 5W      $
��Left=�6   $��
147,72,0,0q�63   $
��Wrap=�6G   $��Name:��6[   $	��Top=�6h   
�������$��15(�6�   $
��Bold"�6�   �� 5X      $
��Left=�6   $��147,188,0,0q�63   $
��Wrap=�6H   $��Role:��6\   $	��Top=�6i   
�������$��15(�6�   $
��Bold"�6�   �� 5Y      $
��Left=�6   $��147,236,0,0q�63   $
��Wrap=�6H   $��	Password:��6\   $	��Top=�6m   
�������$��15(�6�   $
��Bold"�6�   �� 5Z      $
��Left=�6   $��147,132,0,0q�63   $
��Wrap=�6H   $��	Username:��6\   $	��Top=�6m   
�������$��15(�6�   $
��Bold"�6�   �� 5[      -   5         ��Name$ backBtn��5\        ExitButtonTemplate#��[ 5[      $
��Back��5]      $��Center=�5^      $��60��5_      $��25��6   $��16(�5a      $
��Bold"�6   
���   �5b      �� 5c      $��Register new worker��6   $
��Left=�62   $��6,2,0,0q�6M   $	��Top=�6^   
��� ���$��28(�6�   $��Haettenschweiler)�6�   5d      5e      5f      