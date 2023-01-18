// type File = 'A' | 'B' | 'C' | 'D' | 'E' | 'F' | 'G' | 'H';
// type Rank = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8;
// type Square = [File, Rank];
// type Piece = 'Bishop' | 'King' | 'Knight' | 'Pawn' | 'Queen' | 'Rook';

export type BoardState = Record<string,string>;

export interface Board {
    state: BoardState;
}