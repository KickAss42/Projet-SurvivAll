#pragma strict

var Distance :float ;
var Target : Transform; 
var lookAtDistance :float = 20;
var chaseRange :float = 10;
var attackRange :float = 2.2;
var moveSpeed :float = 3;
var Damping :float =6;
var attackRepeatTime :float = 1;

var TheDammage :float = 10;

private var attackTime : float;

var controller : CharacterController;
var gravity : float = 20;

private var moveDirection : Vector3 = Vector3.zero;

function Start () {
    attackTime = Time.time;
    Findhealth ();
}

function Update () {
    Distance = Vector3.Distance(Target.position , transform.position);

    if (Distance< lookAtDistance){
        lookAt();
    }
    if (Distance < attackRange){
        attack();
    }
    else if(Distance < chaseRange) {
        chase();
    }

}
function lookAt(){
    var rotation = Quaternion.LookRotation(Target.position - transform.position );
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime * Damping);
        
}

function chase (){
    GetComponent.<Animator>().Play("walk");

    moveDirection = transform.forward;
    moveDirection *= moveSpeed;

    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection*Time.deltaTime);

}
function attack (){
    if(Time.time > attackTime){
        GetComponent.<Animator>().Play("attack");

       	Target.SendMessage("ApplyDammage", TheDammage);
        Debug.Log("The enemy has attacked ");
        attackTime = Time.time + attackRepeatTime;
    }

}

function ApplyDammage(){
    chaseRange += 30;
    moveSpeed+= 2;
    lookAtDistance +=40;
}

function Findhealth()
{
    Target = GameObject.FindGameObjectWithTag ("Player").transform;
}