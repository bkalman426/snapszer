import { Player } from "../types";
import { Card } from "./Card";

export function CardHand({player} : Readonly<{player: Player}>){

    return <div className="card-hand">
        {player.hand.map((card, index) => <Card key={index} card={card}/>)}
    </div>
}