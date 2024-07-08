using System.Drawing;
using System.Windows.Forms;

namespace BomberJack
{
    public partial class Form1 : Form
    {
        private int countX, countY;
        private Font fnt = new Font("Arial", 10);
        private Color[] playerColor = { Color.Gray, Color.Red, Color.Blue, Color.Purple, Color.Green }; // item 0 will be ignored. Players count from 1 to 4


        private int windowLeft;
        private int windowRight;
        private int windowTop;
        private int windowBottom;
        private int windowSizeX;
        private int windowSizeY;
        private int cellSizeX;
        private int cellSizeY;



        public class GameCell
        {
            public int count;
            public int owner;
            public int maxCapacity;

            public bool hasReachedCapacity { get {return this.count > this.maxCapacity; } }

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

        public Form1(int countX, int countY)
        {
            InitializeComponent();
            this.countX = countX;
            this.countY = countY;


            // initialize board
            this.board = new GameCell[countX, countY];
            for (int y = 0; y < this.countY; y++)
            {
                for (int x = 0; x < this.countX; x++)
                {
                    board[x, y] = new GameCell();
                }
            }
            for (int x = 1; x < this.countX -1; x++)
            {
                board[x, 0].maxCapacity = 3;
                board[x, this.countY -1].maxCapacity = 3;
            }
            for (int y = 1; y < this.countY -1; y++)
            {
                board[0, y].maxCapacity = 3;
                board[this.countX -1, y].maxCapacity = 3;
            }
            board[0, 0].maxCapacity = 2;
            board[this.countX -1, 0].maxCapacity = 2;
            board[0, this.countY -1].maxCapacity = 2;
            board[this.countX -1, this.countY -1].maxCapacity = 2;


        }

        private void ClickField(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int clickX = e.X;
                int clickY = e.Y;

                // Check boarders
                if ((clickX < this.windowLeft) || (clickX > this.windowRight) || (clickY < this.windowTop) || (clickY > this.windowBottom)) return;

                int x = (clickX-this.windowLeft) / this.cellSizeX;
                int y = (clickY-this.windowTop) / this.cellSizeY;

                //@@@ here we need to check if the player can play this cell
                this.board[x, y].owner = 1;
                this.board[x, y].count++;

                // Redraw
                this.Field.Invalidate();
            }
        }

        public void DrawField(object sender, PaintEventArgs e)
        {
            const int borderWidth = 5;
            const int topBorderWitdh = 10;

            this.windowLeft = this.Field.Left + borderWidth;
            this.windowRight = this.Field.Right - windowLeft - borderWidth;
            this.windowTop = this.Field.Top + topBorderWitdh;
            this.windowBottom = this.Field.Bottom -windowTop - borderWidth;

            this.windowSizeX = windowRight - windowLeft;
            this.windowSizeY = windowBottom - windowTop;
            this.cellSizeX = this.windowSizeX / this.countX;
            this.cellSizeY = this.windowSizeY / this.countY;
            this.windowLeft += (this.windowSizeX - (this.cellSizeX * this.countX)) / 2;
            this.windowTop  += (this.windowSizeY - (this.cellSizeY * this.countY)) / 2;
            this.windowSizeX = this.countX * this.cellSizeX;
            this.windowSizeY = this.countX * this.cellSizeY;
            this.windowRight = this.windowLeft + this.windowSizeX;
            this.windowBottom = this.windowTop + this.windowSizeY;

            Graphics g = e.Graphics;

            // Draw a string on the PictureBox.
            g.DrawString("This is a diagonal line drawn on the control",
                fnt, System.Drawing.Brushes.Blue, new Point(30, 30));


            // Draw a vertical lines
            for (int i=0; i<=this.countX; i++)
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
            for (int x=0; x<this.countX; x++)
            {
                for (int y=0; y<this.countY; y++)
                {
                    if (board[x, y].owner != 0)
                    {
                        SolidBrush blueBrush = new SolidBrush(this.playerColor[board[x,y].owner]);
                        Rectangle rect = new Rectangle(
                            this.windowLeft + 2 + x * this.cellSizeX, this.windowTop + 2 + y * this.cellSizeY,
                            this.cellSizeX - 3, this.cellSizeY - 3);
                        g.FillRectangle(blueBrush, rect);

                        g.DrawString(board[x,y].count.ToString(),
                            fnt, System.Drawing.Brushes.White, new Point(this.windowLeft + (this.cellSizeX >>2) + (x * this.cellSizeX), this.windowTop + (this.cellSizeY >>2) + (y * this.cellSizeY)));

                    }
                }
            }
        }
    }
}