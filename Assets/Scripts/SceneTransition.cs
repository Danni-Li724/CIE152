using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OpenCafe()
    {
        SceneManager.LoadScene("Cafe");
    }

    public void OpenClub()
    {
        SceneManager.LoadScene("Club");
    }

    public void OpenCompany()
    {
        SceneManager.LoadScene("Company");
    }

    public void OpenWedding()
    {
        SceneManager.LoadScene("Wedding");
    }
    
    public void OpenMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    
}
