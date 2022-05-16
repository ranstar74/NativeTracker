using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using NativeTracker.ViewModels;
using NativeTracker.ViewModels.Assets;
using NativeTracker.Views.Assets;
using ReactiveUI;

namespace NativeTracker.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
            
            Interactions.AddVehicleInteraction.RegisterHandler(AddVehicleHandler);
            Interactions.ShowLoginDialogInteraction.RegisterHandler(ShowLoginDialogHandler);
        }

        private void ShowLoginDialogHandler(InteractionContext<Unit, bool> interaction)
        {
            throw new NotImplementedException();
        }

        private async Task AddVehicleHandler(InteractionContext<Unit, VehicleAddViewModel> interaction)
        {
            var vm = new VehicleAddViewModel();
            var window = new VehicleAddWindow
            {
                DataContext = vm
            };

            var result = await window.ShowDialog<VehicleAddViewModel>(this);
            interaction.SetOutput(result);
        }
    }
}