using App2.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace App2.ViewModel
{
    public class PrincipalViewModel : BaseViewModel
   {
        #region Propriedade

        CultureInfo culture;

        private string _quant;

        public string Quant
        {
            get { return _quant; }
            set { _quant = value; OnPropertyChanged(); }
        }

        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; OnPropertyChanged(); }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged(); }
        }

        private string _minimo;

        public string Minimo
        {
            get { return _minimo; }
            set { _minimo = value; OnPropertyChanged(); }
        }

        #endregion
        #region Command
        public ObservableCollection<ValoresModel> Valores { get; set; }

        public Command CalcularCommand { get; }
        
        public Command LimparCommand { get; }
#endregion
        public PrincipalViewModel()
        {
            Valores = new ObservableCollection<ValoresModel>();
            CalcularCommand = new Command(ExecuteCalcularCommand);
            LimparCommand = new Command(ExecuteLimparCommand);
            culture = new CultureInfo("pt-BR");
        }

        private void ExecuteCalcularCommand()
        {
            float resultado = (float.Parse(Valor,culture) * 1000) / float.Parse(Quant,culture);
            Result =resultado.ToString("N2",culture);
            Valores.Add(new ValoresModel(Quant, Valor, Result));
            float valorMinimo = 9999999;
            
            if (valorMinimo > resultado)
            {
                Minimo = $"Preço de tabela: R${Valor}, Preço calculado:R${Result}";
                valorMinimo = resultado;
            }
        }

        private void ExecuteLimparCommand()
        {
            Valores.Clear();
            Result = "";
            Valor = "";
            Quant = "";
        }
    }
}
