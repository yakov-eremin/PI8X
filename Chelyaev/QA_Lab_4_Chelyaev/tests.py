import sys
import unittest
import main

class MyTests(unittest.TestCase):

    def create_GameField_Test(self):
        main.GameField.draw_field(self, field=range(1,10))
        self.assertIsNotNone(sys.stdout)

    #Тест на проверку правильности выбора знака пользователем
    def choice_Sign_Test(self):
        self.assertIn(main.player_sign_choice(), "xo")

    #Тест на правильность введенных данных
    def right_input_test(self):
        self.assertIs(main.input_sign(player_choice='X'), True)
        self.assertIs(main.input_sign(player_choice='O'), True)


if __name__ == '__main__':
    unittest.main()