   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5       ComCon.Client.Modules.Login8   2ComCon.Client.Modules.Login.Views.RegistrationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ntoolkit:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      -   5          >�Name$  Window��5   7   
������� J� Opacity$ 1Q�6Z   
�������$��1q�6{   $��6,10,6,0q�6�    � Triggers 5	      :� 5
   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      �� .��5      W�  W� From$ 0X�6&   	 W� To$ 1X�6/    �� TargetProperty$ Opacity�66    �� 
TargetName$ Window��6Z    g� Duration$ 0:0:0.5D�6y   5      5      5      5      :� 5   
   	 :� 
SourceName$	 LoginButton��6   $ Button.Click��60   .[�5      �� .��5      �� .��5      U� $: 4(UserControl.RenderTransform).(TranslateTransform.Y)�64   $ Window��6�   $ 0:0:1D�6�   .\�5      �� 
 O� Value$
 0Q�6/    O� KeyTime$ 0:0:0.2��69   6M   �� 5      $	
 600Q�6/   $ 0:0:0.25��6;   6P   5      5      5      5      .��5      %   Xceed.Wpf.Toolkit.BusyIndicator     BusyContent$ Login...��6[      IsBusy 6   �� *IsBusy+ �� UpdateSourceTrigger$ PropertyChanged=�.��5   
   � .+�5       ��    MainBackgroundBrush#��[  6   $	��350��6G   $	��260��6T    �� CornerRadius$ 5��6`   ._�5!      �� $��Center=�6   $��Center=�68   .+�5#      �� 
�������$��20(�63   $��Registrierung��6A   $��Center=�6V   $��Center=�6s   $��0,0,0,25q�6�   $��Calibri)�6�   �� 5$      -   5         ��Name$ MailBox��5$   �   ���	#FF303030$��15(�65   $��Calibri)�6C     WaterMarkTextBoxMail#��[ 6X   $��40��6�   $	��220��6�   $��Center=�6�   $��5q�6�   
�������$��2q�6M  ��6�   �� *EMail+$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 6M  �� 5%      -   5        $ NameBox��5%   �   ���	#FF303030$��15(�65   $��Calibri)�6C     WaterMarkTextBoxUsername#��[ 6X   $��40��6�   $	��220��6�   $��Center=�6�   $��5q�6�   
�������$��2q�6T  ��6�   �� *
Username+$ PropertyChanged=�$ TwoWay=� . 6T  G� 5'      -   5        $��40��5'   "   $	��220��6.   $��Center=�6:   $��5q�6U     NormalPasswordBox#��[ 6`   
�������$��2q�6�   5(      G� 5)      -   5        $��40��5)   "   $	��220��6.   $��Center=�6:   $��5q�6U     ReTypePasswordBox#��[ 6`   
�������$��2q�6�   5*      �� 5+      -   5         ��Name$ LoginButton��5+   y   $��Registrieren��6   $	��150��64   $��Calibri)�6@   $
��Bold"�6U   $��0,20,0,0q�6g   ��6�   �� *RegisterCommand+��5,      �� 5-       �� 
TargetType" ��6$   .�5.   "   ��  �� Property � �� �� Value
 �����6?   �� 5/   "    � �� 50   &   �� 51   *    �� 
TargetType" ��6:   .R�52   .   � #��z��63   '  !System.Windows.VisualStateManager   VisualStateGroups 53   2   %  System.Windows.VisualStateGroup  55   6   
Common��   States. 56   :      System.Windows.VisualState  
Normal��   
Storyboard. 57   >   �� .��58   B   ��   MainGreenColor	 �� To# [ 6Q   $ 0:0:0.1D�6v   $ 
MainBorder��6�   $1 +(Border.Background).(SolidColorBrush.Color)�6�   59   ?   5:   ;     5;   :   	MouseOver��. 5<   >   �� .��5=   B   ��   MainHoverColor# [ 6Q   $ 0:0:0.1D�6v   $ 
MainBorder��6�   $1 +(Border.Background).(SolidColorBrush.Color)�6�   5>   ?   5?   ;     5@   :   Pressed��. 5A   >   �� .��5B   B   ��   MainActiveColor# [ 6Q   $ 0:0:0.1D�6w   $ 
MainBorder��6�   $1 +(Border.Background).(SolidColorBrush.Color)�6�   5C   ?   5D   ;   5E   7   .+�5G   2   ��  ��Name$ 
MainBorder��69     MainGreenBrush#��[ 6M   $��30��6z   $ 5��6�   ._�5H   6   �� $��Center=�6G   $��Center=�6d   5I   3   5J   /   5K   +   5M   #   5O      5R      �� 5S      -   5         ��Name$ ValidationTextBlock��5S       
���  ��$
��Bold"�6�   $��Center=�6�   $
��Wrap=�6�   $��0,8,0,0q�6  $ 0Q�6  ��6=   �� *ValidationText+$ PropertyChanged=� �� NotifyOnTargetUpdated .  �� NotifyOnSourceUpdated .  5T      :� 5U      $ Binding.TargetUpdated��6+   .[�5V   "   �� .��5W   &   �� .��5X   *   W� $ Opacity�6:   $ 0:0:1D�6^   $ 0X�6o   $	 1.0X�6x   W� 5Y   *   $ Opacity�6:   $ 0:0:2D�6^   $	 1.0X�6o   $	 0.0X�6z     g� 	BeginTime$  0:0:3X�6�   5Z   '   5[   #   5\      5^      5_      5`      5a      5b      5c      