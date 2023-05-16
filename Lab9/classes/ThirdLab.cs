using Lab9.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab9
{
    class ThirdLab
    {
        //Interfaces transferring data
        interface IUsbBus
        {
            void ToUsbDevice(int value);
        }

        interface ISata
        {
            void ToDisk(int value);
        }

        interface INetwork
        {
            void ToNetworkCard(int value);
        }

        interface IInnerBus
        {
            void ToRam(int value);
        }

        interface IMotherBoard
        {
            void ToMotherBoard(int value);
        }


        //Classes implementing the interfaces and transferring data
        class Connectable
        {
            protected int value;
            private string name;
            private IMotherBoard motherBoard;

            public Connectable(string name)
            {
                this.name = name;
            }

            public string Info()
            {
                return name + ": " + value;
            }

            public void ToMotherBoard(int value)
            {
                motherBoard.ToMotherBoard(value);
            }

            public void Connect(IMotherBoard motherBoard)
            {
                this.motherBoard = motherBoard;
            }
        }

        class ConnectableUsb : Connectable, IUsbBus
        {
            protected ConnectableUsb(string name) : base(name) { }
            public void ToUsbDevice(int value)
            {
                this.value = value;
            }
        }

        class ConnectableDisk : Connectable, ISata
        {
            protected ConnectableDisk(string name) : base(name) { }
            public void ToDisk(int value)
            {
                this.value = value;
            }
        }

        class ConnectableNetworkCard : Connectable, INetwork
        {
            protected ConnectableNetworkCard(string name) : base(name) { }
            public void ToNetworkCard(int value)
            {
                this.value = value;
            }
        }

        class ConnectableRam : Connectable, IInnerBus
        {
            protected ConnectableRam(string name) : base(name) { }
            public void ToRam(int value)
            {
                this.value = value;
            }
        }


        //MotherBoard combines in itself all the devices and communicates with them
        class MotherBoard : IMotherBoard, IUsbBus, ISata, INetwork, IInnerBus
        {
            private int value;
            private ConnectableUsb usbDevice;
            private ConnectableDisk disk;
            private ConnectableNetworkCard networkCard;
            private ConnectableRam ram;

            public string Info() { return "motherBoard: " + value; }

            public void ToMotherBoard(int value)
            {
                this.value = value;
            }

            // transfering values to the connected devices
            public void ToUsbDevice(int value)
            {
                this.usbDevice.ToUsbDevice(value);
            }

            public void ToDisk(int value)
            {
                this.disk.ToDisk(value);
            }

            public void ToNetworkCard(int value)
            {
                this.networkCard.ToNetworkCard(value);
            }

            public void ToRam(int value)
            {
                this.ram.ToRam(value);
            }


            // Connecting external devices
            public void ConnectUsbDevice(Connectable device)
            {
                device.Connect(this);
                this.usbDevice = (ConnectableUsb)device;
            }

            public void ConnectDisk(Connectable device)
            {
                device.Connect(this);
                this.disk = (ConnectableDisk)device;
            }

            public void ConnectNetworkCard(Connectable device)
            {
                device.Connect(this);
                this.networkCard = (ConnectableNetworkCard)device;
            }

            public void ConnectRam(Connectable device)
            {
                device.Connect(this);
                this.ram = (ConnectableRam)device;
            }

        }


        //Device classes
        class RamMemory : ConnectableRam
        {
            public RamMemory(string name) : base(name) { }
        }

        class HardDisk : ConnectableDisk
        {
            public HardDisk(string name) : base(name) { }
        }

        class Printer : ConnectableUsb
        {
            public Printer(string name) : base(name) { }
        }

        class Scanner : ConnectableUsb
        {
            public Scanner(string name) : base(name) { }
        }

        class NetworkCard : ConnectableNetworkCard
        {
            public NetworkCard(string name) : base(name) { }
        }

        class KeyBoard : ConnectableUsb
        {
            public KeyBoard(string name) : base(name) { }

        }


        public static void start()
        {
            //FileHelper.writeToFile("Lab3 Interfaces");
            MotherBoard motherBoard = new MotherBoard();
            KeyBoard keyBoard = new KeyBoard("Cool keyboard");

            //sending some data from the keyboard to motherboard
            motherBoard.ConnectUsbDevice(keyBoard);
            keyBoard.ToMotherBoard(123);
            FileHelper.writeToFile(motherBoard.Info());


            //sending a response from the motherboard to the keyboard
            motherBoard.ToUsbDevice(321);
            FileHelper.writeToFile(keyBoard.Info());


            //connecting printer and sending some data to the printer
            Printer printer = new Printer("Cool printer");
            motherBoard.ConnectUsbDevice(printer);
            motherBoard.ToUsbDevice(843);
            FileHelper.writeToFile(printer.Info());
        }
    }
}
