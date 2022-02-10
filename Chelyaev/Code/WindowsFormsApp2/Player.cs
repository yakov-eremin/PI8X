using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApp2
{
    public class Player
    {
        private int mana;
        private int maxMana;
        private int health;
        
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if(value < health)
                {
                    icon.bumpImage.Visible = true;
                    icon.Update();
                    Thread.Sleep(400);
                    icon.bumpImage.Visible = false;
                    icon.Update();
                }
                health = value;
                refreshIcon();
                if (health <= 0) frm.GameOver();
            }
        }
        private int amountCardsInHand;
        private int amountCardsOnTable;
        public int AmountCardsOnTable
        {
            get
            {
                return amountCardsOnTable;
            }
        }
        private int amountCardsInDeck;
        private PlayerIcon icon;
        private Form1 frm;
        
        List<Card> cardsInDeck;
        List<Card> cardsInHand;
        List<Card> cardsOnTable;


        public Player(PlayerIcon pli, int _health, Form1 frmm)
        {
            frm = frmm;
            icon = pli;
            cardsInDeck = new List<Card>();
            cardsInHand = new List<Card>();
            cardsOnTable = new List<Card>();
            health = _health;
            mana = 1;
            maxMana = 1;
            refreshIcon();
            amountCardsInDeck = 0;
            amountCardsInHand = 0;
            amountCardsOnTable = 0;
            
        }


        public bool addCardToDeck(Card c)
        {
            cardsInDeck.Add(c);
            amountCardsInDeck++;
            return true;
        }

        public void refreshIcon()
        {
            icon.healthSphere.Amount.Text = Convert.ToString(health);
            icon.ManaSphere.Amount.Text = Convert.ToString(mana);
        }

        //колода -> рука для первого игрока
        public Card getCardFromDeck()
        {
            if (amountCardsInDeck != 0)
            {
                if (amountCardsInHand <= 8)
                {
                    amountCardsInDeck--;
                    amountCardsInHand++;
                    //cardsInDeck.Count;
                    Random rnd = new Random();
                    int numCurt = rnd.Next(cardsInDeck.Count);
                    Card c = cardsInDeck[numCurt];
                    cardsInHand.Add(c);
                    cardsInDeck.Remove(c);
                    return c;
                }
                else
                {
                    amountCardsInDeck--;
                    Random rnd = new Random();
                    int numCurt = rnd.Next(cardsInDeck.Count);
                    Card c = cardsInDeck[numCurt - 1];
                    cardsInDeck.Remove(c);
                    frm.History.Text += "Недостаточно места в руке, карточка " + c.name + " была уничтожена\r\n";
                    return null;
                }
            }
            else return null;
            //cardsInDeck.Remove(cardsInDeck[0]);
        }


        
        


        //для игрока рука -> стол
        public bool addEntityOnBattleField(Card c)
        {
            if (mana >= c.ManaCost)
            {
                amountCardsOnTable++;
                amountCardsInHand--;
                cardsOnTable.Add(c);
                cardsInHand.Remove(c);
                c.isCardOnTable = true;
                mana -= c.ManaCost;
                refreshIcon();
                return true;
            }
            else return false;
            
        }
        
        /// <summary>
        /// выложить заклинание
        /// </summary>
        public bool AddSpellOnBattleField(Card c)
        {
            if (mana >= c.ManaCost)
            {                
                amountCardsInHand--;                
                cardsInHand.Remove(c);                
                mana -= c.ManaCost;
                refreshIcon();
                c = null;
                return true;
            }
            else return false;

        }

        public void deleteCardFromTable (Card c)
        {
            amountCardsOnTable--;
            cardsOnTable.Remove(c);            
        }

       
        public void PutAllCardsOnTable()
        {
            foreach(Card c in cardsInHand.ToArray())
            {
                //frm.AddCardOnTableForPlayer2(c, false);
                if (mana >= c.ManaCost) c.AddCardOnBattleField();    
               
               
            }
        }

        /// <summary>
        /// снять всем карточкам запрет на удар
        /// </summary>
        public void AllCardsCanBeat()
        {
            foreach(Card c in cardsOnTable)
            {
                c.isCanBeat = true;
            }
        }

        public void ChangeManaAfterMove()
        {
            if(maxMana< 10) maxMana++;
            mana = maxMana;
            refreshIcon();
        }


        /// <summary>
        /// Атака компьютера
        /// </summary>
        public void AttackForPlayer2()
        {
            foreach (Card c in cardsOnTable.ToArray())
            {
                if (c.isCanBeat)
                {
                    c.isCurrent(true);
                    c.Update();
                    Entity EC;
                    if ((EC = (Entity)frm.player[0].ReturnCardWithProvocation()) != null)
                    {
                        Thread.Sleep(700);
                        c.bump(EC);
                        frm.History.Text += "Противник наносит " + EC.name + " " + Convert.ToString(((Entity)c).Damage) + " урона \r\n";
                        frm.Update();
                    }
                    else
                    {
                        Random rnd = new Random();
                        double probability = rnd.Next(10);
                        if (probability > 3 && frm.player[0].AmountCardsOnTable != 0)
                        {
                            EC = (Entity)frm.player[0].GetRandomCardFromTable();
                            frm.History.Text += "Противник наносит " + EC.name+ " " + Convert.ToString(((Entity)c).Damage) + " урона \r\n";
                            Thread.Sleep(700);
                            c.bump(EC);
                            frm.Update();
                        }
                        else
                        {
                            frm.History.Text += "Противник наносит вам " + Convert.ToString(((Entity)c).Damage) + " урона карточкой " + c.name + "\r\n";
                            frm.player1Icon.status.BackColor = Color.Green;
                            frm.player1Icon.Update();
                            Thread.Sleep(700);
                            frm.player[0].Health -= ((Entity)c).Damage;
                            frm.player1Icon.status.BackColor = Color.Transparent;
                        }
                    }
                }
                if (c != null)
                {
                    c.isCurrent(false);
                    c.Update();
                }
            }
        }

        public Card ReturnCardWithProvocation()
        {
            foreach(Card c in cardsOnTable)
            {
                if (((Entity)c).provocation) return c;
            }
            return null;
        }

        public Card GetRandomCardFromTable()
        {
            Random rnd = new Random();
            int numCurt = rnd.Next(cardsOnTable.Count);
            return cardsOnTable[numCurt];
        }

        public void GreenStatusForCardsOnTable(bool show)
        {
            foreach (Card c in cardsOnTable)
            {
                if (c.isCanBeat && show) c.isAvailable(true);
                else c.isAvailable(false);
            }

        }

        public void GreenStatusForCardsInHand(bool show)
        {
            foreach(Card c in cardsInHand)
            {
                if (show) if (mana - c.ManaCost >= 0) c.isAvailable(true);
                    else;
                else c.isAvailable(false);
            }
        }

        public void ShowAvailable(bool show)
        {
            GreenStatusForCardsInHand(show);
     
            GreenStatusForCardsOnTable(show);
            frm.Update();
        }
       /* public void addCardToDeck(Card c)
        {
            cardsInDeck.Add(c);
            amountCardsInDeck++;
        }*/
    }

}
