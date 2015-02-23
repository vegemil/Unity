using UnityEngine;
using System.Collections;

public enum MoleState
{
    NONE,
    OPEN,
    IDLE,
    CLOSE,
    CATCH
};

public class Hole : MonoBehaviour
{

    public MoleState MState;

    public Texture[] Open_Images;
    public Texture[] Idle_Images;
    public Texture[] Close_Images;
    public Texture[] Catch_Images;

    public float Ani_Speed;
    public float _now_ani_time;

    int Ani_Count;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_now_ani_time >= Ani_Speed)
        {
            if (MState == MoleState.OPEN)
            {
                Open_Ing();
            }

            if (MState == MoleState.IDLE)
            {
                Idle_Ing();
            }
            if (MState == MoleState.CATCH)
            {
                Catch_Ing();
            }
            if (MState == MoleState.CLOSE)
            {
                Close_Ing();
            }
            _now_ani_time = 0;
        }

        else
        {
            _now_ani_time += Time.deltaTime;
        }
    }

    public void Open_On()
    {
        MState = MoleState.OPEN;
        Ani_Count = 0;
    }

    public void Open_Ing()
    {
        renderer.material.mainTexture = Open_Images[Ani_Count];
        Ani_Count += 1;

        //Open 애니메이션이 끝나는 순간
        if (Ani_Count >= Open_Images.Length)
        {
            Idle_On();
        }
    }

    public void Idle_On()
    {
        MState = MoleState.IDLE;
        Ani_Count = 0;
    }

    public void Idle_Ing()
    {
        renderer.material.mainTexture = Idle_Images[Ani_Count];
        Ani_Count += 1;

        //Idle 애니메이션이 끝나는 순간
        if (Ani_Count >= Idle_Images.Length)
        {
            Close_On();
        }
    }

    public void Close_On()
    {
        MState = MoleState.CLOSE;
        Ani_Count = 0;
    }

    public void Close_Ing()
    {
        renderer.material.mainTexture = Close_Images[Ani_Count];
        Ani_Count += 1;

        //Close 애니메이션이 끝나는 순간
        if (Ani_Count >= Close_Images.Length)
        {
            StartCoroutine("Wait");
        }
    }
    public void Catch_On()
    {
        MState = MoleState.CATCH;
        Ani_Count = 0;
    }

    public void Catch_Ing()
    {
        renderer.material.mainTexture = Catch_Images[Ani_Count];
        Ani_Count += 1;

        //Catch 애니메이션이 끝나는 순간
        if (Ani_Count >= Catch_Images.Length)
        {

            StartCoroutine("Wait");

        }
    }


    public IEnumerator Wait()
    {
        MState = MoleState.NONE;
        Ani_Count = 0;

        float wait_Time = Random.Range(0.5f, 4.5f);
        yield return new WaitForSeconds(wait_Time);
        Open_On();
    }
}
