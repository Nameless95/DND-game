using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        //1= Restart the Scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
