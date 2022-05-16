using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;

namespace NativeTracker.ViewModels.Assets;

public class VehicleAddViewModel : ValidatableViewModel
{
    [Reactive] public string Name { get; set; }
    [Reactive] public byte[] Photo { get; set; }

    public ICommand BrowsePhotoCommand { get; }

    public ReactiveCommand<Unit, VehicleAddViewModel> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public Interaction<Unit, string> ShowOpenFileDialog { get; } = new();

    public VehicleAddViewModel()
    {
        this.ValidationRule(
            vm => vm.Name,
            name => !string.IsNullOrEmpty(name),
            "Name can't be empty.");

        this.ValidationRule(
            vm => vm.Photo,
            photo => photo != null,
            "Photo required.");

        var hasErrorsObservable = this.WhenAnyValue(
            x => x.HasErrors,
            hasErrors => !hasErrors);

        BrowsePhotoCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            string path = await ShowOpenFileDialog.Handle(Unit.Default);

            if (path != string.Empty)
            {
                Photo = File.ReadAllBytes(path);
            }
        });

        SaveCommand = ReactiveCommand.Create(() => this, hasErrorsObservable);
        CancelCommand = ReactiveCommand.Create(() => { });
    }
}