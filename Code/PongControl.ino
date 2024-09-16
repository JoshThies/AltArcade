#include "DEV_Config.h"
#include <HCSR04.h>
#include <Keyboard.h>

const int trigPin1 = 0;
const int echoPin1 = 1;
const int trigPin2 = 3;
const int echoPin2 = 4;

float duration1, distance1, duration2, distance2, durationRepeat, distanceRepeat;

void setup() {                              
  pinMode(trigPin1, OUTPUT);
  pinMode(echoPin1, INPUT);
  pinMode(trigPin2, OUTPUT);
  pinMode(echoPin2, INPUT);
  Serial.begin(9600);
  Keyboard.begin(); // Initialize Keyboard library
}

void loop() {
  digitalWrite(trigPin1, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin1, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin1, LOW);
  duration1 = pulseIn(echoPin1, HIGH);
  distance1 = (duration1*.0343)/2;
  Serial.print("Distance1: ");
  Serial.println(distance1);

  digitalWrite(trigPin2, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin2, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin2, LOW);
  duration2 = pulseIn(echoPin2, HIGH);
  distance2 = (duration2*.0343)/2;
  //Serial.print("Distance2: ");
  //Serial.println(distance2);

  // Control up and down arrow keys based on the first sensor
  if (distance1 > 0 && distance1 < 100) {
    delay(5);
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    durationRepeat = pulseIn(echoPin1, HIGH);
    distanceRepeat = (durationRepeat*.0343)/2;
    Serial.print("DistanceRepeat: ");
    Serial.println(distanceRepeat);
    if (distanceRepeat > distance1) {
      if (distanceRepeat > (distance1 + 1)) {
        Keyboard.press(KEY_UP_ARROW);
        colorChanger();
        Keyboard.release(KEY_UP_ARROW);
      }
      else {
        Keyboard.press(KEY_UP_ARROW);
        delay(5);
        Keyboard.release(KEY_UP_ARROW);
        colorChanger();
      }
    }
    else if (distance1 > distanceRepeat) {
      if(distance1 > (distanceRepeat + 1)) {
        Keyboard.press(KEY_DOWN_ARROW);
        colorChanger();
        Keyboard.release(KEY_DOWN_ARROW);
      }
      else {
        Keyboard.press(KEY_DOWN_ARROW);
        delay(5);
        Keyboard.release(KEY_DOWN_ARROW);
        colorChanger();
      }
    }
    else {
      colorChanger();
    }
  }

  else{
    colorChanger();
  }
  // Add a short delay before the next loop iteration
  delay(1);
}

void colorChanger() {
  if (distance2 > 0 && distance2 < 10) {
      Keyboard.press('1');
      delay(10);
      Keyboard.release('1');
    }
    else if (distance2 > 10 && distance2 < 15) {
      Keyboard.press('2');
      delay(10);
      Keyboard.release('2');
    }
    else if (distance2 > 15 && distance2 < 20) {
      Keyboard.press('3');
      delay(10);
      Keyboard.release('3');
    }
    else if (distance2 > 20 && distance2 < 25) {
      Keyboard.press('4');
      delay(10);
      Keyboard.release('4');
    }
    else if (distance2 > 25 && distance2 < 30) {
      Keyboard.press('5');
      delay(10);
      Keyboard.release('5');
    }
    else if (distance2 > 30 && distance2 < 100) {
      Keyboard.press('6');
      delay(10);
      Keyboard.release('6');
    }
    else{
      delay(10);
    }
}

