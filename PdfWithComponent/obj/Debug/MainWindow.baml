   M S B A M L   `   `   `  ����K  GPdfWithComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PdfWithComponentPdfWithComponent  5   	   !    PdfWithComponent.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PdfWithComponent     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5   
   � $	��350��6   $	��525��6   
�������.+�5      � -   5        $��GridForm��5      $��
28,0,32,47q�6#   
�������$	��264��6J   $��Bottom=�6W    � ColumnDefinitions 5      �� 5      $
��388* �6'   �� 5      $	��77* �6'    � RowDefinitions 5      �� 5      $
��252* �6$   .+�5      �� -   5         ��Name$ errormessage��5   U   $��20��6   $
��Left=�6(   $��67,0,0,0q�6C   $	��Top=�6l   $	��247��6�    J� OpacityMask
 �<�����	#FFE5572C6�   �� 5      -   5        $��textBlockFirstname��5   V   $��23��6   $
��Left=�6(   $��	42,52,0,0q�6C   $��First Name:��6p   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockLastName��5   V   $��23��6   $
��Left=�6(   $��	42,82,0,0q�6C   $��
Last Name:��6o   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockEmailId��5   W   $��23��6   $
��Left=�6(   $��
42,112,0,0q�6C   $��EmailId��6o   $	��Top=�6~   $	��110��6�   �� 5      -   5        $��textBlockPassword��5   W   $��23��6   $
��Left=�6(   $��
42,139,0,0q�6C   $��	Password:��6p   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockConfirmPwd��5   W   $��23��6   $
��Left=�6(   $��
42,168,0,0q�6C   $��ConfirmPassword:��6r   $	��Top=�6�   $	��110��6�   �� 5      -   5        $��textBlockAddress��5   W   $��23��6   $
��Left=�6(   $��
42,198,0,0q�6C   $��Address��6o   $	��Top=�6~   $	��110��6�   �� 5      -	   5        $��textBoxFirstName��5   U   $��23��6   $
��Left=�6&   $��
158,52,0,0q�6A   $	��Top=�6m   $	��222��6�   �� 5      -
   5        $��textBoxLastName��5   U   $��23��6   $
��Left=�6&   $��
158,82,0,0q�6A   $	��Top=�6l   $	��222��6�   �� 5      -   5        $��textBoxEmail��5   V   $��23��6   $
��Left=�6&   $��158,112,0,0q�6A   $	��Top=�6j   $	��222��6�   G� 5      -   5        $��passwordBox1��5   Z   $��23��6   $
��Left=�6*   $��158,139,0,0q�6E   $	��Top=�6n   $	��222��6�   G� 5       -   5        $��passwordBoxConfirm��5    Z   $��23��6   $
��Left=�6*   $��158,168,0,0q�6E   $	��Top=�6t   $	��222��6�   �� 5!      -   5        $��textBoxAddress��5!   U   $��23��6   $
��Left=�6&   $��
158,0,0,34q�6A   $��Bottom=�6k   $	��222��6�   �� 5"      -   5        $��btnGeneratePDFFile��5"      $��Generate pdf��6   $��center=�60   $��Center=�6N   $��150,238,110,6q�6�   $	��128��6�   �� 5#      -   5        $��btnOpenPDFFile��5#   e   $��Open pdf��6   $
��Left=�6,   $��Center=�6H   $��
27,240,0,4q�6�   $	��101��6�   �� 5$      -   5        $��button3��5$   f   $��Cancel��6   $��23��6*   $��Right=�66   $��
0,235,22,0q�6R   $	��Top=�6u   $��70��6�   �� 5&      -   5        $��textBlockHeading��5&   T   $��23��6   $
��Left=�6(   $��6,6,0,0q�6C   $��Registration Form��6l   $	��Top=�6�   $	��153��6�   $��17(�6�   $��ExtraCondensed&�6�   5'      �� 5(      -   5        $��button1��5(   d   $��
Create PDF��6   $��23��6*   $
��Left=�66   $��	421,5,0,0q�6Q   $	��Top=�6s   $��75��6�   5)      5*      5+      