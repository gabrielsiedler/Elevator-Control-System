using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ECS.Animations
{
    class PanelButton
    {
        /* Image sources (button sprites) */
        BitmapImage buttonClicked;
        BitmapImage buttonUnclicked;

        /* Reference to all panel images to make possible edit them */
        List<Image> firstPanel;
        List<Image> secondPanel;

        public PanelButton(List<Image> firstPanel, List<Image> secondPanel)
        {
            buttonClicked = new BitmapImage(new Uri("/Resources/buttonClicked.png", UriKind.Relative));
            buttonUnclicked = new BitmapImage(new Uri("/Resources/buttonUnclicked.png", UriKind.Relative));

            this.firstPanel = firstPanel;
            this.secondPanel = secondPanel;
        }

        /* Change the button sprite to "pressed" */
        public void changeSprite_press(int floorId, int panelId)
        {
            //floorId starts in 1, vector starts in 0
            floorId--;

            //Select the right panel
            if (panelId == 1)
                firstPanel[floorId].Source = buttonClicked;
            else
                secondPanel[floorId].Source = buttonClicked;
        }

        /* Change the button sprite to "unpressed" */
        public void changeSprite_unpress(int floorId, int panelId)
        {
            //floorId starts in 1, vector starts in 0
            floorId--;

            //Select the right panel
            if (panelId == 1)
                firstPanel[floorId].Source = buttonUnclicked;
            else
                secondPanel[floorId].Source = buttonUnclicked;
        }
    }
}
