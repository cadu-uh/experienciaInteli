using AppInteliWeb.Model;
using AppInteliWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppInteliWeb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : ContentPage
    {
        private ClienteApi clienteApi;
        private List<Cliente> clientes;

        public MainPage()
        {
            InitializeComponent();
            clienteApi = new ClienteApi();
            AtualizaDados();
        }

        async void AtualizaDados()
        {
            clientes = await clienteApi.GetAllClient();
            lvCliente.ItemsSource = clientes.OrderBy(item => item.FirstName).ToList();
            
        }

        public bool Valida()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtSurName.Text) && string.IsNullOrEmpty(txtAge.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LimpaCliente()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtSurName.Text = "";
            txtAge.Text = "";
            txtData.Text = "";
        }

        public bool ValidaInsert()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            if (ValidaInsert())
            {
                Guid identy = Guid.Parse(txtId.Text);
                Cliente cli = await clienteApi.GetById(identy);
                var result = cli.Id.ToString();

                if (result.Equals(txtId.Text))
                {
                    await DisplayAlert("Erro", "Usuario Já Cadastrado..", "OK");
                }
                else
                {
                    if (Valida())
                    {
                        var novoProduto = new Cliente
                        {
                            FirstName = txtFirstName.Text.Trim(),
                            SurName = txtSurName.Text.Trim(),
                            Age = int.Parse(txtAge.Text)                           
                        };
                        try
                        {
                            await clienteApi.CreateClient(novoProduto);
                            LimpaCliente();
                            AtualizaDados();
                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Erro", ex.Message, "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Dados inválidos...", "OK");
                    }
                }
            }
            else
            {
                if (Valida())
                {
                    Cliente novoProduto = new Cliente
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        SurName = txtSurName.Text.Trim(),
                        Age = int.Parse(txtAge.Text)
                    };
                    try
                    {
                        await clienteApi.CreateClient(novoProduto);
                        LimpaCliente();
                        AtualizaDados();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Erro", ex.Message, "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Erro", "Dados inválidos...", "OK");
                }
            }

        }

        private void lvCliente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var clie = e.SelectedItem as Cliente;
            txtId.Text = clie.Id.ToString();
            txtFirstName.Text = clie.FirstName;
            txtSurName.Text = clie.SurName;
            txtAge.Text = clie.Age.ToString();
            txtData.Text = clie.CreationDate.ToString();
        }    

        private async void OnAtualizar(object sender, EventArgs e)
        {
            if (Valida())
            {
                try
                {
                    var mi = ((MenuItem)sender);
                    Cliente clienteAtualizar = (Cliente)mi.CommandParameter;
                    clienteAtualizar.FirstName = txtFirstName.Text;
                    clienteAtualizar.SurName = txtSurName.Text;
                    clienteAtualizar.Age = int.Parse(txtAge.Text);
                    await clienteApi.UpDateClient(clienteAtualizar);
                    LimpaCliente();
                    AtualizaDados();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Dados inválidos...", "OK");
            }
        }

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Cliente produtoDeletar = (Cliente)mi.CommandParameter;
                await clienteApi.DeleteClient(produtoDeletar.Id);
                LimpaCliente();
                AtualizaDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            LimpaCliente();
            AtualizaDados();
        }
    }
}
