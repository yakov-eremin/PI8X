import random

board = [1, 2, 3, 4, 5, 6, 7, 8, 9]

# Ввод знака игрока
def player_mark_choice():
    print("Каким знаком вы будете играть? (x - вы начнете первым, o - вы начнете вторым)")
    ok = False
    while not ok:
        player_mark = input()
        if (player_mark != "x") and (player_mark != "o"):
            print("Введите корректный знак.")
        else:
            ok = True
    return player_mark

# Ввод символа
def take_input(player_token):
    valid = False
    while not valid:
        print("В какую ячейку поставим ваш знак?")
        player_answer = input()
        player_answer = int(player_answer)
        if player_answer >= 1 and player_answer <= 9:
            if (str(board[player_answer-1]) not in "xo"):
                board[player_answer-1] = player_token
                valid = True
            else:
                print("Эта клеточка уже занята")
        else:
            print("Некорректный ввод. Введите число от 1 до 9 чтобы походить.")
    return valid


# Класс игрового поля
class GameField(object):
    def __init__(self, board):
        self.board = board

    def draw_board(self, board):
        print("-------------")
        for i in range(3):
            print("|", board[0 + i * 3], "|", board[1 + i * 3], "|", board[2 + i * 3], "|")
            print("-------------")

    def check_win(self, board):
        win_coord = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
        for each in win_coord:
            if board[each[0]] == board[each[1]] == board[each[2]]:
                return board[each[0]]
        return False


# Класс ИИ (в нашем случае, искусственного идиота), соревнующегося с игроком
class VirtualPlayer(object):
    def __init__(self, ii_mark):
        self.ii_mark = ii_mark

    def make_mark(self, ii_mark):
        fine = False
        while not fine:
            bot_point = random.randint(1, 9)
            if (str(board[bot_point - 1]) not in "xo"):
                board[bot_point - 1] = ii_mark
                fine = True
        return bot_point


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    # Создадим игровое поле
    Game = GameField(board)
    # Создадим бота
    Bot = VirtualPlayer(board)

    # Отрисуем игровое поле
    Game.draw_board(board)

    # Зададим знак пользователя
    person_mark = player_mark_choice()

    # Присваивание знака боту
    if person_mark == "x":
        bot_mark = "o"
    else:
        bot_mark = "x"

    # Алгоритм самой игры
    counter = 0
    win = False
    while not win:
        if person_mark == "x":
            Game.draw_board(board)
            if counter % 2 == 0:
                take_input("x")
            else:
                Bot.make_mark("o")
            counter += 1
            if counter > 4:
                tmp = Game.check_win(board)
                if tmp:
                    print(tmp, "выиграл!")
                    win = True
                    break
            if counter == 9:
                print("Ничья!")
                break
        else:
            Game.draw_board(board)
            if counter % 2 == 0:
                Bot.make_mark("x")
            else:
                take_input("o")
            counter += 1
            if counter > 4:
                tmp = Game.check_win(board)
                if tmp:
                    print(tmp, "выиграл!")
                    win = True
                    break
            if counter == 9:
                print("Ничья!")
                break
    Game.draw_board(board)

