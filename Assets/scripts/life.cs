using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {
	Rigidbody2D wallerigid;
	Animator anim;
	public float moveTime = .1f;	
	public float inverseMoveTime;	
	public float speed =0f;



	// Use this for initialization
	void Start () {
		wallerigid = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1.1f;
		anim = GetComponent<Animator> ();


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int horizontal = 0;
		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		if (horizontal != 0)
			move (horizontal);
		else
			speed = 0;	

		if (Input.GetAxis ("Horizontal") < -0.1f)
			transform.localScale = new Vector3 (-1, 1, 1);
		if (Input.GetAxis ("Horizontal") > 0.1f)
			transform.localScale = new Vector3 (1, 1, 1);

		anim.SetFloat ("speed", speed);	
	
		}

	void move(int xdir)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xdir, 0);
		Vector3 newPostion = Vector3.MoveTowards(wallerigid.position, end, ((float)speed+inverseMoveTime) * Time.deltaTime);

		if (speed < 3)
			speed += .1f;
		wallerigid.MovePosition (newPostion);
	



	}	

}
