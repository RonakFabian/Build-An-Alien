using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool isMoving;

    [HeaderAttribute(" -----------------Attributes------------------")]
    public float Damage;

    public float Health;
    public float Speed = 2f;
    public float TouchSpeed = 1.25f;
    public bool isRanged = false;

    [HeaderAttribute(" ----------------References-------------------")]
    public List<GameObject> wayPoints = new List<GameObject>();
    public List<GameObject> playerPawns = new List<GameObject>();

    public GameObject CamOne;
    public GameObject CamTwo;
    public Transform pawnSpawnPoint;
    public float rowDistance = 1;
    public float columnDistance = 1;
    public int playerCount = 1;
    public int maximumPlayerCount = 20;
    public float MaxTurnSpeed = 0.2f;

    public GameObject meleeRagdoll;
    public GameObject rangedRagdoll;
    public SaveData bodySaveData;


    private MeshSpawner meshSpawner;
    private UnityEvent onArenaReached;
    private GameObject currentTarget;
    private Vector3 targetPos;
    private float horizontalAxis;
    private float verticalPos;
    private float magnitude;
    private float camPos;
    private float MaxTurnSpeedREF;
    private int currentIndex;

    private bool isTouching = false;
    bool canRestCam = false;
    private bool canMove = true;

    int x = 0;
    int y = 0;
    Vector3 pos;
    private Vector2 touchPos;
    private Vector2 distance = Vector2.zero;
    private Rigidbody rb;
    private Vector2 touchDeltaPosition;
    public CinemachineVirtualCamera inGameCam;


    void Start()
    {
        currentIndex = 0;
        currentTarget = wayPoints[currentIndex];
        verticalPos = transform.position.y;
        meshSpawner = GetComponent<MeshSpawner>();
        rb = GetComponent<Rigidbody>();
        inGameCam = GameObject.Find("CM_InGame").GetComponent< CinemachineVirtualCamera>();

    }

    void Update()
    {
        if (isMoving)
        {
            MovePlayer();
          //  MovePawns();
        }
      
    }

    private void MovePlayer()
    {
        if (canMove) horizontalAxis = Input.GetAxis("Horizontal");

        if (currentIndex < wayPoints.Count)
        {
            targetPos = wayPoints[currentIndex].transform.position - transform.position;
            targetPos.y = 0;

            if (Mathf.Abs(targetPos.magnitude) <= 1.5f)
            {
                currentIndex++;
            }

            if (Input.touchCount > 0 &&
                Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                // Get movement of the finger since last frame
                touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            }
            targetPos += Vector3.forward * (horizontalAxis);
            transform.Translate(-Speed*Time.deltaTime, 0, touchDeltaPosition.x *Time.deltaTime/TouchSpeed);
            transform.Translate(-Speed * Time.deltaTime, 0, horizontalAxis);
            WrapPlayer();
        }
    }

    private void WrapPlayer()
    {
        if (transform.position.z > 5f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 5f);
        if (transform.position.z < -5f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -5f);
    }

    private void RotatePlayer()
    {
        float targetRotation = Mathf.Atan2(rb.velocity.y, rb.velocity.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up *
                                Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref MaxTurnSpeedREF,
                                    MaxTurnSpeed);
    }

    public void OnStartRunning()
    {
        isMoving = true;
        Animator[] anims = GetComponentsInChildren<Animator>();
        foreach (var a in anims)
        {
            if(a)
               a.Play("Run");
        }
    }

    public void SwitchCamera()
    {
        CamOne.SetActive(false);
        CamTwo.SetActive(true);
    }

    void MovePawns()
    {
         pawnSpawnPoint.transform.position = transform.position + Vector3.right * 2 + Vector3.forward * (-1 * rowDistance);
       // pawnSpawnPoint.transform.position = Vector3.Lerp(pawnSpawnPoint.transform.position, transform.position + Vector3.right * 2 + Vector3.forward * (-1 * rowDistance), Time.deltaTime * 10);
    }

    public void ArenaReached()
    {
        isMoving = false;

        Animator[] anims = GetComponentsInChildren<Animator>();
        foreach (var a in anims)
        {
            if (a)
                a.Play("Idle");
        }

        foreach (var g in playerPawns)
        {
            Animator[] ani = g.GetComponentsInChildren<Animator>();
            foreach (var a in anims)
            {
                if(a)
                 a.Play("Idle");
            }
        }
    }

    void ResetCamera()
    {
        //  inGameCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = 11;
    }

    public void ResumePlayerInput()
    {
        canMove = true;
    }

    public void StopPlayerInput()
    {
        canMove = false;
    }

    public void StepBackCam()
    {
        //inGameCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = 16f;
        //Invoke("ResetCamera", 0.2f);
        //canRestCam = true;

    }
    public void DeletePawns()
    {

        GameObject go = playerPawns[playerPawns.Count - 1];
        playerPawns.RemoveAt(playerPawns.Count - 1);
        GameObject temp;

        if (bodySaveData.isRanged)
        {
            temp = Instantiate(rangedRagdoll, go.transform.position-(Vector3.up*2), Quaternion.Euler(Vector3.up * -80));
            temp.GetComponent<Ragdoll>().SetPawnMesh();
        }
        else
        {
            temp = Instantiate(meleeRagdoll, go.transform.position - (Vector3.up * 2), Quaternion.Euler(Vector3.up * -80));
            temp.GetComponent<Ragdoll>().SetPawnMesh();

        }
        Destroy(go);


        x--;
        if (x < 1)
        {
            x = (playerPawns.Count - 1) / 3;
            y = playerPawns.Count - 1 / 3;
        }
    }


    public void SpawnPawn()
    {
        if (playerPawns.Count <= 40)
        {
            GameObject gO = Instantiate(this.gameObject, transform.position, Quaternion.identity);
            playerPawns.Add(gO);
            gO.GetComponent<Player>().enabled = false;
            gO.GetComponent<CapsuleCollider>().enabled = false;
            gO.GetComponent<MeshSpawner>().enabled = false;

            gO.transform.SetParent(pawnSpawnPoint);
            gO.transform.localPosition = Vector3.zero;
            gO.transform.localScale = Vector3.zero;
            gO.GetComponent<Pop>().enabled = true;
            gO.GetComponent<Animator>().enabled = false;

            y++;
            if (y > 3)
            {
                y = 1;
                x++;
                x = (playerPawns.Count - 1) / 3;
                camPos = CamTwo.GetComponent<CinemachineVirtualCamera>()
                    .GetCinemachineComponent<CinemachineTransposer>()
                    .m_FollowOffset
                    .x;

                Mathf.Lerp(camPos, CamTwo.GetComponent<CinemachineVirtualCamera>()
                    .GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset
                    .x += 1, Time.deltaTime * 2);
            }

           
            pos = new Vector3(0, 0, (y) * columnDistance);
            gO.transform.transform.SetParent(pawnSpawnPoint.GetComponent<FollowPlayer>().targets[x].transform);
            gO.transform.localPosition = pos;
          
           


            Animator[] anims = gO.GetComponentsInChildren<Animator>();
            foreach (var a in anims)
            {
                a.Play("Run");
            }
        }
    }

    public void DeleteAllRunnerAllies()
    {
       foreach(var p in playerPawns)
        {
            Destroy(p.gameObject);
        }
    }
}