#pragma strict

private var initiatePosition : Vector3 ;
private var startShaking : float ;
private var ShakeForce: float ;
private var ShakeTime: float ;
private var ShakeItUp: boolean ;
private var MaxShakesForce: float ;

function Start () {
	initiatePosition = transform.position;
	ShakeItUp = false;
	startShaking = 0;
	ShakeForce = 0 ;
	ShakeTime = 0 ;
	MaxShakesForce = 30;
}

function Update () {
	if (ShakeItUp) {
		if(Time.time-startShaking>ShakeTime){
			ShakeItUp = false;
			transform.position = initiatePosition;
		}else{

			var randomPose = new Vector3(
				initiatePosition.x+Random.Range(-ShakeForce, ShakeForce), 
				initiatePosition.y+Random.Range(-ShakeForce, ShakeForce), 
				initiatePosition.z
			); //Random.Range(1, 3)
			
			transform.position = randomPose;
		}
	};
}

function ShakeIt(force:int, howlong){
	ShakeItUp = true;
	startShaking = Time.time;
	ShakeForce = force/2;
	ShakeForce = (ShakeForce > MaxShakesForce) ? MaxShakesForce : ShakeForce;
	ShakeTime = howlong;
}