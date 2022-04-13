import random
import sys
import unittest
import main

class MyTestCase(unittest.TestCase):

    # Проверка, заполняется ли игровое поле
    def test_GameField_Is_Created(self):
        main.GameField.draw_board(self, board=range(1, 10))
        self.assertIsNotNone(sys.stdout)

    # Проверка, корректно ли пользователь произвел ввод данных
    def test_User_Correct_Input(self):
        self.assertIs(main.take_input(player_token='X'), True)
        self.assertIs(main.take_input(player_token='O'), True)

if __name__ == '__main__':
    unittest.main()
