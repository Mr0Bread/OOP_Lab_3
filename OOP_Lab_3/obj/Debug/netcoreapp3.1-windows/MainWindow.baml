   M S B A M L   `   `   `  ����D  @OOP_Lab_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:OOP_Lab_3	OOP_Lab_3  5   	   1clr-namespace:OOP_Lab_3.ViewsOOP_Lab_3.Views  5   	   ;"clr-namespace:OOP_Lab_3.ViewModelsOOP_Lab_3.ViewModels  5   	       OOP_Lab_3.MainWindow   5   	   e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:OOP_Lab_3     5   	   /viewsclr-namespace:OOP_Lab_3.Views     5   	   9
viewModels"clr-namespace:OOP_Lab_3.ViewModels     5   	     � Title$  Bread's Bakery��5
   	   $	��450��5   	   $	��800��5   	   $	��450��5   	   $	��800��5   	    � DataContext 5      .   (OOP_Lab_3.ViewModels.MainWindowViewModel  5   
    � 	Resources 5       �� DataType*   $OOP_Lab_3.ViewModels.SignInViewModel    OOP_Lab_3.Views.SignInView,   &OOP_Lab_3.ViewModels.MainMenuViewModel"   OOP_Lab_3.Views.MainMenuView)   #OOP_Lab_3.ViewModels.UsersViewModel   OOP_Lab_3.Views.UsersView �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)'�� �     '�� �     '�� h    '�� �    'G� 6    '�� �    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5!   
   " ��6   .�5"      ��  � ��
 �����5$      5%      �� 5'   
   " ��6   .�5(      ��  � �� �	#FF836C6C5*      �� 5+       � �� �	#FFEDE1E15-      5.      �� 50   
   " ��6   .�51      ��  � �� �#302c2c53      54      �� 56   
   " ��6   .�57      ��  � �� �#302c2c59      �� 5:       � ��
 �����5<      5=      �� 5?   
   " G�6   .�5@      ��  � �� �#302c2c5B      �� 5C       � ��
 �����5E      5F      �� 5H   
   " ��6   .�5I      ��  � �� �	#FFD5C6C65K      �� 5L       � �� �	#FF6B5F5F5N      �� 5O       � �� 5P      �� 5Q      " ��6&   .R�5R      �� #��z��6!   ._�5S      �� $��Center=�6/   $��Center=�6L   5T      5U      5W       5X      P� 5Y      	 �@J�IsMouseOver$

 True��61   . �5Z      ��  � �� �#4a414163   5[      5]      5^      .��5`      � ���	#FF163939.+�5a   
   �� ��5b      �� *CurrentViewModel+5c      5d      