   M S B A M L   `   `   `  ����B  >Napelem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NapelemNapelem  5   	       Napelem.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Napelem     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Login��5	   	   $	��350��6   $	��400��6$    � WindowStyle$
 None=�60    � WindowStartupLocation$ CenterScreen=�5
   	    � AllowsTransparency$
 True��5   	   
������ .��5      �� ���	#FF1B1919$��1q�6$    �� CornerRadius$ 30��68   ._�5   
   � -   5        $	��400��5      .+�5      �� -   5         ��Name$ titleTextBlock��5      $
��Left=�60   $��	44,33,0,0q�6K   $
��Wrap=�6^   $��ALL IN ENERGY��6r   $	��Top=�6�   ${�False��6�   $��72(�6�   $��Normal$�6�   $��Normal"�6�   $��Haettenschweiler)�6�   
��� ���$��2��6  �� 5      -   5         ��Name$ userTextBox��5      $
��Left=�6+   $��119,163,0,0q�6F   $	��Top=�6[   $	��162��6s   $y�Visible=�6   $��22��6�   $�� ��6�   $��Center=�6�   $��Center=�6�   .��6�    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��69   5      5      .��6%   5      �� 5      -   5        $ 	UserLabel��5      $
��Left=�6+   $��160,137,0,0q�6F   $
��Wrap=�6[   $��	Username:��6o   $	��Top=�6�    J� RenderTransformOrigin$ -0.122,-0.06&�6�   
�������$��16(�6�   $
��Bold"�6�   �� 5      -   5        $ 	PassLabel��5      $
��Left=�6+   $��162,190,0,0q�6F   $
��Wrap=�6[   $��	Password:��6o   $	��Top=�6�   $ -0.122,-0.06&�6�   
�������$��16(�6�   $
��Bold"�6�   G� 5      -   5        $��passwordBox��5      $
��Left=�6-   $��119,216,0,0q�6H   $	��Top=�6]   $	��162��6u   $��22��6�   $��Center=�6�   $��Center=�6�   ��5      �� 5      "	 G�6    �� 	Resources 5      ��%^   '��       �� 5      "	 ��6$   .�5   "   �� 
 �@��CornerRadius$ 8��6A   5      5      .�5       �� 
 � �� 5!      �� 5"   "    �� 
TargetType" G�62   .R�5#   &   ��  ��Name$ border��6-   $ 8��6=   #��z��6N   #��z��6z   #��z��6�    J� SnapsToDevicePixels$
 True��6�   ._�5$   *   ��  ��Name$ PART_ContentHost��67   $|�false��6Q   $��Hidden=�6c   $��Hidden=�6�   5%   '    �� Triggers 5&   &   P� 5'   *    P� Property � {� P� Value$ false��6G   . �5(   .   ��  �� 
TargetName$ border��6H   
 �@J�Opacity$
 0.56Q�6\   5)   +   P� 5*   *    �@J�IsMouseOver$
 true��6I   . �5+   .   �� $ border��6L   
 � �� �	#FF7EB4EA6`   5,   +   P� 5-   *    �@J�IsKeyboardFocused$
 true��6O   . �5.   .   �� $ border��6L   
 � �� �	#FF569DE56`   5/   +   51   #   53       �� Triggers 54      ]� 55       ]� 
Conditions 56   "   �� 57   &    �� Property+ �@G�#IsInactiveSelectionHighlightEnabled �� Value$
 true��6_   �� 58   &    �@G�IsSelectionActive$ false��6M   ./�5:   "   �� 
 �@G�SelectionBrush# � /�6C   5;      5=      5?      �� 5@      -   5        $��passwordTxtBox��5@      $
��Left=�6,   $��119,216,0,0q�6G   $	��Top=�6\   $	��162��6t   $��22��6�   $y�	Collapsed=�6�   $��2��6�   �� 5A      -   5        $��ShowPass��5A      $
��Left=�6'   $��288,220,0,0q�6B   $	��Top=�6W   6�   �� 5B      -	   5        $��Loginbtn��5D         RoundeButtonTemplate#��[  5C      $��Login��5E      $
��Left=�5F      $��119,253,0,0q�5G      $	��Top=�5H      $ 
0.222,-1.2&�5I      $��27��5J      $	��162��6   $
��Bold"�5K      
���   �5M      �� 5N      -
   5         ��Name$ closeApplicationBtn��5P        ExitButtonTemplate#��[ 5O      $
��Bold"�5Q      $��Close��5R      6    5T      5U      5V      