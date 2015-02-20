using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ECS.Objects;

namespace ECS.Listeners
{
    static partial class Listener
    {
        /* Check out which button from which elevator was called
         * Call the elevator method to handle the input with the information given.
         * c = element that called the funcion, in this case, the Cavas of the button
         */
        public static void ListenElevator(Canvas c, Controller controller)
        {
            //Get the unique ID of the button
            int uid = Convert.ToInt32(c.Uid);

            Elevator elevator;

            if (uid <= 15) //From 1 to 15 in the first elevator's panel
            { 
                elevator = controller.getElevatorById(1); //Get the reference to the first elevator
                elevator.userCall(controller.getFloorById(uid));
            }
            else if ((uid >= 19) && (uid < 34)) //From 1 to 15 in the second elevator's panel
            {
                elevator = controller.getElevatorById(2); //Get the reference to the second elevator

                /* There are 18 buttons in a elevator. 
                 * The floor id still the same
                 * It is needed to subtract 18 from the result to get the actual floor
                 */
                elevator.userCall(controller.getFloorById(uid - 18)); 
            }
        }
    }
}
