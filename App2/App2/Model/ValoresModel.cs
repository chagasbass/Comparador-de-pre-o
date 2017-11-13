namespace App2.Model
{
    public class ValoresModel
    {
        public string Quantidade { get; set; }

        public string Preco { get; set; }

        public string Resultado { get; set; }

        public ValoresModel(string quantidade, string preco, string resultado)
        {
            Quantidade = quantidade;
            Preco = preco;
            Resultado = resultado;
        }
    }
}
