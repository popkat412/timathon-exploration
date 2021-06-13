using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
	public int sizeOfMaze = 10;
	public GameObject wall;
	void Start()
	{ 
		bool[][][] mazeWall = generateMaze();
		bool[][] mazeWallHorizontal = mazeWall[0];
		bool[][] mazeWallVertical = mazeWall[1];

		int counterY = 0;
		foreach(bool[] i in mazeWallHorizontal){
			int counterX = 0;
			foreach(bool j in i){
				Instantiate(wall, new Vector3(counterX, 5.1f, counterY), Quaternion.identity);
				counterX++;
			}
			counterY++;
		}

		foreach(bool[] i in mazeWallVertical){
			foreach(bool j in i){
				
			}
		}
	}

	void Update()
	{

	}

	bool[][][] generateMaze()
	{
		//first index is vertical, second is horizontal (stores if the place has been visited)
		//see diagram below jst in case
		//           2nd index
		//1st index [[][][][]]
		//1st index [[][][][]]
		bool[][] maze = { };
		maze[0][0] = true; maze[1][0] = true;

		//to store if a wall exist (values are inverted btw so false means wall exists since bool is false by default)
		bool[][] wallHorizontal = { };
		bool[][] wallVertical = { };

		//position we are currently at (y vertical x horizontal)
		Vector2 pos = new Vector2(0, 0);

		Vector2[] directions = { new Vector2(pos.x - 1, pos.y - 1),
														new Vector2(pos.x + 1, pos.y - 1),
														new Vector2(pos.x - 1, pos.y + 1),
														new Vector2(pos.x + 1, pos.y + 1) };

		Stack<Vector2> beenTo = new Stack<Vector2>();

		while (true)
		{
			//going through the maze :) 
			//keep in mind i have to do this because maze generation needs to be random

			Vector2[] directionsBeenTo = { };
			bool success = false;

			for (int i = 0; i < 4; i++)
			{
				int rand = Random.Range(0, 3);
				Vector2 direction = pos += directions[rand];

				if (direction.x < 0 || direction.x > sizeOfMaze - 1 || direction.y < 0 || direction.y > sizeOfMaze - 1)
				{
					//checking if we went out of the maze 
					//what im doing here is explained below too 
					// (i dw to combine for loop just to save some computational power in not running the for loop)
					i--;
					continue;
				}

				bool checkedBefore = false; //if we have been to this location (in this for loop (since its random))
				foreach (Vector2 j in directionsBeenTo)
				{
					if (j == direction)
					{
						checkedBefore = true;
						break;
					}

				}

				if (checkedBefore || maze[(int)direction.y][(int)direction.x])
				{
					//take it as if the for loop never run by minusing the iterations count
					//and attempt to generate another random one
					i--;
					continue;
				}

				//remove the wall
				if (direction.x == pos.x)
				{
					//horizontal
					if (direction.y < pos.y) wallHorizontal[(int)direction.y][(int)direction.x] = true;
					else wallHorizontal[(int)pos.y][(int)direction.x] = true;
				}
				else
				{
					//vertical
					if (direction.x < pos.x) wallHorizontal[(int)direction.y][(int)direction.x] = true;
					else wallHorizontal[(int)direction.y][(int)pos.x] = true;
				}

				beenTo.Push(pos);

				//it is valid and we change our position to there
				pos = direction;

				//set the maze part to visited
				maze[(int)direction.y][(int)direction.x] = true;

				success = true;
			}

			if (!success)
			{
				pos = beenTo.Pop();
			}
			if(beenTo.Count == 0){
				break;
			}
		}

		bool[][][] wall = { wallHorizontal, wallHorizontal };
		return wall;
	}
}
