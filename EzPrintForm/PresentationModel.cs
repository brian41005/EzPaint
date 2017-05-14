using PaintModel;
using System.Drawing;
using System.Windows.Forms;

namespace EzPrintForm
{
    public class PresentationModel
    {
        private Model _model;

        //
        public PresentationModel(Model model, Control canvas)
        {
            _model = model;
            
        }

        //
        public void Draw(Graphics graphics)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //
        public Image Save(Graphics graphics, int width, int height)
        {
            Image bitmap = new Bitmap(width, height);
            _model.Save(new WindowsFormsGraphicsAdaptor(Graphics.FromImage(bitmap)));
            return bitmap;
        }
    }
}
