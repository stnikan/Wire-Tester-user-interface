using System;
using System.Windows.Forms;
using System.IO.Ports;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
 
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void arduinoButton_Click(object sender, EventArgs e)
        {
            comboBox.Items.Clear();
            // Получаем список COM портов доступных в системе
            string[] portnames = SerialPort.GetPortNames();
            // Проверяем есть ли доступные
            if (portnames.Length == 0)
            {
                MessageBox.Show("COM PORT not found");
            }
            foreach (string portName in portnames)
            {
                //добавляем доступные COM порты в список           
                comboBox.Items.Add(portName);
                Console.WriteLine(portnames.Length);
                if(portnames[0] != null)
                {
                    comboBox.SelectedItem = portnames[0];
                }
            }
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox.GetItemText(comboBox.SelectedItem);
            serialPort.PortName = selectedPort;
            serialPort.Open();
            connectButton.Text = "Disconnect";
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            serialPort.Close();
            connectButton.Text = "Connect";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии программы, закрываем порт
            if (serialPort.IsOpen) serialPort.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if(isConnected)
            {
                serialPort.Write("1");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort.Write("0");
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}