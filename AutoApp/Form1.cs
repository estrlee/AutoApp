using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;



namespace AutoApp
{
    public partial class Form1 : Form
    {
        private int totalSeconds;
        private int seconds;

        bool connected = false;
        SerialPort sp;

        public Form1()
        {

            InitializeComponent();
            var ports = SerialPort.GetPortNames();
            comboBox2.DataSource = ports;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sp = new SerialPort(comboBox2.SelectedItem.ToString(), 9600);

                if (!connected)
                {
                    sp.Open();
                    connected = true;
                    MessageBox.Show("Serial port connected");
                }
                else
                {
                    sp.Close();
                    sp.Dispose();

                    connected = false;

                    MessageBox.Show("Serial port disconnected");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Serial port cannot connect");
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;    //ADD ALL TIMERS
            this.timer2.Enabled = false;
            

            sp.Write("a");     
            checkBox7.Checked = false;

            sp.Write("b");
            checkBox8.Checked = false;

            sp.Write("c");
            checkBox11.Checked = false;

            sp.Write("d");
            checkBox10.Checked = false;

            sp.Write("e");
            checkBox1.Checked = false;

            sp.Write("f");
            checkBox2.Checked = false;

            sp.Write("g");
            checkBox3.Checked = false;

            sp.Write("h");
            checkBox4.Checked = false;

            sp.Write("i");
            checkBox5.Checked = false;

            sp.Write("j");
            checkBox6.Checked = false;

            sp.Write("m");
            checkBox9.Checked = false;

            MessageBox.Show("Experiment stopped");
        }

        private void button1_Click(object sender, EventArgs e)  //start button
        {
            //Experiment 1 drop down
            if (comboBox1.SelectedIndex == 1)    //experiment 1
            {
                int minutes = 1;
                seconds = (minutes / 60);
                totalSeconds = (minutes * 60) + seconds;
                this.timer1.Enabled = true;     //coressponding timer
            }
            else
            {
                this.timer1.Enabled = false;
            }


            //Experiment 2 drop down
            if (comboBox1.SelectedIndex == 2)    //experiment 2 //corresponding index
            {
                int minutes = 1;        //total experiment time
                seconds = (minutes / 60);
                totalSeconds = (minutes * 60) + seconds;
                this.timer2.Enabled = true;     //coressponding timer

            }
            else
            {
                this.timer2.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)    //timer for expirement 1
        {
            if (totalSeconds > 0)
            {
                //EVENT 1 --> Event 5
                //opens mix to motor
                if (totalSeconds <= 59 & totalSeconds > 56)    //valve will turn on after 5s and turn off after 15s
                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    sp.Write("E");          //pin number
                    checkBox1.Checked = true;   //corresponding pin number label
                }
                else    //closes valve after seconds have passed
                {
                    sp.Write("e");     //valve will close after 10s
                    checkBox1.Checked = false;
                }

                //EVENT 2 --> Event 13
                //turns VFD on
                if (totalSeconds <= 58 & totalSeconds > 51 || totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("A");
                    checkBox7.Checked = true;
                    /*MessageBox.Show("Experiment stopped");*/
                }
                else

                {
                    sp.Write("a");
                    checkBox7.Checked = false;
                }

                //EVENT 3 --> Event 10 = EVENT 2
                //turns on motor to cleaning
                if (totalSeconds <= 58 & totalSeconds > 51)
                {
                    sp.Write("F");
                    checkBox2.Checked = true;
                }
                else
                {
                    sp.Write("f");
                    checkBox2.Checked = false;
                }

                //EVENT 4 --> Event 12
                //Opens valve from cleaning to motor
                if (totalSeconds <= 57 & totalSeconds > 52)
                {
                    sp.Write("G");
                    checkBox3.Checked = true;
                }
                else
                {
                    sp.Write("g");
                    checkBox3.Checked = false;
                }

                //EVENT 5
                //closing valve from mixing to motor

                //EVENT 6 --> Event 8
                //turning on immersion heater
                if (totalSeconds <= 55 & totalSeconds > 54)
                {
                    sp.Write("M");
                    checkBox9.Checked = true;
                }
                else
                {
                    sp.Write("m");
                    checkBox9.Checked = false;
                }

                //EVENT 7 = EVENT 6
                //TURNING ON ULTRASONIC
                if (totalSeconds <= 55 & totalSeconds > 54)
                {
                    sp.Write("B");
                    checkBox8.Checked = true;
                }
                else
                {
                    sp.Write("b");
                    checkBox8.Checked = false;
                }

                //EVENT 8
                //TURNING OFF IMMERSION HEATER

                //EVENT 9 = 8
                //TURNING OFF ULTRASONIC

                //EVENT 10
                //CLOSING MOTOR TO CLEANING VALVE

                //EVENT 11 --> Event 14 = EVENT 10
                //OPENING MOTOR TO RECOVERY VALVE
                if (totalSeconds <= 53 & totalSeconds > 50)
                {
                    sp.Write("H");
                    checkBox4.Checked = true;
                }
                else
                {
                    sp.Write("h");
                    checkBox4.Checked = false;
                }

                //EVENT 12
                //CLOSING CLEANING TO MOTOR

                //EVENT 13
                //TURNS OFF VFD

                //EVENT 14
                //CLOSING MOTOR TO RECOVERY

                //EVENT 15a --> event 16
                //TURNING ON OZONE
                if (totalSeconds <= 49 & totalSeconds > 48)
                {
                    sp.Write("D");
                    checkBox10.Checked = true;
                }
                else
                {
                    sp.Write("d");
                    checkBox10.Checked = false;
                }

                //EVENT 15b --> event 16
                //TURNING ON UV
                if (totalSeconds <= 49 & totalSeconds > 48)
                {
                    sp.Write("C");
                    checkBox11.Checked = true;
                }
                else
                {
                    sp.Write("c");
                    checkBox11.Checked = false;
                }

                //Event 16
                //Turning off UV and Ozone

                //EVENT 17
                //OPENING RECOVERY TO MOTOR VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("I");
                    checkBox5.Checked = true;
                }
                else
                {
                    sp.Write("i");
                    checkBox5.Checked = false;
                }

                //EVENT 18 = 17
                //TURNING ON VFD

                //EVENT 19 = 17
                //OPENING MOTOR TO MIXING VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("J");
                    checkBox6.Checked = true;
                }
                else
                {
                    sp.Write("j");
                    checkBox6.Checked = false;
                }

                totalSeconds--;
                int mintues = totalSeconds / 60;
                int seconds = totalSeconds - (mintues * 60);
                this.label12.Text = mintues.ToString() + ":" + seconds.ToString();
            }

