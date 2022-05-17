using System.Collections.Generic;

namespace NativeTracker.ViewModels.Assets;

public class CreateTrackIssueViewModel : ValidatableViewModel
{
    public IEnumerable<KeyValuePair<int, string>> IssueTypes { get; } = new[]
    {
        new KeyValuePair<int, string>(1, "Установка устройства"),
        new KeyValuePair<int, string>(2, "Снятие устройства"),
        new KeyValuePair<int, string>(2, "Ремонт устройства"),
    };
}