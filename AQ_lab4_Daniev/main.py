gameBoard = list(range(1,10))

# Класс поля для Крестиков-ноликов
class CrossZeroField(object):
    def __init__(self, gameBoard):
        self.gameBoard = gameBoard

    def draw_game_board(self, gameBoard):
        print ("-" * 19)
        for i in range(3):
            print ("| ", gameBoard[0+i*3], " | ", gameBoard[1+i*3], " | ", gameBoard[2+i*3], " |")
            print ("-" * 19)
    
    def win_condition(self, gameBoard):
        win_combination = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
        for each in win_combination:
            if gameBoard[each[0]] == gameBoard[each[1]] == gameBoard[each[2]]:
                return gameBoard[each[0]]
        return False    

def put_sign(player_choice):
    valid = False
    while not valid:
        player_decision = input("Куда поставим " + player_choice+"? ")
        try:
            player_decision = int(player_decision)
        except:
            print ("Некорректный ввод. Вы уверены, что ввели число?")
            continue
        if player_decision >= 1 and player_decision <= 9:
            if (str(gameBoard[player_decision-1]) not in "XO"):
                gameBoard[player_decision-1] = player_choice
                valid = True
            else:
                print("Клетка уже занята")
        else:
            print("Введите число от 1 до 9")
    return valid



if __name__ == '__main__':
    
    Game = CrossZeroField(gameBoard)
    Game.draw_game_board(gameBoard)
#    main(gameBoard)