            else
            {
                this.timer1.Enabled = false;    //change timer number
                this.timer1.Stop();             //change timer number
                MessageBox.Show("Experiment Completed!");
            }

        }

        private void timer2_Tick(object sender, EventArgs e)    //timer for experiment 2
        {
            if (totalSeconds > 0)
            {
                //EVENT 1 --> Event 5
                //opens mix to motor
                if (totalSeconds <= 59 & totalSeconds > 56)    //valve will turn on after 5s and turn off after 15s
                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    sp.Write("E");          //pin number
                    checkBox1.Checked = true;   //corresponding pin number label
                }
                else    //closes valve after seconds have passed
                {
                    sp.Write("e");     //valve will close after 10s
                    checkBox1.Checked = false;
                }

                //EVENT 2 --> Event 13
                //turns VFD on
                if (totalSeconds <= 58 & totalSeconds > 51 || totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("A");
                    checkBox7.Checked = true;
                }
                else

                {
                    sp.Write("a");
                    checkBox7.Checked = false;
                }

                //EVENT 3 --> Event 10 = EVENT 2
                //turns on motor to cleaning
                if (totalSeconds <= 58 & totalSeconds > 51)
                {
                    sp.Write("F");
                    checkBox2.Checked = true;
                }
                else
                {
                    sp.Write("f");
                    checkBox2.Checked = false;
                }

                //EVENT 4 --> Event 12
                //Opens valve from cleaning to motor
                if (totalSeconds <= 57 & totalSeconds > 52)
                {
                    sp.Write("G");
                    checkBox3.Checked = true;
                }
                else
                {
                    sp.Write("g");
                    checkBox3.Checked = false;
                }

                //EVENT 5
                //closing valve from mixing to motor

                //EVENT 6 --> Event 8
                //turning on immersion heater
                if (totalSeconds <= 55 & totalSeconds > 54)
                {
                    sp.Write("M");
                    checkBox9.Checked = true;
                }
                else
                {
                    sp.Write("m");
                    checkBox9.Checked = false;
                }

                //EVENT 7 = EVENT 6
                //TURNING ON ULTRASONIC
                if (totalSeconds <= 55 & totalSeconds > 54)
                {
                    sp.Write("B");
                    checkBox8.Checked = true;
                }
                else
                {
                    sp.Write("b");
                    checkBox8.Checked = false;
                }

                //EVENT 8
                //TURNING OFF IMMERSION HEATER

                //EVENT 9 = 8
                //TURNING OFF ULTRASONIC

                //EVENT 10
                //CLOSING MOTOR TO CLEANING VALVE

                //EVENT 11 --> Event 14 = EVENT 10
                //OPENING MOTOR TO RECOVERY VALVE
                if (totalSeconds <= 53 & totalSeconds > 50)
                {
                    sp.Write("H");
                    checkBox4.Checked = true;
                }
                else
                {
                    sp.Write("h");
                    checkBox4.Checked = false;
                }

                //EVENT 12
                //CLOSING CLEANING TO MOTOR

                //EVENT 13
                //TURNS OFF VFD

                //EVENT 14
                //CLOSING MOTOR TO RECOVERY

                //EVENT 15a --> event 16
                //TURNING ON OZONE
                if (totalSeconds <= 49 & totalSeconds > 48)
                {
                    sp.Write("D");
                    checkBox10.Checked = true;
                }
                else
                {
                    sp.Write("d");
                    checkBox10.Checked = false;
                }

                //EVENT 15b --> event 16
                //TURNING ON UV
                if (totalSeconds <= 49 & totalSeconds > 48)
                {
                    sp.Write("C");
                    checkBox11.Checked = true;
                }
                else
                {
                    sp.Write("c");
                    checkBox11.Checked = false;
                }

                //Event 16
                //Turning off UV and Ozone

                //EVENT 17
                //OPENING RECOVERY TO MOTOR VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("I");
                    checkBox5.Checked = true;
                }
                else
                {
                    sp.Write("i");
                    checkBox5.Checked = false;
                }

                //EVENT 18 = 17
                //TURNING ON VFD

                //EVENT 19 = 17
                //OPENING MOTOR TO MIXING VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)
                {
                    sp.Write("J");
                    checkBox6.Checked = true;
                }
                else
                {
                    sp.Write("j");
                    checkBox6.Checked = false;
                }

                totalSeconds--;
                int mintues = totalSeconds / 60;
                int seconds = totalSeconds - (mintues * 60);
                this.label12.Text = mintues.ToString() + ":" + seconds.ToString();
            }

            else
            {
                this.timer2.Enabled = false;    //change timer number
                this.timer2.Stop();             //change timer number
                MessageBox.Show("Experiment Completed!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)   //Mixing to Motor Valve / Relay1
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)   //Motor to Cleaning / Relay2
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)   //Cleaning to Motor / Relay3
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)   //Motor to Recovery / Relay4
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)   //Recovery to Motor / Relay5
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)   //Motor to Mixing / Relay6
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)   //VFD / Relay7
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)   //Ultrasonic / Relay8
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)   //Immersion / Relay9
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)  //Ozone / Relay10
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)  //UV Light / Relay11
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}

