using MauiAppMinhasCompras.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descricaoEntry.Text) || string.IsNullOrWhiteSpace(quantidadeEntry.Text) || string.IsNullOrWhiteSpace(precoEntry.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos", "OK");
                return;
            }

            var produto = new Produto
            {
                Descricao = descricaoEntry.Text,
                Quantidade = int.Parse(quantidadeEntry.Text),
                Preco = double.Parse(precoEntry.Text)
            };

            await App.Db.Insert(produto);

            descricaoEntry.Text = "";
            quantidadeEntry.Text = "";
            precoEntry.Text = "";

            CarregarProdutos();
        }

        private async void CarregarProdutos()
        {
            var produtos = await App.Db.GetAll();
            produtosListView.ItemsSource = produtos;
        }
    }
}
