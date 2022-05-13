field = [1, 2, 3, 4, 5, 6, 7, 8, 9]

#Установка символа в выбранную секцию
def choice_sector(player_choice):
    done = False
    while not done:
        print("В какой сектор вы хотите поставить ваш знак?")
        player_answer = input()
        player_answer = int(player_answer)
        if player_answer >= 1 and player_answer <= 9:
            if (str(field[player_answer - 1]) not in "XO"):
                field[player_answer - 1] = player_choice
                done = True
            else:
                print("ВЫ не можете занять этот сектор. Он уже занят")
        else:
            print("Введите число от 1 до 9, в зависимости от того, какой сектор хотите занять.")
    return done

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
