using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public void LoadScene(){
        SceneManager.LoadScene("Bölüm1");
    }
    //çıkış fonksiyonu
    public void QuitGame(){
        //uygulama editörde çalışıyorsa
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //uygulama derlenmiş bir versiyon olarak çalışıyorsa
        #else
        Application.Quit();
        #endif
    }
}
