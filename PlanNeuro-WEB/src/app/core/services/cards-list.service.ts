import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment.prod';
import {HttpClient} from '@angular/common/http';
import {CardsListModel} from '../../shared/models/cards-list.model';
import {Observable} from 'rxjs';

@Injectable()
export class CardsListService {
  CONTROLLER_URL: string = environment.API_URL + '/CardsList';

  constructor(private http: HttpClient) {
  }

  createCardsList(cardsList: CardsListModel): Observable<CardsListModel> {
    return this.http.post<CardsListModel>(this.CONTROLLER_URL + '/create', cardsList);
  }

  deleteCardsList(cardsList: number): Observable<any> {
    return this.http.delete(this.CONTROLLER_URL + '/delete/' + cardsList.toString());
  }
}
