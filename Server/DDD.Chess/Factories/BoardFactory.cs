using DDD.Chess.ValueObjects;
using DDD.Chess.ValueObjects.Pieces;
using File = DDD.Chess.ValueObjects.File;

namespace DDD.Chess.Factories
{
    internal class BoardFactory
    {
        public static Board EmptyBoard()
        {
            var emptyBoard = new Dictionary<Square, Piece?>();
            foreach (var file in File.Values)
            {
                foreach (var rank in Rank.Values)
                {
                    Square square = new(file, rank);
                    emptyBoard.Add(square, null);
                }
            }
            return new Board(emptyBoard);
        }

        public static Board NewBoard()
        {
            return new Board(new Dictionary<Square, Piece?>
            {
                { new Square(File.A, Rank.ONE), new Rook(Color.WHITE) },
                { new Square(File.B, Rank.ONE), new Knight(Color.WHITE) },
                { new Square(File.C, Rank.ONE), new Bishop(Color.WHITE) },
                { new Square(File.D, Rank.ONE), new Queen(Color.WHITE) },
                { new Square(File.E, Rank.ONE), new King(Color.WHITE) },
                { new Square(File.F, Rank.ONE), new Bishop(Color.WHITE) },
                { new Square(File.G, Rank.ONE), new Knight(Color.WHITE) },
                { new Square(File.H, Rank.ONE), new Rook(Color.WHITE) },
                { new Square(File.A, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.B, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.C, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.D, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.E, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.F, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.G, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.H, Rank.TWO), new Pawn(Color.WHITE) },
                { new Square(File.A, Rank.THREE), null },
                { new Square(File.B, Rank.THREE), null },
                { new Square(File.C, Rank.THREE), null },
                { new Square(File.D, Rank.THREE), null },
                { new Square(File.E, Rank.THREE), null },
                { new Square(File.F, Rank.THREE), null },
                { new Square(File.G, Rank.THREE), null },
                { new Square(File.H, Rank.THREE), null },
                { new Square(File.A, Rank.FOUR), null },
                { new Square(File.B, Rank.FOUR), null },
                { new Square(File.C, Rank.FOUR), null },
                { new Square(File.D, Rank.FOUR), null },
                { new Square(File.E, Rank.FOUR), null },
                { new Square(File.F, Rank.FOUR), null },
                { new Square(File.G, Rank.FOUR), null },
                { new Square(File.H, Rank.FOUR), null },
                { new Square(File.A, Rank.FIVE), null },
                { new Square(File.B, Rank.FIVE), null },
                { new Square(File.C, Rank.FIVE), null },
                { new Square(File.D, Rank.FIVE), null },
                { new Square(File.E, Rank.FIVE), null },
                { new Square(File.F, Rank.FIVE), null },
                { new Square(File.G, Rank.FIVE), null },
                { new Square(File.H, Rank.FIVE), null },
                { new Square(File.A, Rank.SIX), null },
                { new Square(File.B, Rank.SIX), null },
                { new Square(File.C, Rank.SIX), null },
                { new Square(File.D, Rank.SIX), null },
                { new Square(File.E, Rank.SIX), null },
                { new Square(File.F, Rank.SIX), null },
                { new Square(File.G, Rank.SIX), null },
                { new Square(File.H, Rank.SIX), null },
                { new Square(File.A, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.B, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.C, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.D, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.E, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.F, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.G, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.H, Rank.SEVEN), new Pawn(Color.BLACK) },
                { new Square(File.A, Rank.EIGHT), new Rook(Color.BLACK) },
                { new Square(File.B, Rank.EIGHT), new Knight(Color.BLACK) },
                { new Square(File.C, Rank.EIGHT), new Bishop(Color.BLACK) },
                { new Square(File.D, Rank.EIGHT), new Queen(Color.BLACK) },
                { new Square(File.E, Rank.EIGHT), new King(Color.BLACK) },
                { new Square(File.F, Rank.EIGHT), new Bishop(Color.BLACK) },
                { new Square(File.G, Rank.EIGHT), new Knight(Color.BLACK) },
                { new Square(File.H, Rank.EIGHT), new Rook(Color.BLACK) },
            });
        }
    }
}