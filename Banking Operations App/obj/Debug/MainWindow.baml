   M S B A M L   `   `   `  ����Q  MBanking Operations App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Banking_Operations_AppBanking_Operations_App  5   	   '    !Banking_Operations_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Banking_Operations_App     5   	   -   5          � Title$  
MainWindow��5   	   $	��570��6   $	��618��6)   ���	#FFFCFAFA.��5
      �  � ColumnDefinitions 5      �� 5      �� 5      $��0* �6"   .+�5      o� -   5         o�Name$ 	menuStrip��5      $��Times New Roman)�6$   $��22(�6A   $��	0,0,0,511q�6O   .@�5      m� -   5         m�Name$ mnuFile��5      $
��File��6+   $
��Left=�69   $��Center=�6T   $��5,5,0,0q�6o   $
��Bold"�6�   .@�5      m� -   5        $ mnuLogin��5      $��Login��61   m� 5      -   5        $ mnuExit��5      $
��Exit��60   6>   5      m� 5      -   5        $ 
mnuAccount��5      $��Account��6.   $��Center=�6?   $
��Left=�6Z   $��5,5,0,0q�6u   $
��Bold"�6�   .@�5      m� -   5        $ mnuNewAccount��5      $��New Account��66   6K   m� 5      -   5        $ mnuEditAccount��5      $��Edit Account��67   6M   m� 5      -	   5        $ mnuDepositFunds��5      $��Deposit Funds��68   6O   m� 5      -
   5        $ mnuWithdrawFunds��5      $��Withdraw Funds��69   6Q   m� 5      -   5        $ mnuTransferFunds��5      $��Transfer Funds��69   6Q   m� 5      -   5        $ mnuViewTransactions��5      $��View Transactions��6<   6W   5      5      �� 5      -   5         ��Name$ txtUsername��5      $
��Left=�6)   $��
290,92,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��174��6�    � Cursor$
 None��6�   $��Times New Roman)�6�   $��22(�6�   $��5,5,5,5q�6�   4  .System.Windows.Automation.AutomationProperties   HelpText$ AdminPratyush��6�      IsRequiredForForm . $��1��6]  $��35��6j  �� 5      -   5        	 ��Name$	 lblUsername��5      $��	Username:��6'   $
��Left=�6;   $��
136,90,0,0q�6V   $	��Top=�6j   $��38��6�   $	��132��6�   $��25(�6�   �� 5      -   5        $	 lblPassword��5      $��	Password:��6'   $
��Left=�6;   $��138,166,0,0q�6V   $	��Top=�6k   $��38��6�   $	��124��6�   $��25(�6�   �� 5       -   5        
 ��Name$
 btnForgotPassword��5       $
��Left=�6.   $��286,246,0,0q�6I   $	��Top=�6^   
������ ���	#FF00856A$��5,5,5,5q�6�   $��0,0,0,0q�6�   $��51��6�   $	��178��6�   $
 Hand��6
  $��4��6  .��5!      �� $��48��6   $	��176��6'   $��18(�63   B� 6B   .�6M   �� $�Forgot Password...��6Q   6n   6z   5"      �� 5#      -   5        $
 btnLogin��5#      $�� Login ��6%   $
��Left=�67   $��164,276,0,0q�6R   $	��Top=�6g   $��3��6�   G� 5$      -   5         G�Name$ txtPassword��5$      $
��Left=�6-   $��292,166,0,0q�6H   $	��Top=�6]   $	��172��6u   $��35��6�    G� PasswordChar$ *��6�   $��2��6�   $��22(�6�   �� 5%      -   5        $	 txtUsernameValidation��5%      $
��Left=�61   $��292,132,0,0q�6L   $	��Top=�6a   $��22��6y   $	��134��6�   $��12(�6�   ���	#FFFF0B0B6�   �� 5&      -   5        $	 txtPasswordValidation��5&      $
��Left=�61   $��292,207,0,0q�6L   $	��Top=�6a   $��22��6y   $	��134��6�   $��12(�6�   ���	#FFFF0B0B6�   �� 5'      -   5        $	 lblLoginValidation��5'      $�� ��6.   $
��Left=�69   $��264,300,0,0q�6T   $	��Top=�6i   $��25��6�   $	��134��6�   $��14(�6�   ���	#FFFF0B0B6�   &   System.Windows.Controls.DataGrid  5(      -   5          Name$ dgvAllAccData��5(      $��Center=�6,   $	��163��6I   $��	0,361,0,0q�6V   $	��Top=�6i   $	��566��6�      HeadersVisibility$ Column=�6�   $y�Hidden=�6�   �� 5)      -   5         ��Name$ grpLogin��5)      $��Login��6'   $��98,56,98,211q�66   ���	#FFD10E83���	#FF090909$��18(�6{   5*      5+      