using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Constants;
using ECS.Animations;


namespace ECS.Objects
{
    /* The controller itself */
    partial class Controller
    {

        //Reference to the animations handler
        AnimationsHandler animationsHandler;

        //List of all the elevators
        public List<Elevator> Elevators { get; private set; }
        //List of all the floors
        List<Floor> Floors;

        //List of all floors that have a button pending to go up
        public List<Floor> PendingUp { get; private set; }
        //List of all floors that have a button pending to go down
        public List<Floor> PendingDown { get; private set; }

        public Controller(AnimationsHandler animationsHandler)
        {
            this.animationsHandler = animationsHandler;

            //Create a list of elevators
            Elevators = new List<Elevator>();
            //Create a list of pending calls (calls from floors)
            PendingUp = new List<Floor>();
            PendingDown = new List<Floor>();
            //Create a list with all floors avaiable
            Floors = new List<Floor>();

            //Create the floors
            for (int i = 1; i <= Const.NUM_FLOORS; i++)
                Floors.Add(new Floor(i, animationsHandler));

            //Create the elevators
            for (int i = 1; i <= Const.NUM_ELEVATORS; i++)
                Elevators.Add(new Elevator(i, Floors[0], this, animationsHandler));

            animationsHandler.setReferenceToController(this);
        }

    }
}
