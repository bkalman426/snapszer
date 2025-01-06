import { Player } from "./Types";

export const gameState : Array<Player> = [
    {name: "Player 1", hand: [{suit: "Tök", number: "Kilenc"}, {suit: "Tök", number: "Alsó"}, {suit: "Tök", number: "Felső"}, {suit: "Tök", number: "Király"}, {suit: "Tök", number: "Tíz"} ,{suit: "Tök", number: "Ász"}], cardCount: 6, score:20},
    {name: "Player 2", hand: null, cardCount: 6, score: 5},
    {name: "Player 3", hand: null, cardCount: 6, score: 0},
    {name: "Player 4", hand: null, cardCount: 6, score: 0}
]