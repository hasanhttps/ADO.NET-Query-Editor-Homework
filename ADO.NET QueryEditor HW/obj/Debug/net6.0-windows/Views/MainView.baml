   M S B A M L   `   `   `  ����Q  MADO.NET QueryEditor HW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ADO.NET_QueryEditor_HW.ViewsADO.NET_QueryEditor_HW.Views  5   	   +    %ADO.NET_QueryEditor_HW.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ADO.NET_QueryEditor_HW.Views     5   	     � Title$  Query Editor��5   	   $	��450��6   $	��800��6+    � Icon$( "/Static Files/Images/QueryLogo.png��67    � WindowStartupLocation$ CenterScreen=�6a   ���#D8D8D8.��5	      � .+�5
   
   �� -   5         ��Name$ BaseTabControl��5
      .@�5      �� $��Query Editor��6   .��5      � .+�5      �� -   5        $��ProviderNamesCB��5      $��22��66   $	��200��6B   $��	15 35 0 0q�6N   $	��Top=�6a   $
��Left=�6y    �� SelectedItem 6�   �� *ProviderName+ �� Mode$ TwoWay=��� 5      -   5        $��GetAllProviderBT��5      $��Get All Provider��65   $��25��6Q   $	��150��6]   $	��Top=�6i   $��Right=�6�   $��15 35q�6�   ���#B2BEB5
�������$
��Bold"�6�   ��6�   �� *GetAllProvidersCommand+ � 	Resources 5       �� 
TargetType �� Property	 �� Value��%^   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$	 5��6A   5      5      5      �� 5      -   5        $��QueryTB��5      $��25��6-   $��
15 0 120 0q�69   $��Center=�6M   .��6o    5      ��%^   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$	 5��6A   5      5      .��6-   5      �� 5      -   5        $��	ExecuteBT��5      $
��EXEC��6.   $��25��6>   $��90��6J   $��Right=�6U   $
��15 0q�6q   ���#B2BEB5
�������$
��Bold"�6�   ��6�   �� *ExecuteCommand+��6�   �� 
 �� ElementName$
 QueryTB�� �� Path$
 Text� 5       ��%^   '��       �� 5!      " ��6$   .�5"   "   ��  �@��CornerRadius$	 5��6A   5#      5$      5%      5&      5'      5(      5)      5*      