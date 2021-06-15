using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
	public int sizeOfMaze = 10;
	public GameObject wall;
	void Start()
	{ 
		bool[][,] mazeWall = generateMaze();
		bool[,] mazeWallHorizontal = mazeWall[0];
		bool[,] mazeWallVertical = mazeWall[1];
		for (int i = 0; i < sizeOfMaze; i++)
		{
			for (int j = 0; j < sizeOfMaze; j++)
			{
				if(mazeWallHorizontal[i,j]){
					Instantiate(wall, new Vector3(i, 5.1f, j), Quaternion.identity);
				}
			}
		}
	}

	void Update()
	{

	}

	bool[][,] generateMaze()
	{
		//first index is vertical, second is horizontal (stores if the place has been visited)
		//see diagram below jst in case
		//           2nd index
		//1st index [[][][][]]
		//1st index [[][][][]]
		bool[,] maze = new bool[sizeOfMaze, sizeOfMaze];
		maze[0,0] = true; maze[1,0] = true;

		//to store if a wall exist (values are inverted btw so false means wall exists since bool is false by default)
		bool[,] wallHorizontal = new bool[sizeOfMaze, sizeOfMaze];
		bool[,] wallVertical = new bool[sizeOfMaze, sizeOfMaze];

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
			print(pos);

			int[] directionsBeenTo = { };
			bool success = false;

			for (int i = 0; i < 4; i++)
			{
				int rand = Random.Range(0, 3);
				Vector2 direction = pos + directions[rand];

				if (direction.x < 0 || direction.x > sizeOfMaze - 1 || direction.y < 0 || direction.y > sizeOfMaze - 1)
				{
					//checking if we went out of the maze 
					//what im doing here is explained below too 
					// (i dw to combine for loop just to save some computational power in not running the for loop)
					i--;
					continue;
				}

				bool checkedBefore = false; //if we have been to this location (in this for loop (since its random))
				foreach (int j in directionsBeenTo)
				{
					if (j == rand)
					{
						checkedBefore = true;
						break;
					}
				}

				if (checkedBefore)
				{
					//take it as if the for loop never run by minusing the iterations count
					//and attempt to generate another random one
					i--;
					continue;
				}

				if(maze[(int)direction.y, (int)direction.x]){
					directionsBeenTo[i] = rand;
					i --;
					continue;
				}

				//remove the wall
				if (direction.x == pos.x)
				{
					//horizontal
					if (direction.y < pos.y) wallHorizontal[(int)direction.y, (int)direction.x] = true;
					else wallHorizontal[(int)pos.y, (int)direction.x] = true;
				}
				else
				{
					//vertical
					if (direction.x < pos.x) wallHorizontal[(int)direction.y, (int)direction.x] = true;
					else wallHorizontal[(int)direction.y, (int)pos.x] = true;
				}

				beenTo.Push(pos);

				//it is valid and we change our position to there
				pos = direction;

				//set the maze part to visited
				maze[(int)direction.y, (int)direction.x] = true;

				success = true;
			}

			if (!success)
			{
				pos = beenTo.Pop();
			}
			if (beenTo.Count == 0)
			{
				break;
			}
		}

		bool[][,] wall = new bool[2][,];
		wall[0] = wallHorizontal;
		wall[1] = wallVertical;
		return wall;
	}
}
