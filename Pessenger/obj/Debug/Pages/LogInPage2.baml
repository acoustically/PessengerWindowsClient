   M S B A M L   `   `   `  ����D  @Pessenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Pessenger	Pessenger  5          Pessenger.LogInPage2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Pessenger     5        N� Title$  
LogInPage2��5	       � 	Resources 5
      $  Pessenger.HintTextBoxConverter   hintTextBoxConverter��%   &	          5      6!   5      .��5      �  � RowDefinitions 5      �� 5      $	��40* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��40* �6   .+�5      � 
�������$��Center=�6   $��Center=�6;   $��1��6V   .+�5      �� $
��Wrap=�6   $��Center=�6&   $��10, 0, 0, 0q�6A   $��50��6V   $��Password��6d   
����İ�y�5   0   ��  �� ElementName$ passwordBox�� �� Path$ Text.IsEmpty� �� 	Converter# [  G� 5      -   5        $��passwordBox��5   A   $	��200��6   $��30��6    $��
8, 5, 0, 0q�6,   
������ 6T   5      �� 5      -   5        $��2��5      $
��Wrap=�6   $��Center=�61    �� TextAlignment$ Center=�6L   $
��Next��6�   ��5      �� 5   
    �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value
	 ��·�6)   
 �� Triggers
 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � ��
	 ��� �6-   5       5"      5$      5%      5&      