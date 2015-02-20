using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ECS.Objects;
using ECS.Constants;

namespace ECS.Listeners
{
    static partial class Listener
    {
        /* Check out which button (or which floor) called the elevator 
         * Call the controller method to handle the input with the information given.
         */
        public static void ListenFloor(Image i, Controller controller)
        {
            switch(i.Name)
            {
                case "Floor1Up":
                    controller.floorCall(controller.getFloorById(1), Direction.Up);
                    break;
                case "Floor2Up":
                    controller.floorCall(controller.getFloorById(2), Direction.Up);
                    break;
                case "Floor3Up":
                    controller.floorCall(controller.getFloorById(3), Direction.Up);
                    break;
                case "Floor4Up":
                    controller.floorCall(controller.getFloorById(4), Direction.Up);
                    break;
                case "Floor5Up":
                    controller.floorCall(controller.getFloorById(5), Direction.Up);
                    break;
                case "Floor6Up":
                    controller.floorCall(controller.getFloorById(6), Direction.Up);
                    break;
                case "Floor7Up":
                    controller.floorCall(controller.getFloorById(7), Direction.Up);
                    break;
                case "Floor8Up":
                    controller.floorCall(controller.getFloorById(8), Direction.Up);
                    break;
                case "Floor9Up":
                    controller.floorCall(controller.getFloorById(9), Direction.Up);
                    break;
                case "Floor10Up":
                    controller.floorCall(controller.getFloorById(10), Direction.Up);
                    break;
                case "Floor11Up":
                    controller.floorCall(controller.getFloorById(11), Direction.Up);
                    break;
                case "Floor12Up":
                    controller.floorCall(controller.getFloorById(12), Direction.Up);
                    break;
                case "Floor13Up":
                    controller.floorCall(controller.getFloorById(13), Direction.Up);
                    break;
                case "Floor14Up":
                    controller.floorCall(controller.getFloorById(14), Direction.Up);
                    break;
                case "Floor2Down":
                    controller.floorCall(controller.getFloorById(2), Direction.Down);
                    break;
                case "Floor3Down":
                    controller.floorCall(controller.getFloorById(3), Direction.Down);
                    break;
                case "Floor4Down":
                    controller.floorCall(controller.getFloorById(4), Direction.Down);
                    break;
                case "Floor5Down":
                    controller.floorCall(controller.getFloorById(5), Direction.Down);
                    break;
                case "Floor6Down":
                    controller.floorCall(controller.getFloorById(6), Direction.Down);
                    break;
                case "Floor7Down":
                    controller.floorCall(controller.getFloorById(7), Direction.Down);
                    break;
                case "Floor8Down":
                    controller.floorCall(controller.getFloorById(8), Direction.Down);
                    break;
                case "Floor9Down":
                    controller.floorCall(controller.getFloorById(9), Direction.Down);
                    break;
                case "Floor10Down":
                    controller.floorCall(controller.getFloorById(10), Direction.Down);
                    break;
                case "Floor11Down":
                    controller.floorCall(controller.getFloorById(11), Direction.Down);
                    break;
                case "Floor12Down":
                    controller.floorCall(controller.getFloorById(12), Direction.Down);
                    break;
                case "Floor13Down":
                    controller.floorCall(controller.getFloorById(13), Direction.Down);
                    break;
                case "Floor14Down":
                    controller.floorCall(controller.getFloorById(14), Direction.Down);
                    break;
                case "Floor15Down":
                    controller.floorCall(controller.getFloorById(15), Direction.Down);
                    break;
            }

        }
    }
}
