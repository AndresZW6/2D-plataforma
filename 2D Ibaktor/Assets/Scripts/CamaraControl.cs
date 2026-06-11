using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    //Variable de seguimiento
    public Transform target;

    //Variables para asignar los planos dentro de la escena
    public Transform Background, Midground;

    //Variable para almacenar la ultima posicion en el eje x del player
    //private float lastXPos;

    //Variable de tipo vector 2 para almacenar la ultima posicion del player en ambos ejes
    private Vector2 lastPos;

    //Variables para el movimiento vertical
    public float minHeight, maxHeight;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //paralaje horizontal
        //lastXPos = transform.position.x;

        //paralaje vertical y horizontal
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Seguimiento de camara
        //Manipulando el eje horizontal
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);   
        
        //float clampedY = Mathf.Clamp(target.position.y, minHeight, maxHeight);
        //Manipulando unicamente el eje vertical
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //Paralaje horizontal
        //float amountToMoveX = transform.position.x - lastXPos;

        //paralaje vertical y horizontal
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        Background.position = Background.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        Midground.position += new Vector3(amountToMove.x,amountToMove.y , 0f) * 0.5f;

        //paralaje horizontal
        //lastXPos = transform.position.x;
        lastPos = transform.position;

        //Midground.position = transform.position;
    }


}
