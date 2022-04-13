# board = [1, 2, 3, 4, 5, 6, 7, 8, 9]
#
# # Функция ввода символа
# def take_input(player_token):
#     valid = False
#     while not valid:
#         print("В какую ячейку поставим ваш знак?")
#         player_answer = input()
#         player_answer = int(player_answer)
#         if player_answer >= 1 and player_answer <= 9:
#             if (str(board[player_answer-1]) not in "XO"):
#                 board[player_answer-1] = player_token
#                 valid = True
#             else:
#                 print("Эта клеточка уже занята")
#         else:
#             print("Некорректный ввод. Введите число от 1 до 9 чтобы походить.")
#     return valid


# Класс игрового поля
class GameField(object):
   def __init__(self, board):
       self.board = board

   def draw_board(self, board):
       print("-------------")
       for i in range(3):
           print("|", board[0 + i * 3], "|", board[1 + i * 3], "|", board[2 + i * 3], "|")
           print("-------------")

   # def check_win(board):
   #     win_coord = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
   #     for each in win_coord:
   #         if board[each[0]] == board[each[1]] == board[each[2]]:
   #             return board[each[0]]
   #     return False

# Класс ИИ (в нашем случае, искусственного идиота), соревнующегося с игроком
# class VirtualPlayer(object):
#     def __init__(self, mark):
#         self.mark = mark
#     pass


# Press the green button in the gutter to run the script.
if __name__ == '__main__':



    # Создадим игровое поле
    Game = GameField(board)
    Game.draw_board(board)



