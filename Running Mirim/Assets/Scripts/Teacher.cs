using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public string Imgname;

    public bool isGreet; //인사확인변수

    private void Start()
    {
        Imgname = "teacher_normal";
        isGreet = false;
    }
}
