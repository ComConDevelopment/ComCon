   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5       ComCon.Client.Modules.Login1   +ComCon.Client.Modules.Login.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ntoolkit:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      -   5          >�Name$  Window��5   7   
������� J� Opacity$ 0Q�6Z   
�������$��1q�6{   $��6,10,6,0q�6�    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard   MainGreenColor	
 �� To g� Duration �� 
TargetName �� TargetProperty  MainHoverColor  MainActiveColor ��Name  MainGreenBrush �� CornerRadius��%�  '��       7   7  7  7  �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6    5        5   "   
Common��. 5   &     
Normal��.	 5   *   �� .��5   .   �� 8
   $ 0:0:0.1D�6b   $ 
MainBorder��6u   $1 +(Border.Background).(SolidColorBrush.Color)�6�   5   +   5   '     5   &   	MouseOver��.	 5   *   �� .��5   .   �� 8
  $ 0:0:0.1D�6b   $ 
MainBorder��6u   $1 +(Border.Background).(SolidColorBrush.Color)�6�   5   +   5   '     5   &   Pressed��.	 5   *   �� .��5   .   �� 8
  $ 0:0:0.1D�6c   $ 
MainBorder��6v   $1 +(Border.Background).(SolidColorBrush.Color)�6�   5    +   5!   '   5"   #   .+�5$      �� $ 
MainBorder��6%   8�� $��30��6f   $ 5��6r   ._�5%   "   �� $��Center=�63   $��Center=�6P   5&      5'      5(      5*      5,      5-       � Triggers 5.      :� 5/   
    :� RoutedEvent$ Loaded��6   .[�50      �� .��51      �� .��52      W�  W� From$ 0X�6&   	 W� To$ 1X�6/   $ Opacity�66   $ Window��6Z   $ 0:0:0.5D�6y   54      55      56      57      :� 58   
    :� 
SourceName$ LoginButton��6   $ Button.Click��60   .[�59      �� .��5:      �� .��5;      U� $: 4(UserControl.RenderTransform).(TranslateTransform.Y)�64   $ Window��6�   $ 0:0:1D�6�   .\�5<      ��  O� Value$ 0Q�6/    O� KeyTime$ 0:0:0.2��69   6M   �� 5=      $	 600Q�6/   $ 0:0:0.25��6;   6P   5>      5?      5@      5A      .��5C      %   Xceed.Wpf.Toolkit.BusyIndicator     BusyContent$ Login...��6[      IsBusy 6   �� *IsBusy+ �� UpdateSourceTrigger$ PropertyChanged=�.��5D   
   � .+�5E   
   ��   MainBackgroundBrush#��[ 6   $	��300��6C   $	��260��6P   $ 5��6\   ._�5F   
   �� $��Center=�6   $��Center=�60   .+�5H      �� 
�������$��20(�63   $��Bitte logge dich ein��6A   $��Center=�6]   $��Center=�6z   $��0,0,0,25q�6�   $��Calibri)�6�   �� 5I      -   5         ��Name$ NameBox��5I   �   ���	#FF303030$��15(�65   $��Calibri)�6C     WaterMarkTextBoxMail#��[ 6X   $��40��6�   $	��220��6�   $��Center=�6�   $��5q�6�   
�������$��2q�61  ��6�   �� *EMail+$ PropertyChanged=� �� Mode$ TwoWay=�.��6E  5J      G� 5L      -   5        $��40��5L      $	��220��6*   $��Center=�66   $��5q�6Q   
�������  NormalPasswordBox#��[ 6p   $��2q�6�   5M      �� 5N      -   5         ��Name$ LoginButton��5N   j   $��Login��6   $	��150��6%   $��Calibri)�61   $
��Bold"�6F   $��0,20,0,0q�6X   ��6   �� *LoginCommand+5u      �� 5v      $��Registrieren��6   $	��150��64   
������ 
������ $��0,10,0,0q�6�   ��6s   �� *ShowRegisterViewCommand+6�   �� 5w      -   5         ��Name$ ValidationTextBlock��5w       
���  ��$
��Bold"�6�   $��Center=�6�   $
��Wrap=�6�   $��0,8,0,0q�6  $ 0Q�6  ��6=   �� *ValidationText+$ PropertyChanged=� �� NotifyOnTargetUpdated .  �� NotifyOnSourceUpdated .  5x      :� 5y      $ Binding.TargetUpdated��6+   .[�5z   "   �� .��5{   &   �� .��5|   *   W� $ Opacity�6:   $ 0:0:1D�6^   $ 0X�6o   $	 1.0X�6x   W� 5}   *   $ Opacity�6:   $ 0:0:1D�6^   $	 1.0X�6o   $	 0.0X�6z     g� 	BeginTime$  0:0:3X�6�   5~   '   5   #   5�      5�      5�      5�      5�      5�      5�      