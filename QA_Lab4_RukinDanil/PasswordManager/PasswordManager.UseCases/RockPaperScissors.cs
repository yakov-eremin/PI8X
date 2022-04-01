using PasswordManager.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.UseCases
{
    /// <summary>
    /// Игра 'Камень ножницы бумага'
    /// </summary>
    /// <inheritdoc/>
    public abstract class RockPaperScissors : Game
    {
        protected ChoiceVariant[,] _matrix = new ChoiceVariant[,]
            {
                { ChoiceVariant.Stone, ChoiceVariant.Stone, ChoiceVariant.Paper},
                { ChoiceVariant.Stone, ChoiceVariant.Scissors, ChoiceVariant.Scissors},
                { ChoiceVariant.Paper, ChoiceVariant.Scissors, ChoiceVariant.Paper }
            };

        public ChoiceVariant UserChoice { get; set; }
        protected int _roundsCount;
        public int RoundsCount
        {
            get => _roundsCount;
            set => _roundsCount = (value / 2 == 0 ? value + 1 : value);
        }

        public RockPaperScissors()
        {
            UserChoice = ChoiceVariant.Paper;
            RoundsCount = 1;
        }

        public ChoiceVariant GetWinningVariant(ChoiceVariant firstVariant, ChoiceVariant secondVariant)
        {
            return _matrix[(int)firstVariant, (int)secondVariant];
        }
    }

    /// <summary>
    /// Вариант выбора в игре 'Камень ножницы бумага'
    /// </summary>
    public enum ChoiceVariant : int
    {
        /// <summary>
        /// Камень
        /// </summary>
        Stone,
        /// <summary>
        /// Ножницы
        /// </summary>
        Scissors,
        /// <summary>
        /// Бумага
        /// </summary>
        Paper
    }
}
