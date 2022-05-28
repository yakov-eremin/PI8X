gameBoard = list(range(1,10))

# Класс поля для Крестиков-ноликов
class CrossZeroField(object):
    def __init__(self, gameBoard):
        self.gameBoard = gameBoard

    def draw_game_board(self, gameBoard):
        print ("-" * 19)
        for i in range(3):
            print("|", " - ", "|", " - ", "|", " - ", "|")
            print ("-" * 19)

def put_sign(player_choice):
    valid = False
    while not valid:
        player_decision = input("Куда поставим " + player_choice+"? ")
        try:
            player_decision = int(player_decision)
        except:
            print ("Некорректный ввод")
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


