import sys
import unittest
import main

class GameTests(unittest.TestCase):

    # Проверка, заполняется ли игровое поле
    def test_Create_Cross_Zero_Fieldd(self):
        main.CrossZeroField.draw_game_board(self, gameBoard=range(1, 10))
        self.assertIsNotNone(sys.stdout)

    def test_Correct_Sector_Choice(self):
        self.assertIs(main.put_sign(player_choice="X"), True)
        self.assertIs(main.put_sign(player_choice="O"), True)




if __name__ == '__main__':
    unittest.main()