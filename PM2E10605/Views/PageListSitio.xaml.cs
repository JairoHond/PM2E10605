using PM2E10605.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10605.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListSitio : ContentPage
    {
        public PageListSitio()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List.ItemsSource = await App.Instancia.GetAll();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageInicial());
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            Sitios sitioSeleccionado = (Sitios)List.SelectedItem;

            if (sitioSeleccionado != null)
            {
                bool confirmacion = await DisplayAlert("Confirmar eliminación", "¿Está seguro que desea eliminar el sitio?", "Sí Eliminala", "No, Dejala");

                if (confirmacion)
                {
                    await App.Instancia.DeleteSitio(sitioSeleccionado);

                    List.ItemsSource = await App.Instancia.GetAll();
                }
            }
        }


        private async void Btnmapa_Clicked(object sender, EventArgs e)
        {
            Sitios selectedSitio = (Sitios)List.SelectedItem;

            if (selectedSitio != null)
            {
                bool confirmacion = await DisplayAlert("Confirmar", "¿Desea ir a la ubicación Seleccionada?", "Quiero ir", "Me quiero quedar");

                if (confirmacion)
                {
                    await Navigation.PushAsync(new PageMap(selectedSitio));
                }
            }
        }

    }
}