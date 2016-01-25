#pragma strict

var grenades : int = 50;

var healthbase : int = 100;
var healthmax : int = 100;

function ApplyDammage (TheDammage : int)
{
    healthbase -= TheDammage;
    
    if(healthbase <= 0){
     Dead();
    }
}

function Dead (){
Debug.Log("Player died");
}