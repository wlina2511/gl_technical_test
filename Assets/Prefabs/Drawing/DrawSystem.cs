using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawSystem : MonoBehaviour
{
    public GameObject currentDraw;
    public GameObject drawPrefab;
    public int actualOrder;
    public List<Vector3> currentPoints = new List<Vector3>();
    public float timer;
    public Vector3 offset;
    public float currentX;
    public float currentY;
    public DrawManager drawManager;
    public Transform hand;
    public Vector3 handOffset;
    public Material tShirtMaterial;
    public RenderTexture texture;

    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 point = new Vector3();

        Vector2 mousePos = new Vector2();

       

        if (Input.GetMouseButtonDown(0))
        {
            hand.GetComponent<Animator>().SetTrigger("Click");
        }

        else if (Input.GetMouseButtonUp(0))
        {
            hand.GetComponent<Animator>().SetTrigger("Idle");
        }

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        hand.position = new Vector3(mousePos.x, mousePos.y, 0) + new Vector3(handOffset.x, handOffset.y, 0);

        currentX = mousePos.x;
        currentY = mousePos.y;
        point = this.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, this.GetComponent<Camera>().nearClipPlane));
        point += offset;

        if(Input.GetMouseButtonDown(0) && mousePos.y > 550 && mousePos.y < 1500)
        {
   

            if(currentDraw == null)
            {
                GameObject newDraw = Instantiate(drawPrefab);
                newDraw.SetActive(true);
                newDraw.GetComponent<LineRenderer>().sortingOrder = actualOrder;
                actualOrder++;
                currentPoints.Clear();
                currentDraw = newDraw;
                newDraw.GetComponent<LineRenderer>().material.color = drawManager.currentColor;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            currentDraw = null;
        }

        if(currentDraw)
        {
            this.GetComponent<AudioSource>().volume += Time.deltaTime;

            timer += Time.deltaTime;

            if(timer > 0.03f)
            {
                timer = 0;
                currentPoints.Add(point);
                currentDraw.GetComponent<LineRenderer>().positionCount = currentPoints.Count;

                for(int i = 0; i < currentPoints.Count; i++)
                {
                    currentDraw.GetComponent<LineRenderer>().SetPosition(i, currentPoints[i]);
                }

                
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                currentDraw.GetComponent<LineRenderer>().widthMultiplier += 1;
            }
            
        }

        else
        {
            this.GetComponent<AudioSource>().volume -= Time.deltaTime * 10;
        }

    }

    public void PrintTShirt()
    {
        this.GetComponent<Camera>().orthographicSize = 2.5f;
        tShirtMaterial.mainTexture = toTexture2D(texture);
        LineRenderer[] lines = GameObject.FindObjectsOfType<LineRenderer>();

        foreach(LineRenderer LR in lines)
        {
            LR.widthMultiplier = 0;
        }
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(2048, 2048, TextureFormat.ARGB32, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
