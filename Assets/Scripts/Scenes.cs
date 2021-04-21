using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("test");
        SceneManager.LoadScene(1);
    }
   // public Button playbutton;
    public Button quitbutton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //playbutton.GetComponent<Button>().onClick.AddListener(PlayGame);
        quitbutton.GetComponent<Button>().onClick.AddListener(Quit);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }


}
