using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Constants;
using ECS.Animations;

namespace ECS.Objects
{
    class ElevatorPanel
    {
        //List of button status of the elevator panel
        List<Pressed> button;
        //Reference to the animationsHandler object
        AnimationsHandler animationsHandler;

        public ElevatorPanel(AnimationsHandler animationsHandler)
        {
            this.animationsHandler = animationsHandler;
            button = new List<Pressed>();

            //Set all button as unpressed
            for (int i = 0; i < 15; i++)
                button.Add(Pressed.unpressed);

        }

        //Tell that a button should be pressed
        public void press(Floor floor, int id, int panel)
        {
            //The actual id starts in 1 and the vector starts in 0
            id--;

            //Indicates that the button "id" was pressed
            button[id] = Pressed.pressed;

            //Change the button image
            animationsHandler.pressButton(floor, panel);
        }

        //Tell that a button should be unpressed
        public void unpress(Floor floor, int id, int panel)
        {
            //The actual id starts in 1 and the vector starts in 0
            id--;

            //Indicates that the button "id" was pressed
            button[id] = Pressed.unpressed;

            //Change the button image
            animationsHandler.unpressButton(floor, panel);
        }

        //Check if a button is pressed
        public bool isPressed(Floor floor)
        {
            //The floor id starts in 1, and the vector in 0
            if(button[floor.id-1] == Pressed.pressed)
                return true;

            return false;
        }

    }
}
