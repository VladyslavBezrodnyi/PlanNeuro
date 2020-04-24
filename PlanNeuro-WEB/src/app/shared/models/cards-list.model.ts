import {CardModel} from './card.model';

export class CardsListModel {
  id: number;
  boardId: number;
  type: string;
  cards: CardModel[];
}
