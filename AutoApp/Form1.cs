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



        public Form1()
        {
            InitializeComponent();
            
            serialPort1.Open();

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

            serialPort1.Write("a");     
            checkBox7.Checked = false;

            serialPort1.Write("b");
            checkBox8.Checked = false;

            serialPort1.Write("c");
            checkBox11.Checked = false;

            serialPort1.Write("d");
            checkBox10.Checked = false;

            serialPort1.Write("e");
            checkBox1.Checked = false;

            serialPort1.Write("f");
            checkBox2.Checked = false;

            serialPort1.Write("g");
            checkBox3.Checked = false;

            serialPort1.Write("h");
            checkBox4.Checked = false;

            serialPort1.Write("i");
            checkBox5.Checked = false;

            serialPort1.Write("j");
            checkBox6.Checked = false;

            serialPort1.Write("m");
            checkBox9.Checked = false;

            MessageBox.Show("Experiment stopped");
        }

        private void button1_Click(object sender, EventArgs e)  //start button
        {
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
                //list all events



                //EVENT 1
                //opens mix to motor
                if (totalSeconds <= 59 & totalSeconds > 56)    //valve will turn on after 5s and turn off after 15s
                                                                //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("E");
                    checkBox1.Checked = true;
                }
                else
                {
                    serialPort1.Write("e");     //valve will close after 10s
                    checkBox1.Checked = false;
                }



                //EVENT 2
                //turns VFD on
                if (totalSeconds <= 58 & totalSeconds > 51)    //valve will turn on after 5s and turn off after 15s
                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("A");     //pin number
                    checkBox7.Checked = true;   //corresponding pin number label
                }
                else //closes valve after seconds have passed

                {
                    serialPort1.Write("a");
                    checkBox7.Checked = false;
                }



                //EVENT 3 = EVENT 2
                //turns on motor to cleaning
                if (totalSeconds <= 58 & totalSeconds > 53)    //valve will turn on after 5s and turn off after 15s
                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("F");
                    checkBox2.Checked = true;
                }
                else
                {
                    serialPort1.Write("f");     //valve will close after 10s
                    checkBox2.Checked = false;
                }




                //EVENT 4
                //Opens valve from cleaning to motor
                if (totalSeconds <= 57 & totalSeconds > 52)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("G");      //change pin letter
                    checkBox3.Checked = true;
                }
                else
                {
                    serialPort1.Write("g");     //change pin letter
                    checkBox3.Checked = false;
                }




                //EVENT 5
                //closing valve from mixing to motor
                


                //EVENT 6
                //turning on immersion heater
                if (totalSeconds <= 55 & totalSeconds > 54)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("M");      //change pin letter
                    checkBox9.Checked = true;
                }
                else
                {
                    serialPort1.Write("m");     //change pin letter
                    checkBox9.Checked = false;
                }




                //EVENT 7 = EVENT 6
                //TURNING ON ULTRASONIC
                if (totalSeconds <= 55 & totalSeconds > 54)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("B");      //change pin letter
                    checkBox7.Checked = true;
                }
                else
                {
                    serialPort1.Write("b");     //change pin letter
                    checkBox7.Checked = false;
                }




                //EVENT 8
                //TURNING OFF IMMERSION HEATER




                //EVENT 9 = 8
                //TURNING OFF ULTRASONIC




                //EVENT 10
                //CLOSING MOTOR TO CLEANING VALVE




                //EVENT 11 = EVENT 10
                //OPENING MOTOR TO RECOVERY VALVE
                if (totalSeconds <= 53 & totalSeconds > 50)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("H");      //change pin letter
                    checkBox4.Checked = true;
                }
                else
                {
                    serialPort1.Write("h");     //change pin letter
                    checkBox4.Checked = false;
                }






                //EVENT 15a
                //TURNING ON OZONE
                if (totalSeconds <= 49 & totalSeconds > 48)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("D");      //change pin letter
                    checkBox10.Checked = true;
                }
                else
                {
                    serialPort1.Write("d");     //change pin letter
                    checkBox10.Checked = false;
                }





                //EVENT 15b
                //TURNING ON UV
                if (totalSeconds <= 49 & totalSeconds > 48)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("C");      //change pin letter
                    checkBox11.Checked = true;
                }
                else
                {
                    serialPort1.Write("c");     //change pin letter
                    checkBox11.Checked = false;
                }





                //EVENT 17
                //OPENING RECOVERY TO MOTOR VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("I");      //change pin letter
                    checkBox5.Checked = true;
                }
                else
                {
                    serialPort1.Write("i");     //change pin letter
                    checkBox5.Checked = false;
                }






                //EVENT 18 = 17
                //TURNING ON VFD
                if (totalSeconds <= 47 & totalSeconds > 46)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("A");      //change pin letter
                    checkBox7.Checked = true;
                }
                else
                {
                    serialPort1.Write("a");     //change pin letter
                    checkBox7.Checked = false;
                }





                //EVENT 19 = 17
                //OPENING MOTOR TO MIXING VALVE
                if (totalSeconds <= 47 & totalSeconds > 46)    //valve will turn on after 5s and turn off after 15s
                                                                               //based on total mintues(of entire experiment) convert to seconds, subtract desired seconds from total
                                                                               // totalSeconds < (total seconds - desired seconds(amount of seconds you want the valve to turn on after)
                                                                               // total seconds > (total seconds - desired seconds(amount of seconds you want the valve to turn off after)
                {
                    serialPort1.Write("J");      //change pin letter
                    checkBox6.Checked = true;
                }
                else
                {
                    serialPort1.Write("j");     //change pin letter
                    checkBox6.Checked = false;
                }


                
                totalSeconds--;
                int mintues = totalSeconds / 60;
                int seconds = totalSeconds - (mintues * 60);
                this.label12.Text = mintues.ToString() + ":" + seconds.ToString();
                
            }

            else
            {


                this.timer1.Enabled = false;
                this.timer1.Stop();
                MessageBox.Show("Experiment Completed!");
            }

        }

        private void timer2_Tick(object sender, EventArgs e)    //timer for experiment 2
        {

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

        
    }
}

