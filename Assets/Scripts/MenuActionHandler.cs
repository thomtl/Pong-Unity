using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActionHandler : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Tests");
    }

}
