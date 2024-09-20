#include "DEV_Config.h"
#include <HCSR04.h>
#include <Keyboard.h>

const int trigPin1 = 0;
const int echoPin1 = 1;
const int trigPin2 = 3;
const int echoPin2 = 4;

float duration1, distance1, duration2, distance2, duration1Repeat, distance1Repeat, distance2Repeat, duration2Repeat;

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
  if (distance1 > 5 && distance1 < 100) {
    delay(5);
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    duration1Repeat = pulseIn(echoPin1, HIGH);
    distance1Repeat = (duration1Repeat*.0343)/2;
    Serial.print("DistanceRepeat: ");
    Serial.println(distance1Repeat);
    if (distance1Repeat > distance1) {
      if (distance1Repeat > (distance1 + 1)) {
        Keyboard.press(KEY_UP_ARROW);
        delay(10);
        Keyboard.release(KEY_UP_ARROW);
      }
      else {
        Keyboard.press(KEY_UP_ARROW);
        delay(5);
        Keyboard.release(KEY_UP_ARROW);
        delay(10);
      }
    }
    else if (distance1 > distance1Repeat) {
      if(distance1 > (distance1Repeat + 1)) {
        Keyboard.press(KEY_DOWN_ARROW);
        delay(10);
        Keyboard.release(KEY_DOWN_ARROW);
      }
      else {
        Keyboard.press(KEY_DOWN_ARROW);
        delay(5);
        Keyboard.release(KEY_DOWN_ARROW);
        delay(10);
      }
    }
    else {
      delay(10);
    }
  }

  else if (distance1 <= 5) {
    Keyboard.press(KEY_DOWN_ARROW);
    delay(10);
    Keyboard.release(KEY_DOWN_ARROW);
  }

  else{
    Keyboard.press(KEY_UP_ARROW);
    delay(10);
    Keyboard.release(KEY_UP_ARROW);
  }

  if (distance2 > 5 && distance2 < 100) {
    delay(5);
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin2, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin2, LOW);
    duration2Repeat = pulseIn(echoPin2, HIGH);
    distance2Repeat = (duration2Repeat*.0343)/2;
    Serial.print("DistanceRepeat: ");
    Serial.println(distance2Repeat);
    if (distance2Repeat > distance2) {
      if (distance2Repeat > (distance2 + 1)) {
        Keyboard.press(KEY_LEFT_ARROW);
        delay(10);
        Keyboard.release(KEY_LEFT_ARROW);
      }
      else {
        Keyboard.press(KEY_LEFT_ARROW);
        delay(5);
        Keyboard.release(KEY_LEFT_ARROW);
        delay(10);
      }
    }
    else if (distance2 > distance2Repeat) {
      if(distance2 > (distance2Repeat + 1)) {
        Keyboard.press(KEY_RIGHT_ARROW);
        delay(10);
        Keyboard.release(KEY_RIGHT_ARROW);
      }
      else {
        Keyboard.press(KEY_RIGHT_ARROW);
        delay(5);
        Keyboard.release(KEY_RIGHT_ARROW);
        delay(10);
      }
    }
    else {
      delay(10);
    }
  }

  else if (distance2 <= 5) {
    Keyboard.press(KEY_RIGHT_ARROW);
    delay(10);
    Keyboard.release(KEY_RIGHT_ARROW);
  }

  else{
    Keyboard.press(KEY_LEFT_ARROW);
    delay(10);
    Keyboard.release(KEY_LEFT_ARROW);
  }

  
  // Add a short delay before the next loop iteration
  delay(1);
}

