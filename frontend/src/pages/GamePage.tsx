import { CardHand } from "../components/CardHand";
import { Player } from "../types";
import "./GamePage.css"

export function GamePage(){
    const players: Array<Player> = [
        {name: "Player 1", hand: [{suit: "Tök", number: "Kilenc"}, {suit: "Tök", number: "Alsó"}, {suit: "Tök", number: "Felső"}, {suit: "Tök", number: "Király"}, {suit: "Tök", number: "Tíz"} ,{suit: "Tök", number: "Ász"}]},
        {name: "Player 2", hand: [{suit: "Tök", number: "Kilenc"}, {suit: "Tök", number: "Alsó"}, {suit: "Tök", number: "Felső"}, {suit: "Tök", number: "Király"}, {suit: "Tök", number: "Tíz"} ,{suit: "Tök", number: "Ász"}]},
        {name: "Player 3", hand: [{suit: "Tök", number: "Kilenc"}, {suit: "Tök", number: "Alsó"}, {suit: "Tök", number: "Felső"}, {suit: "Tök", number: "Király"}, {suit: "Tök", number: "Tíz"} ,{suit: "Tök", number: "Ász"}]},
        {name: "Player 4", hand: [{suit: "Tök", number: "Kilenc"}, {suit: "Tök", number: "Alsó"}, {suit: "Tök", number: "Felső"}, {suit: "Tök", number: "Király"}, {suit: "Tök", number: "Tíz"} ,{suit: "Tök", number: "Ász"}]}
    ]

    return <div className="game-page">    
        <div className="top-side-hand">
            <CardHand player={players[2]}/>
        </div>

        <div className="left-side-hand">
            <CardHand player={players[3]}/>
        </div>

        <div className="right-side-hand">
            <CardHand player={players[1]}/>
        </div>

        <div className="bottom-side-hand">
            <CardHand player={players[0]}/>
        </div>
        <div className="game-area">
            Game area
        </div>
    </div>
}