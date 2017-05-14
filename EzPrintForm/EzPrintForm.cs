using GoogleDriveUploader.GoogleDrive;
using PaintModel;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace EzPrintForm
{
    public partial class EzPaintForm : Form
    {
        private Model _model;
        private PresentationModel _presentationModel;
        private GoogleDriveService _service;
        const string APPLICATION_NAME = "DrawAnywhere";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const string FILTER = "Bitmap Image|*.bmp";
        const string SAVE_TITLE = "Save an Image File";
        const string UP_LOAD_TITLE = "Upload an Image File";
        const string MESSAGE = "You uploaded a bit map.";
        const string CAPTION = "Message";
        //
        public EzPaintForm(Model model)
        {
            _model = model;
            _model._modelChange += RefreshUI;
            InitializeComponent();
            _presentationModel = new PresentationModel(_model, _printPanel);
            _undoToolStripMenuItem.Enabled = false;
            _redoToolStripMenuItem.Enabled = false;
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //
        private void RefreshUI()
        {
            _undoToolStripMenuItem.Enabled = _model.IsUndoEnabled;
            _redoToolStripMenuItem.Enabled = _model.IsRedoEnabled;
            Invalidate(true);
        }

        //
        private void PrintPanelMouseDown(object sender, MouseEventArgs e)
        {
            _model.MouseDown(new PaintModel.Point(e.Location.X, e.Location.Y));
        }

        //
        private void PrintPanelMouseMove(object sender, MouseEventArgs e)
        {
            _model.MouseMove(new PaintModel.Point(e.Location.X, e.Location.Y));
        }

        //
        private void PrintPanelMouseUp(object sender, MouseEventArgs e)
        {
            _model.MouseUp();
        }

        //
        private void ClickUndoToolStripMenuItem(object sender, EventArgs e)
        {
            _model.Undo();
        }

        //
        private void ClickRedoToolStripMenuItem(object sender, EventArgs e)
        {
            _model.Redo();
        }

        //
        private void PrintPanelPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //
        private void ClickRectangleToolStripMenuItem(object sender, EventArgs e)
        {
            _model.SetShape(0);
        }

        //
        private void ClickTriangleToolStripMenuItem(object sender, EventArgs e)
        {
            _model.SetShape(1);
        }

        //
        private void ClickCircleToolStripMenuItem(object sender, EventArgs e)
        {
            _model.SetShape(2);
        }

        //
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            Image image = _presentationModel.Save(_printPanel.CreateGraphics(), _printPanel.Width, _printPanel.Height);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DirectoryInfo directory = new DirectoryInfo(Application.StartupPath);
            saveFileDialog.InitialDirectory = directory.Parent.Parent.Parent.FullName;
            saveFileDialog.Filter = FILTER;
            saveFileDialog.Title = SAVE_TITLE;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
        }

        //
        private void ClickLineToolStripMenuItem(object sender, EventArgs e)
        {
            _model.SetShape(3);
        }

        //
        private void ClickSaveToGoogleDriveToolStripMenuItem(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DirectoryInfo directory = new DirectoryInfo(Application.StartupPath);
            openFileDialog.InitialDirectory = directory.Parent.Parent.Parent.FullName;
            openFileDialog.Filter = FILTER;
            openFileDialog.Title = UP_LOAD_TITLE;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                const string CONTENT_TYPE = "image/bmp";
                _service.UploadFile(openFileDialog.FileName, CONTENT_TYPE);
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(MESSAGE, CAPTION, buttons);
            }

        }
    }
}
