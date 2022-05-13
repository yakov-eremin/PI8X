#Выбор знака
def choice_sign():
    print("За кого будете играть? (х или о)")
    right = False
    while not right:
        player_sign = input()
        if ((player_sign != "x") and (player_sign != "o")):
            print("Такими знаками в эту игру не играют, выберете корректный (х или о)!!!")
        else:
            right = True
    return player_sign


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
