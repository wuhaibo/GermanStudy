   M S B A M L   `   `   `  ����O  KGermanLearningModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GermanLearningModule.UtilGermanLearningModule.Util  5      1    +GermanLearningModule.Views.TestWordListView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8util'clr-namespace:GermanLearningModule.Util     5      .��5      � -   5        $��TestUnit��5      
�������  � 	Resources  5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $9 3/GermanLearningModule;component/Theme/StyleDic.xaml?�6)   6h   %    5      .+�5   
   �� $
��Left=�6   $��50��6/   $��	55,26,0,0q�6;   $
��Wrap=�6N   $	��Top=�6�   $	��497��6�   $��32(�6�   ��6b   ��  �� Path$ TestItem.Question�6�   �� 5   
   -   5        $��lstBoxAnswers��5      $
��Left=�6)   $	��183��6D   $��
55,105,0,0q�6Q   $	��Top=�6e   $	��276��6}   $��0q�6�   ��5      �� 5      .R�5      �� $��50��6!   .+�5      	�  	� 	GroupName$ Answers��6&   $��10q�5   &   $��15(�62   ��5   :   �� $ .���5   &   �� *#!DataContext.GoNextQuestionCommand+ �� RelativeSource ��  �� AncestorType" ����5   &   ��  �� *Self+5   2   5      5      5!      �� 5$   
      HB_ButtonStyle#��[  5&      $
��Next��5'      $
��Left=�6!   $��33��6<   $��468,288,0,0q�6H   $	��Top=�6]   $��84��6u   ��5$      �� $( "GoNextQuestionNoAnswerCheckCommand�y�5%      �� $ ShowGoNextBtn�5'   u   �� 5)   
   #��[  5+      $��	Next Unit��6:   $
��Left=�6N   $��33��6i   $��354,288,0,0q�6u   $	��Top=�6�   $��84��6�   ��5)      �� $ Navi2NextUnitCommand�y�5*      �� $ ShowGoNextUnitBtn�5+   �   �� 5,   
   -   5         ��Name$ lstBoxAnswersJudge��5,      $
��Left=�60   $	��183��6K   $��354,105,0,0q�6X   $	��Top=�6m   $	��158��6�   $��0q�6�     5-      2   ,GermanLearningModule.Util.ImagePathConverter  ImagePathConverter��%   &	         5.      6*   5/      ��50      �� 51      .R�52      �� $��50��6!   .+�53      �� $��5q�6    $��50��6+   $
��Fill=�54       ��53   7   �� $ .� �� 	Converter# [ 55      56      57      59      5;      5<      