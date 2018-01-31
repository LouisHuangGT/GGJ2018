using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject movingPlayer;
    public float chargingRatio = 1f;
    public float maxChargingDuration = 3f;
    public float initialSpeed = 10f;
    public float DEBUG_chargingDuration;
    public bool DEBUG_isGrounded;
    public GameObject explosion;
    public GameObject directionIndicator;
    public GameObject biuSound;

    private float chargingDuration;
    private bool released;
    private bool isGrounded;
    private DirectionIndicator dirIndicator;
    private GameObject chargingAnimation;
    private AudioSource chargingSound;
    private GameObject spawnPoint;

    public float y_distance_camera_elf = 20.7f;

    // Use this for initialization
    void Start()
    {
        chargingDuration = 0f;
        released = false;
        isGrounded = false;
        directionIndicator = Instantiate(directionIndicator, transform.position, Quaternion.identity);
        dirIndicator = directionIndicator.GetComponent<DirectionIndicator>();
        directionIndicator.SetActive(false);

        GameObject follower = GameObject.FindGameObjectWithTag("TrailFollower");
        if (follower) follower.GetComponent<FollowElf>().SetTarget(gameObject);

        spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
        //if (spawnPoint) spawnPoint.GetComponent<FollowElf>().SetTarget(gameObject);

        chargingAnimation = transform.GetChild(0).gameObject;

        chargingSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "boundary" || collision.gameObject.tag != "deadzone")
            isGrounded = true;
        //Debug.Log("Ground on platform: " + collision.gameObject.name);
        Vector3 startPoint = transform.position;
        startPoint.z = 0;
        dirIndicator.SetStartPoint(startPoint);
        dirIndicator.SetEndPoint(startPoint);
        directionIndicator.SetActive(true);
    }

    void OnCollisionExit(Collision collision)
    {
        ResetStates();
        //Debug.Log("Leave platform: " + collision.gameObject.name);
    }

    void ResetStates()
    {
        chargingDuration = 0f;
        released = false;
        isGrounded = false;
        directionIndicator.SetActive(false);
        chargingAnimation.SetActive(false);
        chargingSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            spawnPoint.transform.position = transform.position;
        }

        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            chargingAnimation.SetActive(true);
        }

        if (isGrounded && Input.GetMouseButton(0))
        {
            if (!chargingSound.isPlaying)
            {
                chargingSound.Play();
            }
            chargingDuration += Time.deltaTime;
            if (chargingDuration >= maxChargingDuration)
            {
                chargingDuration = maxChargingDuration;
                released = true;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.DrawLine(this.transform.position, hitInfo.point, Color.black);
                if (dirIndicator)
                {
                    Vector3 startPoint = transform.position;
                    startPoint.z = 0;
                    dirIndicator.SetStartPoint(startPoint);
                    Vector3 hitPoint = hitInfo.point;
                    hitPoint.z = 0;
                    dirIndicator.SetEndPoint(hitPoint);
                    dirIndicator.SetWidthRatio(chargingDuration / maxChargingDuration);
                }
            }

            this.transform.GetChild(2).localScale = Vector3.one * (1 - 0.5f * chargingDuration / maxChargingDuration);
        }

        if (isGrounded && Input.GetMouseButtonUp(0))
        {
            released = true;
            chargingSound.Stop();
        }

        DEBUG_chargingDuration = chargingDuration;
        DEBUG_isGrounded = isGrounded;

        if (released)
        {
            //Debug.Log("charging duration: " + chargingDuration);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log("Hit on " + hitInfo.point);
                //Debug.DrawLine(this.transform.position, hitInfo.point, Color.red, 1f);
                directionIndicator.SetActive(false);
                dirIndicator.SelfDestroy();
                Vector2 transmitDirection = hitInfo.point - this.transform.position;
                //Debug.Log("Transmit direction: " + transmitDirection);
                GameObject elf = Instantiate(movingPlayer, this.transform.position, Quaternion.identity);
                elf.GetComponent<LightElf>().Init(transmitDirection, initialSpeed, chargingRatio * chargingDuration);
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                Instantiate(biuSound, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }

}