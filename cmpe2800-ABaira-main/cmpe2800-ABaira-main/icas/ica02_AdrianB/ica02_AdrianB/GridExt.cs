//*************************************************************************************************
//Submission Code:  2800_1242_A02                  
//Program:          ica02_AdrianB
//Description:      IEnumerable, Iterator Methoids, Defferred Execution
//Date:             Jan. 20, 2025
//Author:           Adrian Baira
//Course:           CMPE2800
//Class:            CNTA03
//**************************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ica02_AdrianB
{
    public class GridExt : IEnumerable
    {
        private (int x, int y) _grid;       //size of the grid
        private (int x, int y) _pos;        //position of cursor to check around

        /// <summary>
        /// Size of Grid
        /// </summary>
        /// <param name="grid">row and colomn of how big the grid should be</param>
        /// <exception cref="ArgumentException">If user puts -1 or 0 grid can't have a 0 or a negative grid</exception>
        public GridExt((int x,int y) grid)
        {
            if (grid.x <= 0 || grid.y <= 0)
                throw new ArgumentException("Grid can't be 0 or negative");
            _grid = grid;
            _pos = (0,0);
        }
        /// <summary>
        /// Set the cursor of where to search in the grid
        /// </summary>
        /// <param name="pos">x and y position of the grid like a graph (1,1) or (4,5)</param>
        /// <exception cref="ArgumentException">if the cursor is not in the grid paramaters then throw execption</exception>
        public void setCursor((int,int) pos)
        {
            if (pos.Item1 < 0 || pos.Item2 < 0 || pos.Item1 > _grid.x || pos.Item2 > _grid.y)
                throw new ArgumentException($"Cursor Position needs to be within the grid boundrys min: (0,0)  Max: ({_grid.x},{_grid.y})");
            _pos = pos;
        }
        /// <summary>
        /// will return -1, -1 if it is not within the bounds of the grid
        /// will return all positon that can be in the grid
        /// </summary>
        /// <returns>positions in the grid</returns>
        public IEnumerator GetEnumerator()
        {
            /*
             *  0   0   0
             *  0   0   1  <- (2,1)   y
             *  0   0   0
             *      x
             * cursor = (0,0)
             * Position of cursor + direction -> position around cursor
             * if position is 0,0 if x becomes smaller than 0 then its not on the grid
             * so if any x or y value becomes -1 then its not in bounds of the grid
             * _pos.x + 1 , _pos + 0 --> 0, 1
             * _pos.x + 0 , 
             * return 0,0
             * return 0,1
             * return 1,1
             * return 1,0
             */
    
            for (int checkx = -1; checkx <= 1; checkx++)
            {
                for(int checky = -1; checky <= 1; checky++)
                {
                    int x = _pos.x + checkx;
                    int y = _pos.y + checky;
                    if (x < 0 || x >= _grid.x || y < 0 || y >= _grid.y)
                        yield return (-1, -1);
                    else
                        yield return (x, y);
                }
            }
        }

       
    }
}
