using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Constants;
using ECS.Animations;

namespace ECS.Objects
{
    partial class Elevator
    {
        //When the user select the destination in the elevator's panel
        public void userCall(Floor floor)
        {
            //If the elevator is in the current floor
            if (actualFloor == floor)
                return;

            //If the button is already pressed
            if (elevatorPanel.isPressed(floor))
                return;

            //Press the button
            elevatorPanel.press(floor, floor.id, id);

            //Add floor to the elevator's pending list
            pending.Add(floor);

            //Wake up elevator
            wakeUp();
                
        }

        public void wakeUp()
        {
            //If the elevator is in idle, start the action loop
            if(status == Status.idle)
                actionLoop();
        }

        public void setAnimating()
        {
            status = Status.animating;
        }

        public void returnFromAnimation()
        {
            status = Status.moving;
            actionLoop();
        }
    }
}
