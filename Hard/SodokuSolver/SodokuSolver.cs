using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Hard.SodokuSolver
{
    class SodokuSolver
    {

      

        public void SolveSudoku(char[][] board)
        {
            solveSudoku(board);
        }

        private bool solveSudoku(char[][] board)
        {
            Cell emptyCell = getFirstEmptyCell(board);

            if (emptyCell == null)
            {
                return true;
            }

            List<char> candidates = getCandidates(board, emptyCell);

            foreach (char candidate in candidates)
            {
                board[emptyCell.Row][emptyCell.Column] = candidate;
                if (solveSudoku(board))
                {
                    return true;
                }
            }

            board[emptyCell.Row][emptyCell.Column] = '.';

            return false;
        }


        private class Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }
        private Cell getFirstEmptyCell(char[][] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                for(int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        return new Cell
                        {
                            Row = i,
                            Column = j
                        };
                    }
                }
            }
            return null;
        }

        private List<char> getCandidates(char[][] board, Cell cell)
        {
            List<char> candidates = new List<char>();
            for(int i = 1; i <= 9; i++)
            {
                candidates.Add(Char.Parse(i.ToString()));
            }

            //Rows and Column
            for(int i = 0; i < board.Length; i++)
            {

                candidates.Remove(board[i][cell.Column]);
                candidates.Remove(board[cell.Row][i]);
            }

            //Sector
            int sectorRow = cell.Row / 3 * 3;
            int sectorColumn = cell.Column / 3 * 3;

            for(int i = sectorRow; i < sectorRow + 3; i++)
            {
                for(int j = sectorColumn; j < sectorColumn + 3; j++)
                {
                    candidates.Remove(board[i][j]);
                }
            }
            return candidates;

        }
    }
}
