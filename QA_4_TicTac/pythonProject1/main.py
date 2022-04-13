
  #Класс игрового поля
class GameField(object):
   def __init__(self, board):
       self.board = board

   def draw_board(self, board):
       print("-------------")
       for i in range(3):
           print("|", board[0 + i * 3], "|", board[1 + i * 3], "|", board[2 + i * 3], "|")
           print("-------------")

#
#    def check_win(board):
#        win_coord = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
#        for each in win_coord:
#            if board[each[0]] == board[each[1]] == board[each[2]]:
#                return board[each[0]]
#        return False

# #Класс ИИ (в нашем случае, искусственного идиота), соревнующегося с игроком
# class VirtualPlayer(object):
#     def __init__(self, mark):
#         self.mark = mark


# Press the green button in the gutter to run the script.
if __name__ == '__main__':

    board = range(1, 10)

    #Создадим игровое поле
    Game = GameField(board)
    Game.draw_board(board)

