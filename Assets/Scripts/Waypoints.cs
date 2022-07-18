using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Points; // Scriptin bağlı olduğu tüm objelerde bu dizi tanımlı olacaktır.

    void Awake()
    {
        Points = new Transform[transform.childCount]; // bu referans hiçbir objeye bağlı değil yeni oluşturuyoruz.
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = transform.GetChild(i); // 0'dan count sayısına kadar tüm transformları diziye aktardım.
        }
    }
}
