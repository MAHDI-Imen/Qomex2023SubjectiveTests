using UnityEngine;
using System.Collections;
using System.Collections.Generic;


using System.Text;
using System.IO;
using System;
using System.Threading;


public class PlayerMovementsRecorder : MonoBehaviour
{
    string fileName = "Assets/Files/PlayerMovements/"; // file pathname
    public int index = 0;
    float xPos;
    float zPos;
    float yPos;
    string output = "";

    void Start()
    {
        fileName += "posrot" + index + ".csv";
        System.IO.File.WriteAllText(fileName, "");
    }


    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
        var rotg = transform.rotation;
        var rot = transform.rotation.eulerAngles;
        var pos = transform.position;
        output = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}", xPos, yPos, zPos, rot[0], rot[1], rot[2], Time.time);
        output += "\n";
        if((xPos != 0) && (yPos != 0) && (zPos != 0)) {
            System.IO.File.AppendAllText(fileName, output);
        }

    }

}