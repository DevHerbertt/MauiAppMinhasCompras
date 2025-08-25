using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CarregarProdutos();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(entryDescricao.Text)
            && int.TryParse(entryQuantidade.Text, out int qtd)
            && decimal.TryParse(entryPreco.Text, out decimal preco))
        {
            var produto = new Produto
            {
                Descricao = entryDescricao.Text,
                Quantidade = qtd,
                Preco = preco
            };

            await App.Db.Insert(produto);

            await DisplayAlert("Sucesso", "Produto registrado!", "OK");

            entryDescricao.Text = string.Empty;
            entryQuantidade.Text = string.Empty;
            entryPreco.Text = string.Empty;

            CarregarProdutos();
        }
        else
        {
            await DisplayAlert("Erro", "Preencha todos os campos corretamente!", "OK");
        }
    }

    private async void CarregarProdutos()
    {
        var lista = await App.Db.GetAll();
        collectionProdutos.ItemsSource = lista;
    }
}
