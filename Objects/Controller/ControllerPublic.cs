using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Constants;

namespace ECS.Objects
{
    /* Public Controller methods */
    partial class Controller
    {

        //When a user call the elevator from some floor
        public void floorCall(Floor floor, Direction direction)
        {
            if (direction == Direction.Up)
            {
                //If the button is already pressed
                if (floor.ButtonUp == Pressed.pressed)
                    return;

                //Indicates the button is pressed
                floor.Press(Direction.Up);

                //Add the floor to the pending up list
                PendingUp.Add(floor);
            }
            else
            {
                //If the button is already pressed
                if (floor.ButtonDown == Pressed.pressed)
                    return;

                //Indicates the button is pressed
                floor.Press(Direction.Down);

                //Add the floor to the pending up list
                PendingUp.Add(floor);

            }

            //Wake up all elevators
            foreach (Elevator elevator in Elevators)
                elevator.wakeUp();

        }

        //Get a floor given its id
        public Floor getFloorById(int id)
        {
            foreach (Floor floor in Floors)
                if (floor.id == id)
                    return floor;

            return null;
        }

        //Get an elevator given its id
        public Elevator getElevatorById(int id)
        {
            foreach (Elevator elevator in Elevators)
                if (elevator.id == id)
                    return elevator;

            return null;
        }

        //Get all floors that have the button up called and are above the floor given
        public List<Floor> getPendingUp(Floor floor)
        {
            if (floor == null)
                return null;

            //Create a new list to group those objects
            List<Floor> pUp = new List<Floor>();


            foreach (Floor f in PendingUp)
                if (f.id > floor.id)
                    pUp.Add(f);

            return pUp;
        }

        //Get all floors that have the button down called and are below the floor given
        public List<Floor> getPendingDown(Floor floor)
        {
            if (floor == null)
                return null;

            //Create a new list to group those objects
            List<Floor> pDown = new List<Floor>();

            foreach (Floor f in PendingDown)
                if (f.id < floor.id)
                    pDown.Add(f);

            return pDown;
        }

        //Get a concatenated result list from both pending global lists
        public bool existsPending()
        {
            //Create a new list to group those objects
            bool result = false;

            if ((PendingDown.Count > 0) || (PendingUp.Count > 0))
                result = true;

            return result;
        }

        //Remove floor from one of the pending lists
        public void removeFloor(Floor floor, Direction direction)
        {
            if(direction == Direction.Up)
                PendingUp.Remove(floor);
            else
                PendingDown.Remove(floor);
            
        }

        public Floor getHigher()
        {
            //big number to be replaced at first
            int higher = 0;
            Floor result = null;

            foreach (Floor floor in PendingDown)
            {
                if (floor.id > higher)
                {
                    higher = floor.id; //store the higher
                    result = floor; //store the floor
                }
            }

            foreach (Floor floor in PendingUp)
            {
                if (floor.id > higher)
                {
                    higher = floor.id; //store the higher
                    result = floor; //store the floor
                }
            }

            //return the floor
            return result;
        }

    }

}
