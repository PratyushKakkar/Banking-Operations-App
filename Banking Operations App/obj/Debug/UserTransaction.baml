   M S B A M L   `   `   `  ����Q  MBanking Operations App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Banking_Operations_AppBanking_Operations_App  5   	   ,    &Banking_Operations_App.UserTransaction   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Banking_Operations_App     5   	   -   5          � Title$  UserTransaction��5   	   $	��549��6!   $	��523��6.   .��5	      � .+�5
      �� -   5         ��Name$ lblUserTransaction��5
      $
��Bold"�6.   $��25(�6@   $	��503��6N   $��49��6Z   $	��Top=�6f   $��Center=�6~   ���	#FF7F2B7B#��� ��6�   $��10,10,10,10q�6�   $��Account Transaction��6  $��0,7,0,0q�6,  �� 5      -   5        $ lblFirstName��5      $��First Name:��6(   $
��Left=�6>   $��
56,122,0,0q�6Y   $	��Top=�6m   �� 5      -   5         ��Name$ txtFirstName��5      $
��Left=�6*   $��276,124,0,0q�6E    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��201��6�   ���	#FFE5E5E5 �� 
IsReadOnly . 6�   �� 5      -   5        $ 
lblSurname��5      $��Surname:��6&   $
��Left=�69   $��
57,168,0,0q�6T   $	��Top=�6h   �� 5      -   5        $ 
txtSurname��5      $
��Left=�6(   $��276,171,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��201��6�   ���	#FFE5E5E5 . 6�   �� 5      -   5        $ lblAccountNum��5      $��Account Number:��6)   $
��Left=�6C   $��	56,75,0,0q�6^   $	��Top=�6q   �� 5      -   5         ��Name$ cboAccountNumber��5      $
��Left=�6/   $��
276,75,0,0q�6J   $	��Top=�6^   $	��201��6v   6�   	� 5      -	   5         	�Name$ 
rdoDeposit��5      $��Deposit��6,   $
��Left=�6>   $��
86,297,0,0q�6Y   $	��Top=�6m    d� 	IsChecked$
 TrueY�6�   $��18(�6�   {�.  6�   	� 5      -
   5        $ rdoWithdrawl��5      $��	Withdrawl��6.   $
��Left=�6B   $��
82,353,0,0q�6]   $	��Top=�6q   $��18(�6�   {�.  6�   �� 5      -   5        $ 	txtAmount��5      $
��Left=�6'   $��322,375,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   $��16(�6�   $
��Bold"�6�   6�   �� 5      -   5        $ txtEuro��5      $
��Left=�6%   $��292,375,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $��24��6�   $	��€��6�   $��16(�6�   $
��Bold"�6�   �� 5      -   5         ��Name$ 	btnSubmit��5      $��Submit��6&   $
��Left=�67   $��
97,447,0,0q�6R   $	��Top=�6f   {�.  6�   �� 5      -   5        $ lblUpdateValidation��5      
��� � �$
��Left=�6B   $��250,451,0,0q�6]   $	��Top=�6r   $��32��6�   $	��202��6�   $��15(�6�   $y�	Collapsed=�6�   �� 5      -   5        $ txtCurrentBalance��5      $
��Left=�6/   $
 Wrap=�6J   $	��Top=�6^   $	��120��6v   $��16(�6�   $
��Bold"�6�   $��322,286,0,0q�6�   {�.  ���	#FFE5E5E56�   �� 5      -   5        $ txtEuro_Copy��5      $
��Left=�6*   $��292,286,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $��24��6�   $	��€��6�   $��16(�6�   $
��Bold"�6�   ���	#FFE5E5E56�   �� 5      -   5        $ lblCurrentBalance��5      $��Current Balance:��6-   $
��Left=�6H   $��292,245,0,0q�6c   $	��Top=�6x   �� 5      -   5        $ 	lblAmount��5      $��Enter Amount:��6%   $
��Left=�6=   $��292,340,0,0q�6X   $	��Top=�6m   $
��Bold"�6�   5      5      