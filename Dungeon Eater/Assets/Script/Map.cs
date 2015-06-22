using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public TextAsset map_textAsset;
	string[] maptext;

	int width;
	int height;

	char[,] mapdata;

	public GameObject jewel;
	public GameObject block;
	public GameObject player;
	public GameObject ghost;
	public GameObject sword;
	public GameObject empty;
	GameObject Planes;
	GameObject Jewels;
	GameObject Blocks;


	enum MAPFORMAT
	{
		JEWEL,
		BLOCK,
		PLAYER,
		GHOST,
		SWORD,
		EMPTY
	};

	// Use this for initialization
	void Start () {
		Planes = new GameObject();
		Planes.transform.position = new Vector3(0, 0, 0);
		Planes.transform.name = "Planes";

		Jewels = new GameObject();
        Jewels.transform.position = new Vector3(0, 0.224f, 0);
		Jewels.transform.name = "Jewels";

		Blocks = new GameObject();
		Blocks.transform.position = new Vector3(0, 0, 0);
		Blocks.transform.name = "Blocks";

		System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;

		maptext = map_textAsset.text.Split(new char[] {'\r', '\n'}, option);

		char[] spliter = new char[1] { ',' };

		string[] sizewh = maptext[0].Split(spliter, option);
		width = int.Parse(sizewh[0]);
		height = int.Parse(sizewh[1]);

		mapdata = new char[height, width];

		for (int i = 0; i<height; ++i)
		{
			string[] data = maptext[height - i].Split(spliter, option);

			for(int j = 0; j<width; ++j)
			{
				mapdata[i, j] = data[j][0];
			}
		}

		CreateMap();

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateMap()
	{
		for (int x = 0; x < width; ++x)
		{
			for (int z = 0; z < height; ++z)
			{
				GameObject obj = Instantiate(SwapData(mapdata[z, x]), new Vector3(x, 0, z), Quaternion.identity) as GameObject;

				if (obj.transform.name.Contains("Jewel"))
					obj.transform.parent = Jewels.gameObject.transform;
				else if (obj.transform.name.Contains("Cube"))
					obj.transform.parent = Blocks.gameObject.transform;


				GameObject plane = Instantiate(empty, new Vector3(x, 0, z), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
				plane.transform.parent = Planes.gameObject.transform;
			}
		}
	}

	GameObject SwapData(char data)
	{
		switch(data)
		{
			case 'c':
			case 't':
				return jewel;
			case '*':
				return block;
			case 'p':
				return player;
			case 's':
				return sword;
			case '1':
			case '2':
			case '3':
			case '4':
				return ghost;
			case 'x':
				return empty;
		}
		return null;
	}
}
