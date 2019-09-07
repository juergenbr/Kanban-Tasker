﻿using KanbanTasker.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KanbanTasker.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainViewModel ViewModel { get; set; }
        private FlyoutBase ActiveFlyout;

        public MainView()
        {
            this.InitializeComponent();

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);
            ViewModel = App.GetViewModel(contentFrame, KanbanInAppNotification);
        }

        

        private async void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SettingsView();
            var result = await dialog.ShowAsync();
        }

        // This is a hack - works for the moment but there are other ways to show / hide flyouts
        private void ShowFlyout(object sender, RoutedEventArgs e)
        {
            ActiveFlyout = FlyoutBase.GetAttachedFlyout((FrameworkElement)sender);
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void HideFlyout(object sender, RoutedEventArgs e)
        {
            if (ActiveFlyout == null)
                return;

            ActiveFlyout.Hide();
        }

        private void EditBoardFlyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            // Call VM method to reset current board to tmpBoard if user clicks away 
            if (txtBoxNewBoardName.Text == "" && txtBoxNewBoardName.Text == "")
                ViewModel.SetCurrentBoardOnClose();
            else if (txtBoxNewBoardName.Text == "")
                ViewModel.SetCurrentBoardOnClose();
            else if (txtBoxNewBoardName.Text == "")
                ViewModel.SetCurrentBoardOnClose();
        }
    }
}
