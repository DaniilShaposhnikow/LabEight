   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��label1��5       $��28��5
      $
��Left=�6   $��	10,33,0,0q�5      $	��Top=�6.   $	��120��5      .��6   Enter string:6(   �� 5   
   -   5        $��textBox1��5       �� 	MaxLength$ 24��5      $��23��6!   $��
10,57,51,0q�6-   $	��Top=�5      �� 5   
   -   5        $��	groupBox1��5      $��Crypto Type��5      $��10,91,118,127q�6(   .��5      �� -   5        $��stackPanel1��5   %   $��52��6   $	��127��68   .+�5      	� -   5        $��radioButton1��5   *   $��16��6   $	��120��6>   .��6J   
MD5 Hash5      	� 5      -   5        $��radioButton2��5   *   $��16��6   $	��120��6>   .��6J   	SHA1 Hash5       	� 5      -   5        $��radioButton3��5   *   $��16��6   $	��120��6>   .��6J   DES Encrypt5   "   5      5      �� 5   
   -   5        $��button1��5   0   $��23��6   $��	10,0,0,90q�6   $��Bottom=�5      $
��Left=�5      $��89��6(   .��63   	Compute6<   �� 5   
   -	   5        $��textBox2��5   2   $��63��6   $��
10,0,51,13q�6   $��Bottom=�6B    �� TextWrapping$
 Wrap=�6]   o� 5   
   -
   5        $��menu1��5      $��22��6   $	��Top=�6(    o� 
IsMainMenu$
 True��6@   .@�5      m� $��_File��6   .@�5       m� -   5        $��fileNew��5    )   $
��_New��6   6)   m� 5!      -   5        $��fileOpen��5!   *   $��_Open��6   6*   �� 5"      m� 5#      -   5        $��fileExit��5#   *   $��E_xit��6    m� InputGestureText$ Alt-F4��6:    � ToolTip$ Exit CryptoCalc��6T   6n   5$      m� 5%      $��_Help��6   .@�5&      m� $��Help Topics��6   �� 5'      m� 5(      $��About CryptoCalc��6   5)      5*      5-      5.      