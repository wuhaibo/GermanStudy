   M S B A M L   `   `   `  ����  GermanLearningModule.    (GermanLearningModule.Views.ScoreListView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � 
�������.+�5	   
   �� .+�5
      �� $
��27,0q�6     �� Orientation$  
Horizontal=�6'   .+�5      	� -   5        $��	rBtnStudy��5   A    	� 	GroupName$ 	StudyTest��6S    d� 	IsChecked 6   ��  �� Path$ IsStudy�.��6j   Study5      	� 5      -   5        $��rBtnTest��5   @   $ 	StudyTest��6Q   $
��10,0q�6g    6   �� $ IsTest�.��6u   Test5      5      �� 5      $��
0,20,10,10q�6   .+�5      �� -   5        $��lstBoxScores��5      $	��300��6   $��Stretch=�60   $��0q�6U   ��5      �� 5      .R�5      A�  A� Columns$ 4��6*   5      ��5      �� 5      .�5      ��  �� Property � �� �� Value$ 0q�6@   6L    �� Triggers 5       P� 5!   "    P� Property �@��
IsSelected	 P� Value	 . . �5"   &   ��  � ��
 �  ��6O   5#   #   5%      ��5(      �� 5)      .R�5*      � $��0q�6#   
�������.+�5,   "   � $��10q�6'   
 � RowDefinitions
 5-   &   �� 5.   *   6:   �� 5/   *   6:   �� 50   *   6:   .+�52   &   �� $��70��56   %   $	��100��64   $��0��6C   $��2��6P   ���	#FF4DA6DE��52   -   �� *#!DataContext.Navi2StudyTestCommand+ �� RelativeSource ��  �� AncestorType" >���53   -   ��  �� *Self+
 � Tag 54   -   �� $
 Unit�.��57   *   �� .+�58   .   �� $  
Horizontal=�69   .+�59   2   �� 
�������$��Unit: ��6P   6`   �� 5:   2   
���������6P   �� $
 Unit�6m   5;   /   �� 5<   .   $  
Horizontal=�69   .+�5=   2   �� 
�������$��Score: ��6P   6a   �� 5>   2   
���������6P   �� $ ScoreNum� �� StringFormat$ {0:F0}��6�   5?   /   5A   +   5C   '   5E   #   5G      5H      5J      5L      5P      5Q      5R      