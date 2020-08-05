using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public enum PlayerDirection
{
    LEFT = 0,
    RIGHT = 1,
    UP = 2,
    DOWN = 3
}


public class HeadScript : MonoBehaviour
{


    public static float NodeSize = 1f;

    public Vector3 PositionForNextPart;

    public float TimeBetwwenMoves = 0.8f;

    private float TimePassed = 0;

    private PlayerDirection Direction = PlayerDirection.RIGHT;

    public BodyScript BodySegment;

    public AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorDir = Input.GetAxisRaw("Horizontal");
        float VerDir = Input.GetAxisRaw("Vertical");

        if(HorDir == 1 && (Direction != PlayerDirection.RIGHT && Direction != PlayerDirection.LEFT))
        {
            Direction = PlayerDirection.RIGHT;
        }
        else if(HorDir == -1 && (Direction != PlayerDirection.RIGHT && Direction != PlayerDirection.LEFT))
        {
            Direction = PlayerDirection.LEFT;
        }
        
        if(VerDir == 1 && (Direction != PlayerDirection.UP && Direction != PlayerDirection.DOWN))
        {
            Direction = PlayerDirection.UP;
        }
        else if(VerDir == -1 && (Direction != PlayerDirection.UP && Direction != PlayerDirection.DOWN))
        {
            Direction = PlayerDirection.DOWN;
        }


        TimePassed += Time.deltaTime;
        if(ShouldMove)
        {
            TimePassed = 0;
            Vector3 Old = transform.position;
           Move();
            BodySegment.SignalToMove(Old);
        }
    }

    private void Move()
    {
        Vector3 NewPosition = new Vector3(0f, 0f, 0f);

        switch(Direction)
        {
            case PlayerDirection.DOWN:
                NewPosition.z -= 1;
                break;
            case PlayerDirection.UP:
                NewPosition.z += 1;
                break;
            case PlayerDirection.LEFT:
                NewPosition.x -= 1;
                break;
            case PlayerDirection.RIGHT:
                NewPosition.x += 1;
                break;

        }
        transform.position += NewPosition;
        
    }

    bool ShouldMove
    {
        get
        {
            return TimePassed >= TimeBetwwenMoves;
        }
    }

    
    public void EatApple()
    {
        source.Play();
        BodySegment.SignalToExtend();
    }
}
