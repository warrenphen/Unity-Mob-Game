using UnityEngine;
using System.Collections;

public class changeForm : MonoBehaviour
{
	public Sprite spriteNormal;
	public Sprite spriteTouched;
	
	SpriteRenderer sr;
	
	void Start ()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		if (Input.GetMouseButton(0))
		{
			sr.sprite = spriteTouched;
		}
		else
		{
			sr.sprite = spriteNormal;
		}
	}
}