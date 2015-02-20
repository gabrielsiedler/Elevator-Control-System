using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Objects;
using ECS.Constants;

namespace ECS.Animations
{
    class AnimationsHandler
    {
        public FloorButton callButton;
        public AnimationsElevator elevator;
        public PanelButton normalButton;

        public AnimationsHandler(FloorButton callButton, AnimationsElevator elevator, PanelButton normalButton)
        {
            this.callButton = callButton;
            this.elevator = elevator;
            this.normalButton = normalButton;
        }

        public void setReferenceToController(Controller controller)
        {
            elevator.setReferenceToController(controller);
        }

        //Press Panel Button
        public void pressButton(Floor floor, int panelId)
        {
            normalButton.changeSprite_press(floor.id, panelId);
        }

        //Press Floor Button
        public void pressButton(Floor floor, Direction direction)
        {
            callButton.changeSprite_press(floor.id, direction);
        }

        //Unpress Panel Button
        public void unpressButton(Floor floor, int panelId)
        {
            normalButton.changeSprite_unpress(floor.id, panelId);
        }

        //Unpress Floor Button
        public void unpressButton(Floor floor, Direction direction)
        {
            callButton.changeSprite_unpress(floor.id, direction);
        }

        //Open elevator's doors
        public void openDoors(Elevator elevator)
        {
            this.elevator.animateDoors(elevator.id);
        }

        //Move the elevator one floor up
        public void moveUp(Elevator elevator)
        {
            this.elevator.elevatorMove(elevator, Direction.Up);
        }

        //Move the elevator one floor down
        public void moveDown(Elevator elevator)
        {
            this.elevator.elevatorMove(elevator, Direction.Down);
        }

    }
}
