using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    // Sahne geçişleri esnasında animasyon şeklinde kararma ve aydınlanma olacak.

    public Image ImageClr;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn() // Sahne açıldığında
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            ImageClr.color = new Color(0f, 0f, 0f, a); // a = alpha (4.renk)
            yield return 0;
        }
    }
    IEnumerator FadeOut(string scene) // Başka sahneye geçiş
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            ImageClr.color = new Color(0f, 0f, 0f, a); // a = alpha (4.renk)
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
}
