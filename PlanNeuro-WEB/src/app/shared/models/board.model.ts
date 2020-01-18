import {CardsListModel} from './cards-list.model';
import {UserModel} from './user.model';

export class BoardModel {
  id: number;
  title: string;
  date: Date;
  cardsList: CardsListModel[];
  participants: UserModel[];
}
