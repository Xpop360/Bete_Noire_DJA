using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Puzzle1 : MonoBehaviour {

    int [] nums;
    int column = 0;
    public int num1, num2, num3;
    public GameObject puzzleObject;
    public GameObject Way;
	
	void Start () {
        nums = new int[] { 0, 0, 0 };
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) //panel navigation
        {
            if (column != 2)
            {
                column++;
            }
            else
            {
                column = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (column != 0)
            {
                column--;
            }
            else
            {
                column = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (nums[column] != 9)
            {
                nums[column]++;
            }
            else
            {
                nums[column] = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (nums[column] != 0)
            {
                nums[column]--;
            }
            else
            {
                nums[column] = 9;
            }
        }
        UpdatePanels();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter");
            if (WinCheck())
            {
                OpenWay();
                Time.timeScale = 1f;
            }
        }
    }

    void UpdatePanels()
    {
        Text[] text = GetComponentsInChildren<Text>().ToArray();
        for (int i = 0; i < 3; i++)
        {
            text[i].text = nums[i].ToString();
        }
    }

    bool WinCheck()
    {
        if (nums[0] == num1 && nums[1] == num2 && nums[2] == num1)
        {
            return true;
        }
        return false;
    }

    void OpenWay()
    {
        gameObject.SetActive(false);
        Way.GetComponent<Animator>().SetBool("doIt", true);
        Destroy(puzzleObject);
    }
}
