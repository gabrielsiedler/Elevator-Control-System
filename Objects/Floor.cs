using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Constants;
using ECS.Animations;

namespace ECS.Objects
{
    class Floor
    {
        //Unique id
        public int id { get; private set; }
        /* Actual status of the buttons in the floor */
        public Pressed ButtonUp { get; set; }
        public Pressed ButtonDown { get; set; }
        //Reference to the animations handler
        AnimationsHandler animationsHandler;

        public Floor(int id, AnimationsHandler animationsHandler)
        {
            this.id = id;
            this.animationsHandler = animationsHandler;

            //Set the initial status as unpressed
            ButtonUp = Pressed.unpressed;
            ButtonDown = Pressed.unpressed;
        }

        //Press a floor button
        public void Press(Direction dir)
        {
            if (dir == Direction.Up)
                ButtonUp = Pressed.pressed;
            else
                ButtonDown = Pressed.pressed;

            //Change the sprite of the button pressed
            animationsHandler.pressButton(this, dir);
        }

        //Unpress a floor button
        public void Unpress(Direction dir)
        {
            if (dir == Direction.Up)
                ButtonUp = Pressed.unpressed;
            else
                ButtonDown = Pressed.unpressed;

            //Change the sprite of the button pressed
            animationsHandler.unpressButton(this, dir);
        }

    }
}
