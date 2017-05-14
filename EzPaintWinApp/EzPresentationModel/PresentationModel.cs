using PaintModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EzPaintWinApp.EzPresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _graphics;

        //
        public PresentationModel(Model model, Canvas canvas)
        {
            _model = model;
            _graphics = new WindowsAppGraphicsAdaptor(canvas);
        }

        //
        public void Draw()
        {
            _model.Draw(_graphics);
        }

    }
}
