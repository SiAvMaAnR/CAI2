using System.Collections.ObjectModel;

namespace CAI2.Models
{
    public class MainViewModel : BaseViewModel
    {
        private IsCorrect isCorrect = IsCorrect.Undefined;
        public IsCorrect IsCorrect
        {
            get { return isCorrect; }
            set
            {
                isCorrect = value;
                OnPropertyChanged(nameof(isCorrect));
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged(nameof(code));
            }
        }

        private ObservableCollection<Lexeme> lexemes = new ObservableCollection<Lexeme>();
        public ObservableCollection<Lexeme> Lexemes
        {
            get { return lexemes; }
            set
            {
                lexemes = value;
            }
        }
    }

    public enum IsCorrect
    {
        Undefined,
        Correct,
        InCorrect
    }
}
