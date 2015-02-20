using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ECS.Constants;
using ECS.Objects;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Media.Animation;


/*          ____ __
 *         { --.\  |          .)%%%)%%
 *          '-._\\ | (\___   %)%%(%%(%%%
 *              `\\|{/ ^ _)-%(%%%%)%%;%%%
 *          .'^^^^^^^  /`    %%)%%%%)%%%'
 *         //\   ) ,  /       '%%%%(%%'
 *   ,  _.'/  `\<-- \< 
 *    `^^^`     ^^   ^^
 * 
 * BEWARE! THERE BE DRAGONS!
 * 
 */

namespace ECS.Animations
{
    class AnimationsElevator
    {
        bool[] opening;
        bool[] closing;

        Controller controller;

        Canvas Elevator1;
        Rectangle[] DoorsElevator1;
        Canvas Elevator2;
        Rectangle[] DoorsElevator2;

        //Animation variables
        Duration elevatorMovingDuration, doorMovingDuration;

        /* Constructor */
        public AnimationsElevator(Canvas elevator1, Canvas elevator2, Rectangle[] doorsElevator1, Rectangle[] doorsElevator2)
        {
            Elevator1 = elevator1;
            Elevator2 = elevator2;

            DoorsElevator1 = doorsElevator1;
            DoorsElevator2 = doorsElevator2;

            opening = new bool[2] { false, false };
            closing = new bool[2] { false, false };

            elevatorMovingDuration = new Duration(TimeSpan.FromSeconds(1));
            doorMovingDuration = new Duration(TimeSpan.FromSeconds(3));
        }

        public void setReferenceToController(Controller controller)
        {
            this.controller = controller;
        }

        public void elevatorMove(Elevator elevator, Direction direction)
        {
            double actualCanvasPosition, newCanvasPosition;
            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.Duration = elevatorMovingDuration;

            Storyboard moveStoryBoard = new Storyboard();
            moveStoryBoard.Duration = elevatorMovingDuration;
            moveStoryBoard.Children.Add(moveAnimation);

            if (elevator.id == 1)
            {
                actualCanvasPosition = Canvas.GetTop(Elevator1);
                newCanvasPosition = getNewElevatorPosition(actualCanvasPosition, direction);

                moveAnimation.To = newCanvasPosition;

                Storyboard.SetTarget(moveAnimation, Elevator1);
                Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(Canvas.Top)"));

                moveStoryBoard.Completed += new EventHandler(completed1);
                moveStoryBoard.Begin();
            }
            else
            {
                actualCanvasPosition = Canvas.GetTop(Elevator2);
                newCanvasPosition = getNewElevatorPosition(actualCanvasPosition, direction);

                moveAnimation.To = newCanvasPosition;

                Storyboard.SetTarget(moveAnimation, Elevator2);
                Storyboard.SetTargetProperty(moveAnimation, new PropertyPath("(Canvas.Top)"));

                moveStoryBoard.Completed += new EventHandler(completed2);
                moveStoryBoard.Begin();
            }
        }

        private void completed1(object sender, EventArgs e)
        {
            controller.getElevatorById(1).returnFromAnimation();
        }

        private void completed2(object sender, EventArgs e)
        {
            controller.getElevatorById(2).returnFromAnimation();
        }

