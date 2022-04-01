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
    public class RockPaperScissors : Game
    {
        ChoiceVariant[,] matrix = new ChoiceVariant[,]
            {
                { ChoiceVariant.Stone, ChoiceVariant.Stone, ChoiceVariant.Paper},
                { ChoiceVariant.Stone, ChoiceVariant.Scissors, ChoiceVariant.Scissors},
                { ChoiceVariant.Paper, ChoiceVariant.Scissors, ChoiceVariant.Paper }
            };

        public override Guid GetAccessToken()
        {
            throw new NotImplementedException();
        }

        public ChoiceVariant GetWinningVariant(ChoiceVariant firstVariant, ChoiceVariant secondVariant)
        {
            return matrix[(int)firstVariant, (int)secondVariant];
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
