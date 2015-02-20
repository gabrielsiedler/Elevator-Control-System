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
using ECS.Listeners;
using ECS.Objects;
using ECS.Animations;

namespace ECS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Controller controller;

        public MainWindow()
        {
            InitializeComponent();

            /*Getting XAML references and storing them in a way that make it possible to handle it in the inner functions */
            AnimationsHandler animationsHandler = createAnimationsHandler();

            //Create the controller class
            controller = new Controller(animationsHandler);
        }

        /* 
         * EVENTS 
         */

        //When a button is clicked in the panel
        private void PanelClick(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = (Canvas)sender;

            Listeners.Listener.ListenElevator(canvas, controller);
        }

        //When a user call the elevator
        private void FloorClick(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;

            Listeners.Listener.ListenFloor(image, controller);
        }

        /*
         * Auxilliary functions
         */

        private AnimationsHandler createAnimationsHandler()
        {
            Rectangle[] doors1 = new Rectangle[2] { elevator1door1, elevator1door2 };
            Rectangle[] doors2 = new Rectangle[2] { elevator2door1, elevator2door2 };
            AnimationsElevator animationsElevator = new AnimationsElevator(elevator1, elevator2, doors1, doors2);

            List<Image> buttonsUp = fillUpVector();
            List<Image> buttonsDown = fillDownVector();
            FloorButton animationsCallButton = new FloorButton(buttonsUp, buttonsDown);

            List<Image> firstPanel = fillFirstPanel();
            List<Image> secondPanel = fillSecondPanel();
            PanelButton animationsNormalButton = new PanelButton(firstPanel, secondPanel);

            return new AnimationsHandler(animationsCallButton, animationsElevator, animationsNormalButton);
        }
        
        private List<Image> fillUpVector()
        {
            List<Image> buttonsUp = new List<Image>();

            buttonsUp.Add(Floor1Up);
            buttonsUp.Add(Floor2Up);
            buttonsUp.Add(Floor3Up);
            buttonsUp.Add(Floor4Up);
            buttonsUp.Add(Floor5Up);
            buttonsUp.Add(Floor6Up);
            buttonsUp.Add(Floor7Up);
            buttonsUp.Add(Floor8Up);
            buttonsUp.Add(Floor9Up);
            buttonsUp.Add(Floor10Up);
            buttonsUp.Add(Floor11Up);
            buttonsUp.Add(Floor12Up);
            buttonsUp.Add(Floor13Up);
            buttonsUp.Add(Floor14Up);

            return buttonsUp;
        }

        private List<Image> fillDownVector()
        {
            List<Image> buttonsDown = new List<Image>();

            buttonsDown.Add(null); //pos 0 - the first floor does not have down button
            buttonsDown.Add(Floor2Down);
            buttonsDown.Add(Floor3Down);
            buttonsDown.Add(Floor4Down);
            buttonsDown.Add(Floor5Down);
            buttonsDown.Add(Floor6Down);
            buttonsDown.Add(Floor7Down);
            buttonsDown.Add(Floor8Down);
            buttonsDown.Add(Floor9Down);
            buttonsDown.Add(Floor10Down);
            buttonsDown.Add(Floor11Down);
            buttonsDown.Add(Floor12Down);
            buttonsDown.Add(Floor13Down);
            buttonsDown.Add(Floor14Down);
            buttonsDown.Add(Floor15Down);

            return buttonsDown;
        }

        private List<Image> fillFirstPanel()
        {
            List<Image> firstPanel = new List<Image>();

            firstPanel.Add(button1);
            firstPanel.Add(button2);
            firstPanel.Add(button3);
            firstPanel.Add(button4);
            firstPanel.Add(button5);
            firstPanel.Add(button6);
            firstPanel.Add(button7);
            firstPanel.Add(button8);
            firstPanel.Add(button9);
            firstPanel.Add(button10);
            firstPanel.Add(button11);
            firstPanel.Add(button12);
            firstPanel.Add(button13);
            firstPanel.Add(button14);
            firstPanel.Add(button15);
            firstPanel.Add(button16);
            firstPanel.Add(button17);
            firstPanel.Add(button18);

            return firstPanel;
        }

        private List<Image> fillSecondPanel()
        {
            List<Image> secondPanel = new List<Image>();

            secondPanel.Add(button19);
            secondPanel.Add(button20);
            secondPanel.Add(button21);
            secondPanel.Add(button22);
            secondPanel.Add(button23);
            secondPanel.Add(button24);
            secondPanel.Add(button25);
            secondPanel.Add(button26);
            secondPanel.Add(button27);
            secondPanel.Add(button28);
            secondPanel.Add(button29);
            secondPanel.Add(button30);
            secondPanel.Add(button31);
            secondPanel.Add(button32);
            secondPanel.Add(button33);
            secondPanel.Add(button34);
            secondPanel.Add(button35);
            secondPanel.Add(button36);

            return secondPanel;
        }
        



        



    }
}
