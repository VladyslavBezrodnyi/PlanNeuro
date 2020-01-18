import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment.prod';
import {Injectable} from '@angular/core';
import {BoardModel} from '../../shared/models/board.model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {
  private CONTROLLER_URL: string = environment.API_URL + '/board';

  constructor(private http: HttpClient) {
  }

  getPersonalBoard(): Observable<BoardModel> {
    return this.http.get<BoardModel>(this.CONTROLLER_URL + '/personal');
  }

  getShareBoards(): Observable<BoardModel[]> {
    return this.http.get<BoardModel[]>(this.CONTROLLER_URL + '/share');
  }

  getBoard(boardId: number): Observable<BoardModel> {
    return this.http.get<BoardModel>(this.CONTROLLER_URL + '/board/' + boardId.toString());
  }

  createBoard(board: BoardModel): Observable<BoardModel> {
    return this.http.post<BoardModel>(this.CONTROLLER_URL + '/create', board);
  }

  deleteBoard(boardId: number): Observable<any> {
    return this.http.delete(this.CONTROLLER_URL + '/delete/' + boardId.toString());
  }
}
