﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SceneCodeUtil : MonoBehaviour
{
    public SceneCode sceneCode;
    public Rect CameraClamp;
    public bool isRecordCameraClamp;
    void Start(){
        transform.name = sceneCode.ToString();
    }
    void Update()
    {
        if(isRecordCameraClamp){
            BasicFollower bf = Camera.main.GetComponent<BasicFollower>();
            if(BasicFollower.cameraClamps.ContainsKey(sceneCode)){
                BasicFollower.cameraClamps[sceneCode] = bf.cameraClamp;
            }
            else{
                BasicFollower.cameraClamps.Add(sceneCode, bf.cameraClamp);
            }
            CameraClamp = bf.cameraClamp;
        }
    }
}
