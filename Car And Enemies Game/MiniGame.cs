using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiMedia_MiniGame__Full_Edition_
{
      
    public partial class MiniGame : Form
    {
        public MiniGame()
        {
            Size = new Size(400, 600);
            
            Paint += MiniGame_Paint;
            Load += MiniGame_Load;
            timer.Tick += Timer_Tick;
            timer.Interval = 15;
            timer.Start();
            KeyDown += MiniGame_KeyDown;
        }

        bool isLeft = false, isRight = false;
        bool CreateTime = false;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        List<RoadMarks> roadMarks = new List<RoadMarks>();
        List<RoadMarks> DynamicRoadMarks = new List<RoadMarks>();
        List<Car> cars = new List<Car>();
        List<Enemy> enemies = new List<Enemy>();

        Bitmap Screen;

        int tickCount = 0;

        public class RoadMarks
        {
            public int X, Y, Width, Height;
            public int directionY = 1;
            public Color color;
        }
        public class Object
        {
            public int X, Y;
            public Bitmap img;
        }
        public class Car : Object
        {

        }
        public class Enemy : Object
        {
            public int DirectionY = 1;
        }
        public class LeftEnemy : Enemy
        {

        }
        public class RightEnemy : Enemy
        {

        }
        private void MiniGame_Load(object? sender, EventArgs e)
        {
            Screen = new Bitmap(ClientSize.Width, ClientSize.Height);
            CreateWhiteMarks();
            CreateYellowMarks();
            CreateCar();
        }


        private void MiniGame_KeyDown(object? sender, KeyEventArgs e)
        {
            Car Player = cars[0];

            // CHECKS IF PLAYER IS ALREADY LEFT

            if (Player.X <= 60)
                isLeft = true;
            else
                isLeft = false;

            // CHECKS IF PLAYER IS ALREADY RIGHT

            if (Player.X >= 242)
                isRight = true;
            else
                isRight = false;
    
            switch (e.KeyCode)
            {
                case Keys.A: // Left
                    if (!isLeft)
                        Player.X -= 12;
                    break;

                case Keys.D: // Right
                    if(!isRight)
                        Player.X += 12;
                    break;
                case Keys.Escape:
                    Close();
                    break;
               
            }
            DrawDoubleBuffer(CreateGraphics());
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (isHit(cars[0]) == true) 
            { 
                timer.Stop();
                GameOver gameover = new GameOver();
                Hide();
                gameover.ShowDialog();
                Close();
            }
                
            Text = "Score: " + tickCount / 10+ "";
            
            if (tickCount % 25 == 0)
                CreateYellowMarks();
  
            if (tickCount == 321)
                CreateTime = true;
            if (CreateTime == true)
            {
                if (tickCount % 321 == 0)
                    CreateLeftEnemy();
            }
     
            if (tickCount % 500 == 0)
                CreateRightEnemy();
            
            tickCount++;
            animateRoad();
            animateEnemy();
            DrawDoubleBuffer(CreateGraphics());
        }


        private void MiniGame_Paint(object? sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }
        void CreateYellowMarks()
        {
            RoadMarks LeftYellowMark = new RoadMarks();
            LeftYellowMark.X = 100;
            LeftYellowMark.Width = 10;
            LeftYellowMark.Height = 65;
            LeftYellowMark.Y = 0 - LeftYellowMark.Height;
            LeftYellowMark.color = Color.Yellow;

            DynamicRoadMarks.Add(LeftYellowMark);

            RoadMarks RightYellowMark = new RoadMarks();
            RightYellowMark.X = 290;
            RightYellowMark.Width = 10;
            RightYellowMark.Height = 65;
            RightYellowMark.Y = 0 - RightYellowMark.Height;
            RightYellowMark.color = Color.Yellow;

            DynamicRoadMarks.Add(RightYellowMark);

        }
        void CreateWhiteMarks()
        {
            RoadMarks LeftMark = new RoadMarks();
            LeftMark.X = 0;
            LeftMark.Y = 0;
            LeftMark.Width = 10;
            LeftMark.Height = ClientSize.Height;
            LeftMark.color = Color.White;

            roadMarks.Add(LeftMark);

            RoadMarks MiddleMark = new RoadMarks();
            MiddleMark.X = ClientSize.Width / 2 - MiddleMark.Width;
            MiddleMark.Y = 0;
            MiddleMark.Width = 10;
            MiddleMark.Height = ClientSize.Height;
            MiddleMark.color = Color.White;

            roadMarks.Add(MiddleMark);

            RoadMarks RightMark = new RoadMarks();
            RightMark.Width = 10;
            RightMark.X = ClientSize.Width - RightMark.Width;
            RightMark.Y = 0;
            RightMark.Height = ClientSize.Height;
            RightMark.color = Color.White;

            roadMarks.Add(RightMark);
        }
        void CreateCar()
        {
            Car Player = new Car();
            Player.X = 60;
            Player.img = new Bitmap("car1.png");
            Player.Y = ClientSize.Height - Player.img.Height - 20;
            Player.img.MakeTransparent(Player.img.GetPixel(0, 0));
            cars.Add(Player);
        }
        // CREATE ENEMY
        void CreateLeftEnemy()
        {
            LeftEnemy enemy = new LeftEnemy();
            enemy.X = 60;

            enemy.img = new Bitmap("car2.png");
            enemy.Y = 0 - enemy.img.Height;
            enemy.img.MakeTransparent(enemy.img.GetPixel(0, 0));
            enemies.Add(enemy);
        }
        void CreateRightEnemy()
        {
            RightEnemy enemy = new RightEnemy();
            enemy.X = 245;

            enemy.img = new Bitmap("car2.png");
            enemy.Y = 0 - enemy.img.Height;
            enemy.img.MakeTransparent(enemy.img.GetPixel(0, 0));
            enemies.Add(enemy);
        }
        // ANIMATE
        void animateEnemy()
        {
            for (int i = 0; i < enemies.Count(); i++)
            {
                Enemy tmp = enemies[i];
                tmp.X += 0;
                tmp.Y += tmp.DirectionY * 5;
            }
        }
        void animateRoad()
        {
            for (int i = 0; i < DynamicRoadMarks.Count(); i++)
            {
                RoadMarks tmp = DynamicRoadMarks[i];
                tmp.X += 0;
                tmp.Y += tmp.directionY * 5;
            }
        }
        // CREATE GRAPHICS
        void DrawScene(Graphics graphics)
        {
            graphics.Clear(Color.DimGray);
            for (int i = 0; i < roadMarks.Count(); i++)
            {
                SolidBrush solidBrush = new SolidBrush(roadMarks[i].color);
                graphics.FillRectangle(solidBrush, roadMarks[i].X, roadMarks[i].Y, roadMarks[i].Width, roadMarks[i].Height);
            }
            for (int i = 0; i < DynamicRoadMarks.Count(); i++)
            {
                SolidBrush solidBrush = new SolidBrush(DynamicRoadMarks[i].color);
                graphics.FillRectangle(solidBrush, DynamicRoadMarks[i].X, DynamicRoadMarks[i].Y, DynamicRoadMarks[i].Width, DynamicRoadMarks[i].Height);
            }
            for (int i = 0; i < cars.Count(); i++)
            {
                Car tmp = cars[i];
                graphics.DrawImage(cars[i].img, cars[i].X, cars[i].Y);
            }
            for (int i = 0; i < enemies.Count(); i++)
            {
                Enemy tmp = enemies[i];
                graphics.DrawImage(enemies[i].img, enemies[i].X, enemies[i].Y);
            }
        }
        void DrawDoubleBuffer(Graphics graphics)
        {
            Graphics graphics1 = Graphics.FromImage(Screen);
            DrawScene(graphics1);
            graphics.DrawImage(Screen, 0, 0);
        }
        // GAME LOGIC
        bool isHit(Car Player)
        {
           
            for (int i = 0; i < enemies.Count(); i++)
            {
                if                  (Player.X >= enemies[i].X && 
                    Player.X  <= (enemies[i].X + enemies[i].img.Width)
                                    && Player.Y >= enemies[i].Y 
                    && Player.Y <= (enemies[i].Y + enemies[i].img.Height))
                {
                    return true;
                }
            }
            return false;        
        }
    }
}

