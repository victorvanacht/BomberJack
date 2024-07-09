using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.Media;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;



namespace BomberJack
{
    public partial class Form1 : Form
    {
        private int countX, countY;
        private Color[] playerColor = { Color.Gray, Color.Red, Color.Blue, Color.Purple, Color.Green }; // item 0 will be ignored. Players count from 1 to 4
        private Board board;

        private int currentPlayer = 0;
        private Player[] player;
        private int maxPlayer;

        public class Player
        {
            public int score;
            public bool hasPlayed;
            public bool isKilled;
            public Color color;

            public Player(Color color) 
            { 
                this.score = 0;
                this.hasPlayed = false;
                this.isKilled = false;
                this.color = color;
            }
        }

        public class Board
        {
            public class GameCell
            {
                public int count = 0;
                public int owner = 0;
                public int maxCapacity = 4;
                public int[,] explosionDirections = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

                public bool hasReachedCapacity { get { return this.count > this.maxCapacity; } }

                public GameCell()
                {
                }
                public void ReduceCount()
                {
                    this.count -= maxCapacity;
                }
            }

            public GameCell[,] board;

            private int countX, countY;

            private int windowLeft;
            private int windowRight;
            private int windowTop;
            private int windowBottom;
            private int windowSizeX;
            private int windowSizeY;
            private int cellSizeX;
            private int cellSizeY;

            private Font fnt = new Font("Arial", 10);
            private GroupBox field;
            private Player[] player;

            public Board(int countX, int countY, GroupBox field, Player[] player)
            {
                this.countX = countX;
                this.countY = countY;
                this.field = field;
                this.player = player;

                this.board = new GameCell[countX, countY];
                for (int y = 0; y < this.countY; y++)
                {
                    for (int x = 0; x < this.countX; x++)
                    {
                        this.board[x, y] = new GameCell();
                    }
                }
                for (int x = 1; x < this.countX - 1; x++)
                {
                    this.board[x, 0].maxCapacity = 3;
                    this.board[x, 0].explosionDirections = new int[,] { { -1, 0 }, { 1, 0 }, { 0, 1 } };
                    this.board[x, this.countY - 1].maxCapacity = 3;
                    this.board[x, this.countY - 1].explosionDirections = new int[,] { { -1, 0 }, { 0, -1 }, { 1, 0 } };
                }
                for (int y = 1; y < this.countY - 1; y++)
                {
                    this.board[0, y].maxCapacity = 3;
                    this.board[0, y].explosionDirections = new int[,] { { 0, -1 }, { 1, 0 }, { 0, 1 } };
                    this.board[this.countX - 1, y].maxCapacity = 3;
                    this.board[this.countX - 1, y].explosionDirections = new int[,] { { -1, 0 }, { 0, -1 }, { 0, 1 } };
                }
                this.board[0, 0].maxCapacity = 2;
                this.board[0, 0].explosionDirections = new int[,] { { 0, 1 }, { 1, 0 } };
                this.board[this.countX - 1, 0].maxCapacity = 2;
                this.board[this.countX - 1, 0].explosionDirections = new int[,] { { -1, 0 }, { 0, 1 } };
                this.board[0, this.countY - 1].maxCapacity = 2;
                this.board[0, this.countY - 1].explosionDirections = new int[,] { { 0, -1 }, { 1, 0 } };
                this.board[this.countX - 1, this.countY - 1].maxCapacity = 2;
                this.board[this.countX - 1, this.countY - 1].explosionDirections = new int[,] { { -1, 0 }, { 0, -1 } };
                this.field.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            }

            public void Draw(object sender, PaintEventArgs e)
            {
                const int borderWidth = 5;
                const int topBorderWitdh = 10;

                this.windowLeft = this.field.Left + borderWidth;
                this.windowRight = this.field.Right - windowLeft - borderWidth;
                this.windowTop = this.field.Top + topBorderWitdh;
                this.windowBottom = this.field.Bottom - windowTop - borderWidth;

                this.windowSizeX = windowRight - windowLeft;
                this.windowSizeY = windowBottom - windowTop;
                this.cellSizeX = this.windowSizeX / this.countX;
                this.cellSizeY = this.windowSizeY / this.countY;
                this.windowLeft += (this.windowSizeX - (this.cellSizeX * this.countX)) / 2;
                this.windowTop += (this.windowSizeY - (this.cellSizeY * this.countY)) / 2;
                this.windowSizeX = this.countX * this.cellSizeX;
                this.windowSizeY = this.countX * this.cellSizeY;
                this.windowRight = this.windowLeft + this.windowSizeX;
                this.windowBottom = this.windowTop + this.windowSizeY;

                Graphics g = e.Graphics;

                // Draw a vertical lines
                for (int i = 0; i <= this.countX; i++)
                {
                    g.DrawLine(System.Drawing.Pens.Black,
                        this.windowLeft + i * this.cellSizeX, this.windowTop,
                        this.windowLeft + i * this.cellSizeX, this.windowBottom);
                }
                // Draw a horizontal lines
                for (int i = 0; i <= this.countY; i++)
                {
                    g.DrawLine(System.Drawing.Pens.Black,
                        this.windowLeft, this.windowTop + i * this.cellSizeY,
                        this.windowRight, this.windowTop + i * this.cellSizeY);

                }
                // Fill squares
                for (int x = 0; x < this.countX; x++)
                {
                    for (int y = 0; y < this.countY; y++)
                    {
                        if (board[x, y].owner != 0)
                        {
                            SolidBrush brush;
                            if (board[x, y].count <= board[x, y].maxCapacity)
                            {
                                brush = new SolidBrush(this.player[board[x, y].owner].color);
                            }
                            else
                            {
                                brush = new SolidBrush(Color.Yellow);
                            }
                            Rectangle rect = new Rectangle(
                                this.windowLeft + 2 + x * this.cellSizeX, this.windowTop + 2 + y * this.cellSizeY,
                                this.cellSizeX - 3, this.cellSizeY - 3);
                            g.FillRectangle(brush, rect);

                            g.DrawString(board[x, y].count.ToString(),
                                fnt, System.Drawing.Brushes.White, new Point(this.windowLeft + (this.cellSizeX >> 2) + (x * this.cellSizeX), this.windowTop + (this.cellSizeY >> 2) + (y * this.cellSizeY)));

                        }
                    }
                }
            }

