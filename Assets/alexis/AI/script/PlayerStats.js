#pragma strict

var timebeforehealth : float = 0;
var healthbase : int = 100;
var healthmax : int = 100;
var bloodUI : GameObject;

InvokeRepeating("Regen",0,1);
InvokeRepeating("reduceTimer",0,1);

function ApplyDammage (TheDammage : int)
{
    healthbase -= TheDammage;
    timebeforehealth += 5;
    
    if(healthbase <= 0){
     Dead();
    }
}

function Dead ()
{
//Debug.Log("Player died");
Application.LoadLevel("map 2");
}

function Update(){
if (healthbase >= 1 && healthbase <30){
bloodUI.GetComponent(CanvasGroup).alpha = 1;
}
if (healthbase >= 30 && healthbase <60){
bloodUI.GetComponent(CanvasGroup).alpha = 0.6;
}
if (healthbase >= 60 && healthbase <80){
bloodUI.GetComponent(CanvasGroup).alpha = 0.3;
}
if (healthbase >= 80 && healthbase <=100){
bloodUI.GetComponent(CanvasGroup).alpha = 0;
}
if(healthbase > 100) {
healthbase = 100;
}

if(timebeforehealth >= 5) {
timebeforehealth = 5;
}

if(timebeforehealth <= 0) {
timebeforehealth = 0;
}
}

function reduceTimer(){
timebeforehealth -= 1;
}

function Regen(){
if(timebeforehealth == 0){
healthbase +=5;
}
}