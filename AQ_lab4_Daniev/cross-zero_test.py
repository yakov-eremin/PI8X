import sys
import unittest
import main

class GameTests(unittest.TestCase):

    # Тест на заполние игрового поля
    def test_Create_Cross_Zero_Fieldd(self):
        main.CrossZeroField.draw_game_board(self, gameBoard=range(1, 10))
        self.assertIsNotNone(sys.stdout)

    # Тест на правильный выбор ячейки для символа
    def test_Correct_Sector_Choice(self):
        self.assertIs(main.put_sign(player_choice="X"), True)
        self.assertIs(main.put_sign(player_choice="O"), True)

    #Тест на достижение условий победы
    def test_win_condition_success(self):
        self.assertIsNot(main.CrossZeroField.win_condition_success(self, gameBoard=range(1,10)), True)


if __name__ == '__main__':
    unittest.main()