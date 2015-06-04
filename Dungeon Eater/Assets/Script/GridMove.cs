using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour
{
	public float moveSpeed = 2f;
	private float gridSize = 1f;
	private enum Orientation
	{
		Horizontal,
		Vertical
	};
	private Orientation gridOrientation = Orientation.Horizontal;
	private bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
	Quaternion rotation;

	Animator animator;
	void Start()
	{
		animator = GetComponent<Animator>();
	}



	public void Update()
	{
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        transform.forward = forward * 0.1f;
		Debug.Log("transform.forward : " + transform.forward);
		Debug.DrawRay(transform.position, forward, Color.green);


		if (!isMoving)
		{
			input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if (!allowDiagonals)
			{
				if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
				{
					input.y = 0;
				}
				else
				{
					input.x = 0;
				}
			}

			if (input != Vector2.zero)
			{
				StartCoroutine(move(transform));
			}
		}

		
	}

	public IEnumerator move(Transform transform)
	{
		isMoving = true;

		animator.SetTrigger("Move");


		startPosition = transform.position;
		Debug.Log(transform.forward);
		Debug.Log(Vector3.forward);

		t = 0;

		if (gridOrientation == Orientation.Horizontal)
		{
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		}
		else
		{
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
				startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}

		if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
		{
			factor = 0.7071f;
		}
		else
		{
			factor = 1f;
		}

		while (t < 1f)
		{
			t += Time.deltaTime * (moveSpeed / gridSize) * factor;


			Vector3 dir = endPosition - startPosition;
			dir.y = 0.0f;
			dir.Normalize();
			transform.rotation = Quaternion.Lerp(transform.rotation,
																  Quaternion.LookRotation(dir),
																  10.0f * Time.deltaTime);
			transform.position = Vector3.Lerp(startPosition, endPosition, t);


			transform.forward = transform.TransformDirection(Vector3.forward);

			yield return null;
		}

		isMoving = false;
		yield return 0;
	}
}