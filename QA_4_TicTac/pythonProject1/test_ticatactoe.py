import sys
import unittest
import main

class MyTestCase(unittest.TestCase):

    #Проверка, заполняется ли игровое поле
    def test_GameField_Is_Created(self):
        main.GameField.draw_board(self, board=range(1,10))
        self.assertIsNotNone(sys.stdout)


if __name__ == '__main__':
    unittest.main()
