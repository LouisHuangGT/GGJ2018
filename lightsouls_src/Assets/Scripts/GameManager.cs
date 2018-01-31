using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject UICanvas;
    public GameObject WinCanvas;
   // public GameObject PauseCanvas;
    public GameObject SpawnPoint;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject elf = GameObject.FindGameObjectWithTag("Player");
            elf.transform.position = SpawnPoint.transform.position;

 
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    public void GameStart()
    {
        StartCoroutine(wait(5f));

    }

    IEnumerator wait(float s)
    {
        yield return new WaitForSeconds(s);
        SceneManager.LoadScene("Level 1");
    }

    public void Death()
    {
        GameObject elf = GameObject.FindGameObjectWithTag("Player");
        Destroy(elf);

        UICanvas.SetActive(true);
        UICanvas.GetComponent<Animator>().SetBool("GameOver", true);
        Debug.Log("Dead");
    }

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(5);
        if (SceneManager.GetActiveScene().name == "Level 1")
            SceneManager.LoadScene("Level 2");
        else if (SceneManager.GetActiveScene().name == "Level 2")
            SceneManager.LoadScene("StartScene_Re");

    }

    public void Win()
    {
        // SceneManager.LoadScene("ClearScene");
        //UICanvas.SetActive(true);
        //UICanvas.GetComponent<Animator>().SetBool("Win", true);
        if (SceneManager.GetActiveScene().name == "Level 1")
            WinCanvas.transform.GetChild(1).GetComponent<Text>().text = "You saved the MOON!";
        else if (SceneManager.GetActiveScene().name == "Level 2")
            WinCanvas.transform.GetChild(1).GetComponent<Text>().text = "You saved the SUN!";
        WinCanvas.SetActive(true);
        StartCoroutine(loadNextLevel());
    }
}