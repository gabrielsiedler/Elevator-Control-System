using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ECS.Constants;

namespace ECS.Animations
{
    class FloorButton
    {
        /* Image sources (button sprites) */
        BitmapImage buttonClickedUp;
        BitmapImage buttonClickedDown;
        BitmapImage buttonUnclickedUp;        
        BitmapImage buttonUnclickedDown;

        /* Reference to all panel images to make possible edit them */
        List<Image> listButtonsUp;
        List<Image> listButtonsDown;

        public FloorButton(List<Image> listButtonsUp, List<Image> listButtonsDown)
        {
            buttonClickedUp = new BitmapImage(new Uri("/Resources/goUpClicked.png", UriKind.Relative));
            buttonUnclickedUp = new BitmapImage(new Uri("/Resources/goUp.png", UriKind.Relative));
            buttonClickedDown = new BitmapImage(new Uri("/Resources/goDownClicked.png", UriKind.Relative));
            buttonUnclickedDown = new BitmapImage(new Uri("/Resources/goDown.png", UriKind.Relative));

            this.listButtonsUp = listButtonsUp;
            this.listButtonsDown = listButtonsDown;
        }


        /* Change the right button sprite to "pressed" */
        public void changeSprite_press(int floorId, Direction direction)
        {
            //floorId starts in 1, vector starts in 0
            floorId--;

            //select the image depending on the direction
            if(direction == Direction.Up)
                listButtonsUp[floorId].Source = buttonClickedUp;
            else
                listButtonsDown[floorId].Source = buttonClickedDown;
        }

        /* Change the right button sprite to "unpressed" */
        public void changeSprite_unpress(int floorId, Direction direction)
        {
            floorId--; //id starts in 1, vector in 0

            //select the image depending on the direction
            if (direction == Direction.Up)
                listButtonsUp[floorId].Source = buttonUnclickedUp;
            else
                listButtonsDown[floorId].Source = buttonUnclickedDown;
        }
    }
}
