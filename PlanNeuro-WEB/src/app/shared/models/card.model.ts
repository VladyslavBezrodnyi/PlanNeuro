import {UserModel} from './user.model';

export class CardModel {
  id: number;
  boardId: number;
  cardsListId: number;
  discriminator: string;
  itemNumber: number;
  title: string;
  description: string;
  start: Date;
  end: Date;
  duration: number;
  complexity: number;
}

export class PlanCardModel extends CardModel {
  doneCounter: number;
  notDoneCounter: number;
}

export class HabitCardModel extends CardModel {
  isDone: boolean;
  doneUserId: number;
  doneUser: UserModel;
}