        private double getNewElevatorPosition(double actualCanvasPosition, Direction direction)
        {
            double newCanvasPosition = -1;

            if (direction == Direction.Up)
            {
                if ((actualCanvasPosition > (434 - 4)) && (actualCanvasPosition < (434 + 4)))
                {
                    newCanvasPosition = 403;
                }
                else if ((actualCanvasPosition > (403 - 4)) && (actualCanvasPosition < (403 + 4)))
                {
                    newCanvasPosition = 372;
                }
                else if ((actualCanvasPosition > (372 - 4)) && (actualCanvasPosition < (372 + 4)))
                {
                    newCanvasPosition = 341;
                }
                else if ((actualCanvasPosition > (341 - 4)) && (actualCanvasPosition < (341 + 4)))
                {
                    newCanvasPosition = 310;
                }
                else if ((actualCanvasPosition > (310 - 4)) && (actualCanvasPosition < (310 + 4)))
                {
                    newCanvasPosition = 279;
                }
                else if ((actualCanvasPosition > (279 - 4)) && (actualCanvasPosition < (279 + 4)))
                {
                    newCanvasPosition = 248;
                }
                else if ((actualCanvasPosition > (248 - 4)) && (actualCanvasPosition < (248 + 4)))
                {
                    newCanvasPosition = 217;
                }
                else if ((actualCanvasPosition > (217 - 4)) && (actualCanvasPosition < (217 + 4)))
                {
                    newCanvasPosition = 186;
                }
                else if ((actualCanvasPosition > (186 - 4)) && (actualCanvasPosition < (186 + 4)))
                {
                    newCanvasPosition = 155;
                }
                else if ((actualCanvasPosition > (155 - 4)) && (actualCanvasPosition < (155 + 4)))
                {
                    newCanvasPosition = 124;
                }
                else if ((actualCanvasPosition > (124 - 4)) && (actualCanvasPosition < (124 + 4)))
                {
                    newCanvasPosition = 93;
                }
                else if ((actualCanvasPosition > (93 - 4)) && (actualCanvasPosition < (93 + 4)))
                {
                    newCanvasPosition = 62;
                }
                else if ((actualCanvasPosition > (62 - 4)) && (actualCanvasPosition < (62 + 4)))
                {
                    newCanvasPosition = 31;
                }
                else if ((actualCanvasPosition > (31 - 4)) && (actualCanvasPosition < (31 + 4)))
                {
                    newCanvasPosition = 0;
                }
            }
            else
            {
                if ((actualCanvasPosition > (403 - 4)) && (actualCanvasPosition < (403 + 4)))
                {
                    newCanvasPosition = 434;
                }
                else if ((actualCanvasPosition > (372 - 4)) && (actualCanvasPosition < (372 + 4)))
                {
                    newCanvasPosition = 403;
                }
                else if ((actualCanvasPosition > (341 - 4)) && (actualCanvasPosition < (341 + 4)))
                {
                    newCanvasPosition = 372;
                }
                else if ((actualCanvasPosition > (310 - 4)) && (actualCanvasPosition < (310 + 4)))
                {
                    newCanvasPosition = 341;
                }
                else if ((actualCanvasPosition > (279 - 4)) && (actualCanvasPosition < (279 + 4)))
                {
                    newCanvasPosition = 310;
                }
                else if ((actualCanvasPosition > (248 - 4)) && (actualCanvasPosition < (248 + 4)))
                {
                    newCanvasPosition = 279;
                }
                else if ((actualCanvasPosition > (217 - 4)) && (actualCanvasPosition < (217 + 4)))
                {
                    newCanvasPosition = 248;
                }
                else if ((actualCanvasPosition > (186 - 4)) && (actualCanvasPosition < (186 + 4)))
                {
                    newCanvasPosition = 217;
                }
                else if ((actualCanvasPosition > (155 - 4)) && (actualCanvasPosition < (155 + 4)))
                {
                    newCanvasPosition = 186;
                }
                else if ((actualCanvasPosition > (124 - 4)) && (actualCanvasPosition < (124 + 4)))
                {
                    newCanvasPosition = 155;
                }
                else if ((actualCanvasPosition > (93 - 4)) && (actualCanvasPosition < (93 + 4)))
                {
                    newCanvasPosition = 124;
                }
                else if ((actualCanvasPosition > (62 - 4)) && (actualCanvasPosition < (62 + 4)))
                {
                    newCanvasPosition = 93;
                }
                else if ((actualCanvasPosition > (31 - 4)) && (actualCanvasPosition < (31 + 4)))
                {
                    newCanvasPosition = 62;
                }
                else if ((actualCanvasPosition > (0 - 4)) && (actualCanvasPosition < (0 + 4)))
                {
                    newCanvasPosition = 31;
                }
            }

            return newCanvasPosition;
        }


