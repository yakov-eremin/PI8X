#Класс игрового поля
class GameField(object):
   def __init__(self, field):
       self.field = field
    #Метод, выводящий игровое поле
   def draw_field(self, field):
       print("\n-------------")
       for i in range(3):
           print("|", "*", "|", "*", "|", "*", "|")
           print("-------------")

if __name__ == '__main__':

    field = range(1, 10)

    #Создадим игровое поле
    Game = GameField(field)
    Game.draw_field(field)
