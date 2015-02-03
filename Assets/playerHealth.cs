using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public float Health= 100f;
	private SpriteRenderer healthbar;
	private Vector3 healthscale;
	public Sprite spriteNormal;
	public Sprite spriteTouched;
	private int playerScore;
	public GUIText scoreText;


	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		healthbar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer> ();
		healthscale = healthbar.transform.localScale;
		Time.timeScale = 1;
		playerScore = 0;
		updateScore ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Health = 0;
			Time.timeScale = 0;
			}

	
	if (Health > 100) {
		Health = 100;

		}
		
	HealthUpdate ();
	
}


	void HealthUpdate (){
		healthbar.transform.localScale = new Vector3 (healthscale.x * Health * 0.01f, 1, 1);

		if (Input.GetMouseButton(0))
		{
			sr.sprite = spriteTouched;
			Health -= 25 * Time.deltaTime;

				if(Health <=0){
				sr.sprite = spriteNormal;
				}
		}
		else
		{
			sr.sprite = spriteNormal;
			 
		}

}

	void updateScore(){
			scoreText.text = "" + playerScore;
		}

	void OnCollisionEnter(Collision collision) {
		if (sr.sprite == spriteNormal){
			audio.Play();
			Health = 0;
		} 

		if (sr.sprite == spriteTouched){
			playerScore += 1;
		} 
		if(Input.GetMouseButton(0) && collision.gameObject.tag == "Bomb") {
			Health = 100; //increase health
			} 
	 
		
	}

	void OnGUI() {
		
		if(Health == 0){
			
			GUI.Box(new Rect(100,100,80,80), "Score: " + playerScore);
			
			if(GUI.Button(new Rect(205,100,80,80),"Restart")){
				
				Application.LoadLevel(0);

			} 
		} 

	}

}


	