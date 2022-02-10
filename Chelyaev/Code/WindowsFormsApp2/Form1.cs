using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;

namespace WindowsFormsApp2
{
    


    public partial class Form1 : Form
    {
        public Player[] player;
        private TestMessageFilter tsm = new TestMessageFilter();
        public bool isChoosen;
        private Card pickedCard;
        SoundPlayer simpleSound;
        private bool isMusicPlaying = true;

        public Form1()
        {
            InitializeComponent();
            try{
                simpleSound = new SoundPlayer(@"sound\Clanadonia.wav");
                simpleSound.Play();
            }
            catch
            {
                History.Text += "Не удалось воспроизвести музыку\r\n";
                isMusicPlaying = false;
            }
            
            isChoosen = false;
            player = new Player[2];
            player[0] = new Player(player1Icon, 30, this);
            player[1] = new Player(player2Icon, 40, this);

            formDecks();

            addCardToHandForPlayer1();
            addCardToHandForPlayer1();
            addCardToHandForPlayer1();
            addCardToHandForPlayer2();
            addCardToHandForPlayer2();

        }

        public void CardClicked(Card crd)
        {

            //карта не была выбрана
            if (isChoosen == false)
            {
                isChoosen = true;
                pickedCard = crd;
                if (!crd.isCardOnTable)
                {
                    battleFieldPlayer1.BackgroundImage = Properties.Resources.add;
                }
                else if (crd.isCanBeat && player[1].ReturnCardWithProvocation() == null)
                {
                    player2Icon.status.BackColor = Color.Green;
                }
                player[0].ShowAvailable(false);
            }
            //карта, на которую нажали прежде, совпадает с картой, на которую нажали сейчас
            else if (isChoosen == true && pickedCard == crd)
            {
                isChoosen = false;
                pickedCard = null;
                battleFieldPlayer1.BackgroundImage = null;
                player2Icon.status.BackColor = Color.Transparent;
                player[0].ShowAvailable(true);
            }
            //атака карточки противника
            else if (!crd.isFirstsPlayerCard && pickedCard.isCardOnTable && pickedCard.isCanBeat)
            {
                bool isPlayer2hasCardsWithProvocation = player[1].ReturnCardWithProvocation() != null;
                if (isPlayer2hasCardsWithProvocation && ((Entity)crd).provocation || !isPlayer2hasCardsWithProvocation)
                {
                    pickedCard.bump((Entity)crd);
                    if (pickedCard != null) pickedCard.isCurrent(false);
                    pickedCard.isCanBeat = false;
                    isChoosen = false;
                    pickedCard = null;
                    player2Icon.status.BackColor = Color.Transparent;
                    player[0].ShowAvailable(true);
                }
                else {
                    History.Text += "Вы не можете атаковать эту карту - у противника имеются карточки с \"провокацией\" \r\n";
                }
            }


        }
        public void addCardToHandForPlayer2()
        {
            Card c = player[1].getCardFromDeck();
            if(c != null) HandPlayer2.Controls.Add(c);

        }

       
        //сформировать калоды согласно данным из файла
        public void formDecks()
        {
            StreamReader sr = new StreamReader(@"iCard\Player1Cards.txt");
            for (int i = 0; i < 30; i++)
            {
                string name = sr.ReadLine();
                Card c = whichCard(name, true);
                player[0].addCardToDeck(c);
            }
           
            History.Text += "Колода первого игрока сформирована!\r\n\r\n";
            sr = new StreamReader(@"iCard\Player2Cards.txt");

            for (int i = 0; i < 30; i++)
            {
                string name = sr.ReadLine();
                Card c = whichCard(name, false);
                player[1].addCardToDeck(c);
            }
            History.Text += "Колода второго игрока сформирована!\r\n\r\n";

        }

        /// <summary>
        /// создание карточки (можно было бы представить нелинейным алгоритмом) 
        /// </summary>
        public Card whichCard(string name, bool isFirstPlayer)
        {
            Card c;
            switch (name)
            {
                case "Kury":
                    c = new Kury(this, "Kury", isFirstPlayer);
                    break;
                case "Einstein":
                    c = new Einstein(this, "Einstein", isFirstPlayer);
                    break;
                case "Lab Guard":
                    c = new LabGuard(this, "Lab Guard", isFirstPlayer);
                    break;
                case "Damage potion v.3":
                    c = new DamageSpell3(this, "Damage potion v.3", isFirstPlayer);
                    break;
                case "Health potion":
                    c = new HealthPotion(this, "Health potion", isFirstPlayer);
                        break;
                case "Tesla":
                    c = new Tesla(this, "Tesla", isFirstPlayer);
                        break;
                default:
                    c = null;
                    break;
            }
            return c;
        }


