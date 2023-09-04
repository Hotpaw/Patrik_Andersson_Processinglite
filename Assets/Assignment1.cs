using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Assignment1 : ProcessingLite.GP21
{

    public Vector4 lineVector = new Vector4(0,0,0,0);
    public Vector2 circleVector = new Vector2(0f,0f);
    public Vector2 movePosition = new Vector2(0f,0f);
    public float circleDiamter;
    private Camera cam;
    Vector2 mouseWorldPos;
   
     float speed;
    public float maxSpeed;
    float distancebetweenVectors;
    // Start is called before the first frame update
    void Start()
    {
        mouseWorldPos = new Vector2(MouseX,MouseY);
     cam = GetComponent<Camera>();
        InitializeVectors();
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetMouseButton(0))
        {
           
          
            moveCircle();
       
            
        }
        InitializeVectors();
        DrawLineToCircle();

    }
    public void CirclePositionToMouse()
    {
         mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        circleVector.y = mouseWorldPos.y; circleVector.x = mouseWorldPos.x;
    }
    public void DrawLineToCircle()
    {
        if(Input.GetMouseButton(0))
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lineVector.x = mouseWorldPos.x;
            lineVector.y = mouseWorldPos.y;
            lineVector.z = circleVector.x;
            lineVector.w = circleVector.y;
        }
        else
        {
            lineVector.x = 0;
            lineVector.y = 0;
            lineVector.z = 0;
            lineVector.w = 0;
        }
       
        
       

      
    }
    public void InitializeVectors()
    {
        int rgb = ((int)distancebetweenVectors);
        Background(rgb * 10,rgb * 10,rgb * 10);

        Line(lineVector.x, lineVector.y, lineVector.z, lineVector.w);
        Circle(circleVector.x, circleVector.y, circleDiamter);

        if (speed < distancebetweenVectors)
        {
            speed = maxSpeed;

        }
        else
        {
            speed = distancebetweenVectors;
        }
        circleVector += movePosition;

        if(circleVector.x - circleDiamter / 2 < 0 || circleVector.x + circleDiamter / 2 > Width)
        {
            movePosition *= new Vector2(-1, 1);
        }
        if (circleVector.y - circleDiamter / 2 < 0 || circleVector.y  + circleDiamter / 2>Height)
        {
            movePosition *= new Vector2(1, -1);
        }
    }
    public void CalculateVectorDistance()
    {
        
         mouseWorldPos = new Vector2(MouseX, MouseY);
        distancebetweenVectors = Vector2.Distance(mouseWorldPos, circleVector);


        Debug.Log(" Distance of vector:" + distancebetweenVectors);
    }
    public void moveCircle()
    {
       
        

             mouseWorldPos = new Vector2(MouseX, MouseY);
            Vector2 distance = mouseWorldPos - circleVector;
            CalculateVectorDistance();
      
            movePosition = Vector2.ClampMagnitude(distance, speed * Time.deltaTime);

           

            
        
    }




}
