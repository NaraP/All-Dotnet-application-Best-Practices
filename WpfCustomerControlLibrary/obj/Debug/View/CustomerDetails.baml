   M S B A M L   `   `   `  ����T  PWpfCustomerControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WpfCustomerControlLibrary.ViewWpfCustomerControlLibrary.View  5      4    .WpfCustomerControlLibrary.View.CustomerDetails   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:WpfCustomerControlLibrary.View     5      $��364.286��5      $��756.767��60   .��5      � $��0,0,0,96q�6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5           Name$  GridCustomers��5	         CanUserAddRows .     CanUserDeleteRows .     SelectionMode$ Single=�6�   $	��Top=�6�      AutoGenerateColumns .  $��	5,5,394,0q�6  $	��260��6.   J� RenderTransformOrigin$ 0.5,0.5&�6;  ��6*   �� *	Customers+ �� SelectedItem 6L   �� *SelectedEmployee+ �� SelectedIndex 6�   �� *SelectedIndex+z�5
      V� 5      .~�5      �� �� 5       �� AngleX$ 0.376Q�6$   �� 5      T� 5      	 T� X$	 1.121Q�6)   5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
CustomerID+  5      $ Customer Name��6%    6<   �� *Name+  5      $ Address��6%    66   �� *	Address+  5      $ 	Mobile No��6%    68   �� *
Mobileno+  5      $ Email Id��6%    67   �� *	EmailID+5      �� 5   
   $��Customer details��6   $��Center=�6+   $��Center=�6O   $
��Left=�6q   $��	388,7,0,0q�6�   $	��Top=�6�   $	��344��6�   �� 5   
   $��Customer Id :��6   $
��Left=�6(   $��
389,52,0,0q�6C   $	��Top=�6W   $	��124��6o   �� 5   
   -   5         ��Name$ 	txtCustID��5      $
��Left=�6%   $��23��6@   $��
521,52,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��211��6�   �� 5   
   $��Name :��6   $
��Left=�6!   $��
389,88,0,0q�6<   $	��Top=�6P   $	��124��6h   �� 5   
   -   5        $ txtName��5      $
��Left=�6#   $��23��6>   $��
521,88,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��211��6�   �� 5   
   $��Mobile No :��6   $
��Left=�6&   $��389,158,0,0q�6A   $	��Top=�6V   $	��124��6n   �� 5    
   -   5        $ txtMobileNo��5       $
��Left=�6'   $��23��6B   $��521,158,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��211��6�   �� 5!   
   $��	Address :��6   $
��Left=�6$   $��389,121,0,0q�6?   $	��Top=�6T   $	��124��6l   �� 5"   
   -   5        $ 
txtaddress��5"      $
��Left=�6&   $��23��6A   $��521,121,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��211��6�   �� 5#   
   $��
Email Id :��6   $
��Left=�6%   $��389,192,0,0q�6@   $	��Top=�6U   $	��124��6m   �� 5$   
   -   5        $ 
txtEmailId��5$      $
��Left=�6&   $��23��6A   $��521,192,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��211��6�   �� 5%   
   $
��Save��6   $
��Left=�6@   $��438,244,0,0q�6[   $	��Top=�6p   $��86��6�   ��6    �� *SaveCommand+6�   �� 5&   
   $��Delete��6   $
��Left=�6D   $��656,244,0,0q�6_   $	��Top=�6t   $��87��6�   ��6"   �� *DeleteCommand+6�   �� 5'   
   $��Update��6   $
��Left=�6D   $��545,244,0,0q�6_   $	��Top=�6t   $��87��6�   ��6"   �� *UpdateCommand+6�   5)      5*      