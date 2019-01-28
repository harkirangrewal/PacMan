using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_FinalProject
{
    public partial class Form1 : Form
    {
        PacMan Eddie;
        int[,] Map = new int[27, 36];   // -1 : wall 0: path no food 1: Path with food
        Ghosts PinkyGhost;
        Ghosts2 BlinkyGhost;
        Ghosts3 InkyGhost;
        Ghosts4 ClydeGhost;

        //Arrays are tracking location of food pellets and if they have been eaten or not 
        bool[] foodPelletsEaten = new bool[4];
        Point[] foodPelletsLocation = new Point[4];

        public Form1()
        {
            ResetMap();
            newGame();
            InitializeComponent();

            //Pacman object is constructed and called eddie
            Eddie = new PacMan();

            //Ghost object is constructed and called Pinkyghost
            PinkyGhost = new Ghosts(9, 15, Color.Pink, -1);

            //Ghost object is constructed and called Blinkyghost
            BlinkyGhost = new Ghosts2(10, 15, Color.Red, 2);

            //Ghost object is constructed and called Inkyghost
            InkyGhost = new Ghosts3(11, 15, Color.LightSkyBlue, 1);

            //Ghost object is constructed and called Clydeghost
            ClydeGhost = new Ghosts4(12, 15, Color.Orange, 2);

            //The following is used for keyboard inout for pacman to move
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

        }

        public void newGame()
        {   
            //Food pellet location is declared/reset
            // The food pellets are then drawn in the paint function of the picture box
            for (int i = 0; i < 4; i++)
            {
                foodPelletsEaten[i] = false;
            }

            foodPelletsLocation[0].X = 2;
            foodPelletsLocation[0].Y = 4;


            foodPelletsLocation[1].X = 24;
            foodPelletsLocation[1].Y = 4;


            foodPelletsLocation[2].X = 2;
            foodPelletsLocation[2].Y = 25;

            foodPelletsLocation[3].X = 24;
            foodPelletsLocation[3].Y = 25;

        }
        public void GameOver()
        {
            //All variables are reset for both Eddie and all of the Ghosts
            ResetMap();
            Eddie.Set_x(13);
            Eddie.Set_y(28);
            Eddie.Set_lives(3);
            Eddie.Set_score(0);
            Eddie.Set_direction(-2);
            Eddie.energized = false;

            PinkyGhost.Set_x(9);
            PinkyGhost.Set_y(15);
            PinkyGhost.Set_direction(-1);

            BlinkyGhost.Set_x(10);
            BlinkyGhost.Set_y(15);
            BlinkyGhost.Set_direction(2);

            InkyGhost.Set_x(11);
            InkyGhost.Set_y(15);
            InkyGhost.Set_direction(1);

            ClydeGhost.Set_x(12);
            ClydeGhost.Set_y(15);
            ClydeGhost.Set_direction(2);

        }


        // The following class is created to encapsulate all the varialbes and methods required for the PacMan object in the game
        public class PacMan
        {   
            private int x;
            private int y;
            private int score;
            private int lives;
            private int direction;
            // Up: 1   Down:-1   Right:2  Left:-2
            public bool energized;

            public PacMan()
            {
                x = 13;
                y = 28;
                direction = -2;
                score = 0;
                lives = 3;
                energized = false;
            }

            // The following getters and setters are used for protected varialbes in the class
            public void Set_x(int a)
            {
                x = a;
            }

            public void Set_y(int b)
            {
                y = b;
            }

            public int Get_x()
            {
                return x;
            }

            public int Get_y()
            {
                return y;
            }

            public void Set_score(int iscore)
            {
                score = iscore;
            }

            public int Get_score()
            {
                return score;
            }

            public void Set_lives(int life)
            {
                lives = life;
            }

            public int Get_lives()
            {
                return lives;
            }

            public void Set_direction(int arrow_point)
            {
                direction = arrow_point;
            }

            public int Get_direction()
            {
                return direction;
            }

            public void LooseLife()
            {
                lives = lives - 1;
            }

            public void Move(int[,] Map)
            {
                // Up arrow is pressed
                if (direction == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        y = y - 1;
                        score = score + 1;
                        Map[x, y] = 0;
                    }
                }

                // Down arrow is pressed
                else if (direction == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        y = y + 1;
                        score = score + 1;
                        Map[x, y] = 0;
                    }
                }

                // right arrow is pressed
                else if (direction == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        x = x + 1;
                        score = score + 1;
                        Map[x, y] = 0;
                    }
                }

                // left arrow is pressed
                else if (direction == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        x = x - 1;
                        score = score + 1;
                        Map[x, y] = 0;
                    }
                }
            }

            public void Change_Direction(int[,] Map, int d)
            {
                // Up arrow is pressed
                if (d == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        direction = 1;
                    }
                }

                // Down arrow is pressed
                else if (d == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        direction = -1;
                    }
                }

                // right arrow is pressed
                else if (d == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        direction = 2;
                    }
                }

                // left arrow is pressed
                else if (d == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        direction = -2;
                    }
                }
            }

            public void DrawPacMan(Graphics g)
            {
                SolidBrush bYellow = new SolidBrush(Color.Yellow);
                Pen pBlack = new Pen(Color.Black, 2);

                g.FillEllipse(bYellow, x * 15, y * 15, 12, 12);

                // The following code is used for drawing PacMan's mouth
                //When Eddie is travelling towards the right
                if (direction == 2)
                {
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15 + 12, y * 15 + 12);
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15 + 12, y * 15 + 2);
                }

                //When Eddie is going towards the left
                else if (direction == -2)
                {
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15, y * 15 + 12);
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15, y * 15 + 2);
                }

                // When Eddie is travelling up
                else if (direction == 1)
                {
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15 + 2, y * 15 + 2);
                    g.DrawLine(pBlack, x * 15 + 7, y * 15 + 7, x * 15 + 12, y * 15 + 2);
                }

                //When Eddie is travelling down
                else if (direction == -1)
                {
                    g.DrawLine(pBlack, x * 15 + 6, y * 15 + 6, x * 15 + 12, y * 15 + 12);
                    g.DrawLine(pBlack, x * 15 + 6, y * 15 + 6, x * 15 +2, y * 15 + 12);
                }

            }

            public bool IsWinner(int [,] Map)
            {
                // The following double loop is used to check the game board and see where food pellets are 
                bool win;
                win = true;
                for (int i = 0; i < 27; i++)
                {
                    for (int j = 0; j < 36; j++)
                    {
                        // If the gameboard (Map) has food pellets, the boolean value "Win" stays false, and the loop breaks
                        if (Map[i, j] == 1)
                        {
                            win=false;
                            break;
                        }
                    }
                  //  break;
                }
                // If the gameboard does not have food pellets, the boolean value of true is returned
                return win;
            }
        }

        // The following classes are created for all the ghosts 
        public class Ghosts
        {
            protected int x;
            protected int y;
            protected int direction;
            public Color clr;
            Random Ran;

            public Ghosts()
            {
                Ran = new Random();
                x = 13;
                y = 15;
                direction = -2;
                clr = Color.Purple;
            }

            public Ghosts(int xCoord, int yCoord, Color col, int d)
            {
                Ran = new Random();
                x = xCoord;
                y = yCoord;
                clr = col;
                direction = d;
            }
            public void Set_x(int a)
            {
                x = a;
            }
            public void Set_y(int b)
            {
                y = b;
            }
            public int Get_x()
            {
                return x;
            }
            public int Get_y()
            {
                return y;
            }
            public void Set_direction(int arrow_point)
            {
                direction = arrow_point;
            }
            public int Get_direction()
            {
                return direction;
            }
            public void Move(int[,] Map)
            {
                if (direction == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        y = y - 1;
                    }
                }

                else if (direction == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        y = y + 1;

                    }
                }

                else if (direction == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        x = x + 1;

                    }
                }

                else if (direction == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        x = x - 1;

                    }
                }
            }
            public void Change_Direction(int[,] Map)
            {
                bool changeValid;

                changeValid = false;

                while (changeValid == false)
                {
                    int d = Ran.Next(100, 104);   // 100: up  101: down  102:left  103: right


                    if (d == 100)  // up
                    {
                        if (direction == -1)  // you can't switch up if the current direction is down
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y - 1] != -1)
                        {
                            direction = 1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 101)  // down
                    {
                        if (direction == 1)  // you can't switch down if the current direction is up
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y + 1] != -1)
                        {
                            direction = -1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 102)  // left
                    {
                        if (direction == 2)  // you can't switch left if the current direction is right
                        {
                            changeValid = false;

                        }
                        else if (Map[x - 1, y] != -1)
                        {
                            direction = -2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }


                    if (d == 103)  // right
                    {
                        if (direction == -2)  // you can't switch right if the current direction is left
                        {
                            changeValid = false;

                        }
                        else if (Map[x + 1, y] != -1)
                        {
                            direction = 2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                }


            }

            public void DrawGhosts(Graphics g)
            {
                SolidBrush bColor = new SolidBrush(clr);
                SolidBrush eyebrush = new SolidBrush(Color.Black);
                Pen mouthpen = new Pen(Color.Black, 2);

                g.FillEllipse(bColor, x * 15, y * 15, 12, 12);

                g.FillEllipse(eyebrush, x * 15 + 2, y * 15 + 3, 3, 3);
                g.FillEllipse(eyebrush, x * 15 + 7, y * 15 + 3, 3, 3);

                g.DrawLine(mouthpen, x * 15 + 3, y * 15 + 9, x * 15 + 9, y * 15 + 9);
            }
        }

        public class Ghosts2
        {
            protected int x;
            protected int y;
            protected int direction;
            public Color clr;
            Random Ran;

            public Ghosts2()
            {
                Ran = new Random();
                x = 13;
                y = 15;
                direction = -2;
                clr = Color.Purple;
            }

            public Ghosts2(int xCoord, int yCoord, Color col, int d)
            {
                Ran = new Random();
                x = xCoord;
                y = yCoord;
                clr = col;
                direction = d;
            }
            public void Set_x(int a)
            {
                x = a;
            }
            public void Set_y(int b)
            {
                y = b;
            }
            public int Get_x()
            {
                return x;
            }
            public int Get_y()
            {
                return y;
            }
            public void Set_direction(int arrow_point)
            {
                direction = arrow_point;
            }
            public int Get_direction()
            {
                return direction;
            }
            public void Move(int[,] Map)
            {
                if (direction == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        y = y - 1;
                    }
                }

                else if (direction == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        y = y + 1;

                    }
                }

                else if (direction == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        x = x + 1;

                    }
                }

                else if (direction == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        x = x - 1;

                    }
                }
            }
            public void Change_Direction(int[,] Map)
            {
                bool changeValid;

                changeValid = false;

                while (changeValid == false)
                {
                    int d = Ran.Next(100, 104);   // 100: up  101: down  102:left  103: right


                    if (d == 100)  // up
                    {
                        if (direction == -1)  // you can't switch up if the current direction is down
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y - 1] != -1)
                        {
                            direction = 1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 101)  // down
                    {
                        if (direction == 1)  // you can't switch down if the current direction is up
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y + 1] != -1)
                        {
                            direction = -1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 102)  // left
                    {
                        if (direction == 2)  // you can't switch left if the current direction is right
                        {
                            changeValid = false;

                        }
                        else if (Map[x - 1, y] != -1)
                        {
                            direction = -2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }


                    if (d == 103)  // right
                    {
                        if (direction == -2)  // you can't switch right if the current direction is left
                        {
                            changeValid = false;

                        }
                        else if (Map[x + 1, y] != -1)
                        {
                            direction = 2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                }


            }

            public void DrawGhosts(Graphics g)
            {
                SolidBrush bColor = new SolidBrush(clr);
                SolidBrush eyebrush = new SolidBrush(Color.Black);
                Pen mouthpen = new Pen(Color.Black, 2);

                g.FillEllipse(bColor, x * 15, y * 15, 12, 12);

                g.FillEllipse(eyebrush, x * 15 + 2, y * 15 + 3, 3, 3);
                g.FillEllipse(eyebrush, x * 15 + 7, y * 15 + 3, 3, 3);

                g.DrawLine(mouthpen, x * 15 + 3, y * 15 + 9, x * 15 + 9, y * 15 + 9);
            }
        }

        public class Ghosts3
        {
            protected int x;
            protected int y;
            protected int direction;
            public Color clr;
            Random Ran;

            public Ghosts3()
            {
                Ran = new Random();
                x = 13;
                y = 15;
                direction = -2;
                clr = Color.Purple;
            }

            public Ghosts3(int xCoord, int yCoord, Color col, int d)
            {
                Ran = new Random();
                x = xCoord;
                y = yCoord;
                clr = col;
                direction = d;
            }
            public void Set_x(int a)
            {
                x = a;
            }
            public void Set_y(int b)
            {
                y = b;
            }
            public int Get_x()
            {
                return x;
            }
            public int Get_y()
            {
                return y;
            }
            public void Set_direction(int arrow_point)
            {
                direction = arrow_point;
            }
            public int Get_direction()
            {
                return direction;
            }
            public void Move(int[,] Map)
            {
                if (direction == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        y = y - 1;
                    }
                }

                else if (direction == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        y = y + 1;

                    }
                }

                else if (direction == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        x = x + 1;

                    }
                }

                else if (direction == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        x = x - 1;

                    }
                }
            }
            public void Change_Direction(int[,] Map)
            {
                bool changeValid;

                changeValid = false;

                while (changeValid == false)
                {
                    int d = Ran.Next(100, 104);   // 100: up  101: down  102:left  103: right


                    if (d == 100)  // up
                    {
                        if (direction == -1)  // you can't switch up if the current direction is down
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y - 1] != -1)
                        {
                            direction = 1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 101)  // down
                    {
                        if (direction == 1)  // you can't switch down if the current direction is up
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y + 1] != -1)
                        {
                            direction = -1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 102)  // left
                    {
                        if (direction == 2)  // you can't switch left if the current direction is right
                        {
                            changeValid = false;

                        }
                        else if (Map[x - 1, y] != -1)
                        {
                            direction = -2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }


                    if (d == 103)  // right
                    {
                        if (direction == -2)  // you can't switch right if the current direction is left
                        {
                            changeValid = false;

                        }
                        else if (Map[x + 1, y] != -1)
                        {
                            direction = 2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                }


            }

            public void DrawGhosts(Graphics g)
            {
                SolidBrush bColor = new SolidBrush(clr);
                SolidBrush eyebrush = new SolidBrush(Color.Black);
                Pen mouthpen = new Pen(Color.Black, 2);

                g.FillEllipse(bColor, x * 15, y * 15, 12, 12);

                g.FillEllipse(eyebrush, x * 15 + 2, y * 15 + 3, 3, 3);
                g.FillEllipse(eyebrush, x * 15 + 7, y * 15 + 3, 3, 3);

                g.DrawLine(mouthpen, x * 15 + 3, y * 15 + 9, x * 15 + 9, y * 15 + 9);
            }
        }

        public class Ghosts4
        {
            protected int x;
            protected int y;
            protected int direction;
            public Color clr;
            Random Ran;

            public Ghosts4()
            {
                Ran = new Random();
                x = 13;
                y = 15;
                direction = -2;
                clr = Color.Purple;
            }

            public Ghosts4(int xCoord, int yCoord, Color col, int d)
            {
                Ran = new Random();
                x = xCoord;
                y = yCoord;
                clr = col;
                direction = d;
            }
            public void Set_x(int a)
            {
                x = a;
            }
            public void Set_y(int b)
            {
                y = b;
            }
            public int Get_x()
            {
                return x;
            }
            public int Get_y()
            {
                return y;
            }
            public void Set_direction(int arrow_point)
            {
                direction = arrow_point;
            }
            public int Get_direction()
            {
                return direction;
            }
            public void Move(int[,] Map)
            {
                if (direction == 1)
                {
                    if (Map[x, y - 1] != -1)
                    {
                        y = y - 1;
                    }
                }

                else if (direction == -1)
                {
                    if (Map[x, y + 1] != -1)
                    {
                        y = y + 1;

                    }
                }

                else if (direction == 2)
                {
                    if (Map[x + 1, y] != -1)
                    {
                        x = x + 1;

                    }
                }

                else if (direction == -2)
                {
                    if (Map[x - 1, y] != -1)
                    {
                        x = x - 1;

                    }
                }
            }
            public void Change_Direction(int[,] Map)
            {
                bool changeValid;

                changeValid = false;

                while (changeValid == false)
                {
                    int d = Ran.Next(100, 104);   // 100: up  101: down  102:left  103: right


                    if (d == 100)  // up
                    {
                        if (direction == -1)  // you can't switch up if the current direction is down
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y - 1] != -1)
                        {
                            direction = 1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 101)  // down
                    {
                        if (direction == 1)  // you can't switch down if the current direction is up
                        {
                            changeValid = false;

                        }
                        else if (Map[x, y + 1] != -1)
                        {
                            direction = -1;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                    if (d == 102)  // left
                    {
                        if (direction == 2)  // you can't switch left if the current direction is right
                        {
                            changeValid = false;

                        }
                        else if (Map[x - 1, y] != -1)
                        {
                            direction = -2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }


                    if (d == 103)  // right
                    {
                        if (direction == -2)  // you can't switch right if the current direction is left
                        {
                            changeValid = false;

                        }
                        else if (Map[x + 1, y] != -1)
                        {
                            direction = 2;
                            changeValid = true;

                        }
                        else
                        {
                            changeValid = false;
                        }

                    }

                }

            }

            public void DrawGhosts(Graphics g)
            {
                SolidBrush bColor = new SolidBrush(clr);
                SolidBrush eyebrush = new SolidBrush(Color.Black);
                Pen mouthpen = new Pen(Color.Black, 2);

                g.FillEllipse(bColor, x * 15, y * 15, 12, 12);

                g.FillEllipse(eyebrush, x * 15 + 2, y * 15 + 3, 3, 3);
                g.FillEllipse(eyebrush, x * 15 + 7, y * 15 + 3, 3, 3);

                g.DrawLine(mouthpen, x * 15 + 3, y * 15 + 9, x * 15 + 9, y * 15 + 9);
            }
        }

        // The following method is used to reset/draw the map for the gameboard
        public void ResetMap()
        {
            int i, j;
            //All Walls
            // The array is being set to a defualt value, so that all tiles are walls

            for (i = 0; i < 27; i++)
            {
                for (j = 0; j < 36; j++)
                {
                    Map[i, j] = -1;
                }
            }

            //Upper interior paths
            //1
            for (i = 2; i < 13; i++)
            {
                for (j = 2; j < 3; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //2
            for (i = 14; i < 25; i++)
            {
                for (j = 2; j < 3; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //3
            for (i = 2; i < 3; i++)
            {
                for (j = 3; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //4
            for (i = 7; i < 8; i++)
            {
                for (j = 3; j < 6; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //5
            for (i = 12; i < 13; i++)
            {
                for (j = 3; j < 6; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //6
            for (i = 14; i < 15; i++)
            {
                for (j = 3; j < 6; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //7
            for (i = 19; i < 20; i++)
            {
                for (j = 3; j < 6; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //8
            for (i = 24; i < 25; i++)
            {
                for (j = 3; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //9
            for (i = 3; i < 24; i++)
            {
                for (j = 6; j < 7; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //10
            for (i = 3; i < 6; i++)
            {
                for (j = 14; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //11
            for (i = 21; i < 24; i++)
            {
                for (j = 14; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //12
            for (i = 9; i < 18; i++)
            {
                for (j = 15; j < 16; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //13
            for (i = 9; i < 10; i++)
            {
                for (j = 16; j < 24; j++)
                {
                    Map[i, j] = 1;
                }
            }


            //2
            for (i = 13; i < 14; i++)
            {
                for (j = 2; j < 3; j++)
                {
                    Map[i, j] = 1;
                }
            }



            //16
            for (i = 6; i < 7; i++)
            {
                for (j = 7; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }

            for (i = 9; i < 10; i++)
            {
                for (j = 7; j < 10; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //20
            for (i = 17; i < 18; i++)
            {
                for (j = 7; j < 10; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //22
            for (i = 20; i < 21; i++)
            {
                for (j = 7; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //24
            for (i = 3; i < 6; i++)
            {
                for (j = 8; j < 9; j++)
                {
                    Map[i, j] = 1;
                }
            }
            //25

            //26
            for (i = 10; i < 12; i++)
            {
                for (j = 9; j < 10; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //28
            for (i = 15; i < 17; i++)
            {
                for (j = 9; j < 10; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //30
            for (i = 21; i < 24; i++)
            {
                for (j = 8; j < 9; j++)
                {
                    Map[i, j] = 1;
                }
            }

            //33
            for (i = 3; i < 6; i++)
            {
                for (j = 11; j < 12; j++)
                {
                    Map[i, j] = 1;
                }
            }
            //34
            for (i = 11; i < 12; i++)
            {
                for (j = 10; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }
            //35
            for (i = 15; i < 16; i++)
            {
                for (j = 10; j < 15; j++)
                {
                    Map[i, j] = 1;
                }
            }
            //Continue from 36
            /* for (i = ; i < ; i++)
             {
                 for (j = ; j < ; j++)
                 {
                     Map[i, j] = ;
                 }
             }*/


            for (i = 7; i < 9; i++)
            {
                for (j = 18; j < 19; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 10; i < 17; i++)
            {
                for (j = 21; j < 22; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 17; i < 18; i++)
            {
                for (j = 16; j < 24; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 18; i < 20; i++)
            {
                for (j = 18; j < 19; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 7; i < 12; i++)
            {
                for (j = 24; j < 25; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 15; i < 20; i++)
            {
                for (j = 24; j < 25; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 11; i < 12; i++)
            {
                for (j = 24; j < 29; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 15; i < 16; i++)
            {
                for (j = 24; j < 29; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 25; i++)
            {
                for (j = 28; j < 29; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 25; i++)
            {
                for (j = 33; j < 34; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 9; i < 10; i++)
            {
                for (j = 29; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 9; i < 12; i++)
            {
                for (j = 31; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 11; i < 12; i++)
            {
                for (j = 31; j < 33; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 17; i < 18; i++)
            {
                for (j = 29; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 15; i < 18; i++)
            {
                for (j = 31; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 15; i < 16; i++)
            {
                for (j = 31; j < 33; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 6; i++)
            {
                for (j = 22; j < 23; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 3; i++)
            {
                for (j = 22; j < 26; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 3; i < 4; i++)
            {
                for (j = 25; j < 28; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 3; i++)
            {
                for (j = 29; j < 33; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 6; i++)
            {
                for (j = 22; j < 23; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 2; i < 7; i++)
            {
                for (j = 31; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 21; i < 25; i++)
            {
                for (j = 22; j < 23; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 24; i < 25; i++)
            {
                for (j = 22; j < 26; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 23; i < 25; i++)
            {
                for (j = 25; j < 26; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 23; i < 24; i++)
            {
                for (j = 25; j < 28; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 24; i < 25; i++)
            {
                for (j = 28; j < 33; j++)
                {
                    Map[i, j] = 1;
                }
            }
            for (i = 20; i < 24; i++)
            {
                for (j = 31; j < 32; j++)
                {
                    Map[i, j] = 1;
                }
            }

        }

        // The following method is used to draw the energy pellets on the game board
        public void DrawEnergyPellets(Graphics g)
        {
            SolidBrush WhiteBrush = new SolidBrush(Color.White);
            for (int i = 0; i < 4; i++)
            {
                if (foodPelletsEaten[i] == false)  //not eaten
                {
                    g.FillEllipse(WhiteBrush, foodPelletsLocation[i].X * 15 + 1, foodPelletsLocation[i].Y * 15 + 1, 10, 10);
                }
            }
        }
        
        // The following block is used to draw the gameboard, PacMan and all of the ghosts
        private void pbGameBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush bBlue = new SolidBrush(Color.RoyalBlue);
            SolidBrush bBlack = new SolidBrush(Color.Black);
            SolidBrush bWhite = new SolidBrush(Color.White);

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 36; j++)
                {
                    if (Map[i, j] == -1) //Wall
                    {
                        g.FillRectangle(bBlue, i * 15, j * 15, 15, 15);
                    }
                    else if (Map[i, j] == 1)//Path
                    {
                        g.FillRectangle(bBlack, i * 15, j * 15, 15, 15);
                        g.FillEllipse(bWhite, i * 15 + 5, j * 15 + 5, 5, 5);
                    }
                }
            }

            DrawEnergyPellets(g);
            Eddie.DrawPacMan(e.Graphics);
            PinkyGhost.DrawGhosts(e.Graphics);
            BlinkyGhost.DrawGhosts(e.Graphics);
            InkyGhost.DrawGhosts(e.Graphics);
            ClydeGhost.DrawGhosts(e.Graphics);

        }

        // The following method is used to move the Pacman object (using some of the keys)
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                Eddie.Change_Direction(Map, 1);
            }
            else if (e.KeyCode == Keys.S)
            {
                Eddie.Change_Direction(Map, -1);
            }
            else if (e.KeyCode == Keys.A)
            {
                Eddie.Change_Direction(Map, -2);
            }
            else if (e.KeyCode == Keys.D)
            {
                Eddie.Change_Direction(Map, 2);
            }
        }

        private void EddieTimer_Tick(object sender, EventArgs e)
        {
            Eddie.Move(Map);
            for (int i = 0; i < 4; i++)
            {
                //When food pellet is not eaten and when the location of the food pellet is available Eddie becomes energized
                if (foodPelletsEaten[i] == false)  // not eaten
                {
                    if (Eddie.Get_x() == foodPelletsLocation[i].X && Eddie.Get_y() == foodPelletsLocation[i].Y)  // Pacman finds energty pellet
                    {
                        //Eddie becomes energized and score increases
                       Eddie.energized = true;
                       Eddie.Set_score(Eddie.Get_score() + 10);

                        //Energy pellet is not drawn as the value is true
                        foodPelletsEaten[i] = true;

                        //Ghost colour changes and energy timer begins
                        PinkyGhost.clr = Color.Magenta;
                        InkyGhost.clr = Color.Magenta;
                        BlinkyGhost.clr = Color.Magenta;
                        ClydeGhost.clr = Color.Magenta;

                        energyTimer.Start();
                    }
                }
            }

            //Eddie lives are outputted to a label
            lbllives.Text = Eddie.Get_lives().ToString();

            if (Eddie.Get_x() == PinkyGhost.Get_x() && Eddie.Get_y() == PinkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, Eddie's lives are decreased
                    //Eddie is set back to original position, Pinky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    PinkyGhost.Set_x(9);
                    PinkyGhost.Set_y(15);
                    PinkyGhost.Set_direction(-1);
                    PinkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {
                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    PinkyGhost.Set_x(9);
                    PinkyGhost.Set_y(15);
                    PinkyGhost.Set_direction(-1);
                    Eddie.Set_score(Eddie.Get_score() + 200);
                }        
            }

            if (Eddie.Get_x() == InkyGhost.Get_x() && Eddie.Get_y() == InkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Inky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    InkyGhost.Set_x(11);
                    InkyGhost.Set_y(15);
                    InkyGhost.Set_direction(1);
                    InkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    InkyGhost.Set_x(11);
                    InkyGhost.Set_y(15);
                    InkyGhost.Set_direction(1);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }

            if (Eddie.Get_x() == BlinkyGhost.Get_x() && Eddie.Get_y() == BlinkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Blinky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    BlinkyGhost.Set_x(10);
                    BlinkyGhost.Set_y(15);
                    BlinkyGhost.Set_direction(2);
                    BlinkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    BlinkyGhost.Set_x(10);
                    BlinkyGhost.Set_y(15);
                    BlinkyGhost.Set_direction(2);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }

            if (Eddie.Get_x() == ClydeGhost.Get_x() && Eddie.Get_y() == ClydeGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Clyde is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    ClydeGhost.Set_x(12);
                    ClydeGhost.Set_y(15);
                    ClydeGhost.Set_direction(2);
                    ClydeTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    ClydeGhost.Set_x(12);
                    ClydeGhost.Set_y(15);
                    ClydeGhost.Set_direction(2);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }
            

            //If Eddie runs out of lives message box shows game over
            if (Eddie.Get_lives() == 0)
            {
                EddieTimer.Stop();
                PinkyTimer.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                StaggersGhostStart.Stop();
                
                this.Hide();
                GameOverForm GameOverForm = new GameOverForm();
                GameOverForm.ShowDialog();
                this.Close();
                
            }

            bool Winner;
            Winner = Eddie.IsWinner(Map);

            if (Winner == true)
            {
                EddieTimer.Stop();
                StaggersGhostStart.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                PinkyTimer.Stop();
                this.Hide();
                Winner You_Win = new Winner();
                You_Win.ShowDialog();
                this.Close();
                
            }
    
            lblScore.Text = Eddie.Get_score().ToString();
            pbGameBoard.Invalidate();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // When the play button is pressed, the timers start, and the new game button is enabled
            EddieTimer.Start();
            StaggersGhostStart.Start();
            btnNewGame.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PinkyTimer_Tick(object sender, EventArgs e)
        {
            PinkyGhost.Change_Direction(Map);
            PinkyGhost.Move(Map);

            if (Eddie.Get_x() == PinkyGhost.Get_x() && Eddie.Get_y() == PinkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Pinky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    PinkyGhost.Set_x(9);
                    PinkyGhost.Set_y(15);
                    PinkyGhost.Set_direction(-1);
                    PinkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    PinkyGhost.Set_x(9);
                    PinkyGhost.Set_y(15);
                    PinkyGhost.Set_direction(-1);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

           }

            //If Eddie runs out of lives message box shows game over
            if (Eddie.Get_lives() == 0)
            {
                EddieTimer.Stop();
                PinkyTimer.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                StaggersGhostStart.Stop();

                this.Hide();
                GameOverForm GameOverForm = new GameOverForm();
                GameOverForm.ShowDialog();
                this.Close();

            }

            pbGameBoard.Invalidate();
        }

        private void BlinkyTimer_Tick(object sender, EventArgs e)
        {
            BlinkyGhost.Change_Direction(Map);
            BlinkyGhost.Move(Map);

            if (Eddie.Get_x() == BlinkyGhost.Get_x() && Eddie.Get_y() == BlinkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Blinky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    BlinkyGhost.Set_x(10);
                    BlinkyGhost.Set_y(15);
                    BlinkyGhost.Set_direction(2);
                    BlinkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    BlinkyGhost.Set_x(10);
                    BlinkyGhost.Set_y(15);
                    BlinkyGhost.Set_direction(2);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }

            //If Eddie runs out of lives message box shows game over
            if (Eddie.Get_lives() == 0)
            {
                EddieTimer.Stop();
                PinkyTimer.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                StaggersGhostStart.Stop();
                this.Hide();
                GameOverForm GameOverForm = new GameOverForm();
                GameOverForm.ShowDialog();
                this.Close();

            }

            pbGameBoard.Invalidate();
        }

        private void InkyTimer_Tick(object sender, EventArgs e)
        {
            InkyGhost.Change_Direction(Map);
            InkyGhost.Move(Map);

            if (Eddie.Get_x() == InkyGhost.Get_x() && Eddie.Get_y() == InkyGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Inky is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    InkyGhost.Set_x(11);
                    InkyGhost.Set_y(15);
                    InkyGhost.Set_direction(1);
                    InkyTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    InkyGhost.Set_x(11);
                    InkyGhost.Set_y(15);
                    InkyGhost.Set_direction(1);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }

            //If Eddie runs out of lives message box shows game over
            if (Eddie.Get_lives() == 0)
            {
                EddieTimer.Stop();
                PinkyTimer.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                StaggersGhostStart.Stop();
                this.Hide();
                GameOverForm GameOverForm = new GameOverForm();
                GameOverForm.ShowDialog();
                this.Close();
            }
        }

        private void ClydeTimer_Tick(object sender, EventArgs e)
        {
            ClydeGhost.Change_Direction(Map);
            ClydeGhost.Move(Map);

            if (Eddie.Get_x() == ClydeGhost.Get_x() && Eddie.Get_y() == ClydeGhost.Get_y())
            {
                if (Eddie.energized == false)
                {
                    //If Eddie runs into a ghost without energy pellets, eddies lives are decreased
                    //Eddie is set back to original position, Clyde is set to orignial position, directions are reset
                    Eddie.Set_lives(Eddie.Get_lives() - 1);
                    Eddie.Set_x(13);
                    Eddie.Set_y(28);
                    Eddie.Set_direction(-2);
                    ClydeGhost.Set_x(12);
                    ClydeGhost.Set_y(15);
                    ClydeGhost.Set_direction(2);
                    ClydeTimer.Stop();
                    StaggersGhostStart.Start();

                }
                else if (Eddie.energized == true)
                {

                    //Eddie is energized and runs into a ghost the ghost is reset and Eddie gains points
                    ClydeGhost.Set_x(12);
                    ClydeGhost.Set_y(15);
                    ClydeGhost.Set_direction(2);
                    Eddie.Set_score(Eddie.Get_score() + 200);

                }

            }

            //If Eddie runs out of lives message box shows game over
            if (Eddie.Get_lives() == 0)
            {
                EddieTimer.Stop();
                PinkyTimer.Stop();
                InkyTimer.Stop();
                BlinkyTimer.Stop();
                ClydeTimer.Stop();
                StaggersGhostStart.Stop();
                this.Hide();
                GameOverForm GameOverForm = new GameOverForm();
                GameOverForm.ShowDialog();
                this.Close();
            }


        }

        private void energyTimer_Tick(object sender, EventArgs e)
        {
            // When the energy timer ticks
            // Eddie becomes un-energized
            Eddie.energized = false;

            // The color of the ghosts changes
            PinkyGhost.clr = Color.Pink;
            BlinkyGhost.clr = Color.Red;
            InkyGhost.clr = Color.LightSkyBlue;
            ClydeGhost.clr = Color.Orange;

            // The energy time stops
            energyTimer.Stop();
        }

        private void StaggersGhostStart_Tick(object sender, EventArgs e)
        {
            // This timer is used to ensure that the ghosts' movement is delayed when the game first begins
            PinkyTimer.Start();
            InkyTimer.Start();
            BlinkyTimer.Start();
            ClydeTimer.Start();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // When the new game button is pressed, the whole game is reset
            GameOver();
           
            newGame();

            // Resetting Eddie's score
            Eddie.Set_score(0);
            lblScore.Text = Eddie.Get_score().ToString();

            // Resetting Eddie's number of lives
            Eddie.Set_lives(3);
            lbllives.Text = Eddie.Get_lives().ToString();

            EddieTimer.Start();
            StaggersGhostStart.Start();

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // When the pause button is pressed, all of the timers are stopped
            EddieTimer.Stop();
            PinkyTimer.Stop();
            InkyTimer.Stop();
            BlinkyTimer.Stop();
            ClydeTimer.Stop();
            StaggersGhostStart.Stop();

            this.Hide(); 
            PauseForm PauseForm = new PauseForm();
            PauseForm.ShowDialog();
            this.Show();
    
            btnNewGame.Enabled = true;
        }

 
    }
}