        //добавить карту на стол из колоды 
        void addCardToHandForPlayer1()
        {
            HandPlayer1.Controls.Add(player[0].getCardFromDeck());
        }


        /// <summary>
        /// клик по столу
        /// </summary>
        private void battleFieldPlayer1_Click(object sender, EventArgs e)
        {
            if (pickedCard != null)
            {
                if (!pickedCard.isCardOnTable)
                {
                    battleFieldPlayer1.BackgroundImage = null;
                    pickedCard.AddCardOnBattleField();
                    pickedCard.isCurrent(false);
                    isChoosen = false;
                    pickedCard = null;
                    player[0].ShowAvailable(true);
                }
            }
        }

       

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
             EndMove.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("buttonEndMoveDown");
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
             EndMove.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("buttonEndMove");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (History.Size != new System.Drawing.Size(184, 443))
            {
                History.Size = new System.Drawing.Size(184, 443);
                CoverButton.Text = "Cover";
            }
            else
            {
                History.Size = new System.Drawing.Size(184, 150);
                CoverButton.Text = "Uncover";
            }
        }
        private void History_TextChanged(object sender, EventArgs e)
        {
            History.SelectionStart = History.Text.Length;
            History.ScrollToCaret();
        }


        ///удалить карту со стола
        public void deleteCardFromTable(Card c)
        {
            Thread.Sleep(700);
            History.Text += c.name + " повержен\r\n";
            if (c.isFirstsPlayerCard)
            {
                battleFieldPlayer1.Controls.Remove(c);
                player[0].deleteCardFromTable(c);
            }
            else
            {
                battleFieldPlayer2.Controls.Remove(c);
                player[1].deleteCardFromTable(c);
            }
            c = null;
        }

        /// <summary>
        /// конец хода игрока, ход компьтера
        /// </summary>
        private void EndMove_Click(object sender, EventArgs  e)
        {
            
           
            Application.AddMessageFilter(tsm);
            History.Text += "Вы завершили ход\r\n\r\n";
            player[0].ShowAvailable(false);
            if (pickedCard != null)  pickedCard.isCurrent(false);
            isChoosen = false;
            
            battleFieldPlayer1.BackgroundImage = null;
            EndMove.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("buttonEndMoveUnenable");
            Update();
            Thread.Sleep(300);

            
            addCardToHandForPlayer2();
            HandPlayer2.Update();
            
            player[1].PutAllCardsOnTable();
            player[1].AttackForPlayer2();
            player[0].ChangeManaAfterMove();
            player[1].ChangeManaAfterMove();
            EndMove.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("buttonEndMove");
            History.Text += "Противник завершил ход\r\n\r\n";
            player[0].AllCardsCanBeat();
            player[1].AllCardsCanBeat();
            addCardToHandForPlayer1();
            Application.DoEvents();
            Application.RemoveMessageFilter(tsm);
            player[0].ShowAvailable(true);
            
            this.Enabled = true;        
            
            
            
        }
       
        

        /// <summary>
        /// попытка атаковать первому игроку второго
        /// </summary>
        private void player2Icon_Click(object sender, EventArgs e)
        {
            if(isChoosen && pickedCard != null)
            {
                if (pickedCard.isCardOnTable && pickedCard.isCanBeat)
                {
                    if (player[1].ReturnCardWithProvocation() == null)
                    {
                        player[1].Health -= ((Entity)pickedCard).Damage;
                        pickedCard.isCurrent(false);
                        pickedCard.isCanBeat = false;
                        pickedCard = null;
                        isChoosen = false;
                        player2Icon.status.BackColor = Color.Transparent;
                        player[0].ShowAvailable(true);
                    }
                    else History.Text += "Вы не можете атаковать противника - у противника имеются карточки с \"провокацией\" \r\n";
                }
            }
        }
        public void GameOver()
        {
            Application.RemoveMessageFilter(tsm);
            if (player[1].Health <= 0)
            {
                Win w = new Win();
                w.ShowDialog();
            }
            else
            {
                Lose w = new Lose();
                w.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isMusicPlaying)
            {
                simpleSound.Stop();
                Mute.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("MuteMusic");
                isMusicPlaying = false;
            }
            else
            {
                try
                {
                    simpleSound.Play();
                }
                catch
                {
                    History.Text += "Не удалось воспроизвести музыку\r\n";
                }
                finally
                {

                    isMusicPlaying = true;
                    Mute.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("PlayMusic");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class TestMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            // Blocks all the messages relating to the left mouse button.
            if (m.Msg >= 513 && m.Msg <= 515)
            {
                return true;
            }
            return false;
        }
       
    }
    
}
