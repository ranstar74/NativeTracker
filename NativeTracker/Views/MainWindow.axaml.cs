using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using NativeTracker.ViewModels;
using NativeTracker.ViewModels.Assets;
using NativeTracker.Views.Assets;
using nativeTrackerClientService;
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
            Interactions.EditVehicleInteraction.RegisterHandler(EditVehicleHandler);
            Interactions.ShowLoginDialogInteraction.RegisterHandler(ShowLoginDialogHandler);
            Interactions.PickTrackModel.RegisterHandler(PickTrackModelHandler);
            Interactions.CreateIssueInteraction.RegisterHandler(CreateIssueHandler);
        }

        private async Task CreateIssueHandler(InteractionContext<Unit, CreateTrackIssueViewModel> interaction)
        {
            var vm = new CreateTrackIssueViewModel();
            var window = new CreateTrackIssueWindow()
            {
                DataContext = vm
            };

            var result = await window.ShowDialog<CreateTrackIssueViewModel>(this);
            interaction.SetOutput(result);
        }

        private async Task PickTrackModelHandler(
            InteractionContext<TrackModelsViewModel, GetTrackModelResponse> interaction)
        {
            var vm = new TrackModelsViewModel();
            var window = new TrackModelsWindow()
            {
                DataContext = vm
            };

            var result = await window.ShowDialog<GetTrackModelResponse>(this);
            interaction.SetOutput(result);
        }

        private void ShowLoginDialogHandler(
            InteractionContext<Unit, bool> interaction)
        {
            throw new NotImplementedException();
        }

        private async Task AddVehicleHandler(
            InteractionContext<Unit, VehicleAddViewModel> interaction)
        {
            var vm = new VehicleAddViewModel();
            var window = new VehicleAddWindow
            {
                DataContext = vm
            };

            var result = await window.ShowDialog<VehicleAddViewModel>(this);
            interaction.SetOutput(result);
        }

        private async Task EditVehicleHandler(
            InteractionContext<GetVehiclesResponse, VehicleAddViewModel> interaction)
        {
            var vm = new VehicleAddViewModel()
            {
                Name = interaction.Input.Name,
                Photo = interaction.Input.Photo.ToByteArray()
            };
            var window = new VehicleAddWindow
            {
                DataContext = vm
            };

            var result = await window.ShowDialog<VehicleAddViewModel>(this);
            interaction.SetOutput(result);
        }
    }
}