            public bool Click(int clickX, int clickY, int currentPlayer)
            {
                // Check boarders
                if ((clickX < this.windowLeft) || (clickX > this.windowRight) || (clickY < this.windowTop) || (clickY > this.windowBottom)) return false;

                int x = (clickX - this.windowLeft) / this.cellSizeX;
                int y = (clickY - this.windowTop) / this.cellSizeY;

                if ((this.board[x, y].owner != 0) && (this.board[x, y].owner != currentPlayer)) return false;

                this.board[x, y].owner = currentPlayer;
                this.board[x, y].count++;

                this.CheckBoard(currentPlayer);

                this.CountScores();

                //redraw
                this.field.Invalidate();
                return true;
            }

            private void CheckBoard(int player)
            {
                bool dirty = true;

                while (dirty)
                {
                    dirty = false;
                    for (int x = 0; x < this.countX; x++)
                    {
                        for (int y = 0; y < this.countY; y++)
                        {
                            if (this.board[x, y].count > this.board[x, y].maxCapacity)
                            {
                                // explode!!!!!
                                dirty = true;
                                for (int n = 0; n <= this.board[x, y].explosionDirections.GetUpperBound(0); n++)
                                {
                                    int dx = this.board[x, y].explosionDirections[n, 0];
                                    int dy = this.board[x, y].explosionDirections[n, 1];
                                    this.board[x + dx, y + dy].count++;
                                    this.board[x + dx, y + dy].owner = player;
                                    this.field.Invalidate();
                                }
                                this.board[x, y].ReduceCount();
                                this.field.Invalidate();
                            }
                        }
                    }
                }
            }

            private void CountScores()
            {
                // reset all score counters to zero
                for (int i=0;i<this.player.Length-1;i++)
                {
                    this.player[i].score = 0;
                }

                // count the scores
                for (int x = 0; x < this.countX; x++)
                {
                    for (int y = 0; y < this.countY; y++)
                    {
                        if (this.board[x,y].owner != 0)
                        {
                            this.player[this.board[x, y].owner].score++;
                        }
                    }
                }
            }
        }

    public Form1(int countX, int countY)
        {
            InitializeComponent();
            this.Field.MouseClick += this.ClickField;
            this.countX = countX;
            this.countY = countY;

            this.player = new Player[5];
            for (int i = 0; i <= 4; i++) { this.player[i] = new Player(this.playerColor[i]); }
            this.board = new Board(this.countX, this.countY, this.Field, this.player);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.currentPlayer = 1;
            this.maxPlayer = (int)this.numericUpDownPlayers.Value;

            this.numericUpDownPlayers.Enabled = false;
            this.buttonPlayerIndicator.Visible = true;

            this.label1.Visible = true;
            this.labelPlayer1Score.Visible= true;
            this.label2.Visible = true;
            this.labelPlayer2Score.Visible = true;
            if (maxPlayer >= 3)
            {
                this.label3.Visible = true;
                this.labelPlayer3Score.Visible = true;
            }
            if (maxPlayer >= 4)
            {
                this.label4.Visible = true; ;
                this.labelPlayer4Score.Visible = true;
            }
        }

        public void DrawPlayerIndicator(object sender, PaintEventArgs e)
        {
            this.buttonPlayerIndicator.BackColor = this.playerColor[this.currentPlayer];
            this.buttonPlayerIndicator.Text = "Player " + this.currentPlayer.ToString();
        }

        private void ClickField(object sender, MouseEventArgs e)
        {
            if (currentPlayer != 0) // cannot play before the game has started
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (board.Click(e.X, e.Y, this.currentPlayer))
                    {
                        this.label1.Text = this.player[1].score.ToString();
                        this.label2.Text = this.player[2].score.ToString();
                        this.label3.Text = this.player[3].score.ToString();
                        this.label4.Text = this.player[4].score.ToString();

                        // when return true, go to the next player
                        this.currentPlayer++;
                        if (this.currentPlayer > this.maxPlayer) this.currentPlayer = 1;
                        this.buttonPlayerIndicator.Invalidate();
                    }
                }
            }
        }


    }
}