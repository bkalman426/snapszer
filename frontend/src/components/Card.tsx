import "./Card.css";
import { PlayingCard } from "../Types";
import cardBackImage from "../assets/cardback.png";

export function Card({ card }: Readonly<{ card: PlayingCard | null }>) {
    return <div className="playing-card">
        { card ?
            (<p>{card.suit} {card.number}</p>)
            :
            (<img src={cardBackImage} alt="Hátoldal"/>)
        }

    </div>
}