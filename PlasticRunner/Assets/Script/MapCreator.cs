using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour {

	public static float BLOCK_WIDTH = 1.0f;
	public static float BlOCK_HEIGHT = 0.2f;
	public static int BLOCK_NUM_IN_SCREEN = 24;

	private struct FloorBlock
	{
		public bool is_created;
		public Vector3 position;
	};

	private FloorBlock last_block;
	private PlayerControl player = null;

    public GameObject[] BlockPrefab;
    private int block_count = 0;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		this.last_block.is_created = false;
	}
	
	// Update is called once per frame
	void Update () {
		float block_generate_x = player.transform.position.x;
		block_generate_x += BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN + 1) * 0.5f;

        while (last_block.position.x < block_generate_x)
            Create_Floor_Block();
	}

	private void Create_Floor_Block()
	{
		Vector3 block_position;
		if(!last_block.is_created)
		{
			block_position = player.transform.position;

			block_position.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN * 0.5f);
			block_position.y = 0f;
		}

		else
		{
			block_position = last_block.position;
		}

		block_position.x += BLOCK_WIDTH;

		CreateBlock(block_position);

		last_block.position = block_position;
		last_block.is_created = true;
	}

    public void CreateBlock(Vector3 block_Position)
    {
        int next_block_type = this.block_count % BlockPrefab.Length;

        GameObject go = GameObject.Instantiate(this.BlockPrefab[next_block_type]) as GameObject;
        go.transform.position = block_Position;
        this.block_count++;
    }
}
