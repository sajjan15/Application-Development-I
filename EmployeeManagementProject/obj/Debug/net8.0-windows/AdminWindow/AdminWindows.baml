   M S B A M L   `   `   `  ����T  PEmployeeManagementProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:EmployeeManagementProject.AdminWindow%EmployeeManagementProject.AdminWindow  5   	   8    2EmployeeManagementProject.AdminWindow.AdminWindows   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:EmployeeManagementProject.AdminWindow     5   	     � Title$  AdminWindow��5   	   $	��523��6   $	��948��6*   .��5	      � $��0,0,0,5q�6    � ColumnDefinitions 5
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
   $��72,261,311,25q�6   .+�5       �� $
��Wrap=�6   $��Employee ID :��6,   $��Right=�6A   $��16(�6]   $��Calibri)�6k   �� 5!      $
��Wrap=�6   $��Employee Name :��6,   $��Right=�6C   $��0,13,0,0q�6_   $��16(�6q   $��Calibri)�6   �� 5"      $
��Wrap=�6   $��Employee Position :��6,   $��Right=�6G   $��0,15,0,0q�6c   $��16(�6u   $��Calibri)�6�   �� 5#      $
��Wrap=�6   $��Employee Salary :��6,   $��Right=�6E   $��0,16,0,0q�6a   $��16(�6s   $��Calibri)�6�   �� 5$      $
��Wrap=�6   $��Leave Aproval :��6,   $��Right=�6C   $��0,16,0,0q�6_   $��16(�6q   $��Calibri)�6   5%      �� 5&   
   $��218,261,40,26q�6   .+�5'      �� -   5         ��Name$ EmployeeID_TextBox��5'       �� TextWrapping$
 Wrap=�62   $	��175��6F   $��16(�6R   �� 5(      -   5        $ EmployeeName_TextBox��5(      $
 Wrap=�64   $	��175��6H   $��0,10,0,0q�6T   $��16(�6f   �� 5)      -   5         ��Name$ EmployeePosition_ComboBox��5)      $	��175��6:   $��0,10,0,0q�6F   $��16(�6X   .@�5*      �� $��Manager��6   �� 5+      $��	Developer��6   �� 5,      $��Designer��6   �� 5-      $��Tester��6   �� 5.      $��HR��6   5/      �� 50      -   5        $ EmployeeSalary_TextBox��50      $
 Wrap=�66   $	��175��6J   $��0,10,0,0q�6V   $��16(�6h   �� 51      -   5        $$ EmployeeLeaveApproval_ComboBox��51      $	��175��6?   $��0,10,0,0q�6K   $��16(�6]   .@�52      �� $��Accepted��6   �� 53      $��Rejected��6   54      55      �� 56   
   $��503,261,129,0q�6   $��2��6,   .+�57      �� -   5         ��Name$ AddEmployee_Button��57      $��Add Employee ��61   $��14(�6I   $��23.28��6x   ���	#FF53B1156�   �� 58      -   5        $ UpdateEmployee_Button��58      $��Update Employee��64   $��14(�6N   $��0,11,0,0q�6\   $��23.28��6�   ���	#FF1698EC6�   �� 59      -	   5        $ DeleteEmployee_Button��59      $��Delete Employee��64   $��14(�6N   $��0,12,0,0q�6\   $��23.28��6�   ���	#FFBD46466�   �� 5:      -
   5        $ LoadDatabase_Button��5:      $��Load DataBase��62   $��14(�6J   $��0,12,0,0q�6X   $��23.28��6�   ���	#FFD47A2E6�   �� 5;      -   5        $ aproval_button��5;      $��Leave Aproval��6-   $��23.28��6E   $��0,12,0,0q�6T   $��Calibri)�6f   $��16(�6{   ���	#FFE0D9386�   5<      5=      5>      