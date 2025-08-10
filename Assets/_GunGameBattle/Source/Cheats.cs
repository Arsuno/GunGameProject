using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GunGameBattle.Source
{
    public class Cheats : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                SceneManager.LoadScene("BootstrapScene");
        }
    }
}