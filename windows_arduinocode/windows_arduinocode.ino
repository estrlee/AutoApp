  int RelayPin1 = 2; //This is the Arduino Pin that will control Relay #1 (Valve Mixing to Motor)
  int RelayPin2 = 3; //This is the Arduino Pin that will control Relay #2 (Valve Motor to Cleaning)
  int RelayPin3 = 4; //This is the Arduino Pin that will control Relay #3 (Valve Cleaning to Motor)
  int RelayPin4 = 5; //This is the Arduino Pin that will control Relay #4 (Valve Motor to Recovery)
  int RelayPin5 = 6; //This is the Arduino Pin that will control Relay #5 (Valve Recovery to Motor)
  int RelayPin6 = 7; //This is the Arduino Pin that will control Relay #6 (Valve Motor to Mixing)
  int RelayPin7 = 8; //This is the Arduino Pin that will control Relay #7 (VFD-Motor)
  int RelayPin8 = 9; //This is the Arduino Pin that will control Relay #8 (Immersion Heater)
  int RelayPin9 = 10; //This is the Arduino Pin that will control Relay #9 (Ultrasonic Transducers)
  int RelayPin10 = 11; //This is the Arduino Pin that will control Relay #10 (UV Light)
  int RelayPin11 = 12; //This is the Arduino Pin that will control Relay #11 (Ozone)


 int data;  
 void setup() {
  // put your setup code here, to run once:
  

  pinMode(RelayPin1, OUTPUT);
  pinMode(RelayPin2, OUTPUT);
  pinMode(RelayPin3, OUTPUT);
  pinMode(RelayPin4, OUTPUT);
  pinMode(RelayPin5, OUTPUT);
  pinMode(RelayPin6, OUTPUT);
  pinMode(RelayPin7, OUTPUT);
  pinMode(RelayPin8, OUTPUT);
  pinMode(RelayPin9, OUTPUT);
  pinMode(RelayPin10, OUTPUT);
  pinMode(RelayPin11, OUTPUT);

  Serial.begin(9600);
  

}

void loop(){    
  
  if(Serial.available()){    
     data = Serial.read();
     
     /*VFD On/Off for Motor */        
     if(data == 'A'){
      digitalWrite(RelayPin7, HIGH);
      
     }else if(data == 'a'){
      digitalWrite(RelayPin7, LOW);
     }


     /*Turning Immersion Heater On/Off  */
     if(data == 'M'){
      digitalWrite(RelayPin8, HIGH);
     } 
     else if(data == 'm'){
      digitalWrite(RelayPin8, LOW);
     }

     

     /*Turning Ultrasonic Transducers On/Off */
     if(data == 'B'){
      digitalWrite(RelayPin9, HIGH);
     } 
     else if(data == 'b'){
      digitalWrite(RelayPin9, LOW);
     }

     




     /*Turning UV Light On/Off */
     if(data == 'C'){
      digitalWrite(RelayPin10, HIGH);
     } 
     else if(data == 'c'){
      digitalWrite(RelayPin10, LOW);
     }



     /*Turning Ozone On/Off */
     if(data == 'D'){
      digitalWrite(RelayPin11, HIGH);
     } 
     else if(data == 'd'){
      digitalWrite(RelayPin11, LOW);
     }







     /* Opening/Closing Valve from Mixing to Motor */
     if(data == 'E'){
      digitalWrite(RelayPin1, HIGH);
     } 
     else if(data == 'e'){
      digitalWrite(RelayPin1, LOW);
     }



     /*Opening/Closing Valve from Motor to Cleaning  */ 
     if(data == 'F'){
      digitalWrite(RelayPin2, HIGH);
     } 
     else if(data == 'f'){
      digitalWrite(RelayPin2, LOW);
     }



     /*Opening/Closing Valve from Cleaning to Motor  */  
     if(data == 'G'){
      digitalWrite(RelayPin3, HIGH);
     } 
     else if(data == 'g'){
      digitalWrite(RelayPin3, LOW);
     }




     /*Opening/Closing Valve from Motor to Recovery  */ 
     if(data == 'H'){
      digitalWrite(RelayPin4, HIGH);
     } 
     else if(data == 'h'){
      digitalWrite(RelayPin4, LOW);
     }



      /*Opening/Closing Valve from Recovery to Motor */ 
     if(data == 'I'){
      digitalWrite(RelayPin5, HIGH);
     } 
     else if(data == 'i'){
      digitalWrite(RelayPin5, LOW);
     }



     /*Opening/Closing Valve from Motor to Mixing */ 
     if(data == 'J'){
      digitalWrite(RelayPin6, HIGH);
     } 
     else if(data == 'j'){
      digitalWrite(RelayPin6, LOW);
     }
     

  }
}  
