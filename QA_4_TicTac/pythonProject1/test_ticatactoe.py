import random
import sys
import unittest
import main


class MyTestCase(unittest.TestCase):

    # Проверка, заполняется ли игровое поле
    def test_GameField_Is_Created(self):
        main.GameField.draw_board(self, board=range(1, 10))
        self.assertIsNotNone(sys.stdout)

    # Проверка, корректно ли пользователь произвел ввод ячейки
    def test_User_Correct_Input(self):
        self.assertIs(main.take_input(player_token="x"), True)
        self.assertIs(main.take_input(player_token="o"), True)

    # Проверка, корректно ли пользователь выбрал свой знак
    def test_User_Correct_Sign(self):
        self.assertIn(main.player_mark_choice(), "xo")

    # Проверка выбора ячейки ботом
    def test_Bot_Correct_Point(self):
        self.assertIn(main.VirtualPlayer.make_mark(self, ii_mark="x"), range(1, 10))
        self.assertIn(main.VirtualPlayer.make_mark(self, ii_mark="o"), range(1, 10))

    # Проверка определения победителя
    def test_Winner_Correct_Choice(self):
        self.assertIsNot(main.GameField.check_win(self, board=range(1,10)), False)

if __name__ == '__main__':
    unittest.main()
