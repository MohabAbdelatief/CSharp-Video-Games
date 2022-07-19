namespace The_Adventures_of_Paul
{
    public partial class Form1 : Form
    {
        // OBJECTS
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Bitmap Screen;

        Background background = new Background();
        // GROUND AND PLATFORMS
        Ground TileGroundLeft = new Ground();
        Ground TileGroundRight = new Ground();
        Ground PlatformX = new Ground();
        Ground PlatformY = new Ground();
        // DECOR 
        Decor Tree = new Decor();
        Decor Bush = new Decor();
        Decor Rock = new Decor();
        Decor Bench = new Decor();
        Decor Bench2 = new Decor();
        Decor Fountain = new Decor();
        Decor Fountain2 = new Decor();
        Decor Bushes = new Decor();
        // Enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();
        Bullet bullet;
        Laser laser = new Laser();
        // LADDER AND INTERACTABLE OBJECTS
        Ladder Ladder = new Ladder();
        Paul player = new Paul();
        ELevator elevator = new ELevator();
        // LISTS
        List<Ground> grounds = new List<Ground>();
        List<Decor> decors = new List<Decor>();
        List<Ladder> ladders = new List<Ladder>();
        List<Enemy> enemies = new List<Enemy>();
        List<Bullet> bullets = new List<Bullet>();
        List<Laser> lasers = new List<Laser>();
        // IMAGE ARRAYS
        List<String> images = new List<string>(new String[] { "p1.bmp", "p2.bmp", "p3.bmp", "p4.bmp", "p5.bmp", "p6.bmp", });
        List<String> imagesLeft = new List<string>(new String[] { "p1left.bmp", "p2left.bmp", "p3left.bmp", "p4left.bmp", "p5left.bmp", "p6left.bmp", });
        List<String> Jump = new List<string>(new String[] { "jump1.png", "jump2.bmp", "jump3.bmp", "jump4.bmp", });
        List<String> JumpLeft = new List<string>(new String[] { "jump1left.png", "jump2left.bmp", "jump3left.bmp", "jump4left.bmp", });
        List<String> EnemyWalk = new List<string>(new String[] { "enemy_walk_1.bmp", "enemy_walk_2.bmp", "enemy_walk_3.bmp", "enemy_walk_4.bmp", "enemy_walk_5.bmp", "enemy_walk_6.bmp" });
        List<String> LeftEnemyWalk = new List<string>(new String[] { "enemy_walk1l.bmp", "enemy_walk2l.bmp", "enemy_walk3l.bmp", "enemy_walk4l.bmp", "enemy_walk5l.bmp", "enemy_walk6l.bmp" });
        List<String> EnemyWalk2 = new List<string>(new String[] { "enemy2_walk1.bmp", "enemy2_walk2.bmp", "enemy2_walk3.bmp", "enemy2_walk4.bmp", "enemy2_walk5.bmp", "enemy2_walk6.bmp" });
        List<String> EnemyWalk2Left = new List<string>(new String[] { "enemy2_walk1left.bmp", "enemy2_walk2left.bmp", "enemy2_walk3left.bmp", "enemy2_walk4left.bmp", "enemy2_walk5left.bmp", "enemy2_walk6left.bmp" });
        List<Point> points = new List<Point>(new Point[] {});
        // VARIABLES
        int imageFrame = 0;
        int imageFrameLeft = 0;
        int imageFrameJump = 0;
        int imageJumpLeft = 0;
        int EnemyFramesWalk = 0;
        int EnemyFramesWalkLeft = 0;
        int Enemy2FramesWalk = 0;
        int Enemy2FramesWalkLeft = 0;
        int Bullets_CT = 0;
        // BOOLEANS
        bool left = false;
        bool right = false;
        bool isCLicked = false;
        bool RightisCLicked = false;
        // CREATE
        void CreatePaul()
        {
            player.image = new Bitmap("idle1.png");
            player.image.MakeTransparent(player.image.GetPixel(0, 0));
            player.X = 0;
            player.Y = grounds[0].point.Y - player.image.Height;
        }
        void CreateGround()
        {
            TileGroundLeft.bitmap = new Bitmap("Tile_01.png");
            TileGroundLeft.bitmap.MakeTransparent(TileGroundLeft.bitmap.GetPixel(0, 0));
            TileGroundLeft.point = new Point(0, ClientSize.Height - TileGroundLeft.bitmap.Height);
            TileGroundLeft.isHit = false;
            grounds.Add(TileGroundLeft);

            TileGroundRight.bitmap = new Bitmap("Tile_01.png");
            TileGroundRight.bitmap.MakeTransparent(TileGroundRight.bitmap.GetPixel(0, 0));
            TileGroundRight.point = new Point(1300, ClientSize.Height - TileGroundRight.bitmap.Height);
            TileGroundRight.isHit = false;
            grounds.Add(TileGroundRight);

            PlatformX.bitmap = new Bitmap("platform2.bmp");
            PlatformX.bitmap.MakeTransparent(PlatformX.bitmap.GetPixel(0, 0));
            PlatformX.point = new Point(ClientSize.Width - PlatformX.bitmap.Width, TileGroundRight.point.Y - PlatformX.bitmap.Height - 90);
            PlatformX.isHit = false;
            grounds.Add(PlatformX);

            PlatformY.bitmap = new Bitmap("platform2.bmp");
            PlatformY.bitmap.MakeTransparent(PlatformY.bitmap.GetPixel(0, 0));
            PlatformY.point = new Point(TileGroundLeft.X + TileGroundLeft.bitmap.Width - PlatformY.bitmap.Width, ClientSize.Height -  TileGroundLeft.Y - 377);
            PlatformY.isHit = false;
            grounds.Add(PlatformY);
        }
        void CreateDecor()
        {
            Tree.bitmap = new Bitmap("tree.png");
            Tree.bitmap.MakeTransparent(Tree.bitmap.GetPixel(0, 0));
            Tree.point = new Point(0, ClientSize.Height - TileGroundLeft.bitmap.Height - Tree.bitmap.Height);
            decors.Add(Tree);

            Bush.bitmap = new Bitmap("bush.png");
            Bush.bitmap.MakeTransparent(Bush.bitmap.GetPixel(0, 0));
            Bush.point = new Point(0 + Tree.bitmap.Width - 50, ClientSize.Height - TileGroundLeft.bitmap.Height - Bush.bitmap.Height);
            decors.Add(Bush);

            Rock.bitmap = new Bitmap("stone.png");
            Rock.bitmap.MakeTransparent(Rock.bitmap.GetPixel(0, 0));
            Rock.point = new Point(ClientSize.Width - Rock.bitmap.Width, ClientSize.Height - TileGroundLeft.bitmap.Height - Rock.bitmap.Height);
            decors.Add(Rock);

            Bench2.bitmap = new Bitmap("bench2.png");
            Bench2.bitmap.MakeTransparent(Bench2.bitmap.GetPixel(0, 0));
            Bench2.point = new Point(0 + Tree.bitmap.Width + Bench2.bitmap.Width - 15, ClientSize.Height - TileGroundLeft.bitmap.Height - Bench2.bitmap.Height);
            decors.Add(Bench2);

            Bench.bitmap = new Bitmap("bench.png");
            Bench.bitmap.MakeTransparent(Bench.bitmap.GetPixel(0, 0));
            Bench.point = new Point(0 + Tree.bitmap.Width + Bench.bitmap.Width + Bench2.bitmap.Width + 85, ClientSize.Height - TileGroundLeft.bitmap.Height - Bench.bitmap.Height);
            decors.Add(Bench);

            Fountain.bitmap = new Bitmap("ftn.png");
            Fountain.bitmap.MakeTransparent(Bench.bitmap.GetPixel(0, 0));
            Fountain.point = new Point(0 + Tree.bitmap.Width + Bench.bitmap.Width + Bench2.bitmap.Width, ClientSize.Height - TileGroundLeft.bitmap.Height - Fountain.bitmap.Height);
            decors.Add(Fountain);

            Fountain2.bitmap = new Bitmap("ftn.png");
            Fountain2.bitmap.MakeTransparent(Fountain2.bitmap.GetPixel(0, 0));
            Fountain2.point = new Point(ClientSize.Width - Fountain2.bitmap.Width - 400, ClientSize.Height - TileGroundLeft.bitmap.Height - Fountain.bitmap.Height);
            decors.Add(Fountain2);

            Bushes.bitmap = new Bitmap("bushes.bmp");
            Bushes.bitmap.MakeTransparent(Bushes.bitmap.GetPixel(0, 0));
            Bushes.point = new Point(Bench.point.X + Bushes.bitmap.Width + 200, ClientSize.Height - TileGroundLeft.bitmap.Height - Bushes.bitmap.Height);
            decors.Add(Bushes);
        }
        void CreateLadder()
        {
            Ladder.bitmap = new Bitmap("Ladder2.png");
            Ladder.bitmap.MakeTransparent(Ladder.bitmap.GetPixel(0, 0));
            Ladder.point = new Point(PlatformY.point.X - Ladder.bitmap.Width, ClientSize.Height - TileGroundRight.bitmap.Height - Ladder.bitmap.Height);
            ladders.Add(Ladder);
        }
        void CreateEnemey()
        {
            enemy1.image = new Bitmap("enemy_walk_1.bmp");
            enemy1.image.MakeTransparent(enemy1.image.GetPixel(0, 0));
            enemy1.point = new Point(PlatformY.point.X + enemy1.image.Width - enemy1.image.Width, PlatformY.point.Y - enemy1.image.Height);
            enemy1.left = false;
            enemy1.right = false;
            enemy1.isDead = false;
            enemy1.AttackPlayer = false;
            enemies.Add(enemy1);

            enemy2.image = new Bitmap("enemy2_walk1.bmp");
            enemy2.image.MakeTransparent(enemy2.image.GetPixel(0, 0));
            enemy2.point = new Point(grounds[1].point.X + enemy2.image.Width - enemy2.image.Width, grounds[1].point.Y - enemy2.image.Height);
            enemy2.left = false;
            enemy2.right = false;
            enemy2.isDead = false;
            enemy2.AttackPlayer = false;
            enemies.Add(enemy2);

        }
        void CreateBullet()
        {
            bullet = new Bullet();
            bullet.bitmap = new Bitmap("bullet.bmp");
            bullet.point = new Point(player.X + player.image.Width, player.Y + 27);
            bullet.HitEnemy = false;
            bullets.Add(bullet);
        }
        void CreateLaser()
        {
            laser.laser = new Rectangle();
            laser.laser.Width = ClientSize.Width;
            laser.laser.Height = 5;
            laser.laser.X = player.X + player.image.Width;
            laser.laser.Y = player.Y + 29;
            lasers.Add(laser);
        }
        void CreateElevator()
        {
            elevator.Body.X = PlatformY.point.X + PlatformX.bitmap.Width;
            elevator.Body.Y = PlatformY.point.Y;
            elevator.Body.Height = 15;
            elevator.Body.Width = 100;
        }
        public Form1()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Paint += Form1_Paint;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            MouseDown += Form1_MouseDown;
            timer.Tick += Timer_Tick;
            timer.Start();
            timer.Interval = 20;
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Bullets_CT++;
                player.image = new Bitmap("shoot.bmp");
                player.image.MakeTransparent(player.image.GetPixel(0, 0));
                CreateBullet();
                isCLicked = true;
                
            }
            if (e.Button == MouseButtons.Right)
            {
                
                player.image = new Bitmap("shoot.bmp");
                player.image.MakeTransparent(player.image.GetPixel(0, 0));
                CreateLaser();
                RightisCLicked = true;
            }
        }

        private void Form1_KeyUp(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    player.image = new Bitmap("idle1.png");
                    player.image.MakeTransparent(player.image.GetPixel(0, 0));
                    break;
                case Keys.A:
                    player.image = new Bitmap("idle2.png");
                    player.image.MakeTransparent(player.image.GetPixel(0, 0));
                    break;
            }
            
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.X -= 10;
                    imageFrameLeft = ((imageFrameLeft + 1) % imagesLeft.Count());
                    player.image = new Bitmap(imagesLeft[imageFrameLeft]);
                    player.image.MakeTransparent(player.image.GetPixel(0, 0));
                    right = false;
                    left = true;
                    break;
                case Keys.D:
                    player.X += 10;
                    imageFrame = ((imageFrame + 1) % images.Count());
                    player.image = new Bitmap(images[imageFrame]);
                    player.image.MakeTransparent(player.image.GetPixel(0, 0));
                    right = true;
                    left = false;
                    break;
                case Keys.Space:
                    if (!player.onladder)
                    {
                        player.Jump = true;
                    }
                    break;
                case Keys.W: // LADDER UP
                    if (player.onladder)
                    {
                        if (!player.LadderLimitReached)
                        {
                            player.Y -= 10;
                        }
                    }
                    break;
                case Keys.S: // LADDER DOWN
                    if (player.onladder)
                    {
                        if (player.Y <= ClientSize.Height - TileGroundLeft.bitmap.Height - player.image.Height - 10)
                        {
                            player.Y += 10;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        int msTick = 0;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            msTick++;
            CollisonTriggers();
            if (msTick % 3 == 0 && !enemies[0].AttackPlayer && !enemy2.isDead) // FOR SLOWER ANIMATION
            {
                AnimateEnemy2();
            }
            if (msTick % 5 == 0 && !enemies[0].AttackPlayer && !enemy1.isDead) // FOR SLOWER ANIMATION
            {
                AnimateEnemy();
            }
            if (isCLicked)
            {
                 AnimateBullet();
            }
            if (RightisCLicked && msTick % 10 == 0)
            {
                lasers.Remove(laser);
            }
            if (player.Falling && !player.onElevator)
            {
                AnimateFall();
            }
            if (player.onElevator)
            {
                AnimatePlayerAndElevator();
            }
            DoubleBuffer(CreateGraphics());
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            Screen = new Bitmap(ClientSize.Width, ClientSize.Height);
            CreateGround();
            CreateDecor();
            CreateLadder();
            CreateEnemey();
            CreateElevator();
            CreatePaul();
        }

        void RenderScene(Graphics graphics)
        {
            graphics.Clear(Color.White); // CLEAR
            graphics.DrawImage(background.bitmap, 0, 0); // BACKGROUND
            // GROUNDS
            for (int index = 0; index < grounds.Count(); index++)
                graphics.DrawImage(grounds[index].bitmap, grounds[index].point);
            // DECORS
            for (int index = 0; index < decors.Count(); index++)
                graphics.DrawImage(decors[index].bitmap, decors[index].point);
            // LADDERS
            for (int index = 0; index < ladders.Count; index++)
                graphics.DrawImage(ladders[index].bitmap, ladders[index].point);
            // ENEMIES
            for (int index = 0; index < enemies.Count(); index++)
                graphics.DrawImage(enemies[index].image, enemies[index].point);
            // BULLETS
            for (int index = 0; index < bullets.Count(); index++)
                graphics.DrawImage(bullets[index].bitmap, bullets[index].point);
            // LASERS
            for (int i = 0; i < lasers.Count; i++)
                graphics.FillRectangle(Brushes.Red, laser.laser);
            // ELEVATOR
            graphics.FillRectangle(Brushes.White, elevator.Body);
            // PLAYER
            graphics.DrawImage(player.image, player.X, player.Y);
        }
        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            RenderScene(e.Graphics);
        }
        void DoubleBuffer(Graphics graphics)
        {
            Graphics g = Graphics.FromImage(Screen);
            RenderScene(g);
            graphics.DrawImage(Screen, 0, 0);
        }



        // CHECKERS
        void CollisonTriggers()
        {
            // CHECKS IF PLAYER HIT LADDER
            if (player.X + player.image.Width >= ladders[0].point.X)
            {
                player.LadderHit = true;
            }
            else if (player.X > ladders[0].X + ladders[0].bitmap.Width) ;
            {
                player.LadderHit = false;
            }
            // CHECKS IF PLAYER IS ON LADDER
            if (player.X + player.image.Width >= ladders[0].point.X && player.X + player.image.Width <= ladders[0].point.X + ladders[0].bitmap.Width)
            {
                player.onladder = true;
            }
            else
                player.onladder = false;
            // CHECKS IF PLAYER IS ABOVE LADDER
            if (player.Y <= ladders[0].point.Y - player.image.Height)
            {
                player.LadderLimitReached = true;
            }
            else
                player.LadderLimitReached = false;
            // CHECK IF PLAYER HAS JUMPED
            if (player.Jump && !player.JumpLimitReached)
            {
                player.Y = player.Y - player.image.Height * 2;
                player.JumpLimitReached = true;
                player.Jump = false;
            }
            // CHECKS IF PLAYER HIT TILE GROUND 1 AFTER JUMP
            if (player.Y == grounds[0].point.Y - player.image.Height)
            {
                
                player.GroundReached = true;
                player.JumpLimitReached = false;
            }
            else
                player.GroundReached = false;
            // CHECKS IF ENEMY HIT THE RIGHT EDGE OF THE PLATFORM
            if (enemy1.point.X + enemy1.image.Width >= PlatformY.point.X + PlatformY.bitmap.Width)
            {
                enemy1.left = false;
                enemy1.right = true;
            }
            // CHECKS IF ENEMY HIT THE LEFT EDGE OF THE PLATFORM
            if (enemy1.point.X <= PlatformY.point.X)
            {
                enemy1.right = false;
                enemy1.left = true;
            }
            // CHECKS IF ENEMY2 HIT THE RIGHT OF THE PLATFORM
            if (enemy2.point.X + enemy2.image.Width >= ClientSize.Width)
            {
                enemy2.right = true;
                enemy2.left = false;
                
            }
            // CHECKS IF ENEMY2 HIT THE LEFT OF THE PLATFORM
            if (enemy2.point.X <= grounds[1].point.X)
            {
                enemy2.right = false;
                enemy2.left = true;
            }
            // CHECK IF THE ENEMY IS HURT BY BULLET

            for (int index = 0; index < bullets.Count; index++)
            {
                if (bullets[index].point.X + bullets[index].bitmap.Width >= enemy2.point.X && bullets[index].point.X > enemy2.point.X + enemy2.image.Width
                    && bullets[index].point.Y >= enemy2.point.Y && bullets[index].point.Y <= enemy2.point.Y + enemy2.image.Height)
                {
                    if (!enemy2.BulletHitMe)
                    {
                        enemy2.BulletHitMe = true;
                        enemy2.image = new Bitmap("fala7hurt.bmp");
                        enemy2.image.MakeTransparent(enemy2.image.GetPixel(0, 0));
                    }

                }
            }
            // CHECK IF THE ENEMY IS HURT BY LASER
            for (int index = 0; index < lasers.Count; index++)
            {
                if (enemy2.point.X >= lasers[index].laser.X
                     && lasers[index].laser.Y >= enemy2.point.Y && lasers[index].laser.Y <= enemy2.point.Y + enemy2.image.Height)
                {
                    if (!enemy2.laserHitMe)
                    {
                        enemy2.laserHitMe = true;
                        enemy2.image = new Bitmap("fala7hurt.bmp");
                        enemy2.image.MakeTransparent(enemy2.image.GetPixel(0, 0));
                    }

                }
            }
            // CHECK IF ENEMY IS HURT BY LASER AND BULLET
            if (enemy2.BulletHitMe && enemy2.laserHitMe)
            {
                enemy2.isDead = true;
                enemy2.image = new Bitmap("fala7dead.bmp");
                enemy2.image.MakeTransparent(enemy2.image.GetPixel(0, 0));
                enemy2.point.Y += 20;
                // AnimateDeath
            }

            // CHECK IF THE ENEMY1 IS HURT BY BULLET
            for (int index = 0; index < bullets.Count; index++)
            {
                if (bullets[index].point.X + bullets[index].bitmap.Width >= enemy1.point.X && bullets[index].point.X > enemy1.point.X + enemy1.image.Width
                    && bullets[index].point.Y >= enemy1.point.Y && bullets[index].point.Y <= enemy1.point.Y + enemy1.image.Height)
                {
                    if (!enemy1.BulletHitMe)
                    {
                        enemy1.BulletHitMe = true;
                        enemy1.image = new Bitmap("hurt.bmp");
                        enemy1.image.MakeTransparent(enemy1.image.GetPixel(0, 0));
                    }

                }
            }

            // CHECK IF THE ENEMY1 IS HURT BY LASER
            for (int index = 0; index < lasers.Count; index++)
            {
                if (enemy1.point.X >= lasers[index].laser.X
                    && lasers[index].laser.Y >= enemy1.point.Y && lasers[index].laser.Y <= enemy1.point.Y + enemy1.image.Height)
                {
                    if (!enemy1.laserHitMe)
                    {
                        enemy1.laserHitMe = true;
                        enemy1.image = new Bitmap("hurt.bmp");
                        enemy1.image.MakeTransparent(enemy1.image.GetPixel(0, 0));
                    }

                }
            }
            // CHECK IF ENEMY1 IS HURT BY LASER AND BULLET
            if (enemy1.BulletHitMe && enemy1.laserHitMe)
            {
                enemy1.isDead = true;
                enemy1.image = new Bitmap("notfala7dead.bmp");
                enemy1.image.MakeTransparent(enemy1.image.GetPixel(0, 0));
                enemy1.point.Y += 20;
                // AnimateDeath
            }
            // CHECK IF PLAYER IS OF GROUND 0
            if (player.X >= grounds[0].point.X + grounds[0].bitmap.Width && player.X <= grounds[1].point.X - player.image.Width)
            {
                player.Falling = true;
            }
            // CHECK IF PLAYER IS ON ELEVATOR
            if (player.X + player.image.Width >= elevator.Body.X && player.X <= elevator.Body.X
                && player.Y < elevator.Body.Y)
            {
                player.onElevator = true;
                elevator.PlayerHitMe = true;
                player.GroundReached = true;
            }
            else
            /*player.onElevator = false;*/
        

            if (player.JumpLimitReached && !player.GroundReached)
            {
                AnimateFall();
                AnimateJumpFall();
            }
        }
        // ANIMATION
        void AnimatePlayerAndElevator()
        {
            if (elevator.Body.X <= grounds[1].point.X)
            {
                elevator.Body.X += 5;
                player.X += 5;
            }
        }
        void AnimateFall()
        {
            player.Y += 20;
            
        }
        void AnimateEnemy()
        {
            // ENEMY ON LEFT
            if (enemies[0].left && !enemies[0].right)
            {
                EnemyFramesWalk = ((EnemyFramesWalk + 1) % EnemyWalk.Count());
                enemies[0].point = new Point(enemies[0].point.X += 10, enemies[0].point.Y);
                enemies[0].image = new Bitmap(EnemyWalk[EnemyFramesWalk]);
                enemies[0].image.MakeTransparent(enemies[0].image.GetPixel(0, 0));
            }
            if (enemies[0].right && !enemies[0].left)
            {
                EnemyFramesWalkLeft = ((EnemyFramesWalkLeft + 1) % LeftEnemyWalk.Count());
                enemies[0].point = new Point(enemies[0].point.X -= 10, enemies[0].point.Y);
                enemies[0].image = new Bitmap(LeftEnemyWalk[EnemyFramesWalkLeft]);
                enemies[0].image.MakeTransparent(enemies[0].image.GetPixel(0, 0));
            }
        
        }
        void AnimateEnemy2()
        {
            // ENEMY ON RIGHT
            if (enemies[1].left && !enemies[1].right)
            {
                Enemy2FramesWalk = ((Enemy2FramesWalk + 1) % EnemyWalk2.Count());
                enemies[1].point = new Point(enemies[1].point.X += 10, enemies[1].point.Y);
                enemies[1].image = new Bitmap(EnemyWalk2[Enemy2FramesWalk]);
                enemies[1].image.MakeTransparent(enemies[1].image.GetPixel(0, 0));
            }
            if (enemies[1].right && !enemies[1].left)
            {
                Enemy2FramesWalkLeft = ((Enemy2FramesWalkLeft + 1) % EnemyWalk2Left.Count());
                enemies[1].point = new Point(enemies[1].point.X -= 10, enemies[1].point.Y);
                enemies[1].image = new Bitmap(EnemyWalk2Left[Enemy2FramesWalkLeft]);
                enemies[1].image.MakeTransparent(enemies[1].image.GetPixel(0, 0));
            }
        }
        void AnimateBullet()
        {
            for (int index = 0; index < bullets.Count; index++)
            {
                bullets[index].point.X += 60 ;
            }
        }
        void AnimateJumpFall()
        {
            if (right)
            {
                imageFrameJump = ((imageFrameJump + 1) % Jump.Count());
                player.X += 20;
                player.image = new Bitmap(Jump[imageFrameJump]);
                player.image.MakeTransparent(player.image.GetPixel(0, 0));
            }
            else if (left)
            {
                player.X -= 20;
                imageJumpLeft = ((imageJumpLeft + 1) % Jump.Count());
                player.image = new Bitmap(JumpLeft[imageJumpLeft]);
                player.image.MakeTransparent(player.image.GetPixel(0, 0));
            }
            
        }
    }
}