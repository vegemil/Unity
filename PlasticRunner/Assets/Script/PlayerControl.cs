using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public static float ACCELERATION = 10f;
    public static float SPEED_MIN = 4.0f;
    public static float SPEED_MAX = 8.0f;
    public static float JUMP_HEIGHT_MAX = 3.0f;
    public static float JUMP_KEY_RELEASE_REDUCE = 0.5f;

    public enum STEP
    {
        NONE = -1,
        RUN = 0,
        JUMP,
        MISS,
        NUM
    }

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;

    public float step_timer = 0.0f;
    private bool is_landed = false;
    private bool is_colided = false;
    private bool is_key_released = false;
    private Rigidbody rigidbody;
    Vector3 velocity;

	// Use this for initialization
	void Start () {
        next_step = STEP.RUN;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        velocity = rigidbody.velocity;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime));

        Check_Landed();
        step_timer += Time.deltaTime;

        if(next_step == STEP.NONE)
        {
            switch(step)
            {
                case STEP.RUN:
                    if(is_landed == true)
                    {

                    }
                    else
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            next_step = STEP.JUMP;
                        }
                    }
                    break;

                case STEP.JUMP:
                    if (is_landed == true)
                        next_step = STEP.RUN;
                    break;
            }
        }

        while(next_step != STEP.NONE)
        {
            step = next_step;
            next_step = STEP.NONE;

            switch(step)
            {
                case STEP.JUMP:
                    velocity = new Vector3(0, Mathf.Sqrt(2.0f * 9.8f * JUMP_HEIGHT_MAX), 0);
                    rigidbody.velocity = velocity;
                    is_key_released = false;
                    
                    break;
            }
            step_timer = 0;
        }

        switch(step)
        {
            case STEP.RUN:
                velocity.x += ACCELERATION * Time.deltaTime;

                if(Mathf.Abs(velocity.x ) > SPEED_MAX)
                {
                    velocity.x *= SPEED_MAX / Mathf.Abs(rigidbody.velocity.x);
                }

                rigidbody.velocity = velocity;

                break;

            case STEP.JUMP:
                do
                {
                    if(Input.GetMouseButtonDown(0) == false)
                        break;

                    if (is_key_released == true)
                        break;

                    if (velocity.y <= 0)
                        break;

                    velocity.y *= JUMP_KEY_RELEASE_REDUCE;

                    is_key_released = true;


                }while(false);
                break;
        }

        rigidbody.velocity = velocity;

	}

    void Check_Landed()
    {
        is_landed = false;

        do
        {
            Vector3 player_Position = transform.position;
            Vector3 player_under1f = player_Position + Vector3.down * 1.0f;
            RaycastHit hit;

            if (!Physics.Linecast(player_Position, player_under1f, out hit))
                break;

            if (step == STEP.JUMP)
            {
                if (step_timer < Time.deltaTime * 3.0f)
                    break;
            }

            is_landed = true;

        } while (false);
    }
}
