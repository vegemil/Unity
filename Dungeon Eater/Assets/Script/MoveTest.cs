using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

	public float speed = 1.0F;
	public float grid = 1.0f;
	public float rotationSpeed = 100.0F;

	[SerializeField]
	 Direction direction = Direction.NONE;

	Vector3 startPosition;
	Vector3 endPosition = Vector3.zero;
	Vector3 dir = Vector3.zero;

	Hashtable hash = new Hashtable();

	enum Direction
	{
		LEFT,
		RIGHT,
		FORWARD,
		BACK,
		NONE
	};

	Animator animator;

   public bool isColliderHit = false;
   public Transform beforeTransform;

	void Start()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.DownArrow))
			direction = Direction.BACK;
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			direction = Direction.LEFT;
		else if (Input.GetKeyDown(KeyCode.RightArrow))
			direction = Direction.RIGHT;
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			direction = Direction.FORWARD;

		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Walking@loop")&& isColliderHit != true)
			Move();
	}

	void Move()
	{
		startPosition = transform.position;
		

		switch(direction)
		{
			case Direction.LEFT:
				hash.Clear();
				endPosition = startPosition + transform.right * grid * -1;

				dir = endPosition - startPosition;
				dir.y = 0.0f;
				dir.Normalize();

				transform.rotation = Quaternion.Lerp(transform.rotation,
																	 Quaternion.LookRotation(dir),
																	  rotationSpeed);


				hash.Clear();
				hash.Add("position", endPosition);
				hash.Add("speed", speed);
				hash.Add("easetype", iTween.EaseType.linear);
				iTween.MoveTo(gameObject, hash);

				animator.SetTrigger("Move");

				break;
			case Direction.RIGHT:

				hash.Clear();
				endPosition = startPosition + transform.right * grid;

				dir = endPosition - startPosition;
				dir.y = 0.0f;
				dir.Normalize();
				transform.rotation = Quaternion.Lerp(transform.rotation,
																	 Quaternion.LookRotation(dir),
																	  rotationSpeed);

				hash.Add("position", endPosition);
				hash.Add("speed", speed);
				hash.Add("easetype", iTween.EaseType.linear);
				iTween.MoveTo(gameObject, hash);

				animator.SetTrigger("Move");
				break;
			case Direction.FORWARD:

				hash.Clear();

				endPosition = startPosition + transform.forward * grid;

				hash.Add("position", endPosition);
				hash.Add("speed", speed);
				hash.Add("easetype", iTween.EaseType.linear);
				iTween.MoveTo(gameObject, hash);

				animator.SetTrigger("Move");
				break;

			case Direction.BACK:

				hash.Clear();
				endPosition = startPosition + transform.forward * grid * -1;

				dir = endPosition - startPosition;
				dir.y = 0.0f;
				dir.Normalize();
				transform.rotation = Quaternion.Lerp(transform.rotation,
																	 Quaternion.LookRotation(dir),
																	  rotationSpeed);

				hash.Add("position", endPosition);
				hash.Add("speed", speed);
				hash.Add("easetype", iTween.EaseType.linear);
				iTween.MoveTo(gameObject, hash);

				animator.SetTrigger("Move");
				break;
		}

		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		transform.rotation = new Quaternion(Mathf.Round(transform.rotation.x), Mathf.Round(transform.rotation.y), Mathf.Round(transform.rotation.z), Mathf.Round(transform.rotation.w));

		direction = Direction.NONE;
		
	}
}
