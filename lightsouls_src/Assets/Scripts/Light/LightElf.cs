using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightElf : MonoBehaviour
{

    public Vector3 dir = new Vector3(0, 1, 0);
    private float acceleration = 15;
    private float deceleration = 5;
    public float acceleration_Init = 15;
    public float speed = 0;
    private float max_speed = 10;
    public GameObject ori_state;
    public float reflection_refresh = 0.3f;

    private float time_record;
    private float movingtime;
    private float start_decelarating = 0.2f;

    private float start_y = 0;

    private GameObject maincamera;

    private bool lockstate = false;

    // Use this for initialization
    void Start()
    {
        acceleration = acceleration_Init;
        GameObject follower = GameObject.FindGameObjectWithTag("TrailFollower");
        if (follower) follower.GetComponent<FollowElf>().SetTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /*speed += acceleration * Time.deltaTime;
        if (speed >= max_speed)
            acceleration = 0;*/
        
        time_record += Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, max_speed);
        dir.Set(dir.x, dir.y, 0);
        transform.Translate(dir * speed * Time.deltaTime);

        if (time_record >= movingtime * (1 - start_decelarating))
            speed -= deceleration * Time.deltaTime;

        //  Debug.Log("Speed : " + speed);

        // maincamera.transform.position = new Vector3(maincamera.transform.position.x,maincamera.transform.position.y + dir.y * speed * Time.deltaTime,maincamera.transform.position.z);

        //Debug.Log("Y test:" + dir.y);
        if (speed <= 0)
            ConverttoOriginalState();

        transform.position = new Vector3(transform.position.x, transform.position.y,0);

        //Debug.Log(dir);
    }

    void OnTriggerEnter(Collider collision)
    {

        //Debug.Log("Light Elf Bang!");

    }

    public void Init(Vector3 dir_, float speed_, float movingtime_)
    {
        dir = dir_;
        dir = dir.normalized;
        acceleration = acceleration_Init;
        speed = speed_;
        max_speed = speed_;
        movingtime = movingtime_;
        time_record = 0;

        // Debug.Log("MovingTime:" + movingtime_);
        deceleration = speed / (movingtime_ * start_decelarating);

        start_y = transform.position.y;
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void ConverttoOriginalState()
    {
        if (!lockstate)
        {
            PlayerMovement pmovement = Instantiate(ori_state, transform.position, transform.rotation).GetComponent<PlayerMovement>();

            //if(camera_move)
            //  pmovement.CameraMove(transform.position.y - start_y);

            Destroy(gameObject);
        }
        
    }
    public void LockState()
    {
        lockstate = true;
    }
    public void UnLockState()
    {
        lockstate = false;
    }

    public void Refract(Vector3 normal,float eta)
    {
        normal = normal.normalized;

        float cosi = Vector3.Dot(-dir,normal);
        float cos2 = 1 - eta * eta * (1 - cosi * cosi);
        if(cos2 <= 0)
        {
            Reflect(normal);
            return;
        }
       // Debug.Log("Refracted");
        Vector3 t = eta * dir + ((eta * cosi - Mathf.Sqrt(Mathf.Abs(cos2))) * normal);
        dir = t * cos2;

 
    }
    public void Reflect(Vector3 normal)
    {
        // Debug.Log("Normal" + normal);
        // Debug.Log("Dot" + -Vector3.Dot(dir, normal));
        normal = normal.normalized;

        Vector3 reflectiondir = -2 * Vector3.Dot(dir, normal) * normal + dir;
        time_record = movingtime * reflection_refresh;
        speed = max_speed;
        dir = reflectiondir;
        dir = dir.normalized;

    }

}
