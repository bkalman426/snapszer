export type PlayingCard = {
    number: string
    suit: string
};

export type Player = {
    name: string
    hand: Array<PlayingCard> | null
    cardCount: number;
    score: number;
};