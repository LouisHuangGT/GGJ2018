using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBlackhole: MonoBehaviour {

    public GameObject manager;
    bool enterFlag = false;
    Collider player;
    float Timer;

    public float changingTime;

    public Color startColor = new Color(0, 0, 0);
    public Color endColor = new Color(150, 150, 150);
    // Use this for initialization
    void Start()
    {

        GetComponent<Star>().SetColor(startColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (enterFlag)
        {
            GetComponent<Star>().SetColor(Color.Lerp(startColor,endColor,(Time.time-Timer)/changingTime));
        }
    }
    IEnumerator wait(float s)
    {
        yield return new WaitForSeconds(s);
        manager.GetComponent<GameManager>().Win();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lightmode")
        {
            Timer = Time.time;
            enterFlag = true;
            Vector3 dir = Vector3.Normalize(transform.position - other.transform.position);
            other.gameObject.GetComponent<LightElf>().dir = dir;
            other.gameObject.GetComponent<LightElf>().speed = 50.0f;
            other.gameObject.GetComponent<LightElf>().LockState();
            float waitTime = Vector3.Distance(transform.position, other.transform.position) / other.gameObject.GetComponent<LightElf>().speed;

            Destroy(other.gameObject, waitTime * 0.8f);
            StartCoroutine(wait(5f));

        }
    }
}
