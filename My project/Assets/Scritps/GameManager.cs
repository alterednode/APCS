using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public bool xPlayerTurn;
	public GameObject[] prefabXO;
	public bool g;
    




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public static int CheckForWin(int[] checkThis)
	{
		int checkValue=0;
		
		int val1=0;
		int val2=1;
		int val3=2;

		for (int i = 0;i < 9; i++)
		{
			
			if (i<3)
			{
				checkValue = checkThis[val1] + checkThis[val2] + checkThis[val3];
				val1 +=3;
				val2 +=3;
				val3 +=3;
			}else
			{
				if(i<6)
				{
					if (i==3)
					{
						val1 = 0;
						val2 = 3;
						val3 = 6;
						
					}
					checkValue = checkThis[val1] + checkThis[val2] + checkThis[val3];
					val1 +=1;
					val2 +=1;
					val3 +=1;
				}else
				{
					if (i==7)
					{
						checkValue = checkThis[0] + checkThis[4] + checkThis[8];
					}
					if (i==8)
					{
						checkValue = checkThis[2] + checkThis[4] + checkThis[6];
					}
				}
			}
			
			
			
			
			
			
			if (checkValue == 3 || checkValue == -3)
			{
				return(checkValue);
			}
			
			
		}
		return 0;
    
	}
}