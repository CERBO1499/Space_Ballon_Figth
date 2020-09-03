using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class TouchMovement : MonoBehaviour
{
    [SerializeField] int lives; //This should get by PlayerLife...

    [SerializeField] float forceY, forceYTwoLives, forceYOneLive;

    [SerializeField] float forceX;

    [SerializeField] float dragY, dragTwoLives, dragOneLive;

    float width;
    float height;

    Rigidbody rb;

    CMDebugger cMDebugger;

    Vector3 rayDirection;

    Vector2 startYPos = new Vector2();
    Vector2 endYPos = new Vector2();

    Vector2 startYPos2 = new Vector2();
    Vector2 endYPos2 = new Vector2();

    [SerializeField]
    Transform centerPoint;

    public int Lives { get => lives; set => lives = value; }

    private void Awake()
    {
        //Debug.Log("IM AWAKE!!!");

        width = Screen.width;
        height = Screen.height;

        rb = GetComponent<Rigidbody>();

        cMDebugger = GameObject.FindObjectOfType<CMDebugger>();

        ////Vector2 startYPos = new Vector2();
        //startYPos.x = width / 3;
        //startYPos.y = 0;

        ////Vector2 endYPos = new Vector2();
        //endYPos.x = width / 3;
        //endYPos.y = height;

        ////Vector2 startYPos = new Vector2();
        //startYPos2.x = width * 2/3;
        //startYPos2.y = 0;

        ////Vector2 endYPos = new Vector2();
        //endYPos2.x = width * 2/3;
        //endYPos2.y = height;

        //centerPoint.position.x = width/2

        //Debug.Log("Width: " + width);
        //Debug.Log("Height: " + height);
    }

    private void Update()
    {
        //CMDebbugerUpdate();

        ChangeForceDrag();
    }

    private void ChangeForceDrag()
    {
        lives = FindObjectOfType<PlayerLife>().Lifes;

        rb.drag = dragY;

        if (lives == 2)
        {
            forceY = forceYTwoLives;
            dragY = dragTwoLives;
        }
        if (lives == 1)
        {
            forceY = forceYOneLive;
            dragY = dragOneLive;
        }
    }

    private void FixedUpdate()
    {
        #region Movement Build V0.Pending...

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Firs action when touch screen
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

                    Vector2 direction = touchWorldPos - centerPoint.position;

                    if (direction.y < 0)
                    {
                        direction.y *= -1;
                    }

                    JumpDirection(direction.normalized);
                }
            }

            //if touch stay on screen or touch moving arround screen without release
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

                Vector2 direction = touchWorldPos - transform.position;

                //Left
                if (touch.position.x < width / 2)
                {
                    MovementX(Vector3.left);
                }
                //Right
                if (touch.position.x > width / 2)
                {
                    MovementX(Vector3.right);
                }
            }
        }

        #endregion

        #region Movement Build V0.11

        //if (Input.touches.Length > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    //Firs action when touch screen
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

        //        Vector2 direction = touchWorldPos - transform.position;

        //        if (direction.y <= 0)
        //        {
        //            direction.y *= -1;
        //        }

        //        JumpDirection(direction.normalized);
        //    }

        //    //if touch stay on screen or touch moving arround screen without release
        //    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        //    {
        //        Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

        //        Vector2 direction = touchWorldPos - transform.position;

        //        //print("Moving Touch");
        //        //print(touch.position.x);

        //        //Left
        //        if (touchWorldPos.x < transform.position.x)
        //        {
        //            //print("izquierda");
        //            MovementX(Vector3.left);
        //        }
        //        //Right
        //        if (touchWorldPos.x > transform.position.x)
        //        {
        //            MovementX(Vector3.right);
        //        }
        //    }
        //}

        #endregion

        #region Movement Build V0.Pending... (3 PARTS SCREEN)

        //if (Input.touches.Length > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        //Izquierda
        //        if (touch.position.x < width * 1/3)
        //        {
        //            //print("Izquierda");
        //            Vector3 direction = new Vector3(-1, 1, 0);
        //            JumpDirection(direction);
        //        }
        //        //Derecha
        //        if (touch.position.x > width * 2/3)
        //        {
        //            //print("Derecha");
        //            Vector3 direction = new Vector3(1, 1, 0);
        //            JumpDirection(direction);
        //        }
        //        //Centro
        //        if (touch.position.x > width * 1/3 && touch.position.x < width * 2/3)
        //        {
        //            //print("Centro");
        //            JumpY();
        //        }
        //    }

        //    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        //    {
        //        //Izquierda
        //        if (touch.position.x < width * 1 / 3)
        //        {
        //            Vector3 velocity = rb.velocity;
        //            velocity.x = 0f;
        //            rb.velocity = velocity;
        //            rb.AddForce(Vector3.left * forceX, ForceMode.Impulse);
        //        }
        //        //Derecha
        //        if (touch.position.x > width * 2 / 3)
        //        {
        //            Vector3 velocity = rb.velocity;
        //            velocity.x = 0f;
        //            rb.velocity = velocity;
        //            rb.AddForce(Vector3.right * forceX, ForceMode.Impulse);
        //        }
        //    }
        //}

        #endregion

        #region Movement Build V0.10

        // // if (Input.touches.Length > 0)
        // // {
        // //     Touch touch = Input.GetTouch(0);

        // //     //Firs action when touch screen
        // //     if (touch.phase == TouchPhase.Began)
        // //     {
        // //         Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

        // //         Vector2 direction = touchWorldPos - transform.position;

        // //         //Debug.DrawRay()
        // //         rayDirection = direction.normalized;

        // //         //print("Direction: " + direction);

        // //         //Only if tap is over player
        // //         if (direction.y > 0)
        // //         {
        // //             JumpDirection(direction.normalized);
        // //         }
        // //         else //if tap is under player just jump horizontal
        // //         {
        // //             if (direction.x < 0)
        // //             {
        // //                 MovementX(Vector3.left);
        // //             }
        // //             else
        // //             {
        // //                 MovementX(Vector3.right);
        // //             }
        // //         }
        // //     }


        // //     //if touch stay on screen or touch moving arround screen without release
        // //     if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        // //     {
        // //         //Left
        // //         // if (touch.position.x < width / 2 && !IsTouchOverUI.Instance.IsPointerOverUIObject())
        // //         // {
        // //         //     MovementX(Vector3.left);
        // //         // }
        // //         // //Right
        // //         // else if (touch.position.x > width / 2 && !IsTouchOverUI.Instance.IsPointerOverUIObject())
        // //         // {
        // //         //     MovementX(Vector3.right);
        // //         // }


        // //         //  if (touch.position.x < width / 2)
        // //         // {
        // //         //     MovementX(Vector3.left);
        // //         // }
        // //         // //Right
        // //         // else if (touch.position.x > width / 2)
        // //         // {
        // //         //     MovementX(Vector3.right);
        // //         // }
        // //     }
        // }

        #endregion

        #region Movement Build V0.8

        //if (Input.touches.Length > 0 && !SwipeInput.swipedUp)
        //{
        //   Touch touch = Input.GetTouch(0);

        //   if (touch.phase == TouchPhase.Began)
        //   {
        //       //Izquierda
        //       if (touch.position.x < width / 2)
        //       {
        //           Vector3 direction = new Vector3(-1, 1, 0);
        //           JumpDirection(direction);
        //       }
        //       //Derecha
        //       else if (touch.position.x > width / 2 )
        //       {
        //           Vector3 direction = new Vector3(1, 1, 0);
        //           JumpDirection(direction);
        //       }
        //   }

        //   if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        //   {
        //       //Izquierda
        //       if (touch.position.x < width / 2)
        //       {
        //           Vector3 velocity = rb.velocity;
        //           velocity.x = 0f;
        //           rb.velocity = velocity;
        //           rb.AddForce(Vector3.left * forceX, ForceMode.Impulse);
        //       }
        //       //Derecha
        //       else if (touch.position.x > width / 2 )
        //       {
        //           if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        //           {
        //               Vector3 velocity = rb.velocity;
        //               velocity.x = 0f;
        //               rb.velocity = velocity;
        //               rb.AddForce(Vector3.right * forceX, ForceMode.Impulse);
        //           }
        //       }
        //   }
        //}
        // else if (SwipeInput.swipedUp)
        // {
        // //    JumpY();
        // }

        #endregion
    }

    private void MovementX(Vector3 direction)
    {
        //Vector3 velocity = rb.velocity;
        //velocity.x = 0f;
        //rb.velocity = velocity;
        //rb.AddForce(direction * forceX, ForceMode.Impulse);
        rb.AddForce(direction * forceX);
    }

    private void JumpDirection(Vector3 direction)
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0f;
        velocity.x = 0f;
        rb.velocity = velocity;

        //rb.velocity = Vector3.zero;
        rb.AddForce(direction * forceY, ForceMode.Impulse);
    }

    public void JumpY()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = 0f;
        velocity.x = 0f;
        rb.velocity = velocity;
        rb.AddForce(Vector3.up * forceY, ForceMode.Impulse);
    }

    #region CM_Debbuger_Update
    private void CMDebbugerUpdate()
    {
        //Debug.DrawLine(startYPos, endYPos, Color.green);
        //Debug.DrawLine(startYPos2, endYPos2, Color.green);
        //Debug.DrawRay(transform.position, rayDirection, Color.red);

        forceYTwoLives = cMDebugger.SliderForceYTwoLives.value;
        forceYOneLive = cMDebugger.SliderForceYOneLive.value;

        dragOneLive = cMDebugger.SliderDragOneLive.value;
        dragTwoLives = cMDebugger.SliderDragTwoLives.value;

        forceX = cMDebugger.SliderForceX.value;

        cMDebugger.DebugText1.text = "Force WITH 2 Lives: " + forceYTwoLives;
        cMDebugger.DebugText2.text = "Force WITH 1 Live: " + forceYOneLive;
        cMDebugger.DebugText3.text = "Drag WITH 2 Lives: " + dragTwoLives;
        cMDebugger.DebugText4.text = "Drag WITH 1 Live: " + dragOneLive;
        cMDebugger.DebugText5.text = "Force X: " + forceX;

        //rb.drag = cMDebugger.sliderDrag.value;
        //rb.angularDrag = cMDebugger.sliderAng.value;

        //cMDebugger.debugText1.text = "Drag: " + rb.drag;
        //cMDebugger.debugText2.text = "Ang: " + rb.angularDrag;
        //cMDebugger.debugText3.text = "Force: " + force1;
        //cMDebugger.debugText5.text = "Speed: " + speed;

        //cMDebugger.debugText4.text = "TouchCount: " + Input.touchCount.ToString();
    }
    #endregion
}
