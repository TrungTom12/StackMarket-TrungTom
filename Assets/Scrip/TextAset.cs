using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextAset : MonoBehaviour
{
    [SerializeField] private GameObject[] brick;
    private object save;

    enum typeBrick // Khai báo (kiểu liệt kê) các phần tử brick
    {
        brick1, 
        brick2, 
        brick3
    }
    private void Start()
    {
        LoadText();
        int b = (int)(typeBrick.brick1);
        Debug.Log(b);

    }
    private void LoadText()
    {
        string data = Resources.Load<TextAsset>("Maps/Map1").text; // Hàm đọc file text (Resources.Load)
        string[] save = data.Split(new string[] { "\n" }, System.StringSplitOptions.None); //Sử dụng Split để bỏ qua ptử không cần thiết (thêm đuôi để TBD hiểu dùng pp nào !!)
        string[,] a = new string[6, 6];
        for (int i = 0; i < 6; i++) // mảng 2 chiều tạo ma trận 
        {
            string[] temp = save[i].Split(",");
            for (int j = 0; j < 6; j++)
            {
                a[i, j] = temp[j];
                //Debug.Log(a[i, j]);
                RendMap(a[i, j], i, j); // kết xuất ra map từ ma trận
            }
        }
    }
    void RendMap(string a, float x, float z) // Hàm kết xuất 
    {
        int b = int.Parse(a);
        switch (b)
        {
            case (int)(typeBrick.brick1):
                Instantiate(brick[0], new Vector3(x, 0, z), Quaternion.identity);
                Debug.Log("gach khong di duoc");
                break;
            case (int)(typeBrick.brick2):
                Instantiate(brick[1], new Vector3(x, 0, z), Quaternion.identity);
                Debug.Log("gach di dc");
                break;
            case (int)(typeBrick.brick3):
                Instantiate(brick[2], new Vector3(x, 0, z), Quaternion.identity);
                Debug.Log("gach di dc");
                break;
            default:
                break;
        }
    }
}