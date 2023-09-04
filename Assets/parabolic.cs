using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class parabolic : ProcessingLite.GP21
{
   public int modulus;
    public float numberOfLines = 20;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        Stroke(128);

        //for (int i = 0; i < 10; i++)
        //{

        //    if ( i % 3 == modulus)
        //{
        //    Stroke(128);
        //}
        //else
        //{
        //    Stroke(255);
        //}
        //Line(0, 10 - i, 1 + i, 0);

        //}
        float distanceBetweenLinesY = Height / numberOfLines;
        float distanceBetweenLinesX = Width / numberOfLines;

        for (int i = 0; i < numberOfLines; i++)
        {
           

            if (i % 3 == modulus)
            {
                Stroke(128);
            }
            else
            {
                Stroke(255);
            }

            Line(0, Height - i * distanceBetweenLinesY, i * distanceBetweenLinesX, 0);

        }
        modulus++;
        modulus %= 3;
    }
}
