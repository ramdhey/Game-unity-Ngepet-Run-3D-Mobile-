using System.Collections;
using System.Collections.Generic;
using GameLokal.Toolkit;
using UnityEngine;

public class BabiController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 pindah;


    public static int jumlahkoin;
    public float laribabi;
    public float lompatanbabi;
    public float maxSpeedBabi;
    public float gravitasi = -20;

    private int desiredLane = 1; //(0=Left;1=middle;2=right)
    public float laneDistance = 2.5f; //The distance between two lanes atau jarak antara dua jalur

    public Animator animManusia;
    public Animator animBabi;
    public gameManager gameManager;

    public GameObject manusia, babi;

    public static int whichAvatarIsOn = 1;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        JadiBabi();

        jumlahkoin = PlayerPrefs.GetInt("");
    }

    void Update()
    {
        SetAnimasi("isGameStarted", true);

        if (laribabi < maxSpeedBabi)
            laribabi += 0.1f * Time.deltaTime;

        pindah.z = laribabi;

        pindah.y += gravitasi * Time.deltaTime;

        SetAnimasi("isGrounded", true);

        if (controller.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            pindah.y += gravitasi * Time.deltaTime;
        }

        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);
        //controller.center = controller.center;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        controller.Move(pindah * Time.fixedDeltaTime);
    }



    private void Jump()
    {
        SetAnimasi("isGrounded", false);

        pindah.y = lompatanbabi;

        SetAnimasi("isGrounded", true);

    }

    private IEnumerator Slide()
    {
        SetAnimasi("isSliding", true);

        yield return new WaitForSeconds(1.3f);

        SetAnimasi("isSliding", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lilin")
        {
            Destroy(other.gameObject);
            gameManager.jumlahLilin += 1;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            gameManager.gameOver = true;
            SetAnimasi("isDead", true);
        }
    }

    public void SwitchAvatar()
    {
        switch (whichAvatarIsOn)
        {
            case 1:
                JadiManusia();
                break;

            case 2:
                JadiBabi();
                break;
        }
    }

    private void JadiManusia()
    {
        whichAvatarIsOn = 2;
        babi.SetActive(false);

        manusia.SetActive(true);
        GameEvent.Trigger("Jadi Manusia");
    }

    private void JadiBabi()
    {
        whichAvatarIsOn = 1;
        babi.SetActive(true);

        manusia.SetActive(false);
        GameEvent.Trigger("Jadi Babi");
    }

    private void SetAnimasi(string namaAnimasi, bool value)
    {
        if (animBabi.gameObject.activeInHierarchy)
        {
            animBabi.SetBool(namaAnimasi, value);
        }
        
        if (animManusia.gameObject.activeInHierarchy)
        {
            animManusia.SetBool(namaAnimasi, value);
        }
    }
}
