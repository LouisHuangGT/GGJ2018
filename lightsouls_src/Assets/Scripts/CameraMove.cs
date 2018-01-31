using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float y_distance_camera_elf = 0;
    public float y_distance_deathbox = -15;
    private GameObject maincamera;
    private GameObject deathBox;
    private bool camera_moveflag = false;
    private bool box_moveflag = false;
    private Vector3 new_camera_pos;
    private Vector3 ori_camera_pos;

    public float move_distance = 25;

    private Vector3 new_box_pos;
    private Vector3 ori_box_pos;
    private float lerp_t = 0;
    private float lerp_t_box = 0;
    private float lerp_speed = 3;
    public int choice = 0;

    // Use this for initialization
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        deathBox = GameObject.FindGameObjectWithTag("DBox");
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0 && !camera_moveflag && choice == 0)
        {
            FCameraMove();
            //  DBoxMove();
        }
        //   if (!camera_moveflag)
        //   Debug.Log("Test Distance" + (transform.position.y + y_distance_camera_elf - maincamera.transform.position.y > move_distance && !camera_moveflag) + "MoveDistance: " + (transform.position.y + y_distance_camera_elf - maincamera.transform.position.y));

        if (transform.position.y + y_distance_camera_elf - maincamera.transform.position.y > move_distance && !camera_moveflag && choice == 1)
        {
            FCameraMove();
            // EditorApplication.isPaused = true;

        }
        if (camera_moveflag)
        {
            lerp_t += lerp_speed * Time.deltaTime;
            if (lerp_t >= 1)
            {
                lerp_t = 1;
                maincamera.transform.position = new_camera_pos;
                // deathBox.transform.position = new_box_pos;
                camera_moveflag = false;
            }
            maincamera.transform.position = Vector3.Lerp(ori_camera_pos, new_camera_pos, lerp_t);
            // deathBox.transform.position = Vector3.Lerp(ori_box_pos, new_box_pos, lerp_t);
        }

    }

    void DBoxMove()
    {

        deathBox = GameObject.FindGameObjectWithTag("DBox");
        deathBox.transform.position = new Vector3(deathBox.transform.position.x, transform.position.y + y_distance_deathbox, deathBox.transform.position.z);
        //   ori_box_pos = deathBox.transform.position;
        //  lerp_t = 0;
        // Debug.Log("Transform_Y: " + transform.position.y);
        //   new_camera_pos = new Vector3(maincamera.transform.position.x, transform.position.y + y_distance_camera_elf, maincamera.transform.position.z);
        //   new_box_pos = new Vector3(deathBox.transform.position.x, transform.position.y + y_distance_deathbox, deathBox.transform.position.z);
    }

    void FCameraMove()
    {
        //deathBox = GameObject.FindGameObjectWithTag("DBox");
        //maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        ori_camera_pos = maincamera.transform.position;
        //ori_box_pos = deathBox.transform.position;
        camera_moveflag = true;
        lerp_t = 0;
        // Debug.Log("Transform_Y: " + transform.position.y);
        new_camera_pos = new Vector3(maincamera.transform.position.x, transform.position.y + y_distance_camera_elf, maincamera.transform.position.z);
        // new_box_pos = new Vector3(deathBox.transform.position.x, transform.position.y + y_distance_deathbox, deathBox.transform.position.z);
    }
}