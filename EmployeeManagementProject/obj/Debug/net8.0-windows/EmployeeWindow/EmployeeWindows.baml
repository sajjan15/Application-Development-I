   M S B A M L   `   `   `  ����T  PEmployeeManagementProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:EmployeeManagementProject.EmployeeWindow(EmployeeManagementProject.EmployeeWindow  5   	   >    8EmployeeManagementProject.EmployeeWindow.EmployeeWindows   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:EmployeeManagementProject.EmployeeWindow     5   	     � Title$  EmployeeWindows��5   	   $	��473��6!   $	��939��6.   .��5	      � $��0,0,0,5q�6    � ColumnDefinitions 5
   
   �� 5      $	��81* �6   �� 5      $	��47* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF585656��6    � Offset$ 0Q�61   � 5      $ 	#FFFDFDFD��6   $ 0.913Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ EmployeeDataGrid��5         AutoGenerateColumns$ False��6-   $
��Left=�6I   $��	28,10,0,0q�6d   $	��Top=�6w   $	��880��6�   $	��233��6�   $
��Bold"�6�   $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
EmployeeID+6P     5      $
	 Name��6%   $
 * 6T    63   �� *EmployeeName+6T     5      $	 Position��6%   $
 * 6\    67   �� *EmployeePosition+6\     5      $	 Salary��6%   $
 * 6X    65   �� *EmployeeSalary+6X     5      $	 
Leave From��6%   $
 * 6v    69   �� *	LeaveFrom+ �� StringFormat$ {0:yyyy-MM-dd}��6v     5      $	 Leave To��6%   $
 * 6r    67   �� *	LeaveTo+$ {0:yyyy-MM-dd}��6r     5      $	 Approval Status��6%   $
 * 6a    6>   �� *ApprovalStatus+6a   5      �� 5   
   $��28,260,396,34q�6   .+�5       �� $
��Wrap=�6   $��Employee ID :��6,   $��Calibri)�6A   $��16(�6V   $��Right=�6d   �� 5!      $
��Wrap=�6   $��Leaves From :��6,   $��Calibri)�6A   $��16(�6V   $��Right=�6d   $��0,15,0,0q�6�   �� 5"      $
��Wrap=�6   $��Leaves To :��6,   $��Calibri)�6?   $��16(�6T   $��Right=�6b   $��0,15,0,0q�6~   5#      �� 5$   
   $��217,260,199,34q�6   .+�5%      �� -   5         ��Name$ EmployeeID_textBox��5%       �� TextWrapping$
 Wrap=�62   $	��175��6F   $��Calibri)�6R   $��16(�6g   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$ from_datepicker��5&      $	��175��62   $��0,12,0,0q�6>     5'      -   5        $ to_datepicker��5'      $	��175��60   $��0,12,0,0q�6<   5(      �� 5)   
   $��417,260,27,34q�6   .+�5*      �� -   5         ��Name$ LoadData_Button��5*      $��LoadData��6.   $	��140��6A   $��Calibri)�6M   $��16(�6b   6p   �� 5+      -   5        $ submit_button��5+      $��Submit Leaves��6,   $��0,12,0,0q�6D   $	��137��6V   $��Calibri)�6b   $��16(�6w   6�   5,      5.      5/      