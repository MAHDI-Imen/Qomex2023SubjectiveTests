using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Replay : MonoBehaviour
{
    public TextAsset coordinates;

    string[] coordinatesArray;
    int currentPointIndex = 0;
    Vector3 destinationVector;
    string[] begin;
    float rotx;
    float roty;
    float rotz;

    public double timestamp = 0;
    public double currentTime = 0;
    double offset = 0;


    void Start()
    {
        coordinatesArray = coordinates.text.Split('\n');
        begin = coordinatesArray[0].Split(',');
    }


    void Update()
    {
        currentTime = Time.time;
        if(currentTime  - offset >= timestamp){

            currentPointIndex = currentPointIndex < coordinatesArray.Length - 1 ? currentPointIndex + 1 : 1;
            if (!string.IsNullOrWhiteSpace(coordinatesArray[currentPointIndex]))
            {

                    string[] xyz = coordinatesArray[currentPointIndex].Split(',');
                    timestamp =  double.Parse(xyz[6]);
                    if (currentPointIndex != 0) {
                        string[] xyz2 = coordinatesArray[currentPointIndex-1].Split(',');
                        if (float.Parse(xyz[3]) - float.Parse(xyz2[3]) < 160 && float.Parse(xyz[3]) - float.Parse(xyz2[3]) > 200) {
                            rotx = float.Parse(xyz[3]) + 180;
                        }
                        else {
                            rotx = float.Parse(xyz[3]);
                        }
                        if (float.Parse(xyz[4]) - float.Parse(xyz2[4]) < 160 && float.Parse(xyz[4]) - float.Parse(xyz2[4]) > 200) {
                            roty = float.Parse(xyz[4]) + 180;
                        }
                        else {
                            roty = float.Parse(xyz[4]);
                        }
                        if (float.Parse(xyz[5]) - float.Parse(xyz2[5]) < 160 && float.Parse(xyz[5]) - float.Parse(xyz2[5]) > 200) {
                            rotz = float.Parse(xyz[5]) + 180;
                        }
                        else {
                            rotz = float.Parse(xyz[5]);
                        }
                    }
                    destinationVector = new Vector3(float.Parse(xyz[0]), float.Parse(xyz[1]), float.Parse(xyz[2]));
                    transform.position = destinationVector;
                    transform.rotation = Quaternion.Euler(rotx, roty, rotz);
            }else{
                offset += timestamp;
                timestamp = 0;
            }
           
        
        }

    }
  
}
