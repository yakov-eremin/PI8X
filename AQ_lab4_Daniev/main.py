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

if __name__ == '__main__':
    
    Game = CrossZeroField(gameBoard)
    Game.draw_game_board(gameBoard)

    