        public void animateDoors(int id)
        {
            this.openDoors(id);
        }

        private void openDoors(int id)
        {
            Rectangle door1Reference;
            Rectangle door2Reference;
            Canvas referenceToElevator;
            if (id == 1)
            {
                referenceToElevator = Elevator1;
                door1Reference = DoorsElevator1[0];
                door2Reference = DoorsElevator1[1];
            }
            else
            {
                referenceToElevator = Elevator2;
                door1Reference = DoorsElevator2[0];
                door2Reference = DoorsElevator2[1];
            }

            DoubleAnimation openDoor1 = new DoubleAnimation();
            DoubleAnimation openDoor2 = new DoubleAnimation();
            DoubleAnimation openDoor2Move = new DoubleAnimation();

            openDoor1.Duration = doorMovingDuration;
            openDoor2.Duration = doorMovingDuration;
            openDoor2Move.Duration = doorMovingDuration;

            Storyboard moveStoryBoard = new Storyboard();


            moveStoryBoard.Duration = doorMovingDuration;
            moveStoryBoard.Children.Add(openDoor1);
            moveStoryBoard.Children.Add(openDoor2);
            moveStoryBoard.Children.Add(openDoor2Move);

            openDoor1.To = 0;
            openDoor2.To = 0;
            openDoor2Move.To = 11 + 7;

            Storyboard.SetTarget(openDoor1, door1Reference);
            Storyboard.SetTarget(openDoor2, door2Reference);
            Storyboard.SetTarget(openDoor2Move, door2Reference);

            Storyboard.SetTargetProperty(openDoor1, new PropertyPath("(Width)"));
            Storyboard.SetTargetProperty(openDoor2, new PropertyPath("(Width)"));
            Storyboard.SetTargetProperty(openDoor2Move, new PropertyPath("(Canvas.Left)"));

            moveStoryBoard.Completed += (sender, eventArgs) =>
            {
                closeDoors(id);
            };

            moveStoryBoard.Begin();
        }

        private void closeDoors(int id)
        {
            Rectangle door1Reference;
            Rectangle door2Reference;
            Canvas referenceToElevator;

            if (id == 1)
            {
                referenceToElevator = Elevator1;
                door1Reference = DoorsElevator1[0];
                door2Reference = DoorsElevator1[1];
            }
            else
            {
                referenceToElevator = Elevator2;
                door1Reference = DoorsElevator2[0];
                door2Reference = DoorsElevator2[1];
            }

            DoubleAnimation openDoor1 = new DoubleAnimation();
            DoubleAnimation openDoor2 = new DoubleAnimation();
            DoubleAnimation openDoor2Move = new DoubleAnimation();

            openDoor1.Duration = doorMovingDuration;
            openDoor2.Duration = doorMovingDuration;
            openDoor2Move.Duration = doorMovingDuration;

            Storyboard moveStoryBoard = new Storyboard();
            moveStoryBoard.Duration = doorMovingDuration;
            moveStoryBoard.Children.Add(openDoor1);
            moveStoryBoard.Children.Add(openDoor2);
            moveStoryBoard.Children.Add(openDoor2Move);

            openDoor1.To = 7;
            openDoor2.To = 7;
            openDoor2Move.To = 11;

            Storyboard.SetTarget(openDoor1, door1Reference);
            Storyboard.SetTarget(openDoor2, door2Reference);
            Storyboard.SetTarget(openDoor2Move, door2Reference);

            Storyboard.SetTargetProperty(openDoor1, new PropertyPath("(Width)"));
            Storyboard.SetTargetProperty(openDoor2, new PropertyPath("(Width)"));
            Storyboard.SetTargetProperty(openDoor2Move, new PropertyPath("(Canvas.Left)"));

            if (id == 1)
                moveStoryBoard.Completed += new EventHandler(completed1);
            else
                moveStoryBoard.Completed += new EventHandler(completed2);

            moveStoryBoard.Begin();
        }

    }
}
