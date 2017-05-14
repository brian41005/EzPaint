using PaintModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using EzPaintWinApp.EzPresentationModel;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using System;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using GoogleDriveForApp.GoogleDriveForApp;
using Windows.UI.Popups;
//空白頁項目範本收錄在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EzPaintWinApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Model _model;
        PresentationModel _presentationModel;
        private GoogleDriveServiceForApp _service;
        const string APPLICATION_NAME = "DrawAnywhere";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const int DOTS_PER_INCH = 96;
        const string CONTENT_TYPE = "image/bmp";
        const string IMAGE_NAME = "103590450";

        //
        public MainPage()
        {
            this.InitializeComponent();
            _model = new Model();
            _presentationModel = new PresentationModel(_model, _canvas);
            _model._modelChange += RefreshUI;
            _undoButton.IsEnabled = false;
            _redoButton.IsEnabled = false;
            _winAppForm.UpdateLayout();
            _service = new GoogleDriveServiceForApp(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }
        
        //
        private void RefreshUI()
        {
            _undoButton.IsEnabled = _model.IsUndoEnabled;
            _redoButton.IsEnabled = _model.IsRedoEnabled;
            _presentationModel.Draw();
            _winAppForm.UpdateLayout();
        }

        //
        private void ClickUndo(object sender, RoutedEventArgs e)
        {
            _model.Undo();
        }

        //
        private void ClickRedo(object sender, RoutedEventArgs e)
        {
            _model.Redo();
        }

        //
        private void ClickRectangle(object sender, RoutedEventArgs e)
        {
            _model.SetShape(0);
        }

        //
        private void ClickTriangle(object sender, RoutedEventArgs e)
        {
            _model.SetShape(1);
        }

        //
        private void ClickCircle(object sender, RoutedEventArgs e)
        {
            _model.SetShape(2);
        }

        //
        private void ClickLine(object sender, RoutedEventArgs e)
        {
            _model.SetShape(3);
        }

        //
        private FileSavePicker GetPicker()
        {
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileSavePicker.FileTypeChoices.Add("Bitmap Image", new List<string>()
            {
                ".bmp"
            });
            return fileSavePicker;
        }

        //
        private async void ClickSave(object sender, RoutedEventArgs e)
        {
            FileSavePicker fileSavePicker = GetPicker();
            StorageFile file = await fileSavePicker.PickSaveFileAsync();
            if (file != null)
            {
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
                await renderTargetBitmap.RenderAsync(_canvas);
                IBuffer pixels = await renderTargetBitmap.GetPixelsAsync();
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, stream);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)_canvas.ActualWidth, (uint)_canvas.ActualHeight, DOTS_PER_INCH, DOTS_PER_INCH, pixels.ToArray());
                    await encoder.FlushAsync();
                }
            }
        }

        //
        private async void ClickUpload(object sender, RoutedEventArgs e)
        {
            //MessageDialog dialog = new MessageDialog("Google Drive API DLL 一直有問題，會有runtime ERROR.\n 編譯器指出問題出在GoogleDriveServiceForApp", "T^T");
            //UICommand button = new UICommand("OK");
            //dialog.Commands.Add(button);
            //await dialog.ShowAsync();
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(); await renderTargetBitmap.RenderAsync(_canvas); StorageFolder folder = ApplicationData.Current.LocalFolder; StorageFile file = await folder.CreateFileAsync(IMAGE_NAME);
            if (file != null)
            {
                await renderTargetBitmap.RenderAsync(_canvas);
                IBuffer pixels = await renderTargetBitmap.GetPixelsAsync();
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, stream);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)_canvas.ActualWidth, (uint)_canvas.ActualHeight, DOTS_PER_INCH, DOTS_PER_INCH, pixels.ToArray());
                    await encoder.FlushAsync();
                }
                await _service.UploadFile(IMAGE_NAME, CONTENT_TYPE);
               }
         }

        //
        private void MouseDown(object sender, PointerRoutedEventArgs e)
        {
            _model.MouseDown(new PaintModel.Point((int)e.GetCurrentPoint(_canvas).Position.X, (int)e.GetCurrentPoint(_canvas).Position.Y));
        }

        //
        private void MouseUp(object sender, PointerRoutedEventArgs e)
        {
            _model.MouseUp();
        }

        //
        private void MouseMove(object sender, PointerRoutedEventArgs e)
        {
            _model.MouseMove(new PaintModel.Point((int)e.GetCurrentPoint(_canvas).Position.X, (int)e.GetCurrentPoint(_canvas).Position.Y));
        }
        
    }
}
