using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    public GameObject camStart, camEnd;

    public void Start()
    {
        GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void OnMouseDown()
    {
        camStart.SetActive(false);
        camEnd.SetActive(true);

        StartCoroutine(LoadLevel());
        StartCoroutine(ScreenFadeOut());
    }

    public IEnumerator LoadLevel()
    {
        // Wait for one second
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("level1");
    }

    public IEnumerator ScreenFadeOut()
    {
        yield return new WaitForSeconds(1f);

        float x = 0;
        while(x < 1)
        {
            Color color = GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color;
            x += 4f / 256f;
            color.a = x;
            GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = color;
            yield return new WaitForSeconds(1f / 256f);
        }
    }
}
