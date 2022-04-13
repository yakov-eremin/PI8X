import unittest
import main

class MyTestCase(unittest.TestCase):

    def test_GameField_Is_Created(self):
        self.assertLogs(main.GameField.draw_board(self, board=range(1, 10)))


if __name__ == '__main__':
    unittest.main()
