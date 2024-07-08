using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BomberJack
{
    public partial class Form1 : Form
    {
        private int countX, countY;
        private Color[] playerColor = { Color.Gray, Color.Red, Color.Blue, Color.Purple, Color.Green }; // item 0 will be ignored. Players count from 1 to 4
        private Board board;

        private int player;
        private int maxPlayer;


        public class Board
        {
            public class GameCell
            {
                public int count;
                public int owner;
                public int maxCapacity;

                public bool hasReachedCapacity { get { return this.count > this.maxCapacity; } }

                public GameCell()
                {
                    this.count = 0;
                    this.owner = 0;
                    this.maxCapacity = 4;
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
            private Color[] playerColor;

            public Board(int countX, int countY, GroupBox field, Color[] playerColor)
            {
                this.countX = countX;
                this.countY = countY;
                this.field = field;
                this.playerColor = playerColor;

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
                    this.board[x, this.countY - 1].maxCapacity = 3;
                }
                for (int y = 1; y < this.countY - 1; y++)
                {
                    this.board[0, y].maxCapacity = 3;
                    this.board[this.countX - 1, y].maxCapacity = 3;
                }
                this.board[0, 0].maxCapacity = 2;
                this.board[this.countX - 1, 0].maxCapacity = 2;
                this.board[0, this.countY - 1].maxCapacity = 2;
                this.board[this.countX - 1, this.countY - 1].maxCapacity = 2;

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
                            SolidBrush blueBrush = new SolidBrush(this.playerColor[board[x, y].owner]);
                            Rectangle rect = new Rectangle(
                                this.windowLeft + 2 + x * this.cellSizeX, this.windowTop + 2 + y * this.cellSizeY,
                                this.cellSizeX - 3, this.cellSizeY - 3);
                            g.FillRectangle(blueBrush, rect);

                            g.DrawString(board[x, y].count.ToString(),
                                fnt, System.Drawing.Brushes.White, new Point(this.windowLeft + (this.cellSizeX >> 2) + (x * this.cellSizeX), this.windowTop + (this.cellSizeY >> 2) + (y * this.cellSizeY)));

                        }
                    }
                }
            }

            public bool Click(int clickX, int clickY, int player)
            {
                // Check boarders
                if ((clickX < this.windowLeft) || (clickX > this.windowRight) || (clickY < this.windowTop) || (clickY > this.windowBottom)) return false;

                int x = (clickX - this.windowLeft) / this.cellSizeX;
                int y = (clickY - this.windowTop) / this.cellSizeY;

                if ((this.board[x, y].owner != 0) && (this.board[x, y].owner != player)) return false;

                this.board[x, y].owner = player;
                this.board[x, y].count++;

                // Redraw
                this.field.Invalidate();
                return true;
            }
        }

        public Form1(int countX, int countY)
        {
            InitializeComponent();
            this.Field.MouseClick += this.ClickField;
            this.countX = countX;
            this.countY = countY;

            this.board = new Board(this.countX, this.countY, this.Field, this.playerColor);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.numericUpDownPlayers.Enabled = false;
            this.buttonPlayerIndicator.Visible = true;

            this.player = 1;
            this.maxPlayer = (int)this.numericUpDownPlayers.Value;
        }

        public void DrawPlayerIndicator(object sender, PaintEventArgs e)
        {
            this.buttonPlayerIndicator.BackColor = this.playerColor[this.player];
            this.buttonPlayerIndicator.Text = "Player " + this.player.ToString();
        }

        private void ClickField(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (board.Click(e.X, e.Y, this.player))
                { // when return true, go to the next player
                    this.player++;
                    if (this.player > this.maxPlayer) this.player = 1;
                    this.buttonPlayerIndicator.Invalidate();
                }
            }
        }


    }
}