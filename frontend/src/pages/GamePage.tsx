import { CardHand } from "../components/CardHand";
import { gameState } from "../mockData";
import { Player } from "../Types";
import "./GamePage.css"

export function GamePage(){
    const players: Array<Player> = gameState

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