using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private bool _doMovement = true;
    public float PanSpeed = 30f;
    public float PanBorderThicness = 10; // Mouse' in ekranın en yüksek noktasının 10 br altında olmasını sağlamak için.
    public float ScrollSpeed = 10f;
    public float MinY = 80f;
    public float MaxY =80f;
    void Update()
    {
        if(GameManager.GameIsOver) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _doMovement = !_doMovement;
            return;
        }

        if (!_doMovement) return;
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBorderThicness)
        {   
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime,Space.World);
            // Space.World => Local'e değil Globale göre Vector belirlemesi yapar.
        }
        if (Input.GetKey("s") || Input.mousePosition.y <=  PanBorderThicness)
        {   
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBorderThicness)
        {   
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <=PanBorderThicness)
        {   
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime,Space.World);
        }

        ScrollWheel();
    }

    private void ScrollWheel() // Alanı büyütüp küçültmes
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // scroll => (+0.1 , -0.1) değerlerini almakta.
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * ScrollSpeed * Time.deltaTime; // ters orantı var (-) 'de yakınlaştırıyor.
        pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
        transform.position = pos;
    }
}
