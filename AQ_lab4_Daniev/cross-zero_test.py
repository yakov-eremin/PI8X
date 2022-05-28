import sys
import unittest
import main


class GameTests(unittest.TestCase):

    # Проверка, заполняется ли игровое поле
    def test_Create_Cross_Zero_Field(self):
        main.CrossZeroField.draw_game_board(self, gameBoard=range(1, 10))
        self.assertIsNotNone(sys.stdout)

if __name__ == '__main__':
    unittest.main()