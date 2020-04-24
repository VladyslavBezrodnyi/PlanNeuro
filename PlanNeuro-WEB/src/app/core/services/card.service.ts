import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CardModel} from '../../shared/models/card.model';
import {environment} from '../../../environments/environment.prod';
import {Observable} from 'rxjs';

@Injectable()
export class CardService {
  CONTROLLER_URL: string = environment.API_URL + '/card';

  constructor(private http: HttpClient) {
  }

  createCard(card: CardModel): Observable<CardModel> {
    return this.http.post<CardModel>(this.CONTROLLER_URL + '/create', card);
  }

  changeCard(card: CardModel): Observable<CardModel> {
    return this.http.put<CardModel>(this.CONTROLLER_URL + 'change', card);
  }

  deleteCard(cardId: number): Observable<any> {
    return this.http.delete(this.CONTROLLER_URL + '/delete/' + cardId.toString());
  }
}
