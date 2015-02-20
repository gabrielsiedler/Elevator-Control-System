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
        //Unique ID
        public int id { get; private set; }
        //Actual status of the elevator
        public Status status { get; private set; }
        //The direction it is going in
        Direction direction;
        //The actualFloor it is in
        Floor actualFloor;
        //The list of pending floors
        public List<Floor> pending { get; private set; }

        /* Other class' references */
        Controller controller;
        ElevatorPanel elevatorPanel;
        AnimationsHandler animationsHandler;


        public Elevator(int id, Floor floor, Controller controller, AnimationsHandler animationsHandler)
        {
            this.controller = controller;
            this.id = id;

            //Sets the initial status to idle
            status = Status.idle;
            //Sets the initial direction to undefined
            direction = Direction.Undefined;


            pending = new List<Floor>();

            //Sets the actual floor
            actualFloor = floor;

            this.animationsHandler = animationsHandler;
            elevatorPanel = new ElevatorPanel(animationsHandler);
        }

        //make the elevator choose for the next move
        private void actionLoop()
        {
            bool loop = true;

            while (loop)
            {
                //check if the elevator should stop in the current floor
                checkActualFloor();

                //if the animation is running in another thread
                if (status == Status.animating)
                    return;

                //It is the first call (first move)
                if (status == Status.idle)
                {
                    Direction newDirection;
                    //Get nearer floor and define direction
                    newDirection = getNearerFloorDirection();

                    if (newDirection == Direction.Undefined)
                        return;

                    direction = newDirection;

                    //Set new status
                    status = Status.moving;

                    //move
                    move();

                    loop = false;

                }
                else //It is already moving
                {
                    //Is there any pending floor in this direction in both lists?
                    if (pendingDirection())
                    {
                        //move
                        move();

                        loop = false;
                    }
                    else
                    {
                        //If there is any floor in any pending list
                        if ((pending.Count > 0) || (controller.existsPending()))
                        {
                            //Change direction
                            if (direction == Direction.Up)
                            {
                                direction = Direction.Down;
                            }
                            else
                            {
                                direction = Direction.Up;
                            }
                        }
                        else //Dead end
                        {
                            direction = Direction.Undefined;
                            status = Status.idle;
                            loop = false;
                        }
                    }

                }

            }
        }

        private Direction getNearerFloorDirection()
        {
            Direction newDirection = Direction.Undefined;

            int minDistance = Const.POS_INFINITE;
            int difference = 0;
            Floor minFloor = null;

            //Search in the local list first

            //Search for floors above the current
            foreach (Floor floor in pending)
            {
                difference = actualFloor.id - floor.id;
                if (difference < 0)
                {
                    if (Math.Abs(difference) < minDistance)
                    {
                        minDistance = Math.Abs(difference);
                        minFloor = floor;
                        newDirection = Direction.Up;
                    }
                }
            }

            //Search for floors below the current
            foreach (Floor floor in pending)
            {
                difference = actualFloor.id - floor.id;
                if (difference > 0)
                {
                    if (difference < minDistance)
                    {
                        minDistance = difference;
                        minFloor = floor;
                        newDirection = Direction.Down;
                    }
                }

            }


            //If there weren't any floors in the local list
            if (newDirection == Direction.Undefined)
            {
                foreach (Floor floor in controller.PendingUp)
                {
                    difference = actualFloor.id - floor.id;
                    if (difference < 0)
                    {
                        if (Math.Abs(difference) < minDistance)
                        {
                            minDistance = Math.Abs(difference);
                            minFloor = floor;
                            newDirection = Direction.Up;
                        }
                    }
                }

                foreach (Floor floor in controller.PendingDown)
                {
                    difference = actualFloor.id - floor.id;
                    if (difference > 0)
                    {
                        if (difference < minDistance)
                        {
                            minDistance = difference;
                            minFloor = floor;
                            newDirection = Direction.Down;
                        }
                    }
                }
            }

            return newDirection;
        }

        //Move to the next floor in the current direction
        private void move()
        {
            setAnimating();

            if (direction == Direction.Up)
            {
                animationsHandler.moveUp(this);
                actualFloor = controller.getFloorById(actualFloor.id + 1);
            }
            else
            {
                animationsHandler.moveDown(this);
                actualFloor = controller.getFloorById(actualFloor.id - 1);
            }
        }

        //Check if there is any pending floor in the current direction
        private bool pendingDirection()
        {
            //If it is moving up
            if (direction == Direction.Up)
            {
                foreach (Floor floor in controller.PendingUp)
                    if (floor.id > actualFloor.id)
                        return true;

                foreach (Floor floor in pending)
                    if (floor.id > actualFloor.id)
                        return true;
            }
            else //If it is moving down
            {
                foreach (Floor floor in controller.PendingDown)
                    if (floor.id < actualFloor.id)
                        return true;

                foreach (Floor floor in pending)
                    if (floor.id < actualFloor.id)
                        return true;
            }

            return false;
        }


        /* 
         * checkActualFloor function and sub-functions 
         */

        private void checkActualFloor()
        {
            //If the current floor is in any pending list (in the direction the elevator is going)
            if (currentInPending())
            {
                //Remove current floor from list
                removeCurrent();

                //Set buttons to default
                removeCallButtons();

                //Open doors
                openDoors();

            }

        }

        /* Check if the current floor is in any pending list (in the direction the elevator is going) */
        private bool currentInPending()
        {
            //Search the current floor in the local pending list
            foreach (Floor floor in pending)
                if (floor == actualFloor)
                    return true;

            //Search the current floor in the global pendingUp list
            if (direction == Direction.Up)
                foreach (Floor floor in controller.PendingUp)
                    if (floor == actualFloor)
                        return true;

            //Search the current floor in the global pendingDown list
            if (direction == Direction.Down)
                foreach (Floor floor in controller.PendingDown)
                    if (floor == actualFloor)
                        return true;

            return false;
        }

        private void removeCallButtons()
        {

            if (actualFloor.ButtonUp == Pressed.pressed)
                actualFloor.Unpress(direction);

            if (actualFloor.ButtonDown == Pressed.pressed)
                actualFloor.Unpress(direction);

            if (elevatorPanel.isPressed(actualFloor))
                elevatorPanel.unpress(actualFloor, actualFloor.id, id);

        }

        private void removeCurrent()
        {
            //Remove the current floor from the global pendingUp list
            if (direction == Direction.Up)
                controller.PendingUp.Remove(actualFloor);

            //Remove the current floor from the global pendingDown list
            if (direction == Direction.Down)
                controller.PendingDown.Remove(actualFloor);

            //Remove the current floor from the local pending list
            pending.Remove(actualFloor);

        }

        private void openDoors()
        {
            setAnimating();

            animationsHandler.openDoors(this);
        }

        //Wait for the user that just entered in the elevator
        private async void Breathe()
        {
            if (status == Status.moving)
            {
                //freeze the actionLoop
                setAnimating();

                //breathe for x seconds
                await Task.Delay(Const.BREATHE_TIME);

                //release the actionLoop
                returnFromAnimation();
            }
        }
    }
}
