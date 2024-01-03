using Locksley.ViewModels;

namespace Locksley.Pages.Views;

public partial class ScoreSheetListItemView {
    private ScoreSheetListItemViewModel? ViewModel => BindingContext as ScoreSheetListItemViewModel;
    
    public ScoreSheetListItemView() {
        InitializeComponent();
        var gestureRec = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
        
        gestureRec.Tapped += OnGestureRecOnTapped;
        
        GestureRecognizers.Add(gestureRec);
    }

    private void OnGestureRecOnTapped(object? o, TappedEventArgs tappedEventArgs) {
        if (ViewModel != null) {
            ViewModel.Selected = !ViewModel.Selected;
        }
    }
}