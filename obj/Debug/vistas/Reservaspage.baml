   M S B A M L   `   `   `  ����  Nextmeet    NextMeet.ReservaPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Reservas��5      $
��Auto��6   $
��Auto��6&    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth �� Triggers	 P� Property
 P� Value��%H  &	        �� 5   
   " ��6+   .�5      ��  � �� �#3498DB6+   �� 5	       � ��
 �����6+   �� 5
       � ��$ 50��6'   �� 5       � ��$ 10q�6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ Stretch=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 16(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ #2980B9��6'   $ 10Q�67   $ 3Q�6G   5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � �� �#2980B963   �� 5       �@J�Effect 5        5      $ #2980B9��6/   $ 10Q�6?   $ 5Q�6O   5       5!      5#      5$      .��5'      �� $
��Auto=�6   $
��Auto=�68   .��5(   
   � $��0q�6   $��Stretch=�6   $��Stretch=�68    � ColumnDefinitions 5*      �� 5+      $��* �6#   �� 5-      $	��350 �6#   .+�52      � $��0��6   $��10q�6#   .+�53      &   System.Windows.Controls.DataGrid  -   5          Name$ ReservasDataGrid��53         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6c   $
��Left=�6z   $
��1182��6�      Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+6P     56      $ Nombre Cliente��6-   $	 200 6g    6E   �� *NombreCliente+6g     57      $ Correo Cliente��6-   $	 200 6g    6E   �� *CorreoCliente+6g     58      $ Fecha��6-   $	 150 6V    6<   �� *Fecha+6V     59      $ Hora Inicio��6-   $	 120 6a    6B   �� *
HoraInicio+6a     5:      $ Hora Fin��6-   $	 120 6[    6?   �� *	HoraFin+6[     5;      $ 	Tipo Sala��6-   $	 150 6]    6@   �� *
TipoSala+6]     5<      $ 
Total Pago��6-   $	 120 6_    6A   �� *	TotalPago+6_   5>      5?      �� 5B      $��1��6   ���#F3F3F3
������ $��1q�6T   $��10q�6h   ._�5C      �� .+�5D      �� $��Opciones��6   $��10q�61   .��5E      �� .+�5F      �� -   5        $��AgregarButton��5F   ?   $��Agregar Reserva��6%   #��[  6T   $��10q�6�   $��Stretch=�6�   �� 5G      -   5        $��ModificarButton��5G   A   $��Modificar Reserva��6%   #��[  6X   $��10q�6�   $��Stretch=�6�   �� 5H      -   5        $��EliminarButton��5H   @   $��Eliminar Reserva��6%   #��[  6V   $��10q�6�   $��Stretch=�6�   5I      5J      5K      5L      5M      5N      5O      