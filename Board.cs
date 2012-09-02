using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Halma_v0._3
{
    class Board : Control
    {
        static Position[,] positions = new Position[16, 16];
        private static bool isGeneratedStartPawnSet = false;
        private static int playersCount = 4;
        private Position tempPos;

        // Upper left corner of the board  
        internal int startX;
        internal int startY;

        // Size of the boards squares
        internal int cellWidth;

        // Pieces size
        private static int SIZE = 0;

        private Position selectedPosition;

        public void newGame(int Players)
        {
            clearBoard();
            isGeneratedStartPawnSet = false;
            playersCount = Players;
        }

        private void clearBoard()
        {
            positions = new Position[16, 16];
        }

        protected override void OnPaint(PaintEventArgs ev)
        {
            Graphics g = ev.Graphics;
            Size d = ClientSize;
            int marginX;
            int marginY;
            int incValue;

            // Calculates the increments so that we can get a squared board multiplayer
 
            if (d.Width < d.Height)
            {
                marginX = 0;
                marginY = (d.Height - d.Width) / 2;

                incValue = d.Width / 16;
            }
            else
            {
                marginX = (d.Width - d.Height) / 2;
                marginY = 0;

                incValue = d.Height / 16;
            }
            startX = marginX;
            startY = marginY;
            cellWidth = incValue;

            drawBoard(g, marginX, marginY, incValue);
            if (isGeneratedStartPawnSet == false)
            {
                if (playersCount == 2)
                    generateStartPawnSet2Players();
                else
                    generateStartPawnSet4Players();

                isGeneratedStartPawnSet = true;
            }
            if (isGeneratedStartPawnSet == true && (playersCount == 2 || playersCount == 4))
            {
                drawPieces(g, marginX, marginY, incValue);
                Thread.Sleep(100);
            }
            base.OnPaint(ev);
        }

        private void drawBoard(Graphics g, int marginX, int marginY, int incValue)
        {
            int a = incValue - 1;

            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                {
                    drawCell(g, marginX, marginY, incValue, a, y, x);
                }
        }

        private void drawCell(Graphics g, int marginX, int marginY, int incValue, int a, int y, int x)
        {
            Brush cellColor;
            if (isPositionEven(y, x))
                cellColor = new SolidBrush(Color.White);
            else
                cellColor = new SolidBrush(Color.Black);

            if (validateSelectedPosition(y, x))
                cellColor = new SolidBrush(Color.LightGreen);

            if (isGeneratedStartPawnSet == false)
                positions[x, y] = new Position();

            g.FillRectangle(cellColor, marginX + x * incValue, marginY + y * incValue, a, a);
        }

        private static bool isPositionEven(int y, int x)
        {
            return (x + y) % 2 == 0;
        }

        private bool validateSelectedPosition(int y, int x)
        {
            return selectedPosition != null && isPositionsEqual(selectedPosition, positions[x, y]) && selectedPosition.isSelected == true;
        }

        private void generateStartPawnSet4Players()
        {
            Player firstPlayer = new Player(13, 4, false, Color.LightCoral); // up-left
            Player secondPlayer = new Player(13, 12, false, Color.Red); // up-right
            Player thirdPlayer = new Player(13, 2, false, Color.SteelBlue); // left-down
            Player fourthPlayer = new Player(13, 14, false, Color.Indigo); // right-down

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (y <= 3)
                    {
                        if (firstPlayer.firstPawnXposition > x)
                            addPawn(firstPlayer, y, x);
                        else if (secondPlayer.firstPawnXposition <= x)
                            addPawn(secondPlayer, y, x);
                    }
                    else if (y >= 12)
                    {
                        if (thirdPlayer.firstPawnXposition > x)
                            addPawn(thirdPlayer, y, x);
                        else if(fourthPlayer.firstPawnXposition <= x) 
                            addPawn(fourthPlayer, y, x);
                    }
                    positions[x, y].setPosition(x, y);
                }
                changeFirstPawnXposition(firstPlayer, secondPlayer, thirdPlayer, fourthPlayer, y);
            }
        }

        private void generateStartPawnSet2Players()
        {
            Player firstPlayer = new Player(19, 5, false, Color.LightCoral); // up-left
            Player secondPlayer = new Player(19, 14, false, Color.Indigo); // right-down

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (y <= 4)
                    {
                        if (firstPlayer.firstPawnXposition > x)
                            addPawn(firstPlayer, y, x);
                    }
                    else if (y >= 11)
                    {
                        if (secondPlayer.firstPawnXposition <= x)
                            addPawn(secondPlayer, y, x);
                    }
                    positions[x, y].setPosition(x, y); ;
                }
                changeFirstPawnXposition(firstPlayer, secondPlayer, y);
            }
        }

        private static void addPawn(Player firstPlayer, int y, int x)
        {
            Pawn pawn = new Pawn();
            pawn.setColor(firstPlayer.color);
            positions[x, y].setPawn(pawn);
            firstPlayer.quantityOfPawns--;
        }

        private static void changeFirstPawnXposition(Player firstPlayer, Player secondPlayer, Player thirdPlayer, Player fourthPlayer, int y)
        {
            if (!firstPlayer.isPawnsSetted && !secondPlayer.isPawnsSetted && y != 0)
            {
                firstPlayer.firstPawnXposition--;
                secondPlayer.firstPawnXposition++;
            }
            else if (!thirdPlayer.isPawnsSetted && !fourthPlayer.isPawnsSetted && y >= 12 && y < 14)
            {
                thirdPlayer.firstPawnXposition++;
                fourthPlayer.firstPawnXposition--;
            }
        }

        private static void changeFirstPawnXposition(Player firstPlayer, Player secondPlayer, int y)
        {
            if (!firstPlayer.isPawnsSetted && y != 0)
            {
                firstPlayer.firstPawnXposition--;
            }
            else if (!secondPlayer.isPawnsSetted && y >= 11 && y < 14)
            {
                secondPlayer.firstPawnXposition--;
            }
        }

        private void drawPieces(Graphics g, int marginX, int marginY, int incValue)
        {
            Brush pieceColor;
            for (int column = 0; column < 16; column++)
            {
                for (int row = 0; row < 16; row++)
                {
                    if (positions[row, column].isEmpty == false)
                    {
                        int a = incValue - 1 - 2 * SIZE;
                        int x = SIZE + marginX + row * incValue;
                        int y = SIZE + marginY + column * incValue;
                        pieceColor = new SolidBrush(positions[row, column].getPawn().getColor());
                        g.FillEllipse(pieceColor, x, y, a, a);
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Position selectedPosition = getPiecePosition(e.X, e.Y);
            if (isPositionsEqual(selectedPosition, tempPos))
                deselectPawn();
            else if (selectedPosition.isEmpty == false)
                selectPawn(selectedPosition);
            else if (selectedPosition.isEmpty == true && tempPos != null)
                movePawnToEmptySpace(selectedPosition);
        }

        private bool isPositionsEqual(Position pos1, Position pos2)
        {
            if (pos1 != null && pos2 != null)
            {
                if (pos1.getX() == pos2.getX() && pos1.getY() == pos2.getY())
                    return true;
            }
            return false;
        }

        private void movePawnToEmptySpace(Position selectedPosition)
        {
            int distanceX; int distanceY;
            setDiferencesXY(selectedPosition, out distanceX, out distanceY);

            if (isMoveAllowed(selectedPosition, distanceX, distanceY))
                movePawn(selectedPosition);
        }

        private void setDiferencesXY(Position currPos, out int differenceX, out int differenceY)
        {
            differenceX = tempPos.getX() - currPos.getX();
            differenceY = tempPos.getY() - currPos.getY();
        }
        
        private bool isMoveAllowed(Position selectedPosition, int distanceX, int distanceY)
        {
            return checkMoveAllowance(selectedPosition, distanceX, distanceY, 1) || (checkMoveAllowance(selectedPosition, distanceX, distanceY, 2) && checkForNearbyPieces(selectedPosition, distanceX, distanceY));
        }

        private bool checkMoveAllowance(Position selectedPosition, int distanceX, int distanceY, int radius)
        {
            return checkPosition(distanceX, distanceY, radius) && selectedPosition.isEmpty;
        }

        private void movePawn(Position currPos)
        {
            currPos.setPawn(tempPos.getPawn()); // set pawn on position
            deletePawn();
        }

        private void deletePawn()
        {
            foreach (Position position in positions)
            {
                if (tempPos != null && isPositionsEqual(position, tempPos))
                {
                    position.isEmpty = true;
                    deselectPawn();
                }
            }
        }

        private static bool checkForNearbyPieces(Position selectedPosition, int distanceX, int distance)
        {
            return !positions[selectedPosition.getX() + ((distanceX != 0 ? (distanceX > 0 ? distanceX - 1 : distanceX + 1) : 0)),
                                    selectedPosition.getY() + ((distance != 0 ? (distance > 0 ? distance - 1 : distance + 1) : 0))].isEmpty;
        }

        private void deselectPawn()
        {
            selectedPosition.isSelected = false;
            tempPos = null;
            Invalidate();
            Update();
        }

        private bool checkPosition(int differenceX, int differenceY, int range)
        {
            int sqrX = differenceX * differenceX, sqrY = differenceY * differenceY, sqrRange = range * range;
            return (sqrX == 0 || sqrX == sqrRange) && (sqrY == 0 || sqrY == sqrRange);
        }

        private void selectPawn(Position position)
        {
            tempPos = position;
            selectedPosition = position;
            selectedPosition.isSelected = true;
            Invalidate();
            Update();
        }

        private Position getPiecePosition(int currentX, int currentY)
        {
            Position response = null;
            for (int column = 0; column <= 16; column++)
            {
                for (int row = 0; row <= 16; row++)
                {
                    if (SIZE + startX + row * cellWidth >= currentX
                        && SIZE + startX + ((row > 0) ? row - 1 : row) * cellWidth <= currentX)
                    {
                        if (SIZE + startY + column * cellWidth >= currentY
                            && SIZE + startY + ((column > 0) ? column - 1 : row) * cellWidth <= currentY)
                        {
                            Position position = positions[row - 1, column - 1];
                            response = position;
                            Console.WriteLine("Position X = " + position.getX() + " Position Y = " + position.getY());
                        }
                    }
                }
            }
            return response;
        }
    }
}
