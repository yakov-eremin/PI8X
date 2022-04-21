using FontAwesome5;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.UseCases;
using System;
using System.Windows.Input;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class RockPaperScissorsWindowViewModel : ClosableWindowViewModel
    {
        RockPaperScissors _game;
        public RockPaperScissorsWindowViewModel(RockPaperScissors game)
        {
            _game = game;
            ConfigureParameters();
            ConfigureGame();
            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
            RoundCommand = new LambdaCommand(OnRoundCommandExecuted, CanRoundCommandExecute);
            GetAccessTokenCommand = new LambdaCommand(OnGetAccessTokenCommandExecuted,
                CanGetAccessTokenCommandExecute);
            TryElseCommand = new LambdaCommand(OnTryElseCommandExecuted, CanTryElseCommandExecute);
        }

        #region Properties
        private string _status = "";
        public string Status { get => _status; set => Set(ref _status, value); }

        private int _roundsCount = 0;
        public int RoundsCount { get => _roundsCount; set => Set(ref _roundsCount, value); }

        private int _currentRound = 0;
        public int CurrentRound { get => _currentRound; set => Set(ref _currentRound, value); }

        private int _computerScores = 0;
        public int ComputerScores { get => _computerScores; set => Set(ref _computerScores, value); }

        private int _userScores = 0;
        public int UserScores { get => _userScores; set => Set(ref _userScores, value); }

        private EFontAwesomeIcon _computerVariantIcon = EFontAwesomeIcon.Solid_Question;
        public EFontAwesomeIcon ComputerVariantIcon { get => _computerVariantIcon; 
            set => Set(ref _computerVariantIcon, value); }
        #endregion


        #region Commands

        #region CloseCommand
        public ICommand CloseCommand { get; }
        private void OnCloseCommandExecuted(object p)
        {
            OnCloseWindow(new CloseWindowEventArgs(false));
        }
        private bool CanCloseCommandExecute(object p) => true;
        #endregion

        #region RoundCommand
        public ICommand RoundCommand { get; }
        private void OnRoundCommandExecuted(object p)
        {
            try
            {
                Random random = new Random();
                ChoiceVariant userChoice;
                ChoiceVariant computerChoice = 
                    (ChoiceVariant)random.Next((int)ChoiceVariant.Stone, (int)ChoiceVariant.Paper + 1);
                Status = "";
                string eFontAwesomeIcon;
                if (p is string)
                    eFontAwesomeIcon = (string)p;
                else
                {
                    Status = "Попробуйте еще раз";
                    return;
                }
                userChoice = ChoiceFromIconName(eFontAwesomeIcon);
                if (userChoice != computerChoice)
                {
                    ChoiceVariant winner = _game.GetWinningVariant(userChoice, computerChoice);
                    ComputerVariantIcon = IconFromChoice(computerChoice);
                    if (winner == computerChoice)
                    {
                        Status = "компьютер выиграл этот раунд";
                        ComputerScores++;
                    }
                    else
                    {
                        Status = "Вы выиграли этот раунд";
                        UserScores++;
                    }
                    CurrentRound++;
                }
                else
                {
                    Status = "Вы выбрали тот же вариант, что и компьютер, попробуйте еще раз";
                    return;
                }
            }
            catch(Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanRoundCommandExecute(object p) => CurrentRound <= RoundsCount;
        #endregion

        #region GetAccessTokenCommand
        public ICommand GetAccessTokenCommand { get; }
        private void OnGetAccessTokenCommandExecuted(object p)
        {
            OnCloseWindow(new CloseWindowEventArgs(true));
        }
        private bool CanGetAccessTokenCommandExecute(object p) => CurrentRound > RoundsCount
            && UserScores > ComputerScores;
        #endregion

        #region TryElseCommand
        public ICommand TryElseCommand { get; }
        private void OnTryElseCommandExecuted(object p)
        {
            ConfigureParameters();
            ConfigureGame();
        }
        private bool CanTryElseCommandExecute(object p) => true;
        #endregion

        #endregion

        private void ConfigureParameters()
        {
            RoundsCount = 3;
            CurrentRound = 1;
            ComputerScores = 0;
            UserScores = 0;
        }

        private void ConfigureGame()
        {
            _game.RoundsCount = RoundsCount;
        }

        private ChoiceVariant ChoiceFromIconName(string eFontAwesomeIcon) => eFontAwesomeIcon switch
        {
            "Solid_HandRock" => ChoiceVariant.Stone,
            "olid_HandScissors" => ChoiceVariant.Scissors,
            "Solid_HandPaper" => ChoiceVariant.Paper,
            _ => ChoiceVariant.Stone,
        };

        private EFontAwesomeIcon IconFromChoice(ChoiceVariant choiceVariant) => choiceVariant switch
        {
            ChoiceVariant.Stone => EFontAwesomeIcon.Solid_HandRock,
            ChoiceVariant.Scissors => EFontAwesomeIcon.Solid_HandScissors,
            ChoiceVariant.Paper => EFontAwesomeIcon.Solid_HandPaper,
            _ => EFontAwesomeIcon.Solid_HandRock
        };
    }
}
