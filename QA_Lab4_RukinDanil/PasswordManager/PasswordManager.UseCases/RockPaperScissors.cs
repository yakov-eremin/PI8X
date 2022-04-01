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
        public override Guid GetAccessToken()
        {
            throw new NotImplementedException();
        }

        public ChoiceVariant GetWinningVariant(ChoiceVariant firstVariant, ChoiceVariant secondVariant)
        {
            if (firstVariant == secondVariant)
                return firstVariant;
            return ChoiceVariant.Paper;
        }
    }

    /// <summary>
    /// Вариант выбора в игре 'Камень ножницы бумага'
    /// </summary>
    public enum ChoiceVariant
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
