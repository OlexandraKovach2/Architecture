using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPawn Pawn1B = new ChessPawn(1, 2, false);
            ChessPawn Pawn2B = new ChessPawn(8, 2, false);
            ChessKing KingB = new ChessKing(5, 1, false);
            ChessRook Rook1B = new ChessRook(4, 1, false);

            ChessQueen QueenW = new ChessQueen(4, 8, true);
            ChessKing KingW = new ChessKing(5, 8, true);
            ChessHorse Horse1W = new ChessHorse(6,3,true);
            ChessElephant Elephant1W = new ChessElephant(8, 8, true);

            List<ChessFigure> figures = new List<ChessFigure>()
          { Pawn1B, Pawn2B,
            KingW, QueenW,
            KingB, Rook1B,
            Horse1W, Elephant1W};

            ChessBoard board = new ChessBoard(figures);
            board.buildBoard();
            Console.WriteLine(board);
        }

    }

    class ChessBoard
    {
        public string[,] board = new string[,] {
       // 1    2    3    4    5    6    7    8   "*"/"#" - white/black space
        {"*", "#", "*", "#", "*", "#", "*", "#"}, //1
        {"#", "*", "#", "*", "#", "*", "#", "*"}, //2
        {"*", "#", "*", "#", "*", "#", "*", "#"}, //3
        {"#", "*", "#", "*", "#", "*", "#", "*"}, //4
        {"*", "#", "*", "#", "*", "#", "*", "#"}, //5
        {"#", "*", "#", "*", "#", "*", "#", "*"}, //6
        {"*", "#", "*", "#", "*", "#", "*", "#"}, //7
        {"#", "*", "#", "*", "#", "*", "#", "*"}  //8
        };
        public List<ChessFigure> figures;
        
        public ChessBoard(List<ChessFigure> figures)
        {
            this.figures = figures;
            
        }       

        public void addFigures(List<ChessFigure> figures)
        {
            foreach (ChessFigure value in figures)
            {
                if (!this.figures.Exists(element => element.x == value.x))
                {
                    this.figures.Add(value);
                }
            }
        }
        public string[,] buildBoard()
        {
            foreach(ChessFigure value in this.figures)
            {
                this.board[value.y-1, value.x-1] = value.getIcon();
            }

            return this.board;
        }

        public override string ToString()
        {

            string str = "";
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    str += this.board[i,j] + " ";
                }
                str += "\n";
            }
            return str;
        }

    }


    abstract class ChessFigure
    {

        public int x, y;
        public bool color;
        public ChessFigure(int x, int y, bool color)
        {
            if (x >= 1 && x <= 8 &&
                y >= 1 && y <= 8)
            {
                this.x = x-1;
                this.y = y-1;
            }
            else
            {
                throw new Exception();
            }
            this.color = color;
        }
        public virtual string getIcon() {
            return "OK";
        }
    }

    class ChessPawn: ChessFigure
    {
        public ChessPawn(int x, int y, bool color) : base(x, y, color) {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color) { 
                return "PW";
            }
            else
            {
                return "PB";
            }
        } 
    }

    class ChessHorse: ChessFigure
    {
        
        public ChessHorse(int x, int y, bool color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color)
            {
                return "HW";
            }
            else
            {
                return "HB";
            }
        }
    }
    class ChessElephant : ChessFigure
    {
        public ChessElephant(int x, int y, bool color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color)
            {
                return "EW";
            }
            else
            {
                return "EB";
            }
        }
    }

    class ChessRook : ChessFigure
    {
        public ChessRook(int x, int y, bool color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color)
            {
                return "RW";
            }
            else
            {
                return "RB";
            }
        }
    }

    class ChessQueen : ChessFigure
    {
        public ChessQueen(int x, int y, bool color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color)
            {
                return "QW";
            }
            else
            {
                return "QB";
            }
        }
    }
    class ChessKing : ChessFigure
    {
        public ChessKing(int x, int y, bool color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public override string getIcon()
        {
            if (this.color)
            {
                return "KW";
            }
            else
            {
                return "KB";
            }
        }
    }
}
