using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {
	Rigidbody2D wallerigid;
	public float moveTime = .1f;	
	private float inverseMoveTime;	


	// Use this for initialization
	void Start () {
		wallerigid = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 2.1f;

	
	}
	
	// Update is called once per frame
	void Update () {
		int horizontal = 0,vertical =0;
		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));
		if(horizontal != 0)
		{
			vertical = 0;
		}

		if (horizontal != 0 || vertical != 0) {
			move (horizontal, vertical);
		}
		if (Input.GetAxis ("Horizontal") < -0.1f)
			transform.localScale = new Vector3 (-1, 1, 1);
		if (Input.GetAxis ("Horizontal")  > 0.1f)
			transform.localScale = new Vector3 ( 1, 1, 1);

	
	}
	void move(int xdir,int ydir)
	{
		Vector2 start = transform.position;

	//xdir = xdir > 0 ? xdir + 100 : xdir - 100;
		Vector2 end = start + new Vector2 (xdir, ydir);

		StartCoroutine (SmoothMovement (end));


	}	
	protected IEnumerator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
	////	while(sqrRemainingDistance > float.Epsilon)
	//	{
			Vector3 newPostion = Vector3.MoveTowards(wallerigid.position, end, inverseMoveTime * Time.deltaTime);
			
			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			wallerigid.MovePosition (newPostion);
			
			//Recalculate the remaining distance after moving.
			//sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			
			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		//}
	}
}
