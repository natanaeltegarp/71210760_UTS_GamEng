using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    public bool isEscapeToExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKeyUp(KeyCode.Escape)){
        if(isEscapeToExit){
            Application.Quit();
        }else{
            backToMenu();
        }
    }
    }
    public void startGame(){
        SceneManager.LoadScene("gameplay");
    }
    public void backToMenu(){
        SceneManager.LoadScene("mainMenu");
    }
    public void howToPlay(){
        SceneManager.LoadScene("howToPlay");
    }
}
