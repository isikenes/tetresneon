using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float previusTime;
    private float fallTime = 0.6f;
    public static int height = 20;
    public static int width = 10;
    public Vector3 rotationPoint;
    private static Transform[,] grid = new Transform[width, height];
    
    /*
    private Vector2 startTouchPos;
    private Vector2 currentPos;
    private Vector2 endTouchPos;
    private bool stopTouch = false;
    private float swipeRange = 50f;*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MOBILE CODES

        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPos = Input.GetTouch(0).position;
            Vector2 distance = currentPos - startTouchPos;

            if (!stopTouch)
            {
                if (distance.x < -swipeRange)
                {
                    Debug.Log("left");

                    transform.position += new Vector3(-1, 0, 0);
                    if (!isValidMove())
                    {

                        transform.position -= new Vector3(-1, 0, 0);

                    }
                    FindObjectOfType<PlayAudio>().PlayMoveAudio();
                    stopTouch = true;
                }
                else if (distance.x > swipeRange)
                {
                    Debug.Log("right");
                    transform.position += new Vector3(1, 0, 0);
                    if (!isValidMove())
                    {

                        transform.position -= new Vector3(1, 0, 0);

                    }
                    FindObjectOfType<PlayAudio>().PlayMoveAudio();
                    stopTouch = true;
                }
                else if (distance.y > swipeRange)
                {
                    Debug.Log("up");

                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                    if (!isValidMove())
                    {
                        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);

                    }
                    FindObjectOfType<PlayAudio>().PlayRotateAudio();
                    stopTouch = true;
                }
                else if (distance.y < -swipeRange)
                {
                    Debug.Log("down");
                    fallTime = 0.05f;
                    stopTouch = true;
                }
                
            }
        }

        if (Time.time - previusTime > fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!isValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;

                FindObjectOfType<Spawner>().NewTetrominoe(FindObjectOfType<SmallSpawner>().x);
                FindObjectOfType<SmallSpawner>().NewTetrominoe();
            }
            previusTime = Time.time;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPos = Input.GetTouch(0).position;

        }*/

        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!isValidMove())
            {
                
                transform.position -= new Vector3(-1, 0, 0);
                
            }
            FindObjectOfType<PlayAudio>().PlayMoveAudio();

        } 
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!isValidMove())
            {
                
                transform.position -= new Vector3(1, 0, 0);
                
            }
            FindObjectOfType<PlayAudio>().PlayMoveAudio();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint),new Vector3(0,0,1), 90);
            if(!isValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
                
            }
            FindObjectOfType<PlayAudio>().PlayRotateAudio();
        }

        if (Time.time - previusTime > ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!isValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                
                if(grid[4,17]==null)
                {
                    FindObjectOfType<Spawner>().NewTetrominoe(FindObjectOfType<SmallSpawner>().x);
                    FindObjectOfType<SmallSpawner>().NewTetrominoe();
                }
                else
                {

                    StartCoroutine("GameOver");

                }
                

            }
            previusTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<SceneControl>().ActivatePause();
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<SceneControl>().ActivateGOS();
    }

    void CheckForLines()
    {
        for(int i=height-1;i>=0;i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j=0;j<width;j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        FindObjectOfType<PlayAudio>().PlayLineAudio();
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            FindObjectOfType<IncreaseScore>().IncraseScore();
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for(int y=i; y<height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j,y]!=null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
            
        }
    }

    void AddToGrid()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool isValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX>=width || roundedY < 0 || roundedY >= height) {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
