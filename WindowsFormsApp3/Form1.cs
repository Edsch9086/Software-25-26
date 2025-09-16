using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private float blueTankAngle = 90; // 0 = right, but we will rotate image so 0 = up
        private float redTankAngle = 90;
        private float blueTankX, blueTankY;
        private float redTankX, redTankY;
        private const float TankSpeed = 2f; // Slower speed
        private const float TankRotateSpeed = 5f;
        private const float BulletSpeed = 6f;
        private HashSet<Keys> keysDown = new HashSet<Keys>();
        private Timer gameTimer;

        // Initial positions
        private readonly Point blueTankStart = new Point(117, 247);
        private readonly Point redTankStart = new Point(826, 247);

        // Score
        private int blueScore = 0;
        private int redScore = 0;

        // Bullet state
        private bool blueBulletActive = false;
        private float blueBulletX, blueBulletY, blueBulletAngle;
        private bool redBulletActive = false;
        private float redBulletX, redBulletY, redBulletAngle;
        private const int BulletSize = 8;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Initialize tank positions
            ResetTank(bluetank, ref blueTankX, ref blueTankY, ref blueTankAngle, blueTankStart, 90);
            ResetTank(redtank, ref redTankX, ref redTankY, ref redTankAngle, redTankStart, 90);

            bluetank.Tag = bluetank.Image; // Store the original image for rotation
            bluetank.Image = RotateImage((Image)bluetank.Tag, blueTankAngle - 90); // Set initial rotation (up)

            redtank.Tag = redtank.Image;
            redtank.Image = RotateImage((Image)redtank.Tag, redTankAngle - 90);

            gameTimer = new Timer();
            gameTimer.Interval = 16; // ~60 FPS
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keysDown.Add(e.KeyCode);

            // Blue tank shoot (Space)
            if (e.KeyCode == Keys.Space && !blueBulletActive)
            {
                blueBulletActive = true;
                blueBulletX = bluetank.Left + bluetank.Width / 2 - BulletSize / 2;
                blueBulletY = bluetank.Top + bluetank.Height / 2 - BulletSize / 2;
                blueBulletAngle = blueTankAngle;
            }
            // Red tank shoot (Enter)
            if (e.KeyCode == Keys.Enter && !redBulletActive)
            {
                redBulletActive = true;
                redBulletX = redtank.Left + redtank.Width / 2 - BulletSize / 2;
                redBulletY = redtank.Top + redtank.Height / 2 - BulletSize / 2;
                redBulletAngle = redTankAngle;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keysDown.Remove(e.KeyCode);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // --- Blue Tank (WASD) ---
            MoveTank(
                bluetank,
                ref blueTankAngle,
                ref blueTankX,
                ref blueTankY,
                Keys.W, Keys.S, Keys.A, Keys.D
            );

            // --- Red Tank (Arrow Keys) ---
            MoveTank(
                redtank,
                ref redTankAngle,
                ref redTankX,
                ref redTankY,
                Keys.Up, Keys.Down, Keys.Left, Keys.Right
            );

            // Check tank-tank collision
            if (bluetank.Bounds.IntersectsWith(redtank.Bounds))
            {
                Death(bluetank, ref blueTankX, ref blueTankY, ref blueTankAngle, blueTankStart, 90);
                Death(redtank, ref redTankX, ref redTankY, ref redTankAngle, redTankStart, 90);
            }

            // Move and check blue bullet
            if (blueBulletActive)
            {
                blueBulletX += (float)(BulletSpeed * Math.Cos(blueBulletAngle * Math.PI / 180));
                blueBulletY += (float)(BulletSpeed * Math.Sin(blueBulletAngle * Math.PI / 180));
                Rectangle bulletRect = new Rectangle((int)blueBulletX, (int)blueBulletY, BulletSize, BulletSize);

                // Wall collision
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox && c.Tag != null && c.Tag.ToString() == "wall")
                    {
                        if (bulletRect.IntersectsWith(c.Bounds))
                        {
                            blueBulletActive = false;
                            break;
                        }
                    }
                }
                // Red tank collision
                if (blueBulletActive && bulletRect.IntersectsWith(redtank.Bounds))
                {
                    blueScore++;
                    Death(redtank, ref redTankX, ref redTankY, ref redTankAngle, redTankStart, 90);
                    blueBulletActive = false;
                }
                // Out of bounds
                if (blueBulletX < 0 || blueBulletY < 0 || blueBulletX > this.ClientSize.Width || blueBulletY > this.ClientSize.Height)
                    blueBulletActive = false;
            }

            // Move and check red bullet
            if (redBulletActive)
            {
                redBulletX += (float)(BulletSpeed * Math.Cos(redBulletAngle * Math.PI / 180));
                redBulletY += (float)(BulletSpeed * Math.Sin(redBulletAngle * Math.PI / 180));
                Rectangle bulletRect = new Rectangle((int)redBulletX, (int)redBulletY, BulletSize, BulletSize);

                // Wall collision
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox && c.Tag != null && c.Tag.ToString() == "wall")
                    {
                        if (bulletRect.IntersectsWith(c.Bounds))
                        {
                            redBulletActive = false;
                            break;
                        }
                    }
                }
                // Blue tank collision
                if (redBulletActive && bulletRect.IntersectsWith(bluetank.Bounds))
                {
                    redScore++;
                    Death(bluetank, ref blueTankX, ref blueTankY, ref blueTankAngle, blueTankStart, 90);
                    redBulletActive = false;
                }
                // Out of bounds
                if (redBulletX < 0 || redBulletY < 0 || redBulletX > this.ClientSize.Width || redBulletY > this.ClientSize.Height)
                    redBulletActive = false;
            }

            // Update window title with scores
            this.Text = $"Blue: {blueScore}   Red: {redScore}";

            // Redraw for bullets
            Invalidate();
        }

        private void Death(PictureBox tank, ref float tankX, ref float tankY, ref float tankAngle, Point start, float angle)
        {
            ResetTank(tank, ref tankX, ref tankY, ref tankAngle, start, angle);
        }

        private void ResetTank(PictureBox tank, ref float tankX, ref float tankY, ref float tankAngle, Point start, float angle)
        {
            tankX = start.X;
            tankY = start.Y;
            tank.Left = (int)tankX;
            tank.Top = (int)tankY;
            tankAngle = angle;
            tank.Image = RotateImage((Image)tank.Tag, tankAngle - 90);
        }

        private void MoveTank(PictureBox tank, ref float tankAngle, ref float tankX, ref float tankY, Keys forward, Keys backward, Keys left, Keys right)
        {
            float newX = tankX, newY = tankY, newAngle = tankAngle;
            bool moved = false;
            float moveX = 0, moveY = 0;

            if (keysDown.Contains(backward))
            {
                moveX += (float)(TankSpeed * Math.Cos(tankAngle * Math.PI / 180));
                moveY += (float)(TankSpeed * Math.Sin(tankAngle * Math.PI / 180));
                moved = true;
            }
            if (keysDown.Contains(forward))
            {
                moveX -= (float)(TankSpeed * Math.Cos(tankAngle * Math.PI / 180));
                moveY -= (float)(TankSpeed * Math.Sin(tankAngle * Math.PI / 180));
                moved = true;
            }
            if (keysDown.Contains(left))
            {
                newAngle -= TankRotateSpeed;
            }
            if (keysDown.Contains(right))
            {
                newAngle += TankRotateSpeed;
            }

            // Universal sliding: check X and Y separately
            float tempX = newX, tempY = newY;

            // Try X movement
            if (moved && moveX != 0)
            {
                Rectangle testRectX = new Rectangle(
                    (int)(tempX + moveX),
                    (int)tempY,
                    tank.Width,
                    tank.Height);

                bool collidesX = false;
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox && c.Tag != null && c.Tag.ToString() == "wall" && c != tank)
                    {
                        if (testRectX.IntersectsWith(c.Bounds))
                        {
                            collidesX = true;
                            break;
                        }
                    }
                }
                if (!collidesX)
                    tempX += moveX;
            }

            // Try Y movement
            if (moved && moveY != 0)
            {
                Rectangle testRectY = new Rectangle(
                    (int)tempX,
                    (int)(tempY + moveY),
                    tank.Width,
                    tank.Height);

                bool collidesY = false;
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox && c.Tag != null && c.Tag.ToString() == "wall" && c != tank)
                    {
                        if (testRectY.IntersectsWith(c.Bounds))
                        {
                            collidesY = true;
                            break;
                        }
                    }
                }
                if (!collidesY)
                    tempY += moveY;
            }

            if (moved)
            {
                tankX = tempX;
                tankY = tempY;
                tank.Left = (int)tankX;
                tank.Top = (int)tankY;
            }
            tankAngle = newAngle % 360;

            tank.Image = RotateImage((Image)tank.Tag, tankAngle - 90); // Always rotate so 0 = up
        }

        // Helper to rotate the tank image
        private Image RotateImage(Image img, float rotationAngle)
        {
            if (img == null) return null;
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
                g.RotateTransform(rotationAngle);
                g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                g.DrawImage(img, new Point(0, 0));
            }
            return bmp;
        }

        // Draw bullets
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (blueBulletActive)
                e.Graphics.FillEllipse(Brushes.Blue, blueBulletX, blueBulletY, BulletSize, BulletSize);
            if (redBulletActive)
                e.Graphics.FillEllipse(Brushes.Red, redBulletX, redBulletY, BulletSize, BulletSize);
        }
    }
}
